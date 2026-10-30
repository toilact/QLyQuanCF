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
        Text = "Báo Cáo Doanh Thu & Thống Kê Bán Hàng";
        Size = new Size(1100, 720);
        StartPosition = FormStartPosition.CenterParent;
        BackColor = UITheme.CanvasBg;

        // 1. TOP FILTER BAR
        var pnlFilter = new Panel
        {
            Dock = DockStyle.Top,
            Height = 70,
            BackColor = UITheme.Surface,
            BorderStyle = BorderStyle.FixedSingle,
            Padding = new Padding(16, 12, 16, 12)
        };
        Controls.Add(pnlFilter);

        var lblFrom = new Label { Text = "Từ ngày:", Font = UITheme.FontBold, Location = new Point(16, 22), AutoSize = true };
        _dtpFrom = new DateTimePicker { Location = new Point(85, 18), Size = new Size(130, 28), Format = DateTimePickerFormat.Short, Font = UITheme.FontRegular };
        pnlFilter.Controls.Add(lblFrom);
        pnlFilter.Controls.Add(_dtpFrom);

        var lblTo = new Label { Text = "Đến ngày:", Font = UITheme.FontBold, Location = new Point(230, 22), AutoSize = true };
        _dtpTo = new DateTimePicker { Location = new Point(310, 18), Size = new Size(130, 28), Format = DateTimePickerFormat.Short, Font = UITheme.FontRegular };
        pnlFilter.Controls.Add(lblTo);
        pnlFilter.Controls.Add(_dtpTo);

        var btnFilter = new RjButton
        {
            Text = "THỐNG KÊ",
            Location = new Point(460, 15),
            Size = new Size(120, 36),
            BackColor = UITheme.Primary,
            BorderRadius = 6
        };
        btnFilter.Click += async (_, _) => await LoadReportDataAsync();
        pnlFilter.Controls.Add(btnFilter);

        // Quick Filters
        var btnToday = new Button { Text = "Hôm nay", Location = new Point(590, 17), Size = new Size(80, 32), FlatStyle = FlatStyle.Flat, BackColor = UITheme.CanvasBg };
        btnToday.Click += async (_, _) => { _dtpFrom.Value = DateTime.Today; _dtpTo.Value = DateTime.Today; await LoadReportDataAsync(); };
        pnlFilter.Controls.Add(btnToday);

        var btnThisMonth = new Button { Text = "Tháng này", Location = new Point(680, 17), Size = new Size(85, 32), FlatStyle = FlatStyle.Flat, BackColor = UITheme.CanvasBg };
        btnThisMonth.Click += async (_, _) =>
        {
            _dtpFrom.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            _dtpTo.Value = DateTime.Today;
            await LoadReportDataAsync();
        };
        pnlFilter.Controls.Add(btnThisMonth);

        // Export Excel Button
        _btnExportExcel = new RjButton
        {
            Text = "XUẤT BÁO CÁO EXCEL",
            Anchor = AnchorStyles.Top | AnchorStyles.Right,
            Location = new Point(pnlFilter.Width - 220, 14),
            Size = new Size(200, 38),
            BackColor = ColorTranslator.FromHtml("#1D6F42"), // Excel Dark Green
            HoverBackColor = ColorTranslator.FromHtml("#268752"),
            BorderRadius = 6
        };
        _btnExportExcel.Click += BtnExportExcel_Click;
        pnlFilter.Controls.Add(_btnExportExcel);

        // 2. KPI SUMMARY CARDS
        var pnlCards = new Panel
        {
            Dock = DockStyle.Top,
            Height = 110,
            BackColor = UITheme.CanvasBg,
            Padding = new Padding(16, 12, 16, 8)
        };
        Controls.Add(pnlCards);

        Panel CreateKpiCard(string title, out Label lblVal, Color valColor, int x)
        {
            var pnl = new Panel
            {
                Location = new Point(x, 12),
                Size = new Size(330, 85),
                BackColor = UITheme.Surface,
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(16)
            };

            var lblT = new Label { Text = title, Font = UITheme.FontSmall, ForeColor = UITheme.TextMuted, Location = new Point(14, 12), AutoSize = true };
            lblVal = new Label { Text = "0", Font = new Font("Segoe UI", 16f, FontStyle.Bold), ForeColor = valColor, Location = new Point(14, 35), Size = new Size(300, 35) };
            pnl.Controls.Add(lblT);
            pnl.Controls.Add(lblVal);
            return pnl;
        }

        pnlCards.Controls.Add(CreateKpiCard("TỔNG DOANH THU", out _lblTotalRevenue, UITheme.Danger, 16));
        pnlCards.Controls.Add(CreateKpiCard("TỔNG SỐ HÓA ĐƠN ĐÃ BÁN", out _lblTotalBills, UITheme.Primary, 370));
        pnlCards.Controls.Add(CreateKpiCard("GIÁ TRỊ ĐƠN TRUNG BÌNH", out _lblAverageBill, UITheme.Accent, 720));

        // 3. TABS DATA
        var tabs = new TabControl
        {
            Dock = DockStyle.Fill,
            Font = UITheme.FontBold,
            Padding = new Point(16, 8)
        };
        Controls.Add(tabs);

        var tabBills = new TabPage("  Danh Sách Hóa Đơn Thanh Toán  ") { BackColor = UITheme.CanvasBg, Padding = new Padding(8) };
        _dgvBills = new DataGridView { Dock = DockStyle.Fill };
        UITheme.ApplyModernGridStyle(_dgvBills);
        _dgvBills.Columns.Add("Id", "Mã HĐ");
        _dgvBills.Columns["Id"].Width = 90;
        _dgvBills.Columns.Add("Table", "Bàn");
        _dgvBills.Columns["Table"].Width = 140;
        _dgvBills.Columns.Add("User", "Thu Ngân");
        _dgvBills.Columns["User"].Width = 160;
        _dgvBills.Columns.Add("CheckIn", "Giờ Vào");
        _dgvBills.Columns["CheckIn"].Width = 160;
        _dgvBills.Columns.Add("CheckOut", "Giờ Thanh Toán");
        _dgvBills.Columns["CheckOut"].Width = 160;
        _dgvBills.Columns.Add("Discount", "Giảm (%)");
        _dgvBills.Columns["Discount"].Width = 90;
        _dgvBills.Columns.Add("Total", "Thành Tiền");
        _dgvBills.Columns["Total"].Width = 140;
        tabBills.Controls.Add(_dgvBills);
        tabs.TabPages.Add(tabBills);

        var tabTop = new TabPage("  Top Sản Phẩm Bán Chạy  ") { BackColor = UITheme.CanvasBg, Padding = new Padding(8) };
        _dgvTopProducts = new DataGridView { Dock = DockStyle.Fill };
        UITheme.ApplyModernGridStyle(_dgvTopProducts);
        _dgvTopProducts.Columns.Add("Rank", "Hạng");
        _dgvTopProducts.Columns["Rank"].Width = 80;
        _dgvTopProducts.Columns.Add("Name", "Tên Món");
        _dgvTopProducts.Columns["Name"].Width = 300;
        _dgvTopProducts.Columns.Add("Qty", "Số Lượng Bán");
        _dgvTopProducts.Columns["Qty"].Width = 150;
        _dgvTopProducts.Columns.Add("Revenue", "Doanh Thu");
        _dgvTopProducts.Columns["Revenue"].Width = 180;
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
