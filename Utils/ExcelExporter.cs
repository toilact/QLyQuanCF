using ClosedXML.Excel;
using CoffeeShopManagement.Models;

namespace CoffeeShopManagement.Utils;

public static class ExcelExporter
{
    public static void ExportRevenueReport(
        string filePath,
        DateTime fromDate,
        DateTime toDate,
        List<Bill> bills,
        List<(string ProductName, int QuantitySold, decimal Revenue)> topProducts)
    {
        using var workbook = new XLWorkbook();

        // Sheet 1: Danh sách Hóa đơn
        var wsBills = workbook.Worksheets.Add("Doanh Thu Hóa Đơn");

        // Tiêu đề báo cáo
        wsBills.Cell(1, 1).Value = "BÁO CÁO DOANH THU QUÁN CÀ PHÊ";
        wsBills.Cell(1, 1).Style.Font.Bold = true;
        wsBills.Cell(1, 1).Style.Font.FontSize = 16;
        wsBills.Cell(1, 1).Style.Font.FontColor = XLColor.FromHtml("#3D2817");
        wsBills.Range(1, 1, 1, 7).Merge();

        wsBills.Cell(2, 1).Value = $"Từ ngày: {fromDate:dd/MM/yyyy}  -  Đến ngày: {toDate:dd/MM/yyyy}";
        wsBills.Cell(2, 1).Style.Font.Italic = true;
        wsBills.Cell(2, 1).Style.Font.FontSize = 11;
        wsBills.Range(2, 1, 2, 7).Merge();

        // Header Table
        string[] headers = { "Mã HĐ", "Bàn", "Thu ngân", "Giờ vào", "Giờ thanh toán", "Giảm giá (%)", "Thành tiền (VNĐ)" };
        for (int i = 0; i < headers.Length; i++)
        {
            var cell = wsBills.Cell(4, i + 1);
            cell.Value = headers[i];
            cell.Style.Font.Bold = true;
            cell.Style.Font.FontColor = XLColor.White;
            cell.Style.Fill.BackgroundColor = XLColor.FromHtml("#3D2817");
            cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
        }

        int row = 5;
        decimal grandTotal = 0;
        foreach (var b in bills)
        {
            wsBills.Cell(row, 1).Value = $"#{b.Id:D5}";
            wsBills.Cell(row, 2).Value = b.Table?.Name ?? "Mang về";
            wsBills.Cell(row, 3).Value = b.User?.FullName ?? "Staff";
            wsBills.Cell(row, 4).Value = b.CheckInDate.ToString("dd/MM/yyyy HH:mm");
            wsBills.Cell(row, 5).Value = b.CheckOutDate?.ToString("dd/MM/yyyy HH:mm") ?? "-";
            wsBills.Cell(row, 6).Value = b.DiscountPercent;
            wsBills.Cell(row, 6).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            wsBills.Cell(row, 7).Value = b.TotalAmount;
            wsBills.Cell(row, 7).Style.NumberFormat.Format = "#,##0";

            grandTotal += b.TotalAmount;
            row++;
        }

        // Summary row
        var sumLabel = wsBills.Cell(row, 1);
        sumLabel.Value = "TỔNG CỘNG:";
        sumLabel.Style.Font.Bold = true;
        wsBills.Range(row, 1, row, 6).Merge();
        sumLabel.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;

        var sumVal = wsBills.Cell(row, 7);
        sumVal.Value = grandTotal;
        sumVal.Style.Font.Bold = true;
        sumVal.Style.Font.FontColor = XLColor.FromHtml("#C85A32");
        sumVal.Style.NumberFormat.Format = "#,##0";

        // Style border
        var tableRange = wsBills.Range(4, 1, row, 7);
        tableRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        tableRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
        wsBills.Columns().AdjustToContents();

        // Sheet 2: Top món bán chạy
        if (topProducts.Any())
        {
            var wsTop = workbook.Worksheets.Add("Top Món Bán Chạy");
            wsTop.Cell(1, 1).Value = "TOP SẢN PHẨM BÁN CHẠY NHẤT";
            wsTop.Cell(1, 1).Style.Font.Bold = true;
            wsTop.Cell(1, 1).Style.Font.FontSize = 14;
            wsTop.Cell(1, 1).Style.Font.FontColor = XLColor.FromHtml("#3D2817");
            wsTop.Range(1, 1, 1, 4).Merge();

            string[] topHeaders = { "Xếp hạng", "Tên món", "Số lượng bán", "Doanh thu (VNĐ)" };
            for (int i = 0; i < topHeaders.Length; i++)
            {
                var cell = wsTop.Cell(3, i + 1);
                cell.Value = topHeaders[i];
                cell.Style.Font.Bold = true;
                cell.Style.Font.FontColor = XLColor.White;
                cell.Style.Fill.BackgroundColor = XLColor.FromHtml("#C68B59");
                cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            }

            int topRow = 4;
            int rank = 1;
            foreach (var item in topProducts)
            {
                wsTop.Cell(topRow, 1).Value = rank++;
                wsTop.Cell(topRow, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                wsTop.Cell(topRow, 2).Value = item.ProductName;
                wsTop.Cell(topRow, 3).Value = item.QuantitySold;
                wsTop.Cell(topRow, 3).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                wsTop.Cell(topRow, 4).Value = item.Revenue;
                wsTop.Cell(topRow, 4).Style.NumberFormat.Format = "#,##0";
                topRow++;
            }

            var topRange = wsTop.Range(3, 1, topRow - 1, 4);
            topRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            topRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
            wsTop.Columns().AdjustToContents();
        }

        workbook.SaveAs(filePath);
    }
}

