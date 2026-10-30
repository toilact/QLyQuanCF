namespace CoffeeShopManagement.Forms;

partial class FrmLogin
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
        this.lblPhuDe = new System.Windows.Forms.Label();
        this.lblTenDangNhap = new System.Windows.Forms.Label();
        this.txtTenDangNhap = new System.Windows.Forms.TextBox();
        this.lblMatKhau = new System.Windows.Forms.Label();
        this.txtMatKhau = new System.Windows.Forms.TextBox();
        this.lblThongBaoLoi = new System.Windows.Forms.Label();
        this.btnDangNhap = new CoffeeShopManagement.Components.RjButton();
        this.lblGoiY = new System.Windows.Forms.Label();
        this.pnlCard.SuspendLayout();
        this.SuspendLayout();
        // 
        // pnlCard
        // 
        this.pnlCard.BackColor = System.Drawing.Color.White;
        this.pnlCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.pnlCard.Controls.Add(this.lblTieuDe);
        this.pnlCard.Controls.Add(this.lblPhuDe);
        this.pnlCard.Controls.Add(this.lblTenDangNhap);
        this.pnlCard.Controls.Add(this.txtTenDangNhap);
        this.pnlCard.Controls.Add(this.lblMatKhau);
        this.pnlCard.Controls.Add(this.txtMatKhau);
        this.pnlCard.Controls.Add(this.lblThongBaoLoi);
        this.pnlCard.Controls.Add(this.btnDangNhap);
        this.pnlCard.Controls.Add(this.lblGoiY);
        this.pnlCard.Location = new System.Drawing.Point(30, 25);
        this.pnlCard.Name = "pnlCard";
        this.pnlCard.Size = new System.Drawing.Size(360, 430);
        this.pnlCard.TabIndex = 0;
        // 
        // lblTieuDe
        // 
        this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
        this.lblTieuDe.ForeColor = System.Drawing.Color.FromArgb(61, 40, 23);
        this.lblTieuDe.Location = new System.Drawing.Point(20, 25);
        this.lblTieuDe.Name = "lblTieuDe";
        this.lblTieuDe.Size = new System.Drawing.Size(320, 32);
        this.lblTieuDe.TabIndex = 0;
        this.lblTieuDe.Text = "CÀ PHÊ HƯƠNG VIỆT";
        this.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lblPhuDe
        // 
        this.lblPhuDe.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.lblPhuDe.ForeColor = System.Drawing.Color.FromArgb(125, 117, 109);
        this.lblPhuDe.Location = new System.Drawing.Point(20, 60);
        this.lblPhuDe.Name = "lblPhuDe";
        this.lblPhuDe.Size = new System.Drawing.Size(320, 20);
        this.lblPhuDe.TabIndex = 1;
        this.lblPhuDe.Text = "Hệ Thống Bán Hàng & Quản Trị";
        this.lblPhuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lblTenDangNhap
        // 
        this.lblTenDangNhap.AutoSize = true;
        this.lblTenDangNhap.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.lblTenDangNhap.ForeColor = System.Drawing.Color.FromArgb(43, 37, 32);
        this.lblTenDangNhap.Location = new System.Drawing.Point(30, 105);
        this.lblTenDangNhap.Name = "lblTenDangNhap";
        this.lblTenDangNhap.Size = new System.Drawing.Size(109, 19);
        this.lblTenDangNhap.TabIndex = 2;
        this.lblTenDangNhap.Text = "Tên đăng nhập:";
        // 
        // txtTenDangNhap
        // 
        this.txtTenDangNhap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.txtTenDangNhap.Font = new System.Drawing.Font("Segoe UI", 11F);
        this.txtTenDangNhap.Location = new System.Drawing.Point(30, 130);
        this.txtTenDangNhap.Name = "txtTenDangNhap";
        this.txtTenDangNhap.Size = new System.Drawing.Size(300, 27);
        this.txtTenDangNhap.TabIndex = 3;
        // 
        // lblMatKhau
        // 
        this.lblMatKhau.AutoSize = true;
        this.lblMatKhau.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.lblMatKhau.ForeColor = System.Drawing.Color.FromArgb(43, 37, 32);
        this.lblMatKhau.Location = new System.Drawing.Point(30, 175);
        this.lblMatKhau.Name = "lblMatKhau";
        this.lblMatKhau.Size = new System.Drawing.Size(75, 19);
        this.lblMatKhau.TabIndex = 4;
        this.lblMatKhau.Text = "Mật khẩu:";
        // 
        // txtMatKhau
        // 
        this.txtMatKhau.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.txtMatKhau.Font = new System.Drawing.Font("Segoe UI", 11F);
        this.txtMatKhau.Location = new System.Drawing.Point(30, 200);
        this.txtMatKhau.Name = "txtMatKhau";
        this.txtMatKhau.Size = new System.Drawing.Size(300, 27);
        this.txtMatKhau.TabIndex = 5;
        this.txtMatKhau.UseSystemPasswordChar = true;
        // 
        // lblThongBaoLoi
        // 
        this.lblThongBaoLoi.Font = new System.Drawing.Font("Segoe UI", 8.5F);
        this.lblThongBaoLoi.ForeColor = System.Drawing.Color.FromArgb(200, 90, 50);
        this.lblThongBaoLoi.Location = new System.Drawing.Point(30, 235);
        this.lblThongBaoLoi.Name = "lblThongBaoLoi";
        this.lblThongBaoLoi.Size = new System.Drawing.Size(300, 36);
        this.lblThongBaoLoi.TabIndex = 6;
        this.lblThongBaoLoi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // btnDangNhap
        // 
        this.btnDangNhap.BackColor = System.Drawing.Color.FromArgb(61, 40, 23);
        this.btnDangNhap.BorderColor = System.Drawing.Color.FromArgb(232, 226, 217);
        this.btnDangNhap.BorderRadius = 8;
        this.btnDangNhap.BorderSize = 0;
        this.btnDangNhap.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnDangNhap.FlatAppearance.BorderSize = 0;
        this.btnDangNhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnDangNhap.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
        this.btnDangNhap.ForeColor = System.Drawing.Color.White;
        this.btnDangNhap.HoverBackColor = System.Drawing.Color.FromArgb(83, 56, 33);
        this.btnDangNhap.Location = new System.Drawing.Point(30, 280);
        this.btnDangNhap.Name = "btnDangNhap";
        this.btnDangNhap.Size = new System.Drawing.Size(300, 44);
        this.btnDangNhap.TabIndex = 7;
        this.btnDangNhap.Text = "ĐĂNG NHẬP";
        this.btnDangNhap.UseVisualStyleBackColor = false;
        // 
        // lblGoiY
        // 
        this.lblGoiY.Font = new System.Drawing.Font("Segoe UI", 8.5F);
        this.lblGoiY.ForeColor = System.Drawing.Color.FromArgb(125, 117, 109);
        this.lblGoiY.Location = new System.Drawing.Point(20, 350);
        this.lblGoiY.Name = "lblGoiY";
        this.lblGoiY.Size = new System.Drawing.Size(320, 40);
        this.lblGoiY.TabIndex = 8;
        this.lblGoiY.Text = "Tài khoản test mặc định:\r\nadmin / admin123 | staff / staff123";
        this.lblGoiY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // FrmLogin
        // 
        this.AcceptButton = this.btnDangNhap;
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.FromArgb(247, 245, 242);
        this.ClientSize = new System.Drawing.Size(420, 485);
        this.Controls.Add(this.pnlCard);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
        this.Name = "FrmLogin";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Đăng Nhập - Quản Lý Quán Cà Phê";
        this.pnlCard.ResumeLayout(false);
        this.pnlCard.PerformLayout();
        this.ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.Panel pnlCard;
    private System.Windows.Forms.Label lblTieuDe;
    private System.Windows.Forms.Label lblPhuDe;
    private System.Windows.Forms.Label lblTenDangNhap;
    private System.Windows.Forms.TextBox txtTenDangNhap;
    private System.Windows.Forms.Label lblMatKhau;
    private System.Windows.Forms.TextBox txtMatKhau;
    private System.Windows.Forms.Label lblThongBaoLoi;
    private CoffeeShopManagement.Components.RjButton btnDangNhap;
    private System.Windows.Forms.Label lblGoiY;
}
