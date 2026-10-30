using System.Drawing;
using System.Windows.Forms;
using CoffeeShopManagement.Components;
using CoffeeShopManagement.Models;
using CoffeeShopManagement.Services.Interfaces;
using CoffeeShopManagement.Utils;

namespace CoffeeShopManagement.Forms;

public class FrmReport : Form
{
    private readonly IReportService _reportService;

    private DateTimePicker _dtpFrom = null!;
    private DateTimePicker _dtpTo = null!;
    private Label _lblTotalRevenue = null!;
    private Label _lblTotalBills = null!;
    private Label _lblAverageBill = null!;
    private DataGridView _dgvBills = null!;
    private DataGridView _dgvTopProducts = null!;
    private RjButton _btnExportExcel = null!;

    private List<Bill> _currentBills = new();
    private List<(string ProductName, int QuantitySold, decimal Revenue)> _currentTopProducts = new();

    public FrmReport(IReportService reportService)
    {
        _reportService = reportService;
        InitializeComponent();
        _dtpFrom.Value = DateTime.Today.AddDays(-30);
        _dtpTo.Value = DateTime.Today;
        Load += async (_, _) => await LoadReportDataAsync();
    }

    private void InitializeComponent()
    {
        Text = "Báo Cáo Doanh Thu và Thống Kê Bán Hàng";
        Size = new Size(1220, 780);
        MinimumSize = new Size(1050, 680);
        StartPosition = FormStartPosition.CenterParent;
        BackColor = UITheme.CanvasBg;

        // 1. TOP FILTER BAR
        var pnlFilter = new Panel
        {
            Dock = DockStyle.Top,
            Height = 65,
            BackColor = UITheme.Surface,
            BorderStyle = BorderStyle.FixedSingle,
            Padding = new Padding(20, 12, 20, 12)
        };
        Controls.Add(pnlFilter);

        // Left filter elements
        var flpFilterLeft = new FlowLayoutPanel
        {
            Dock = DockStyle.Left,
            AutoSize = true,
            FlowDirection = FlowDirection.LeftToRight,
            WrapContents = false,
            BackColor = Color.Transparent
        };
        pnlFilter.Controls.Add(flpFilterLeft);

        var lblFrom = new Label { Text = "Từ ngày:", Font = UITheme.FontBold, Margin = new Padding(0, 8, 4, 0), AutoSize = true };
        _dtpFrom = new DateTimePicker
        {
            Size = new Size(130, 30),
            Format = DateTimePickerFormat.Custom,
            CustomFormat = "dd/MM/yyyy",
            Font = UITheme.FontRegular,
            Margin = new Padding(0, 4, 16, 0)
        };
        flpFilterLeft.Controls.Add(lblFrom);
        flpFilterLeft.Controls.Add(_dtpFrom);

        var lblTo = new Label { Text = "Đến ngày:", Font = UITheme.FontBold, Margin = new Padding(0, 8, 4, 0), AutoSize = true };
        _dtpTo = new DateTimePicker
        {
            Size = new Size(130, 30),
            Format = DateTimePickerFormat.Custom,
            CustomFormat = "dd/MM/yyyy",
            Font = UITheme.FontRegular,
            Margin = new Padding(0, 4, 16, 0)
        };
        flpFilterLeft.Controls.Add(lblTo);
        flpFilterLeft.Controls.Add(_dtpTo);

        var btnFilter = new RjButton
        {
            Text = "THỐNG KÊ",
            Size = new Size(115, 34),
            BackColor = UITheme.Primary,
            BorderRadius = 6,
            Margin = new Padding(0, 2, 10, 0)
        };
        btnFilter.Click += async (_, _) => await LoadReportDataAsync();
        flpFilterLeft.Controls.Add(btnFilter);

        var btnToday = new RjButton
        {
            Text = "Hôm nay",
            Size = new Size(95, 34),
            BackColor = UITheme.CanvasBg,
            HoverBackColor = ColorTranslator.FromHtml("#EBE2D8"),
            ForeColor = UITheme.TextDark,
            BorderColor = UITheme.Border,
            BorderSize = 1,
            BorderRadius = 6,
            Margin = new Padding(0, 2, 8, 0)
        };
        btnToday.Click += async (_, _) => { _dtpFrom.Value = DateTime.Today; _dtpTo.Value = DateTime.Today; await LoadReportDataAsync(); };
        flpFilterLeft.Controls.Add(btnToday);

        var btnThisMonth = new RjButton
        {
            Text = "Tháng này",
            Size = new Size(100, 34),
            BackColor = UITheme.CanvasBg,
            HoverBackColor = ColorTranslator.FromHtml("#EBE2D8"),
            ForeColor = UITheme.TextDark,
            BorderColor = UITheme.Border,
            BorderSize = 1,
            BorderRadius = 6,
            Margin = new Padding(0, 2, 0, 0)
        };
        btnThisMonth.Click += async (_, _) =>
        {
            _dtpFrom.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            _dtpTo.Value = DateTime.Today;
            await LoadReportDataAsync();
        };
        flpFilterLeft.Controls.Add(btnThisMonth);

        // Right export button
        _btnExportExcel = new RjButton
        {
            Text = "XUẤT BÁO CÁO EXCEL",
            Dock = DockStyle.Right,
            Width = 210,
            BackColor = ColorTranslator.FromHtml("#1D6F42"),
            HoverBackColor = ColorTranslator.FromHtml("#268752"),
            Font = UITheme.FontBold,
            BorderRadius = 6
        };
        _btnExportExcel.Click += BtnExportExcel_Click;
        pnlFilter.Controls.Add(_btnExportExcel);

        // 2. KPI SUMMARY CARDS (Dock = Top)
        var pnlKpiContainer = new Panel
        {
            Dock = DockStyle.Top,
            Height = 115,
            BackColor = UITheme.CanvasBg,
            Padding = new Padding(20, 12, 20, 10)
        };
        Controls.Add(pnlKpiContainer);

        var tblKpi = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            ColumnCount = 3,
            RowCount = 1,
            BackColor = Color.Transparent
        };
        tblKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
        tblKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
        tblKpi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.34F));
        pnlKpiContainer.Controls.Add(tblKpi);

        Panel CreateKpiCard(string title, out Label lblVal, Color valColor)
        {
            var card = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = UITheme.Surface,
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(16, 12, 16, 12),
                Margin = new Padding(6)
            };

            var lblT = new Label
            {
                Text = title,
                Font = UITheme.FontSmall,
                ForeColor = UITheme.TextMuted,
                Dock = DockStyle.Top,
                Height = 20
            };
            lblVal = new Label
            {
                Text = "0 đ",
                Font = new Font("Segoe UI", 16f, FontStyle.Bold),
                ForeColor = valColor,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft
            };
            card.Controls.Add(lblVal);
            card.Controls.Add(lblT);
            return card;
        }

        tblKpi.Controls.Add(CreateKpiCard("TỔNG DOANH THU", out _lblTotalRevenue, UITheme.Danger), 0, 0);
        tblKpi.Controls.Add(CreateKpiCard("TỔNG SỐ HÓA ĐƠN ĐÃ BÁN", out _lblTotalBills, UITheme.Primary), 1, 0);
        tblKpi.Controls.Add(CreateKpiCard("GIÁ TRỊ ĐƠN TRUNG BÌNH", out _lblAverageBill, UITheme.Accent), 2, 0);

        // 3. MAIN DATA TABS CONTAINER (Dock = Fill)
        var pnlTabsContainer = new Panel
        {
            Dock = DockStyle.Fill,
            BackColor = UITheme.CanvasBg,
            Padding = new Padding(20, 0, 20, 20)
        };
        Controls.Add(pnlTabsContainer);
        pnlTabsContainer.BringToFront();

        var tabs = new TabControl
        {
            Dock = DockStyle.Fill,
            Font = UITheme.FontBold,
            Padding = new Point(20, 8)
        };
        pnlTabsContainer.Controls.Add(tabs);

        // Tab 1: Bills Grid
        var tabBills = new TabPage("  Danh Sách Hóa Đơn Thanh Toán  ") { BackColor = UITheme.CanvasBg, Padding = new Padding(12) };
        _dgvBills = new DataGridView
        {
            Dock = DockStyle.Fill,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        };
        UITheme.ApplyModernGridStyle(_dgvBills);

        var colId = new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "Mã HĐ", FillWeight = 11, DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter } };
        _dgvBills.Columns.Add(colId);

        _dgvBills.Columns.Add(new DataGridViewTextBoxColumn { Name = "Table", HeaderText = "Bàn", FillWeight = 15 });
        _dgvBills.Columns.Add(new DataGridViewTextBoxColumn { Name = "User", HeaderText = "Thu Ngân", FillWeight = 18 });

        var colIn = new DataGridViewTextBoxColumn { Name = "CheckIn", HeaderText = "Giờ Vào", FillWeight = 18, DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter } };
        _dgvBills.Columns.Add(colIn);

        var colOut = new DataGridViewTextBoxColumn { Name = "CheckOut", HeaderText = "Giờ Thanh Toán", FillWeight = 18, DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter } };
        _dgvBills.Columns.Add(colOut);

        var colDiscount = new DataGridViewTextBoxColumn { Name = "Discount", HeaderText = "Giảm (%)", FillWeight = 10, DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter } };
        _dgvBills.Columns.Add(colDiscount);

        var colTotal = new DataGridViewTextBoxColumn { Name = "Total", HeaderText = "Thành Tiền", FillWeight = 20, DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight, Font = UITheme.FontBold } };
        _dgvBills.Columns.Add(colTotal);

        tabBills.Controls.Add(_dgvBills);
        tabs.TabPages.Add(tabBills);

        // Tab 2: Top Products Grid
        var tabTop = new TabPage("  Top Sản Phẩm Bán Chạy  ") { BackColor = UITheme.CanvasBg, Padding = new Padding(12) };
        _dgvTopProducts = new DataGridView
        {
            Dock = DockStyle.Fill,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        };
        UITheme.ApplyModernGridStyle(_dgvTopProducts);

        var colRank = new DataGridViewTextBoxColumn { Name = "Rank", HeaderText = "Xếp Hạng", FillWeight = 12, DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter, Font = UITheme.FontBold } };
        _dgvTopProducts.Columns.Add(colRank);

        _dgvTopProducts.Columns.Add(new DataGridViewTextBoxColumn { Name = "Name", HeaderText = "Tên Sản Phẩm", FillWeight = 48 });

        var colQty = new DataGridViewTextBoxColumn { Name = "Qty", HeaderText = "Số Lượng Bán", FillWeight = 20, DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter } };
        _dgvTopProducts.Columns.Add(colQty);

        var colRev = new DataGridViewTextBoxColumn { Name = "Revenue", HeaderText = "Doanh Thu Món", FillWeight = 20, DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight, Font = UITheme.FontBold } };
        _dgvTopProducts.Columns.Add(colRev);

        tabTop.Controls.Add(_dgvTopProducts);
        tabs.TabPages.Add(tabTop);
    }

    private async Task LoadReportDataAsync()
    {
        var from = _dtpFrom.Value;
        var to = _dtpTo.Value;

        var (totalRevenue, totalBills, average) = await _reportService.GetSummaryAsync(from, to);
        _lblTotalRevenue.Text = $"{totalRevenue:N0} đ";
        _lblTotalBills.Text = $"{totalBills:N0} đơn";
        _lblAverageBill.Text = $"{average:N0} đ";

        _currentBills = await _reportService.GetRevenueBillsAsync(from, to);
        _dgvBills.Rows.Clear();
        foreach (var b in _currentBills)
        {
            _dgvBills.Rows.Add(
                $"#{b.Id:D5}",
                b.Table?.Name ?? "Mang về",
                b.User?.FullName ?? "Staff",
                b.CheckInDate.ToString("dd/MM/yyyy HH:mm"),
                b.CheckOutDate?.ToString("dd/MM/yyyy HH:mm") ?? "-",
                $"{b.DiscountPercent}%",
                $"{b.TotalAmount:N0} đ"
            );
        }

        _currentTopProducts = await _reportService.GetTopSellingProductsAsync(from, to, 15);
        _dgvTopProducts.Rows.Clear();
        int rank = 1;
        foreach (var p in _currentTopProducts)
        {
            _dgvTopProducts.Rows.Add(rank++, p.ProductName, $"{p.QuantitySold:N0}", $"{p.Revenue:N0} đ");
        }
    }

    private void BtnExportExcel_Click(object? sender, EventArgs e)
    {
        if (!_currentBills.Any())
        {
            MessageBox.Show("Không có dữ liệu trong khoảng thời gian này để xuất báo cáo.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        using var sfd = new SaveFileDialog
        {
            Filter = "Excel Workbook (*.xlsx)|*.xlsx",
            FileName = $"BaoCaoDoanhThu_{_dtpFrom.Value:yyyyMMdd}_{_dtpTo.Value:yyyyMMdd}.xlsx",
            Title = "Lưu Báo Cáo Doanh Thu"
        };

        if (sfd.ShowDialog() == DialogResult.OK)
        {
            try
            {
                ExcelExporter.ExportRevenueReport(sfd.FileName, _dtpFrom.Value, _dtpTo.Value, _currentBills, _currentTopProducts);
                MessageBox.Show($"Đã xuất file báo cáo Excel thành công tại:\n{sfd.FileName}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xuất Excel: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
