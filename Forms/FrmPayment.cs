using System.Windows.Forms;
using CoffeeShopManagement.Models;
using CoffeeShopManagement.Services.Interfaces;
using CoffeeShopManagement.Utils;

namespace CoffeeShopManagement.Forms;

public partial class FrmPayment : Form
{
    private readonly IBillService? _billService;
    private readonly Bill? _bill;

    public FrmPayment()
    {
        InitializeComponent();
    }

    public FrmPayment(IBillService billService, Bill bill) : this()
    {
        _billService = billService;
        _bill = bill;

        Text = $"Thanh Toán - {_bill.Table?.Name ?? "Hóa đơn"}";
        lblThongTinBanThuNgan.Text = $"Bàn: {_bill.Table?.Name ?? "Mang về"}  |  Thu ngân: {_bill.User?.FullName ?? "Staff"}";

        nudGiamGia.Minimum = 0;
        nudGiamGia.Maximum = 100;
        nudGiamGia.Value = _bill.DiscountPercent;
        nudGiamGia.ValueChanged += (_, _) => CalculateTotals();

        btnXacNhanThanhToan.Click += BtnPay_Click;
        btnQuayLai.Click += (_, _) =>
        {
            DialogResult = DialogResult.Cancel;
            Close();
        };

        CalculateTotals();
    }

    private void CalculateTotals()
    {
        if (_bill == null) return;

        decimal subTotal = _bill.Details.Sum(d => d.Quantity * d.UnitPrice);
        int discountPercent = (int)nudGiamGia.Value;
        decimal discountVal = subTotal * discountPercent / 100m;
        decimal finalTotal = subTotal - discountVal;

        lblTongTienMon.Text = $"{subTotal:N0} đ";
        lblTienGiam.Text = $"-{discountVal:N0} đ";
        lblTongThanhToan.Text = $"{finalTotal:N0} đ";
    }

    private async void BtnPay_Click(object? sender, EventArgs e)
    {
        if (_billService == null || _bill == null) return;

        btnXacNhanThanhToan.Enabled = false;
        btnXacNhanThanhToan.Text = "Đang xử lý...";

        try
        {
            int discount = (int)nudGiamGia.Value;
            var paidBill = await _billService.PayBillAsync(_bill.Id, discount);

            if (chkInHoaDon.Checked)
            {
                var printer = new BillPrinter(paidBill);
                printer.Print(showPreview: chkXemTruocIn.Checked);
            }

            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi thanh toán: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            btnXacNhanThanhToan.Enabled = true;
            btnXacNhanThanhToan.Text = "HOÀN TẤT THANH TOÁN";
        }
    }
}
