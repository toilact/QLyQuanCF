using System.Drawing;
using System.Windows.Forms;
using CoffeeShopManagement.Components;
using CoffeeShopManagement.Models;
using CoffeeShopManagement.Services.Interfaces;

namespace CoffeeShopManagement.Forms;

public class FrmMain : Form
{
    private readonly User _currentUser;
    private readonly ITableService _tableService;
    private readonly IProductService _productService;
    private readonly IBillService _billService;
    private readonly IReportService _reportService;
    private readonly IAuthService _authService;

    // UI Controls
    private FlowLayoutPanel _flpTables = null!;
    private DataGridView _dgvBill = null!;
    private Label _lblSelectedTableName = null!;
    private Label _lblSelectedTableStatus = null!;
    private Label _lblSubTotal = null!;
    private Label _lblTableStats = null!;
    private RjButton _btnAddProduct = null!;
    private RjButton _btnSwitchTable = null!;
    private RjButton _btnMergeTable = null!;
    private RjButton _btnPay = null!;
    private ComboBox _cbAreaFilter = null!;

    private Table? _selectedTable;
    private Bill? _currentBill;
    private List<Table> _loadedTables = new();

    public FrmMain(
        User currentUser,
        ITableService tableService,
        IProductService productService,
        IBillService billService,
        IReportService reportService,
        IAuthService authService)
    {
        _currentUser = currentUser;
        _tableService = tableService;
        _productService = productService;
        _billService = billService;
        _reportService = reportService;
        _authService = authService;

        InitializeComponent();
        Load += async (_, _) => await LoadTablesAsync();
    }

    private void InitializeComponent()
    {
        Text = "Cà Phê Hương Việt - Hệ Thống Bán Hàng & Quản Trị POS";
        Size = new Size(1366, 820);
        MinimumSize = new Size(1200, 750);
        StartPosition = FormStartPosition.CenterScreen;
        WindowState = FormWindowState.Maximized;
        BackColor = UITheme.CanvasBg;

        // 1. TOP HEADER BAR (Dock = Top)
        var pnlHeader = new Panel
        {
            Dock = DockStyle.Top,
            Height = 65,
            BackColor = UITheme.Primary,
            Padding = new Padding(24, 0, 20, 0)
        };
        Controls.Add(pnlHeader);

        // Header Left: Brand info
        var pnlHeaderLeft = new Panel
        {
            Dock = DockStyle.Left,
            Width = 350,
            BackColor = Color.Transparent
        };
        pnlHeader.Controls.Add(pnlHeaderLeft);

        var lblBrand = new Label
        {
            Text = "CÀ PHÊ HƯƠNG VIỆT",
            Font = new Font("Segoe UI", 15f, FontStyle.Bold),
            ForeColor = Color.White,
            Location = new Point(0, 10),
            AutoSize = true
        };
        pnlHeaderLeft.Controls.Add(lblBrand);

        var lblSubBrand = new Label
        {
            Text = "Hệ thống POS bán hàng & Quản trị quán",
            Font = new Font("Segoe UI", 9f, FontStyle.Regular),
            ForeColor = ColorTranslator.FromHtml("#D4C7BA"),
            Location = new Point(2, 38),
            AutoSize = true
        };
        pnlHeaderLeft.Controls.Add(lblSubBrand);

        // Header Right: User info & Logout
        var pnlHeaderRight = new FlowLayoutPanel
        {
            Dock = DockStyle.Right,
            FlowDirection = FlowDirection.RightToLeft,
            AutoSize = true,
            BackColor = Color.Transparent,
            Padding = new Padding(0, 14, 0, 0)
        };
        pnlHeader.Controls.Add(pnlHeaderRight);

        var btnLogout = new RjButton
        {
            Text = "Đăng xuất",
            Size = new Size(100, 36),
            BackColor = UITheme.Accent,
            HoverBackColor = UITheme.AccentHover,
            Font = UITheme.FontBold,
            BorderRadius = 6,
            Margin = new Padding(12, 0, 0, 0)
        };
        btnLogout.Click += (_, _) => Close();
        pnlHeaderRight.Controls.Add(btnLogout);

        var lblRoleBadge = new Label
        {
            Text = _currentUser.Role == "Admin" ? " QUẢN TRỊ VIÊN " : " THU NGÂN ",
            Font = new Font("Segoe UI", 8.5f, FontStyle.Bold),
            ForeColor = Color.White,
            BackColor = _currentUser.Role == "Admin" ? UITheme.Accent : UITheme.TableEmpty,
            TextAlign = ContentAlignment.MiddleCenter,
            Size = new Size(115, 26),
            Margin = new Padding(12, 5, 0, 0)
        };
        pnlHeaderRight.Controls.Add(lblRoleBadge);

        var lblUserName = new Label
        {
            Text = _currentUser.FullName,
            Font = new Font("Segoe UI", 10.5f, FontStyle.Bold),
            ForeColor = Color.White,
            TextAlign = ContentAlignment.MiddleRight,
            AutoSize = true,
            Margin = new Padding(0, 8, 0, 0)
        };
        pnlHeaderRight.Controls.Add(lblUserName);

        // 2. ROOT BODY CONTAINER (Dock = Fill, isolates header from overlapping body)
        var pnlBody = new Panel
        {
            Dock = DockStyle.Fill,
            BackColor = UITheme.CanvasBg
        };
        Controls.Add(pnlBody);
        pnlBody.BringToFront();

        // 2.1 LEFT SIDEBAR (Dock = Left inside pnlBody)
        var pnlSidebar = new Panel
        {
            Dock = DockStyle.Left,
            Width = 230,
            BackColor = UITheme.Surface,
            BorderStyle = BorderStyle.FixedSingle,
            Padding = new Padding(12, 16, 12, 16)
        };
        pnlBody.Controls.Add(pnlSidebar);

        var flpNav = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.TopDown,
            WrapContents = false,
            AutoScroll = true
        };
        pnlSidebar.Controls.Add(flpNav);

        void AddNavButton(string title, bool isAdminOnly, EventHandler onClick)
        {
            var btn = new RjButton
            {
                Text = title,
                Size = new Size(204, 46),
                Margin = new Padding(0, 0, 0, 10),
                BackColor = UITheme.CanvasBg,
                HoverBackColor = ColorTranslator.FromHtml("#EBE2D8"),
                ForeColor = UITheme.TextDark,
                Font = UITheme.FontBold,
                BorderColor = UITheme.Border,
                BorderSize = 1,
                BorderRadius = 8
            };

            if (isAdminOnly && _currentUser.Role != "Admin")
            {
                btn.Enabled = false;
                btn.ForeColor = UITheme.TextMuted;
                btn.Text += " (*)";
            }
            else
            {
                btn.Click += onClick;
            }

            flpNav.Controls.Add(btn);
        }

        AddNavButton("Bán hàng (POS)", false, async (_, _) => await LoadTablesAsync());
        AddNavButton("Thực đơn món", true, (_, _) => OpenForm(new FrmCategoryProduct(_productService)));
        AddNavButton("Quản lý bàn", true, (_, _) => OpenForm(new FrmTableManager(_tableService)));
        AddNavButton("Quản lý nhân viên", true, (_, _) => OpenForm(new FrmUserManager(_authService, _currentUser)));
        AddNavButton("Báo cáo doanh thu", true, (_, _) => OpenForm(new FrmReport(_reportService)));

        if (_currentUser.Role != "Admin")
        {
            var lblRoleHint = new Label
            {
                Text = "(*) Chỉ tài khoản Admin mới mở được",
                Font = UITheme.FontSmall,
                ForeColor = UITheme.TextMuted,
                Size = new Size(204, 40),
                Margin = new Padding(0, 10, 0, 0)
            };
            flpNav.Controls.Add(lblRoleHint);
        }

        // 2.2 RIGHT POS BILL PANEL (Dock = Right inside pnlBody)
        var pnlBill = new Panel
        {
            Dock = DockStyle.Right,
            Width = 460,
            BackColor = UITheme.Surface,
            BorderStyle = BorderStyle.FixedSingle,
            Padding = new Padding(16)
        };
        pnlBody.Controls.Add(pnlBill);

        // Header Info of Selected Table
        var pnlBillHeader = new Panel
        {
            Dock = DockStyle.Top,
            Height = 45,
            BackColor = Color.Transparent
        };
        pnlBill.Controls.Add(pnlBillHeader);

        _lblSelectedTableName = new Label
        {
            Text = "Chọn bàn để thao tác",
            Font = UITheme.FontHeader,
            ForeColor = UITheme.Primary,
            Location = new Point(0, 10),
            AutoSize = true
        };
        pnlBillHeader.Controls.Add(_lblSelectedTableName);

        _lblSelectedTableStatus = new Label
        {
            Text = "",
            Font = UITheme.FontBold,
            Dock = DockStyle.Right,
            TextAlign = ContentAlignment.MiddleRight,
            Width = 140
        };
        pnlBillHeader.Controls.Add(_lblSelectedTableStatus);

        // Actions at the bottom of Bill Panel
        var pnlActions = new Panel
        {
            Dock = DockStyle.Bottom,
            Height = 200,
            BackColor = UITheme.Surface,
            Padding = new Padding(0, 10, 0, 0)
        };
        pnlBill.Controls.Add(pnlActions);

        // Subtotal row
        var pnlSubTotalRow = new Panel
        {
            Dock = DockStyle.Top,
            Height = 40,
            BackColor = Color.Transparent
        };
        pnlActions.Controls.Add(pnlSubTotalRow);

        var lblSubTitle = new Label
        {
            Text = "TỔNG TẠM TÍNH:",
            Font = UITheme.FontHeader,
            ForeColor = UITheme.TextDark,
            Location = new Point(0, 8),
            AutoSize = true
        };
        pnlSubTotalRow.Controls.Add(lblSubTitle);

        _lblSubTotal = new Label
        {
            Text = "0 đ",
            Font = new Font("Segoe UI", 16f, FontStyle.Bold),
            ForeColor = UITheme.Danger,
            Dock = DockStyle.Right,
            TextAlign = ContentAlignment.MiddleRight,
            Width = 240
        };
        pnlSubTotalRow.Controls.Add(_lblSubTotal);

        // Button Row 1 (Add, Switch, Merge)
        var tblButtons = new TableLayoutPanel
        {
            Dock = DockStyle.Top,
            Height = 48,
            ColumnCount = 3,
            RowCount = 1,
            Margin = new Padding(0, 8, 0, 8)
        };
        tblButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
        tblButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 32.5F));
        tblButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 32.5F));
        pnlActions.Controls.Add(tblButtons);

        _btnAddProduct = new RjButton
        {
            Text = "+ THÊM MÓN",
            Dock = DockStyle.Fill,
            BackColor = UITheme.Accent,
            HoverBackColor = UITheme.AccentHover,
            Font = UITheme.FontBold,
            BorderRadius = 6,
            Enabled = false
        };
        _btnAddProduct.Click += BtnAddProduct_Click;
        tblButtons.Controls.Add(_btnAddProduct, 0, 0);

        _btnSwitchTable = new RjButton
        {
            Text = "ĐỔI BÀN",
            Dock = DockStyle.Fill,
            BackColor = Color.White,
            HoverBackColor = ColorTranslator.FromHtml("#F0EBE5"),
            ForeColor = UITheme.TextDark,
            Font = UITheme.FontBold,
            BorderColor = UITheme.Border,
            BorderSize = 1,
            BorderRadius = 6,
            Enabled = false
        };
        _btnSwitchTable.Click += BtnSwitchTable_Click;
        tblButtons.Controls.Add(_btnSwitchTable, 1, 0);

        _btnMergeTable = new RjButton
        {
            Text = "GỘP BÀN",
            Dock = DockStyle.Fill,
            BackColor = Color.White,
            HoverBackColor = ColorTranslator.FromHtml("#F0EBE5"),
            ForeColor = UITheme.TextDark,
            Font = UITheme.FontBold,
            BorderColor = UITheme.Border,
            BorderSize = 1,
            BorderRadius = 6,
            Enabled = false
        };
        _btnMergeTable.Click += BtnMergeTable_Click;
        tblButtons.Controls.Add(_btnMergeTable, 2, 0);

        // Button Row 2 (Pay button)
        _btnPay = new RjButton
        {
            Text = "THANH TOÁN VÀ IN HÓA ĐƠN",
            Dock = DockStyle.Bottom,
            Height = 52,
            BackColor = UITheme.Primary,
            HoverBackColor = UITheme.PrimaryHover,
            Font = new Font("Segoe UI", 11.5f, FontStyle.Bold),
            BorderRadius = 8,
            Enabled = false
        };
        _btnPay.Click += BtnPay_Click;
        pnlActions.Controls.Add(_btnPay);

        // Bill Items DataGridView (Dock = Fill in remaining space)
        _dgvBill = new DataGridView
        {
            Dock = DockStyle.Fill,
            ScrollBars = ScrollBars.Vertical
        };
        UITheme.ApplyModernGridStyle(_dgvBill);
        SetupBillGridColumns();
        pnlBill.Controls.Add(_dgvBill);
        _dgvBill.BringToFront();

        // 2.3 CENTER TABLE MAP AREA (Dock = Fill inside pnlBody)
        var pnlCenter = new Panel
        {
            Dock = DockStyle.Fill,
            BackColor = UITheme.CanvasBg,
            Padding = new Padding(20, 16, 20, 16)
        };
        pnlBody.Controls.Add(pnlCenter);
        pnlCenter.BringToFront();

        // Area Filter Panel
        var pnlFilter = new Panel
        {
            Dock = DockStyle.Top,
            Height = 50,
            BackColor = Color.Transparent
        };
        pnlCenter.Controls.Add(pnlFilter);

        var lblArea = new Label
        {
            Text = "Lọc khu vực:",
            Font = UITheme.FontBold,
            ForeColor = UITheme.TextDark,
            Location = new Point(0, 12),
            AutoSize = true
        };
        pnlFilter.Controls.Add(lblArea);

        _cbAreaFilter = new ComboBox
        {
            Location = new Point(95, 8),
            Size = new Size(200, 32),
            DropDownStyle = ComboBoxStyle.DropDownList,
            Font = UITheme.FontRegular
        };
        _cbAreaFilter.SelectedIndexChanged += (_, _) => FilterTables();
        pnlFilter.Controls.Add(_cbAreaFilter);

        _lblTableStats = new Label
        {
            Text = "",
            Font = UITheme.FontBold,
            ForeColor = UITheme.TextMuted,
            Location = new Point(320, 12),
            AutoSize = true
        };
        pnlFilter.Controls.Add(_lblTableStats);

        // Table FlowLayoutPanel
        _flpTables = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            AutoScroll = true,
            BackColor = Color.Transparent,
            Padding = new Padding(4)
        };
        pnlCenter.Controls.Add(_flpTables);
        _flpTables.BringToFront();
    }

    private void SetupBillGridColumns()
    {
        _dgvBill.Columns.Clear();
        _dgvBill.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        _dgvBill.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;

        _dgvBill.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", Visible = false });

        var colName = new DataGridViewTextBoxColumn
        {
            Name = "ProductName",
            HeaderText = "Tên Món",
            FillWeight = 42
        };
        _dgvBill.Columns.Add(colName);

        var colQty = new DataGridViewTextBoxColumn
        {
            Name = "Quantity",
            HeaderText = "SL",
            FillWeight = 14,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
        };
        _dgvBill.Columns.Add(colQty);

        var colPrice = new DataGridViewTextBoxColumn
        {
            Name = "UnitPrice",
            HeaderText = "Đơn Giá",
            FillWeight = 22,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight }
        };
        _dgvBill.Columns.Add(colPrice);

        var colTotal = new DataGridViewTextBoxColumn
        {
            Name = "LineTotal",
            HeaderText = "Thành Tiền",
            FillWeight = 22,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight }
        };
        _dgvBill.Columns.Add(colTotal);

        var btnCol = new DataGridViewButtonColumn
        {
            Name = "ColDelete",
            HeaderText = "",
            Text = "X",
            UseColumnTextForButtonValue = true,
            Width = 36,
            AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        };
        _dgvBill.Columns.Add(btnCol);

        _dgvBill.CellContentClick += async (s, e) =>
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == _dgvBill.Columns["ColDelete"].Index)
            {
                int detailId = (int)_dgvBill.Rows[e.RowIndex].Cells["Id"].Value;
                if (MessageBox.Show("Xóa món này khỏi bàn?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    await _billService.RemoveDetailAsync(detailId);
                    await RefreshSelectedTableBillAsync();
                    await LoadTablesAsync();
                }
            }
        };
    }

    private async Task LoadTablesAsync()
    {
        _loadedTables = await _tableService.GetAllTablesAsync();

        // Nạp danh sách khu vực
        var areas = new List<string> { "Tất cả" };
        areas.AddRange(_loadedTables.Select(t => t.Area).Distinct());

        string currentSelectedArea = _cbAreaFilter.SelectedItem?.ToString() ?? "Tất cả";
        _cbAreaFilter.DataSource = areas;
        if (areas.Contains(currentSelectedArea))
            _cbAreaFilter.SelectedItem = currentSelectedArea;

        FilterTables();

        if (_selectedTable != null)
        {
            _selectedTable = _loadedTables.FirstOrDefault(t => t.Id == _selectedTable.Id);
            await RefreshSelectedTableBillAsync();
        }
    }

    private void FilterTables()
    {
        _flpTables.Controls.Clear();
        string selectedArea = _cbAreaFilter.SelectedItem?.ToString() ?? "Tất cả";

        var displayTables = selectedArea == "Tất cả"
            ? _loadedTables
            : _loadedTables.Where(t => t.Area == selectedArea).ToList();

        int occupiedCount = displayTables.Count(t => t.Status == 1);
        _lblTableStats.Text = $"Hiển thị: {displayTables.Count} bàn ({occupiedCount} có khách, {displayTables.Count - occupiedCount} trống)";

        foreach (var table in displayTables)
        {
            var card = new UcTableCard
            {
                TableData = table,
                IsSelected = _selectedTable?.Id == table.Id
            };

            card.Click += async (_, _) =>
            {
                _selectedTable = table;
                foreach (Control c in _flpTables.Controls)
                {
                    if (c is UcTableCard tc) tc.IsSelected = (tc.TableData?.Id == table.Id);
                }
                await RefreshSelectedTableBillAsync();
            };

            _flpTables.Controls.Add(card);
        }
    }

    private async Task RefreshSelectedTableBillAsync()
    {
        if (_selectedTable == null)
        {
            _lblSelectedTableName.Text = "Chọn bàn để thao tác";
            _lblSelectedTableStatus.Text = "";
            _lblSubTotal.Text = "0 đ";
            _btnAddProduct.Enabled = false;
            _btnSwitchTable.Enabled = false;
            _btnMergeTable.Enabled = false;
            _btnPay.Enabled = false;
            _dgvBill.Rows.Clear();
            return;
        }

        _lblSelectedTableName.Text = $"{_selectedTable.Name} ({_selectedTable.Area})";
        _btnAddProduct.Enabled = true;

        _currentBill = await _billService.GetActiveBillByTableIdAsync(_selectedTable.Id);
        _dgvBill.Rows.Clear();

        if (_currentBill != null && _currentBill.Details.Any())
        {
            _lblSelectedTableStatus.Text = "CÓ KHÁCH";
            _lblSelectedTableStatus.ForeColor = UITheme.TableOccupied;
            _btnSwitchTable.Enabled = true;
            _btnMergeTable.Enabled = true;
            _btnPay.Enabled = true;

            decimal subTotal = 0;
            foreach (var d in _currentBill.Details)
            {
                decimal total = d.Quantity * d.UnitPrice;
                subTotal += total;
                _dgvBill.Rows.Add(d.Id, d.Product?.Name ?? "Món", d.Quantity, $"{d.UnitPrice:N0}", $"{total:N0}");
            }
            _lblSubTotal.Text = $"{subTotal:N0} đ";
        }
        else
        {
            _lblSelectedTableStatus.Text = "BÀN TRỐNG";
            _lblSelectedTableStatus.ForeColor = UITheme.TableEmpty;
            _lblSubTotal.Text = "0 đ";
            _btnSwitchTable.Enabled = false;
            _btnMergeTable.Enabled = false;
            _btnPay.Enabled = false;
        }
    }

    private async void BtnAddProduct_Click(object? sender, EventArgs e)
    {
        if (_selectedTable == null) return;

        using var dlg = new FrmSelectProduct(_productService, _selectedTable);
        if (dlg.ShowDialog() == DialogResult.OK && dlg.SelectedProduct != null)
        {
            await _billService.AddOrUpdateProductAsync(_selectedTable.Id, dlg.SelectedProduct.Id, dlg.SelectedQuantity, _currentUser.Id);
            await LoadTablesAsync();
        }
    }

    private async void BtnSwitchTable_Click(object? sender, EventArgs e)
    {
        if (_selectedTable == null) return;

        using var dlg = new FrmTransferMergeTable(_tableService, _selectedTable);
        if (dlg.ShowDialog() == DialogResult.OK)
        {
            try
            {
                if (dlg.IsMergeMode)
                {
                    await _tableService.MergeTableAsync(_selectedTable.Id, dlg.TargetTableId);
                }
                else
                {
                    await _tableService.SwitchTableAsync(_selectedTable.Id, dlg.TargetTableId);
                }

                _selectedTable = null;
                await LoadTablesAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }

    private void BtnMergeTable_Click(object? sender, EventArgs e)
    {
        BtnSwitchTable_Click(sender, e);
    }

    private async void BtnPay_Click(object? sender, EventArgs e)
    {
        if (_currentBill == null) return;

        using var dlg = new FrmPayment(_billService, _currentBill);
        if (dlg.ShowDialog() == DialogResult.OK)
        {
            _selectedTable = null;
            await LoadTablesAsync();
        }
    }

    private async void OpenForm(Form form)
    {
        form.StartPosition = FormStartPosition.CenterParent;
        form.ShowDialog();
        await LoadTablesAsync();
    }
}
