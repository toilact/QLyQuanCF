using System.Drawing;
using System.Windows.Forms;
using CoffeeShopManagement.Components;
using CoffeeShopManagement.Models;
using CoffeeShopManagement.Services.Interfaces;

namespace CoffeeShopManagement.Forms;

public partial class FrmMain : Form
{
    private readonly User? _currentUser;
    private readonly ITableService? _tableService;
    private readonly IProductService? _productService;
    private readonly IBillService? _billService;
    private readonly IReportService? _reportService;
    private readonly IAuthService? _authService;

    private Table? _selectedTable;
    private Bill? _currentBill;
    private List<Table> _loadedTables = new();

    // Parameterless constructor cho Visual Studio WinForms Designer
    public FrmMain()
    {
        InitializeComponent();
    }

    public FrmMain(
        User currentUser,
        ITableService tableService,
        IProductService productService,
        IBillService billService,
        IReportService reportService,
        IAuthService authService) : this()
    {
        _currentUser = currentUser;
        _tableService = tableService;
        _productService = productService;
        _billService = billService;
        _reportService = reportService;
        _authService = authService;

        // Cập nhật thông tin User trên Header
        lblTenNhanVien.Text = _currentUser.FullName;
        lblVaiTro.Text = _currentUser.Role == "Admin" ? "QUẢN TRỊ VIÊN" : "THU NGÂN";
        lblVaiTro.BackColor = _currentUser.Role == "Admin" ? UITheme.Accent : UITheme.TableEmpty;

        // Phân quyền Menu
        if (_currentUser.Role != "Admin")
        {
            btnThucDon.Enabled = false;
            btnThucDon.ForeColor = UITheme.TextMuted;
            btnThucDon.Text += " (*)";

            btnQuanLyBan.Enabled = false;
            btnQuanLyBan.ForeColor = UITheme.TextMuted;
            btnQuanLyBan.Text += " (*)";

            btnQuanLyNhanVien.Enabled = false;
            btnQuanLyNhanVien.ForeColor = UITheme.TextMuted;
            btnQuanLyNhanVien.Text += " (*)";

            btnBaoCao.Enabled = false;
            btnBaoCao.ForeColor = UITheme.TextMuted;
            btnBaoCao.Text += " (*)";

            lblGhiChuAdmin.Visible = true;
        }

        // Gắn sự kiện các nút
        btnDangXuat.Click += (_, _) => Close();
        btnBanHang.Click += async (_, _) => await LoadTablesAsync();
        btnThucDon.Click += (_, _) => OpenForm(new FrmCategoryProduct(_productService!));
        btnQuanLyBan.Click += (_, _) => OpenForm(new FrmTableManager(_tableService!));
        btnQuanLyNhanVien.Click += (_, _) => OpenForm(new FrmUserManager(_authService!, _currentUser));
        btnBaoCao.Click += (_, _) => OpenForm(new FrmReport(_reportService!));

        btnAddProductEvent();
        btnSwitchTableEvent();
        btnMergeTableEvent();
        btnPayEvent();

        cboKhuVuc.SelectedIndexChanged += (_, _) => FilterTables();

        UITheme.ApplyModernGridStyle(dgvChiTietHoaDon);
        SetupBillGridColumns();

        Load += async (_, _) => await LoadTablesAsync();
    }

    private void btnAddProductEvent()
    {
        btnThemMon.Click += async (_, _) =>
        {
            if (_selectedTable == null || _productService == null || _billService == null || _currentUser == null) return;

            using var dlg = new FrmSelectProduct(_productService, _selectedTable);
            if (dlg.ShowDialog() == DialogResult.OK && dlg.SelectedProduct != null)
            {
                await _billService.AddOrUpdateProductAsync(_selectedTable.Id, dlg.SelectedProduct.Id, dlg.SelectedQuantity, _currentUser.Id);
                await LoadTablesAsync();
            }
        };
    }

    private void btnSwitchTableEvent()
    {
        btnDoiBan.Click += async (_, _) =>
        {
            if (_selectedTable == null || _tableService == null) return;

            using var dlg = new FrmTransferMergeTable(_tableService, _selectedTable);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (dlg.IsMergeMode)
                        await _tableService.MergeTableAsync(_selectedTable.Id, dlg.TargetTableId);
                    else
                        await _tableService.SwitchTableAsync(_selectedTable.Id, dlg.TargetTableId);

                    _selectedTable = null;
                    await LoadTablesAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        };
    }

    private void btnMergeTableEvent()
    {
        btnGopBan.Click += (s, e) => btnDoiBan.PerformClick();
    }

    private void btnPayEvent()
    {
        btnThanhToan.Click += async (_, _) =>
        {
            if (_currentBill == null || _billService == null) return;

            using var dlg = new FrmPayment(_billService, _currentBill);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                _selectedTable = null;
                await LoadTablesAsync();
            }
        };
    }

    private void SetupBillGridColumns()
    {
        dgvChiTietHoaDon.Columns.Clear();
        dgvChiTietHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvChiTietHoaDon.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;

        dgvChiTietHoaDon.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", Visible = false });

        var colName = new DataGridViewTextBoxColumn
        {
            Name = "ProductName",
            HeaderText = "Tên Món",
            FillWeight = 42
        };
        dgvChiTietHoaDon.Columns.Add(colName);

        var colQty = new DataGridViewTextBoxColumn
        {
            Name = "Quantity",
            HeaderText = "SL",
            FillWeight = 14,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
        };
        dgvChiTietHoaDon.Columns.Add(colQty);

        var colPrice = new DataGridViewTextBoxColumn
        {
            Name = "UnitPrice",
            HeaderText = "Đơn Giá",
            FillWeight = 22,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight }
        };
        dgvChiTietHoaDon.Columns.Add(colPrice);

        var colTotal = new DataGridViewTextBoxColumn
        {
            Name = "LineTotal",
            HeaderText = "Thành Tiền",
            FillWeight = 22,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight }
        };
        dgvChiTietHoaDon.Columns.Add(colTotal);

        var btnCol = new DataGridViewButtonColumn
        {
            Name = "ColDelete",
            HeaderText = "",
            Text = "X",
            UseColumnTextForButtonValue = true,
            Width = 36,
            AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        };
        dgvChiTietHoaDon.Columns.Add(btnCol);

        dgvChiTietHoaDon.CellContentClick += async (s, e) =>
        {
            if (_billService == null) return;

            if (e.RowIndex >= 0 && e.ColumnIndex == dgvChiTietHoaDon.Columns["ColDelete"].Index)
            {
                int detailId = (int)dgvChiTietHoaDon.Rows[e.RowIndex].Cells["Id"].Value;
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
        if (_tableService == null) return;

        _loadedTables = await _tableService.GetAllTablesAsync();

        var areas = new List<string> { "Tất cả" };
        areas.AddRange(_loadedTables.Select(t => t.Area).Distinct());

        string currentSelectedArea = cboKhuVuc.SelectedItem?.ToString() ?? "Tất cả";
        cboKhuVuc.DataSource = areas;
        if (areas.Contains(currentSelectedArea))
            cboKhuVuc.SelectedItem = currentSelectedArea;

        FilterTables();

        if (_selectedTable != null)
        {
            _selectedTable = _loadedTables.FirstOrDefault(t => t.Id == _selectedTable.Id);
            await RefreshSelectedTableBillAsync();
        }
    }

    private void FilterTables()
    {
        flpDanhSachBan.Controls.Clear();
        string selectedArea = cboKhuVuc.SelectedItem?.ToString() ?? "Tất cả";

        var displayTables = selectedArea == "Tất cả"
            ? _loadedTables
            : _loadedTables.Where(t => t.Area == selectedArea).ToList();

        int occupiedCount = displayTables.Count(t => t.Status == 1);
        lblThongKeBan.Text = $"Hiển thị: {displayTables.Count} bàn ({occupiedCount} có khách, {displayTables.Count - occupiedCount} trống)";

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
                foreach (Control c in flpDanhSachBan.Controls)
                {
                    if (c is UcTableCard tc) tc.IsSelected = (tc.TableData?.Id == table.Id);
                }
                await RefreshSelectedTableBillAsync();
            };

            flpDanhSachBan.Controls.Add(card);
        }
    }

    private async Task RefreshSelectedTableBillAsync()
    {
        if (_selectedTable == null || _billService == null)
        {
            lblBanDangChon.Text = "Chọn bàn để thao tác";
            lblTrangThaiBan.Text = "";
            lblTongTamTinh.Text = "0 đ";
            btnThemMon.Enabled = false;
            btnDoiBan.Enabled = false;
            btnGopBan.Enabled = false;
            btnThanhToan.Enabled = false;
            dgvChiTietHoaDon.Rows.Clear();
            return;
        }

        lblBanDangChon.Text = $"{_selectedTable.Name} ({_selectedTable.Area})";
        btnThemMon.Enabled = true;

        _currentBill = await _billService.GetActiveBillByTableIdAsync(_selectedTable.Id);
        dgvChiTietHoaDon.Rows.Clear();

        if (_currentBill != null && _currentBill.Details.Any())
        {
            lblTrangThaiBan.Text = "CÓ KHÁCH";
            lblTrangThaiBan.ForeColor = UITheme.TableOccupied;
            btnDoiBan.Enabled = true;
            btnGopBan.Enabled = true;
            btnThanhToan.Enabled = true;

            decimal subTotal = 0;
            foreach (var d in _currentBill.Details)
            {
                decimal total = d.Quantity * d.UnitPrice;
                subTotal += total;
                dgvChiTietHoaDon.Rows.Add(d.Id, d.Product?.Name ?? "Món", d.Quantity, $"{d.UnitPrice:N0}", $"{total:N0}");
            }
            lblTongTamTinh.Text = $"{subTotal:N0} đ";
        }
        else
        {
            lblTrangThaiBan.Text = "BÀN TRỐNG";
            lblTrangThaiBan.ForeColor = UITheme.TableEmpty;
            lblTongTamTinh.Text = "0 đ";
            btnDoiBan.Enabled = false;
            btnGopBan.Enabled = false;
            btnThanhToan.Enabled = false;
        }
    }

    private async void OpenForm(Form form)
    {
        form.StartPosition = FormStartPosition.CenterParent;
        form.ShowDialog();
        await LoadTablesAsync();
    }
}
