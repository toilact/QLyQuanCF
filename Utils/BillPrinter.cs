using System.Drawing;
using System.Drawing.Printing;
using CoffeeShopManagement.Models;

namespace CoffeeShopManagement.Utils;

public class BillPrinter
{
    private readonly Bill _bill;
    private readonly string _storeName;
    private readonly string _storeAddress;
    private readonly string _storePhone;
    private readonly string _wifiInfo;
    private readonly string _greeting;

    public BillPrinter(
        Bill bill,
        string storeName = "CÀ PHÊ HƯƠNG VIỆT",
        string storeAddress = "123 Đường Số 1, Quận 1, TP.HCM",
        string storePhone = "0901 234 567",
        string wifiInfo = "Wifi: HuongViet_Coffee | Pass: 88888888",
        string greeting = "Cảm ơn quý khách và hẹn gặp lại!")
    {
        _bill = bill;
        _storeName = storeName;
        _storeAddress = storeAddress;
        _storePhone = storePhone;
        _wifiInfo = wifiInfo;
        _greeting = greeting;
    }

    public void Print(bool showPreview = true)
    {
        using var printDoc = new PrintDocument();
        // Kích thước chuẩn giấy in nhiệt K80 (rộng ~80mm = ~315 hundredths of an inch)
        printDoc.DefaultPageSettings.PaperSize = new PaperSize("K80", 315, 800);
        printDoc.PrintPage += PrintPageHandler;

        if (showPreview)
        {
            using var previewDialog = new PrintPreviewDialog();
            previewDialog.Document = printDoc;
            previewDialog.Width = 500;
            previewDialog.Height = 700;
            previewDialog.StartPosition = FormStartPosition.CenterScreen;
            previewDialog.ShowDialog();
        }
        else
        {
            printDoc.Print();
        }
    }

    private void PrintPageHandler(object sender, PrintPageEventArgs e)
    {
        var g = e.Graphics;
        if (g == null) return;

        using var fontTitle = new Font("Segoe UI", 13, FontStyle.Bold);
        using var fontSub = new Font("Segoe UI", 8.5f, FontStyle.Regular);
        using var fontBold = new Font("Segoe UI", 9, FontStyle.Bold);
        using var fontRegular = new Font("Segoe UI", 9, FontStyle.Regular);
        using var fontSmall = new Font("Segoe UI", 8, FontStyle.Italic);

        using var brush = new SolidBrush(Color.Black);
        using var penDashed = new Pen(Color.Gray, 1) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash };

        float startX = 15;
        float startY = 15;
        float width = 285; // Bề rộng nội dung in
        float y = startY;

        var centerFormat = new StringFormat { Alignment = StringAlignment.Center };
        var rightFormat = new StringFormat { Alignment = StringAlignment.Far };
        var leftFormat = new StringFormat { Alignment = StringAlignment.Near };

        // 1. Header Quán
        g.DrawString(_storeName.ToUpper(), fontTitle, brush, new RectangleF(startX, y, width, 25), centerFormat);
        y += 25;
        g.DrawString(_storeAddress, fontSub, brush, new RectangleF(startX, y, width, 18), centerFormat);
        y += 18;
        g.DrawString($"Hotline: {_storePhone}", fontSub, brush, new RectangleF(startX, y, width, 18), centerFormat);
        y += 22;

        g.DrawLine(penDashed, startX, y, startX + width, y);
        y += 8;

        // 2. Tiêu đề Hóa đơn
        g.DrawString("HÓA ĐƠN THANH TOÁN", fontBold, brush, new RectangleF(startX, y, width, 20), centerFormat);
        y += 22;

        // 3. Thông tin chung
        g.DrawString($"Số HĐ: #{_bill.Id:D5}", fontSub, brush, startX, y);
        g.DrawString($"Bàn: {_bill.Table?.Name ?? "Mang về"}", fontBold, brush, new RectangleF(startX, y, width, 18), rightFormat);
        y += 18;

        g.DrawString($"Ngày vào: {_bill.CheckInDate:dd/MM/yyyy HH:mm}", fontSub, brush, startX, y);
        y += 18;

        if (_bill.CheckOutDate.HasValue)
        {
            g.DrawString($"Ngày ra:  {_bill.CheckOutDate.Value:dd/MM/yyyy HH:mm}", fontSub, brush, startX, y);
            y += 18;
        }

        g.DrawString($"Thu ngân: {_bill.User?.FullName ?? "Staff"}", fontSub, brush, startX, y);
        y += 22;

        g.DrawLine(penDashed, startX, y, startX + width, y);
        y += 6;

        // 4. Tiêu đề cột
        // Món (130px) | SL (30px) | Đ.Giá (60px) | T.Tiền (65px)
        g.DrawString("Món", fontBold, brush, startX, y);
        g.DrawString("SL", fontBold, brush, startX + 130, y);
        g.DrawString("Đ.Giá", fontBold, brush, new RectangleF(startX + 155, y, 60, 18), rightFormat);
        g.DrawString("T.Tiền", fontBold, brush, new RectangleF(startX + 215, y, 70, 18), rightFormat);
        y += 20;

        g.DrawLine(penDashed, startX, y, startX + width, y);
        y += 6;

        // 5. Danh sách món
        decimal subTotal = 0;
        foreach (var d in _bill.Details)
        {
            string prodName = d.Product?.Name ?? "Món";
            decimal lineTotal = d.Quantity * d.UnitPrice;
            subTotal += lineTotal;

            g.DrawString(prodName, fontRegular, brush, new RectangleF(startX, y, 125, 34), leftFormat);
            g.DrawString(d.Quantity.ToString(), fontRegular, brush, startX + 133, y);
            g.DrawString($"{d.UnitPrice:N0}", fontRegular, brush, new RectangleF(startX + 155, y, 60, 18), rightFormat);
            g.DrawString($"{lineTotal:N0}", fontRegular, brush, new RectangleF(startX + 215, y, 70, 18), rightFormat);
            y += 22;
        }

        y += 4;
        g.DrawLine(penDashed, startX, y, startX + width, y);
        y += 8;

        // 6. Tổng kết
        g.DrawString("Tổng tiền món:", fontRegular, brush, startX, y);
        g.DrawString($"{subTotal:N0} đ", fontRegular, brush, new RectangleF(startX, y, width, 18), rightFormat);
        y += 20;

        if (_bill.DiscountPercent > 0)
        {
            decimal discountVal = subTotal * _bill.DiscountPercent / 100m;
            g.DrawString($"Chiết khấu ({_bill.DiscountPercent}%):", fontRegular, brush, startX, y);
            g.DrawString($"-{discountVal:N0} đ", fontRegular, brush, new RectangleF(startX, y, width, 18), rightFormat);
            y += 20;
        }

        g.DrawString("THANH TOÁN:", fontBold, brush, startX, y);
        g.DrawString($"{_bill.TotalAmount:N0} đ", fontBold, brush, new RectangleF(startX, y, width, 22), rightFormat);
        y += 26;

        g.DrawLine(penDashed, startX, y, startX + width, y);
        y += 10;

        // 7. Footer
        g.DrawString(_wifiInfo, fontSub, brush, new RectangleF(startX, y, width, 18), centerFormat);
        y += 18;
        g.DrawString(_greeting, fontSmall, brush, new RectangleF(startX, y, width, 18), centerFormat);
    }
}

