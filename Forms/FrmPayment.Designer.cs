namespace CoffeeShopManagement.Forms;

partial class FrmPayment
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        this.pnlCard = new System.Windows.Forms.Panel();
        this.lblTieuDe = new System.Windows.Forms.Label();
        this.lblThongTinBanThuNgan = new System.Windows.Forms.Label();
        this.pnlPhanCach1 = new System.Windows.Forms.Panel();
        this.lblTieuDeTienMon = new System.Windows.Forms.Label();
        this.lblTongTienMon = new System.Windows.Forms.Label();
        this.lblTieuDeGiamGia = new System.Windows.Forms.Label();
        this.nudGiamGia = new System.Windows.Forms.NumericUpDown();
        this.lblTienGiam = new System.Windows.Forms.Label();
        this.pnlPhanCach2 = new System.Windows.Forms.Panel();
        this.lblTieuDeCanThanhToan = new System.Windows.Forms.Label();
        this.lblTongThanhToan = new System.Windows.Forms.Label();
        this.chkInHoaDon = new System.Windows.Forms.CheckBox();
        this.chkXemTruocIn = new System.Windows.Forms.CheckBox();
        this.btnXacNhanThanhToan = new CoffeeShopManagement.Components.RjButton();
        this.btnQuayLai = new CoffeeShopManagement.Components.RjButton();
        this.pnlCard.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.nudGiamGia)).BeginInit();
        this.SuspendLayout();
        // 
        // pnlCard
        // 
        this.pnlCard.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.pnlCard.BackColor = System.Drawing.Color.White;
        this.pnlCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.pnlCard.Controls.Add(this.btnQuayLai);
        this.pnlCard.Controls.Add(this.btnXacNhanThanhToan);
        this.pnlCard.Controls.Add(this.chkXemTruocIn);
        this.pnlCard.Controls.Add(this.chkInHoaDon);
        this.pnlCard.Controls.Add(this.lblTongThanhToan);
        this.pnlCard.Controls.Add(this.lblTieuDeCanThanhToan);
        this.pnlCard.Controls.Add(this.pnlPhanCach2);
        this.pnlCard.Controls.Add(this.lblTienGiam);
        this.pnlCard.Controls.Add(this.nudGiamGia);
        this.pnlCard.Controls.Add(this.lblTieuDeGiamGia);
        this.pnlCard.Controls.Add(this.lblTongTienMon);
        this.pnlCard.Controls.Add(this.lblTieuDeTienMon);
        this.pnlCard.Controls.Add(this.pnlPhanCach1);
        this.pnlCard.Controls.Add(this.lblThongTinBanThuNgan);
        this.pnlCard.Controls.Add(this.lblTieuDe);
        this.pnlCard.Location = new System.Drawing.Point(24, 20);
        this.pnlCard.Name = "pnlCard";
        this.pnlCard.Padding = new System.Windows.Forms.Padding(24);
        this.pnlCard.Size = new System.Drawing.Size(455, 415);
        this.pnlCard.TabIndex = 0;
        // 
        // lblTieuDe
        // 
        this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold);
        this.lblTieuDe.ForeColor = System.Drawing.Color.FromArgb(61, 40, 23);
        this.lblTieuDe.Location = new System.Drawing.Point(20, 15);
        this.lblTieuDe.Name = "lblTieuDe";
        this.lblTieuDe.Size = new System.Drawing.Size(415, 30);
        this.lblTieuDe.TabIndex = 0;
        this.lblTieuDe.Text = "XÁC NHẬN THANH TOÁN";
        this.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lblThongTinBanThuNgan
        // 
        this.lblThongTinBanThuNgan.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.lblThongTinBanThuNgan.ForeColor = System.Drawing.Color.FromArgb(125, 117, 109);
        this.lblThongTinBanThuNgan.Location = new System.Drawing.Point(20, 48);
        this.lblThongTinBanThuNgan.Name = "lblThongTinBanThuNgan";
        this.lblThongTinBanThuNgan.Size = new System.Drawing.Size(415, 20);
        this.lblThongTinBanThuNgan.TabIndex = 1;
        this.lblThongTinBanThuNgan.Text = "Bàn: --  |  Thu ngân: --";
        this.lblThongTinBanThuNgan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // pnlPhanCach1
        // 
        this.pnlPhanCach1.BackColor = System.Drawing.Color.FromArgb(232, 226, 217);
        this.pnlPhanCach1.Location = new System.Drawing.Point(20, 75);
        this.pnlPhanCach1.Name = "pnlPhanCach1";
        this.pnlPhanCach1.Size = new System.Drawing.Size(415, 1);
        this.pnlPhanCach1.TabIndex = 2;
        // 
        // lblTieuDeTienMon
        // 
        this.lblTieuDeTienMon.AutoSize = true;
        this.lblTieuDeTienMon.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.lblTieuDeTienMon.ForeColor = System.Drawing.Color.FromArgb(43, 37, 32);
        this.lblTieuDeTienMon.Location = new System.Drawing.Point(20, 95);
        this.lblTieuDeTienMon.Name = "lblTieuDeTienMon";
        this.lblTieuDeTienMon.Size = new System.Drawing.Size(96, 17);
        this.lblTieuDeTienMon.TabIndex = 3;
        this.lblTieuDeTienMon.Text = "Tổng tiền món:";
        // 
        // lblTongTienMon
        // 
        this.lblTongTienMon.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblTongTienMon.ForeColor = System.Drawing.Color.FromArgb(43, 37, 32);
        this.lblTongTienMon.Location = new System.Drawing.Point(220, 95);
        this.lblTongTienMon.Name = "lblTongTienMon";
        this.lblTongTienMon.Size = new System.Drawing.Size(215, 20);
        this.lblTongTienMon.TabIndex = 4;
        this.lblTongTienMon.Text = "0 đ";
        this.lblTongTienMon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // lblTieuDeGiamGia
        // 
        this.lblTieuDeGiamGia.AutoSize = true;
        this.lblTieuDeGiamGia.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.lblTieuDeGiamGia.ForeColor = System.Drawing.Color.FromArgb(43, 37, 32);
        this.lblTieuDeGiamGia.Location = new System.Drawing.Point(20, 135);
        this.lblTieuDeGiamGia.Name = "lblTieuDeGiamGia";
        this.lblTieuDeGiamGia.Size = new System.Drawing.Size(84, 17);
        this.lblTieuDeGiamGia.TabIndex = 5;
        this.lblTieuDeGiamGia.Text = "Giảm giá (%):";
        // 
        // nudGiamGia
        // 
        this.nudGiamGia.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.nudGiamGia.Location = new System.Drawing.Point(130, 132);
        this.nudGiamGia.Name = "nudGiamGia";
        this.nudGiamGia.Size = new System.Drawing.Size(70, 24);
        this.nudGiamGia.TabIndex = 6;
        // 
        // lblTienGiam
        // 
        this.lblTienGiam.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.lblTienGiam.ForeColor = System.Drawing.Color.FromArgb(200, 90, 50);
        this.lblTienGiam.Location = new System.Drawing.Point(220, 135);
        this.lblTienGiam.Name = "lblTienGiam";
        this.lblTienGiam.Size = new System.Drawing.Size(215, 20);
        this.lblTienGiam.TabIndex = 7;
        this.lblTienGiam.Text = "-0 đ";
        this.lblTienGiam.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // pnlPhanCach2
        // 
        this.pnlPhanCach2.BackColor = System.Drawing.Color.FromArgb(232, 226, 217);
        this.pnlPhanCach2.Location = new System.Drawing.Point(20, 175);
        this.pnlPhanCach2.Name = "pnlPhanCach2";
        this.pnlPhanCach2.Size = new System.Drawing.Size(415, 1);
        this.pnlPhanCach2.TabIndex = 8;
        // 
        // lblTieuDeCanThanhToan
        // 
        this.lblTieuDeCanThanhToan.AutoSize = true;
        this.lblTieuDeCanThanhToan.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold);
        this.lblTieuDeCanThanhToan.ForeColor = System.Drawing.Color.FromArgb(61, 40, 23);
        this.lblTieuDeCanThanhToan.Location = new System.Drawing.Point(20, 195);
        this.lblTieuDeCanThanhToan.Name = "lblTieuDeCanThanhToan";
        this.lblTieuDeCanThanhToan.Size = new System.Drawing.Size(120, 21);
        this.lblTieuDeCanThanhToan.TabIndex = 9;
        this.lblTieuDeCanThanhToan.Text = "THANH TOÁN:";
        // 
        // lblTongThanhToan
        // 
        this.lblTongThanhToan.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
        this.lblTongThanhToan.ForeColor = System.Drawing.Color.FromArgb(200, 90, 50);
        this.lblTongThanhToan.Location = new System.Drawing.Point(170, 186);
        this.lblTongThanhToan.Name = "lblTongThanhToan";
        this.lblTongThanhToan.Size = new System.Drawing.Size(265, 35);
        this.lblTongThanhToan.TabIndex = 10;
        this.lblTongThanhToan.Text = "0 đ";
        this.lblTongThanhToan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // chkInHoaDon
        // 
        this.chkInHoaDon.Checked = true;
        this.chkInHoaDon.CheckState = System.Windows.Forms.CheckState.Checked;
        this.chkInHoaDon.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.chkInHoaDon.ForeColor = System.Drawing.Color.FromArgb(43, 37, 32);
        this.chkInHoaDon.Location = new System.Drawing.Point(25, 250);
        this.chkInHoaDon.Name = "chkInHoaDon";
        this.chkInHoaDon.Size = new System.Drawing.Size(200, 24);
        this.chkInHoaDon.TabIndex = 11;
        this.chkInHoaDon.Text = "In hóa đơn thanh toán";
        this.chkInHoaDon.UseVisualStyleBackColor = true;
        // 
        // chkXemTruocIn
        // 
        this.chkXemTruocIn.Checked = true;
        this.chkXemTruocIn.CheckState = System.Windows.Forms.CheckState.Checked;
        this.chkXemTruocIn.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.chkXemTruocIn.ForeColor = System.Drawing.Color.FromArgb(43, 37, 32);
        this.chkXemTruocIn.Location = new System.Drawing.Point(235, 250);
        this.chkXemTruocIn.Name = "chkXemTruocIn";
        this.chkXemTruocIn.Size = new System.Drawing.Size(200, 24);
        this.chkXemTruocIn.TabIndex = 12;
        this.chkXemTruocIn.Text = "Xem trước bản in (Preview)";
        this.chkXemTruocIn.UseVisualStyleBackColor = true;
        // 
        // btnXacNhanThanhToan
        // 
        this.btnXacNhanThanhToan.BackColor = System.Drawing.Color.FromArgb(61, 40, 23);
        this.btnXacNhanThanhToan.BorderColor = System.Drawing.Color.FromArgb(232, 226, 217);
        this.btnXacNhanThanhToan.BorderRadius = 6;
        this.btnXacNhanThanhToan.BorderSize = 0;
        this.btnXacNhanThanhToan.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnXacNhanThanhToan.FlatAppearance.BorderSize = 0;
        this.btnXacNhanThanhToan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnXacNhanThanhToan.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.btnXacNhanThanhToan.ForeColor = System.Drawing.Color.White;
        this.btnXacNhanThanhToan.HoverBackColor = System.Drawing.Color.FromArgb(83, 56, 33);
        this.btnXacNhanThanhToan.Location = new System.Drawing.Point(205, 320);
        this.btnXacNhanThanhToan.Name = "btnXacNhanThanhToan";
        this.btnXacNhanThanhToan.Size = new System.Drawing.Size(230, 46);
        this.btnXacNhanThanhToan.TabIndex = 13;
        this.btnXacNhanThanhToan.Text = "HOÀN TẤT THANH TOÁN";
        this.btnXacNhanThanhToan.UseVisualStyleBackColor = false;
        // 
        // btnQuayLai
        // 
        this.btnQuayLai.BackColor = System.Drawing.Color.White;
        this.btnQuayLai.BorderColor = System.Drawing.Color.FromArgb(232, 226, 217);
        this.btnQuayLai.BorderRadius = 6;
        this.btnQuayLai.BorderSize = 1;
        this.btnQuayLai.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnQuayLai.FlatAppearance.BorderSize = 0;
        this.btnQuayLai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnQuayLai.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.btnQuayLai.ForeColor = System.Drawing.Color.FromArgb(43, 37, 32);
        this.btnQuayLai.HoverBackColor = System.Drawing.Color.FromArgb(240, 235, 229);
        this.btnQuayLai.Location = new System.Drawing.Point(65, 320);
        this.btnQuayLai.Name = "btnQuayLai";
        this.btnQuayLai.Size = new System.Drawing.Size(130, 46);
        this.btnQuayLai.TabIndex = 14;
        this.btnQuayLai.Text = "QUAY LẠI";
        this.btnQuayLai.UseVisualStyleBackColor = false;
        // 
        // FrmPayment
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.FromArgb(247, 245, 242);
        this.ClientSize = new System.Drawing.Size(504, 461);
        this.Controls.Add(this.pnlCard);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "FrmPayment";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Xác Nhận Thanh Toán";
        this.pnlCard.ResumeLayout(false);
        this.pnlCard.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.nudGiamGia)).EndInit();
        this.ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.Panel pnlCard;
    private System.Windows.Forms.Label lblTieuDe;
    private System.Windows.Forms.Label lblThongTinBanThuNgan;
    private System.Windows.Forms.Panel pnlPhanCach1;
    private System.Windows.Forms.Label lblTieuDeTienMon;
    private System.Windows.Forms.Label lblTongTienMon;
    private System.Windows.Forms.Label lblTieuDeGiamGia;
    private System.Windows.Forms.NumericUpDown nudGiamGia;
    private System.Windows.Forms.Label lblTienGiam;
    private System.Windows.Forms.Panel pnlPhanCach2;
    private System.Windows.Forms.Label lblTieuDeCanThanhToan;
    private System.Windows.Forms.Label lblTongThanhToan;
    private System.Windows.Forms.CheckBox chkInHoaDon;
    private System.Windows.Forms.CheckBox chkXemTruocIn;
    private CoffeeShopManagement.Components.RjButton btnXacNhanThanhToan;
    private CoffeeShopManagement.Components.RjButton btnQuayLai;
}
