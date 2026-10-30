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
    private RjButton _btnAddProduct = null!;
    private RjButton _btnSwitchTable = null!;
    private RjButton _btnMergeTable = null!;
    private RjButton _btnPay = null!;
    private ComboBox _cbAreaFilter = null!;

    private Table? _selectedTable;
    private Bill? _currentBill;

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
        Text = "Hệ Thống Quản Lý Quán Cà Phê - POS Bán Hàng";
        Size = new Size(1280, 800);
        StartPosition = FormStartPosition.CenterScreen;
        WindowState = FormWindowState.Maximized;
        BackColor = UITheme.CanvasBg;

        // 1. TOP HEADER BAR
        var pnlHeader = new Panel
        {
            Dock = DockStyle.Top,
            Height = 60,
            BackColor = UITheme.Primary,
            Padding = new Padding(20, 0, 20, 0)
        };
        Controls.Add(pnlHeader);

        var lblBrand = new Label
        {
            Text = "CÀ PHÊ HƯƠNG VIỆT",
            Font = new Font("Segoe UI", 14f, FontStyle.Bold),
            ForeColor = Color.White,
            AutoSize = true,
            Location = new Point(20, 18)
        };
        pnlHeader.Controls.Add(lblBrand);

        var lblUser = new Label
        {
            Text = $"Nhân viên: {_currentUser.FullName}  [{_currentUser.Role}]",
            Font = UITheme.FontRegular,
            ForeColor = ColorTranslator.FromHtml("#EBE2D8"),
            AutoSize = true,
            Anchor = AnchorStyles.Top | AnchorStyles.Right,
            Location = new Point(pnlHeader.Width - 340, 20)
        };
        pnlHeader.Controls.Add(lblUser);

        var btnLogout = new RjButton
        {
            Text = "Đăng xuất",
            Size = new Size(95, 32),
            BackColor = UITheme.Accent,
            HoverBackColor = UITheme.AccentHover,
            Font = UITheme.FontSmall,
            BorderRadius = 4,
            Anchor = AnchorStyles.Top | AnchorStyles.Right,
            Location = new Point(pnlHeader.Width - 120, 14)
        };
        btnLogout.Click += (_, _) => Close();
        pnlHeader.Controls.Add(btnLogout);

        // 2. LEFT SIDEBAR MENU
        var pnlSidebar = new Panel
        {
            Dock = DockStyle.Left,
            Width = 220,
            BackColor = UITheme.Surface,
            BorderStyle = BorderStyle.FixedSingle,
            Padding = new Padding(12)
        };
        Controls.Add(pnlSidebar);

        int btnY = 20;
        void AddNavButton(string title, bool isAdminOnly, EventHandler onClick)
        {
            var btn = new RjButton
            {
                Text = title,
                Location = new Point(12, btnY),
                Size = new Size(194, 42),
                BackColor = UITheme.CanvasBg,
                HoverBackColor = ColorTranslator.FromHtml("#EBE2D8"),
                ForeColor = UITheme.TextDark,
                Font = UITheme.FontBold,
                BorderColor = UITheme.Border,
                BorderSize = 1,
                BorderRadius = 6
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

            pnlSidebar.Controls.Add(btn);
            btnY += 52;
        }

        AddNavButton("Bán hàng (POS)", false, async (_, _) => await LoadTablesAsync());
        AddNavButton("Thực đơn & Món", true, (_, _) => OpenForm(new FrmCategoryProduct(_productService)));
        AddNavButton("Quản lý Bàn", true, (_, _) => OpenForm(new FrmTableManager(_tableService)));
        AddNavButton("Quản lý Nhân viên", true, (_, _) => OpenForm(new FrmUserManager(_authService, _currentUser)));
        AddNavButton("Báo cáo Doanh thu", true, (_, _) => OpenForm(new FrmReport(_reportService)));

        // Ghi chú quyền
        if (_currentUser.Role != "Admin")
        {
            var lblRoleHint = new Label
            {
                Text = "(*) Chức năng chỉ dành cho Admin",
                Font = UITheme.FontSmall,
                ForeColor = UITheme.TextMuted,
                Location = new Point(12, btnY + 20),
                Size = new Size(194, 40)
            };
            pnlSidebar.Controls.Add(lblRoleHint);
        }

        // 3. RIGHT POS BILL PANEL
        var pnlBill = new Panel
        {
            Dock = DockStyle.Right,
            Width = 440,
            BackColor = UITheme.Surface,
            BorderStyle = BorderStyle.FixedSingle,
            Padding = new Padding(16)
        };
        Controls.Add(pnlBill);

        // Bill Header
        _lblSelectedTableName = new Label
        {
            Text = "Chọn bàn để thao tác",
            Font = UITheme.FontHeader,
            ForeColor = UITheme.Primary,
            Location = new Point(16, 16),
            Size = new Size(260, 25)
        };
        pnlBill.Controls.Add(_lblSelectedTableName);

        _lblSelectedTableStatus = new Label
        {
            Text = "",
            Font = UITheme.FontBold,
            Location = new Point(280, 18),
            Size = new Size(140, 22),
            TextAlign = ContentAlignment.MiddleRight
        };
        pnlBill.Controls.Add(_lblSelectedTableStatus);

        // Bill Items DataGridView
        _dgvBill = new DataGridView
        {
            Location = new Point(16, 50),
            Size = new Size(405, 420),
            Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right
        };
        UITheme.ApplyModernGridStyle(_dgvBill);
        SetupBillGridColumns();
        pnlBill.Controls.Add(_dgvBill);

        // Action Toolbar (Buttons)
        var pnlActions = new Panel
        {
            Dock = DockStyle.Bottom,
            Height = 220,
            BackColor = UITheme.Surface
        };
        pnlBill.Controls.Add(pnlActions);

        // Subtotal row
        var lblSubTitle = new Label
        {
            Text = "TẠM TÍNH:",
            Font = UITheme.FontHeader,
            ForeColor = UITheme.TextDark,
            Location = new Point(16, 15),
            AutoSize = true
        };
        pnlActions.Controls.Add(lblSubTitle);

        _lblSubTotal = new Label
        {
            Text = "0 đ",
            Font = new Font("Segoe UI", 15f, FontStyle.Bold),
            ForeColor = UITheme.Danger,
            Location = new Point(160, 10),
            Size = new Size(260, 30),
            TextAlign = ContentAlignment.MiddleRight
        };
        pnlActions.Controls.Add(_lblSubTotal);

        // Buttons row 1
        _btnAddProduct = new RjButton
        {
            Text = "+ THÊM MÓN",
            Location = new Point(16, 55),
            Size = new Size(130, 42),
            BackColor = UITheme.Accent,
            HoverBackColor = UITheme.AccentHover,
            BorderRadius = 6,
            Enabled = false
        };
        _btnAddProduct.Click += BtnAddProduct_Click;
        pnlActions.Controls.Add(_btnAddProduct);

        _btnSwitchTable = new RjButton
        {
            Text = "ĐỔI BÀN",
            Location = new Point(155, 55),
            Size = new Size(130, 42),
            BackColor = Color.White,
            HoverBackColor = ColorTranslator.FromHtml("#F0EBE5"),
            ForeColor = UITheme.TextDark,
            BorderColor = UITheme.Border,
            BorderSize = 1,
            BorderRadius = 6,
            Enabled = false
        };
        _btnSwitchTable.Click += BtnSwitchTable_Click;
        pnlActions.Controls.Add(_btnSwitchTable);

        _btnMergeTable = new RjButton
        {
            Text = "GỘP BÀN",
            Location = new Point(292, 55),
            Size = new Size(130, 42),
            BackColor = Color.White,
            HoverBackColor = ColorTranslator.FromHtml("#F0EBE5"),
            ForeColor = UITheme.TextDark,
            BorderColor = UITheme.Border,
            BorderSize = 1,
            BorderRadius = 6,
            Enabled = false
        };
        _btnMergeTable.Click += BtnMergeTable_Click;
        pnlActions.Controls.Add(_btnMergeTable);

        // Pay Button
        _btnPay = new RjButton
        {
            Text = "THANH TOÁN & IN HÓA ĐƠN",
            Location = new Point(16, 110),
            Size = new Size(406, 50),
            BackColor = UITheme.Primary,
            HoverBackColor = UITheme.PrimaryHover,
            Font = new Font("Segoe UI", 11f, FontStyle.Bold),
            BorderRadius = 6,
            Enabled = false
        };
        _btnPay.Click += BtnPay_Click;
        pnlActions.Controls.Add(_btnPay);

        // 4. CENTER TABLE MAP AREA
        var pnlCenter = new Panel
        {
            Dock = DockStyle.Fill,
            BackColor = UITheme.CanvasBg,
            Padding = new Padding(20)
        };
        Controls.Add(pnlCenter);

        // Area Filter Panel
        var pnlFilter = new Panel
        {
            Dock = DockStyle.Top,
            Height = 45,
            BackColor = Color.Transparent
        };
        pnlCenter.Controls.Add(pnlFilter);

        var lblArea = new Label
        {
            Text = "Khu vực:",
            Font = UITheme.FontBold,
            ForeColor = UITheme.TextDark,
            Location = new Point(5, 10),
            AutoSize = true
        };
        pnlFilter.Controls.Add(lblArea);

        _cbAreaFilter = new ComboBox
        {
            Location = new Point(80, 6),
            Size = new Size(180, 30),
            DropDownStyle = ComboBoxStyle.DropDownList,
            Font = UITheme.FontRegular
        };
        _cbAreaFilter.SelectedIndexChanged += (_, _) => FilterTables();
        pnlFilter.Controls.Add(_cbAreaFilter);

        // Table FlowLayoutPanel
        _flpTables = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            AutoScroll = true,
            BackColor = Color.Transparent,
            Padding = new Padding(5)
        };
        pnlCenter.Controls.Add(_flpTables);
    }

    private void SetupBillGridColumns()
    {
        _dgvBill.Columns.Clear();
        _dgvBill.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", Visible = false });
        _dgvBill.Columns.Add(new DataGridViewTextBoxColumn { Name = "ProductName", HeaderText = "Tên Món", Width = 150 });
        _dgvBill.Columns.Add(new DataGridViewTextBoxColumn { Name = "Quantity", HeaderText = "SL", Width = 45 });
        _dgvBill.Columns.Add(new DataGridViewTextBoxColumn { Name = "UnitPrice", HeaderText = "Đơn Giá", Width = 90 });
        _dgvBill.Columns.Add(new DataGridViewTextBoxColumn { Name = "LineTotal", HeaderText = "Thành Tiền", Width = 95 });

        // Add Delete Button Column
        var btnCol = new DataGridViewButtonColumn
        {
            Name = "ColDelete",
            HeaderText = "",
            Text = "X",
            UseColumnTextForButtonValue = true,
            Width = 35
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

    private List<Table> _loadedTables = new();

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
            _lblSelectedTableStatus.Text = "Có khách";
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
            _lblSelectedTableStatus.Text = "Bàn trống";
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
