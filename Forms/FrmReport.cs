using System.Windows.Forms;
using CoffeeShopManagement.Components;
using CoffeeShopManagement.Models;
using CoffeeShopManagement.Services.Interfaces;
using CoffeeShopManagement.Utils;

namespace CoffeeShopManagement.Forms;

public partial class FrmReport : Form
{
    private readonly IReportService? _reportService;

    private List<Bill> _currentBills = new();
    private List<(string ProductName, int QuantitySold, decimal Revenue)> _currentTopProducts = new();

    public FrmReport()
    {
        InitializeComponent();
    }

    public FrmReport(IReportService reportService) : this()
    {
        _reportService = reportService;

        UITheme.ApplyModernGridStyle(dgvHoaDon);
        UITheme.ApplyModernGridStyle(dgvTopSanPham);
        SetupReportGrids();

        dtpTuNgay.Value = DateTime.Today.AddDays(-30);
        dtpDenNgay.Value = DateTime.Today;

        btnThongKe.Click += async (_, _) => await LoadReportDataAsync();
        btnHomNay.Click += async (_, _) =>
        {
            dtpTuNgay.Value = DateTime.Today;
            dtpDenNgay.Value = DateTime.Today;
            await LoadReportDataAsync();
        };
        btnThangNay.Click += async (_, _) =>
        {
            dtpTuNgay.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpDenNgay.Value = DateTime.Today;
            await LoadReportDataAsync();
        };
        btnXuatExcel.Click += BtnExportExcel_Click;

        Load += async (_, _) => await LoadReportDataAsync();
    }

    private void SetupReportGrids()
    {
        // Setup dgvHoaDon
        dgvHoaDon.Columns.Clear();
        dgvHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        var colId = new DataGridViewTextBoxColumn
        {
            Name = "Id",
            HeaderText = "Mã HĐ",
            FillWeight = 11,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
        };
        dgvHoaDon.Columns.Add(colId);
        dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn { Name = "Table", HeaderText = "Bàn", FillWeight = 15 });
        dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn { Name = "User", HeaderText = "Thu Ngân", FillWeight = 18 });

        var colIn = new DataGridViewTextBoxColumn
        {
            Name = "CheckIn",
            HeaderText = "Giờ Vào",
            FillWeight = 18,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
        };
        dgvHoaDon.Columns.Add(colIn);

        var colOut = new DataGridViewTextBoxColumn
        {
            Name = "CheckOut",
            HeaderText = "Giờ Thanh Toán",
            FillWeight = 18,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
        };
        dgvHoaDon.Columns.Add(colOut);

        var colDiscount = new DataGridViewTextBoxColumn
        {
            Name = "Discount",
            HeaderText = "Giảm (%)",
            FillWeight = 10,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
        };
        dgvHoaDon.Columns.Add(colDiscount);

        var colTotal = new DataGridViewTextBoxColumn
        {
            Name = "Total",
            HeaderText = "Thành Tiền",
            FillWeight = 20,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight, Font = UITheme.FontBold }
        };
        dgvHoaDon.Columns.Add(colTotal);

        // Setup dgvTopSanPham
        dgvTopSanPham.Columns.Clear();
        dgvTopSanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        var colRank = new DataGridViewTextBoxColumn
        {
            Name = "Rank",
            HeaderText = "Xếp Hạng",
            FillWeight = 12,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter, Font = UITheme.FontBold }
        };
        dgvTopSanPham.Columns.Add(colRank);
        dgvTopSanPham.Columns.Add(new DataGridViewTextBoxColumn { Name = "Name", HeaderText = "Tên Sản Phẩm", FillWeight = 48 });

        var colQty = new DataGridViewTextBoxColumn
        {
            Name = "Qty",
            HeaderText = "Số Lượng Bán",
            FillWeight = 20,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
        };
        dgvTopSanPham.Columns.Add(colQty);

        var colRev = new DataGridViewTextBoxColumn
        {
            Name = "Revenue",
            HeaderText = "Doanh Thu Món",
            FillWeight = 20,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight, Font = UITheme.FontBold }
        };
        dgvTopSanPham.Columns.Add(colRev);
    }

    private async Task LoadReportDataAsync()
    {
        if (_reportService == null) return;

        var from = dtpTuNgay.Value;
        var to = dtpDenNgay.Value;

        var (totalRevenue, totalBills, average) = await _reportService.GetSummaryAsync(from, to);
        lblTongDoanhThu.Text = $"{totalRevenue:N0} đ";
        lblTongHoaDon.Text = $"{totalBills:N0} đơn";
        lblGiaTriTrungBinh.Text = $"{average:N0} đ";

        _currentBills = await _reportService.GetRevenueBillsAsync(from, to);
        dgvHoaDon.Rows.Clear();
        foreach (var b in _currentBills)
        {
            dgvHoaDon.Rows.Add(
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
        dgvTopSanPham.Rows.Clear();
        int rank = 1;
        foreach (var p in _currentTopProducts)
        {
            dgvTopSanPham.Rows.Add(rank++, p.ProductName, $"{p.QuantitySold:N0}", $"{p.Revenue:N0} đ");
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
            FileName = $"BaoCaoDoanhThu_{dtpTuNgay.Value:yyyyMMdd}_{dtpDenNgay.Value:yyyyMMdd}.xlsx",
            Title = "Lưu Báo Cáo Doanh Thu"
        };

        if (sfd.ShowDialog() == DialogResult.OK)
        {
            try
            {
                ExcelExporter.ExportRevenueReport(sfd.FileName, dtpTuNgay.Value, dtpDenNgay.Value, _currentBills, _currentTopProducts);
                MessageBox.Show($"Đã xuất file báo cáo Excel thành công tại:\n{sfd.FileName}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xuất Excel: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
