using System.Drawing;
using System.Windows.Forms;
using CoffeeShopManagement.Components;
using CoffeeShopManagement.Models;
using CoffeeShopManagement.Services.Interfaces;
using CoffeeShopManagement.Utils;

namespace CoffeeShopManagement.Forms;

public class FrmPayment : Form
{
    private readonly IBillService _billService;
    private readonly Bill _bill;

    private NumericUpDown _nudDiscount = null!;
    private Label _lblSubTotal = null!;
    private Label _lblDiscountVal = null!;
    private Label _lblFinalTotal = null!;
    private CheckBox _chkPrint = null!;
    private CheckBox _chkPreview = null!;
    private RjButton _btnPay = null!;

    public FrmPayment(IBillService billService, Bill bill)
    {
        _billService = billService;
        _bill = bill;

        InitializeComponent();
        CalculateTotals();
    }

    private void InitializeComponent()
    {
        Text = $"Thanh Toán - {_bill.Table?.Name ?? "Hóa đơn"}";
        Size = new Size(480, 460);
        StartPosition = FormStartPosition.CenterParent;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        BackColor = UITheme.CanvasBg;

        var pnlCard = new Panel
        {
            Location = new Point(20, 20),
            Size = new Size(425, 375),
            BackColor = UITheme.Surface,
            BorderStyle = BorderStyle.FixedSingle,
            Padding = new Padding(20)
        };
        Controls.Add(pnlCard);

        var lblTitle = new Label
        {
            Text = "XÁC NHẬN THANH TOÁN",
            Font = UITheme.FontDisplay,
            ForeColor = UITheme.Primary,
            Location = new Point(20, 15),
            Size = new Size(385, 30),
            TextAlign = ContentAlignment.MiddleCenter
        };
        pnlCard.Controls.Add(lblTitle);

        var lblSub = new Label
        {
            Text = $"Bàn: {_bill.Table?.Name}  |  Thu ngân: {_bill.User?.FullName ?? "Staff"}",
            Font = UITheme.FontRegular,
            ForeColor = UITheme.TextMuted,
            Location = new Point(20, 48),
            Size = new Size(385, 20),
            TextAlign = ContentAlignment.MiddleCenter
        };
        pnlCard.Controls.Add(lblSub);

        // Divider
        var pnlDiv = new Panel
        {
            Location = new Point(20, 75),
            Size = new Size(385, 1),
            BackColor = UITheme.Border
        };
        pnlCard.Controls.Add(pnlDiv);

        // 1. Tạm tính
        var lbl1 = new Label { Text = "Tổng tiền món:", Font = UITheme.FontRegular, Location = new Point(20, 95), AutoSize = true };
        pnlCard.Controls.Add(lbl1);

        _lblSubTotal = new Label
        {
            Text = "0 đ",
            Font = UITheme.FontBold,
            Location = new Point(220, 95),
            Size = new Size(185, 20),
            TextAlign = ContentAlignment.MiddleRight
        };
        pnlCard.Controls.Add(_lblSubTotal);

        // 2. Giảm giá
        var lbl2 = new Label { Text = "Giảm giá (%):", Font = UITheme.FontRegular, Location = new Point(20, 135), AutoSize = true };
        pnlCard.Controls.Add(lbl2);

        _nudDiscount = new NumericUpDown
        {
            Location = new Point(130, 132),
            Size = new Size(70, 28),
            Font = UITheme.FontBold,
            Minimum = 0,
            Maximum = 100,
            Value = _bill.DiscountPercent
        };
        _nudDiscount.ValueChanged += (_, _) => CalculateTotals();
        pnlCard.Controls.Add(_nudDiscount);

        _lblDiscountVal = new Label
        {
            Text = "-0 đ",
            Font = UITheme.FontRegular,
            ForeColor = UITheme.Danger,
            Location = new Point(220, 135),
            Size = new Size(185, 20),
            TextAlign = ContentAlignment.MiddleRight
        };
        pnlCard.Controls.Add(_lblDiscountVal);

        // Divider 2
        var pnlDiv2 = new Panel
        {
            Location = new Point(20, 175),
            Size = new Size(385, 1),
            BackColor = UITheme.Border
        };
        pnlCard.Controls.Add(pnlDiv2);

        // 3. Khách cần trả
        var lbl3 = new Label { Text = "THANH TOÁN:", Font = UITheme.FontHeader, ForeColor = UITheme.Primary, Location = new Point(20, 195), AutoSize = true };
        pnlCard.Controls.Add(lbl3);

        _lblFinalTotal = new Label
        {
            Text = "0 đ",
            Font = new Font("Segoe UI", 16f, FontStyle.Bold),
            ForeColor = UITheme.Danger,
            Location = new Point(170, 188),
            Size = new Size(235, 35),
            TextAlign = ContentAlignment.MiddleRight
        };
        pnlCard.Controls.Add(_lblFinalTotal);

        // In hóa đơn options
        _chkPrint = new CheckBox
        {
            Text = "In hóa đơn thanh toán",
            Font = UITheme.FontRegular,
            Location = new Point(25, 245),
            Size = new Size(200, 24),
            Checked = true
        };
        pnlCard.Controls.Add(_chkPrint);

        _chkPreview = new CheckBox
        {
            Text = "Xem trước bản in (Preview)",
            Font = UITheme.FontRegular,
            Location = new Point(230, 245),
            Size = new Size(180, 24),
            Checked = true
        };
        pnlCard.Controls.Add(_chkPreview);

        // Action Buttons
        _btnPay = new RjButton
        {
            Text = "HOÀN TẤT THANH TOÁN",
            Location = new Point(195, 300),
            Size = new Size(210, 44),
            BackColor = UITheme.Primary,
            HoverBackColor = UITheme.PrimaryHover,
            Font = UITheme.FontBold,
            BorderRadius = 6
        };
        _btnPay.Click += BtnPay_Click;
        pnlCard.Controls.Add(_btnPay);

        var btnCancel = new RjButton
        {
            Text = "QUAY LẠI",
            Location = new Point(65, 300),
            Size = new Size(120, 44),
            BackColor = Color.White,
            HoverBackColor = ColorTranslator.FromHtml("#F0EBE5"),
            ForeColor = UITheme.TextDark,
            BorderColor = UITheme.Border,
            BorderSize = 1,
            BorderRadius = 6
        };
        btnCancel.Click += (_, _) => { DialogResult = DialogResult.Cancel; Close(); };
        pnlCard.Controls.Add(btnCancel);
    }

    private void CalculateTotals()
    {
        decimal subTotal = _bill.Details.Sum(d => d.Quantity * d.UnitPrice);
        int discountPercent = (int)_nudDiscount.Value;
        decimal discountVal = subTotal * discountPercent / 100m;
        decimal finalTotal = subTotal - discountVal;

        _lblSubTotal.Text = $"{subTotal:N0} đ";
        _lblDiscountVal.Text = $"-{discountVal:N0} đ";
        _lblFinalTotal.Text = $"{finalTotal:N0} đ";
    }

    private async void BtnPay_Click(object? sender, EventArgs e)
    {
        _btnPay.Enabled = false;
        _btnPay.Text = "Đang xử lý...";

        try
        {
            int discount = (int)_nudDiscount.Value;
            var paidBill = await _billService.PayBillAsync(_bill.Id, discount);

            if (_chkPrint.Checked)
            {
                var printer = new BillPrinter(paidBill);
                printer.Print(showPreview: _chkPreview.Checked);
            }

            DialogResult = DialogResult.OK;
            Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi thanh toán: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            _btnPay.Enabled = true;
            _btnPay.Text = "HOÀN TẤT THANH TOÁN";
        }
    }
}

