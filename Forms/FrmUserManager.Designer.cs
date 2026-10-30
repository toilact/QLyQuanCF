namespace CoffeeShopManagement.Forms;

partial class FrmUserManager
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
        this.splitMain = new System.Windows.Forms.SplitContainer();
        this.flpInputs = new System.Windows.Forms.FlowLayoutPanel();
        this.lblTenDangNhap = new System.Windows.Forms.Label();
        this.txtTenDangNhap = new System.Windows.Forms.TextBox();
        this.lblMatKhau = new System.Windows.Forms.Label();
        this.txtMatKhau = new System.Windows.Forms.TextBox();
        this.lblHoTen = new System.Windows.Forms.Label();
        this.txtHoTen = new System.Windows.Forms.TextBox();
        this.lblVaiTro = new System.Windows.Forms.Label();
        this.cboVaiTro = new System.Windows.Forms.ComboBox();
        this.chkHoatDong = new System.Windows.Forms.CheckBox();
        this.tblNutThaoTac = new System.Windows.Forms.TableLayoutPanel();
        this.btnThem = new CoffeeShopManagement.Components.RjButton();
        this.btnCapNhat = new CoffeeShopManagement.Components.RjButton();
        this.btnKhoaMo = new CoffeeShopManagement.Components.RjButton();
        this.btnLamMoi = new CoffeeShopManagement.Components.RjButton();
        this.lblTieuDe = new System.Windows.Forms.Label();
        this.dgvNhanVien = new System.Windows.Forms.DataGridView();
        ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
        this.splitMain.Panel1.SuspendLayout();
        this.splitMain.Panel2.SuspendLayout();
        this.splitMain.SuspendLayout();
        this.flpInputs.SuspendLayout();
        this.tblNutThaoTac.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).BeginInit();
        this.SuspendLayout();
        // 
        // splitMain
        // 
        this.splitMain.BackColor = System.Drawing.Color.FromArgb(232, 226, 217);
        this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
        this.splitMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
        this.splitMain.IsSplitterFixed = true;
        this.splitMain.Location = new System.Drawing.Point(0, 0);
        this.splitMain.Name = "splitMain";
        // 
        // splitMain.Panel1
        // 
        this.splitMain.Panel1.BackColor = System.Drawing.Color.White;
        this.splitMain.Panel1.Controls.Add(this.flpInputs);
        this.splitMain.Panel1.Controls.Add(this.lblTieuDe);
        this.splitMain.Panel1.Padding = new System.Windows.Forms.Padding(24, 20, 24, 20);
        // 
        // splitMain.Panel2
        // 
        this.splitMain.Panel2.BackColor = System.Drawing.Color.FromArgb(247, 245, 242);
        this.splitMain.Panel2.Controls.Add(this.dgvNhanVien);
        this.splitMain.Panel2.Padding = new System.Windows.Forms.Padding(16);
        this.splitMain.Size = new System.Drawing.Size(1080, 650);
        this.splitMain.SplitterDistance = 370;
        this.splitMain.TabIndex = 0;
        // 
        // flpInputs
        // 
        this.flpInputs.AutoScroll = true;
        this.flpInputs.Controls.Add(this.lblTenDangNhap);
        this.flpInputs.Controls.Add(this.txtTenDangNhap);
        this.flpInputs.Controls.Add(this.lblMatKhau);
        this.flpInputs.Controls.Add(this.txtMatKhau);
        this.flpInputs.Controls.Add(this.lblHoTen);
        this.flpInputs.Controls.Add(this.txtHoTen);
        this.flpInputs.Controls.Add(this.lblVaiTro);
        this.flpInputs.Controls.Add(this.cboVaiTro);
        this.flpInputs.Controls.Add(this.chkHoatDong);
        this.flpInputs.Controls.Add(this.tblNutThaoTac);
        this.flpInputs.Controls.Add(this.btnLamMoi);
        this.flpInputs.Dock = System.Windows.Forms.DockStyle.Fill;
        this.flpInputs.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
        this.flpInputs.Location = new System.Drawing.Point(24, 55);
        this.flpInputs.Name = "flpInputs";
        this.flpInputs.Size = new System.Drawing.Size(322, 575);
        this.flpInputs.TabIndex = 1;
        this.flpInputs.WrapContents = false;
        // 
        // lblTenDangNhap
        // 
        this.lblTenDangNhap.AutoSize = true;
        this.lblTenDangNhap.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblTenDangNhap.ForeColor = System.Drawing.Color.FromArgb(43, 37, 32);
        this.lblTenDangNhap.Location = new System.Drawing.Point(0, 8);
        this.lblTenDangNhap.Margin = new System.Windows.Forms.Padding(0, 8, 0, 4);
        this.lblTenDangNhap.Name = "lblTenDangNhap";
        this.lblTenDangNhap.Size = new System.Drawing.Size(104, 17);
        this.lblTenDangNhap.TabIndex = 0;
        this.lblTenDangNhap.Text = "Tên đăng nhập:";
        // 
        // txtTenDangNhap
        // 
        this.txtTenDangNhap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.txtTenDangNhap.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.txtTenDangNhap.Location = new System.Drawing.Point(0, 29);
        this.txtTenDangNhap.Margin = new System.Windows.Forms.Padding(0, 0, 0, 12);
        this.txtTenDangNhap.Name = "txtTenDangNhap";
        this.txtTenDangNhap.Size = new System.Drawing.Size(320, 24);
        this.txtTenDangNhap.TabIndex = 1;
        // 
        // lblMatKhau
        // 
        this.lblMatKhau.AutoSize = true;
        this.lblMatKhau.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblMatKhau.ForeColor = System.Drawing.Color.FromArgb(43, 37, 32);
        this.lblMatKhau.Location = new System.Drawing.Point(0, 73);
        this.lblMatKhau.Margin = new System.Windows.Forms.Padding(0, 8, 0, 4);
        this.lblMatKhau.Name = "lblMatKhau";
        this.lblMatKhau.Size = new System.Drawing.Size(227, 17);
        this.lblMatKhau.TabIndex = 2;
        this.lblMatKhau.Text = "Mật khẩu (để trống nếu không đổi):";
        // 
        // txtMatKhau
        // 
        this.txtMatKhau.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.txtMatKhau.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.txtMatKhau.Location = new System.Drawing.Point(0, 94);
        this.txtMatKhau.Margin = new System.Windows.Forms.Padding(0, 0, 0, 12);
        this.txtMatKhau.Name = "txtMatKhau";
        this.txtMatKhau.Size = new System.Drawing.Size(320, 24);
        this.txtMatKhau.TabIndex = 3;
        this.txtMatKhau.UseSystemPasswordChar = true;
        // 
        // lblHoTen
        // 
        this.lblHoTen.AutoSize = true;
        this.lblHoTen.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblHoTen.ForeColor = System.Drawing.Color.FromArgb(43, 37, 32);
        this.lblHoTen.Location = new System.Drawing.Point(0, 138);
        this.lblHoTen.Margin = new System.Windows.Forms.Padding(0, 8, 0, 4);
        this.lblHoTen.Name = "lblHoTen";
        this.lblHoTen.Size = new System.Drawing.Size(123, 17);
        this.lblHoTen.TabIndex = 4;
        this.lblHoTen.Text = "Họ tên nhân viên:";
        // 
        // txtHoTen
        // 
        this.txtHoTen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.txtHoTen.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.txtHoTen.Location = new System.Drawing.Point(0, 159);
        this.txtHoTen.Margin = new System.Windows.Forms.Padding(0, 0, 0, 12);
        this.txtHoTen.Name = "txtHoTen";
        this.txtHoTen.Size = new System.Drawing.Size(320, 24);
        this.txtHoTen.TabIndex = 5;
        // 
        // lblVaiTro
        // 
        this.lblVaiTro.AutoSize = true;
        this.lblVaiTro.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblVaiTro.ForeColor = System.Drawing.Color.FromArgb(43, 37, 32);
        this.lblVaiTro.Location = new System.Drawing.Point(0, 203);
        this.lblVaiTro.Margin = new System.Windows.Forms.Padding(0, 8, 0, 4);
        this.lblVaiTro.Name = "lblVaiTro";
        this.lblVaiTro.Size = new System.Drawing.Size(130, 17);
        this.lblVaiTro.TabIndex = 6;
        this.lblVaiTro.Text = "Vai trò phân quyền:";
        // 
        // cboVaiTro
        // 
        this.cboVaiTro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cboVaiTro.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.cboVaiTro.FormattingEnabled = true;
        this.cboVaiTro.Items.AddRange(new object[] {
            "Staff",
            "Admin"});
        this.cboVaiTro.Location = new System.Drawing.Point(0, 224);
        this.cboVaiTro.Margin = new System.Windows.Forms.Padding(0, 0, 0, 12);
        this.cboVaiTro.Name = "cboVaiTro";
        this.cboVaiTro.Size = new System.Drawing.Size(320, 25);
        this.cboVaiTro.TabIndex = 7;
        // 
        // chkHoatDong
        // 
        this.chkHoatDong.Checked = true;
        this.chkHoatDong.CheckState = System.Windows.Forms.CheckState.Checked;
        this.chkHoatDong.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.chkHoatDong.Location = new System.Drawing.Point(0, 265);
        this.chkHoatDong.Margin = new System.Windows.Forms.Padding(0, 4, 0, 16);
        this.chkHoatDong.Name = "chkHoatDong";
        this.chkHoatDong.Size = new System.Drawing.Size(320, 28);
        this.chkHoatDong.TabIndex = 8;
        this.chkHoatDong.Text = "Tài khoản đang hoạt động";
        this.chkHoatDong.UseVisualStyleBackColor = true;
        // 
        // tblNutThaoTac
        // 
        this.tblNutThaoTac.ColumnCount = 3;
        this.tblNutThaoTac.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3F));
        this.tblNutThaoTac.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3F));
        this.tblNutThaoTac.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.4F));
        this.tblNutThaoTac.Controls.Add(this.btnThem, 0, 0);
        this.tblNutThaoTac.Controls.Add(this.btnCapNhat, 1, 0);
        this.tblNutThaoTac.Controls.Add(this.btnKhoaMo, 2, 0);
        this.tblNutThaoTac.Location = new System.Drawing.Point(0, 309);
        this.tblNutThaoTac.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
        this.tblNutThaoTac.Name = "tblNutThaoTac";
        this.tblNutThaoTac.RowCount = 1;
        this.tblNutThaoTac.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        this.tblNutThaoTac.Size = new System.Drawing.Size(320, 44);
        this.tblNutThaoTac.TabIndex = 9;
        // 
        // btnThem
        // 
        this.btnThem.BackColor = System.Drawing.Color.FromArgb(61, 40, 23);
        this.btnThem.BorderColor = System.Drawing.Color.FromArgb(232, 226, 217);
        this.btnThem.BorderRadius = 6;
        this.btnThem.BorderSize = 0;
        this.btnThem.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnThem.Dock = System.Windows.Forms.DockStyle.Fill;
        this.btnThem.FlatAppearance.BorderSize = 0;
        this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnThem.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.btnThem.ForeColor = System.Drawing.Color.White;
        this.btnThem.HoverBackColor = System.Drawing.Color.FromArgb(83, 56, 33);
        this.btnThem.Location = new System.Drawing.Point(3, 3);
        this.btnThem.Name = "btnThem";
        this.btnThem.Size = new System.Drawing.Size(100, 38);
        this.btnThem.TabIndex = 0;
        this.btnThem.Text = "Thêm mới";
        this.btnThem.UseVisualStyleBackColor = false;
        // 
        // btnCapNhat
        // 
        this.btnCapNhat.BackColor = System.Drawing.Color.FromArgb(198, 139, 89);
        this.btnCapNhat.BorderColor = System.Drawing.Color.FromArgb(232, 226, 217);
        this.btnCapNhat.BorderRadius = 6;
        this.btnCapNhat.BorderSize = 0;
        this.btnCapNhat.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnCapNhat.Dock = System.Windows.Forms.DockStyle.Fill;
        this.btnCapNhat.Enabled = false;
        this.btnCapNhat.FlatAppearance.BorderSize = 0;
        this.btnCapNhat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnCapNhat.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.btnCapNhat.ForeColor = System.Drawing.Color.White;
        this.btnCapNhat.HoverBackColor = System.Drawing.Color.FromArgb(216, 155, 103);
        this.btnCapNhat.Location = new System.Drawing.Point(109, 3);
        this.btnCapNhat.Name = "btnCapNhat";
        this.btnCapNhat.Size = new System.Drawing.Size(100, 38);
        this.btnCapNhat.TabIndex = 1;
        this.btnCapNhat.Text = "Cập nhật";
        this.btnCapNhat.UseVisualStyleBackColor = false;
        // 
        // btnKhoaMo
        // 
        this.btnKhoaMo.BackColor = System.Drawing.Color.FromArgb(200, 90, 50);
        this.btnKhoaMo.BorderColor = System.Drawing.Color.FromArgb(232, 226, 217);
        this.btnKhoaMo.BorderRadius = 6;
        this.btnKhoaMo.BorderSize = 0;
        this.btnKhoaMo.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnKhoaMo.Dock = System.Windows.Forms.DockStyle.Fill;
        this.btnKhoaMo.Enabled = false;
        this.btnKhoaMo.FlatAppearance.BorderSize = 0;
        this.btnKhoaMo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnKhoaMo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.btnKhoaMo.ForeColor = System.Drawing.Color.White;
        this.btnKhoaMo.HoverBackColor = System.Drawing.Color.FromArgb(178, 75, 39);
        this.btnKhoaMo.Location = new System.Drawing.Point(215, 3);
        this.btnKhoaMo.Name = "btnKhoaMo";
        this.btnKhoaMo.Size = new System.Drawing.Size(102, 38);
        this.btnKhoaMo.TabIndex = 2;
        this.btnKhoaMo.Text = "Khóa/Mở";
        this.btnKhoaMo.UseVisualStyleBackColor = false;
        // 
        // btnLamMoi
        // 
        this.btnLamMoi.BackColor = System.Drawing.Color.White;
        this.btnLamMoi.BorderColor = System.Drawing.Color.FromArgb(232, 226, 217);
        this.btnLamMoi.BorderRadius = 6;
        this.btnLamMoi.BorderSize = 1;
        this.btnLamMoi.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnLamMoi.FlatAppearance.BorderSize = 0;
        this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.btnLamMoi.ForeColor = System.Drawing.Color.FromArgb(43, 37, 32);
        this.btnLamMoi.HoverBackColor = System.Drawing.Color.FromArgb(240, 235, 229);
        this.btnLamMoi.Location = new System.Drawing.Point(0, 363);
        this.btnLamMoi.Margin = new System.Windows.Forms.Padding(0);
        this.btnLamMoi.Name = "btnLamMoi";
        this.btnLamMoi.Size = new System.Drawing.Size(320, 38);
        this.btnLamMoi.TabIndex = 10;
        this.btnLamMoi.Text = "Làm mới Form";
        this.btnLamMoi.UseVisualStyleBackColor = false;
        // 
        // lblTieuDe
        // 
        this.lblTieuDe.Dock = System.Windows.Forms.DockStyle.Top;
        this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
        this.lblTieuDe.ForeColor = System.Drawing.Color.FromArgb(61, 40, 23);
        this.lblTieuDe.Location = new System.Drawing.Point(24, 20);
        this.lblTieuDe.Name = "lblTieuDe";
        this.lblTieuDe.Size = new System.Drawing.Size(322, 35);
        this.lblTieuDe.TabIndex = 0;
        this.lblTieuDe.Text = "THÔNG TIN TÀI KHOẢN";
        // 
        // dgvNhanVien
        // 
        this.dgvNhanVien.BackgroundColor = System.Drawing.Color.White;
        this.dgvNhanVien.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.dgvNhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dgvNhanVien.Dock = System.Windows.Forms.DockStyle.Fill;
        this.dgvNhanVien.Location = new System.Drawing.Point(16, 16);
        this.dgvNhanVien.Name = "dgvNhanVien";
        this.dgvNhanVien.Size = new System.Drawing.Size(674, 618);
        this.dgvNhanVien.TabIndex = 0;
        // 
        // FrmUserManager
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.FromArgb(247, 245, 242);
        this.ClientSize = new System.Drawing.Size(1080, 650);
        this.Controls.Add(this.splitMain);
        this.MinimumSize = new System.Drawing.Size(950, 550);
        this.Name = "FrmUserManager";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Quản Trị Người Dùng và Phân Quyền";
        this.splitMain.Panel1.ResumeLayout(false);
        this.splitMain.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
        this.splitMain.ResumeLayout(false);
        this.flpInputs.ResumeLayout(false);
        this.flpInputs.PerformLayout();
        this.tblNutThaoTac.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.dgvNhanVien)).EndInit();
        this.ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.SplitContainer splitMain;
    private System.Windows.Forms.Label lblTieuDe;
    private System.Windows.Forms.FlowLayoutPanel flpInputs;
    private System.Windows.Forms.Label lblTenDangNhap;
    private System.Windows.Forms.TextBox txtTenDangNhap;
    private System.Windows.Forms.Label lblMatKhau;
    private System.Windows.Forms.TextBox txtMatKhau;
    private System.Windows.Forms.Label lblHoTen;
    private System.Windows.Forms.TextBox txtHoTen;
    private System.Windows.Forms.Label lblVaiTro;
    private System.Windows.Forms.ComboBox cboVaiTro;
    private System.Windows.Forms.CheckBox chkHoatDong;
    private System.Windows.Forms.TableLayoutPanel tblNutThaoTac;
    private CoffeeShopManagement.Components.RjButton btnThem;
    private CoffeeShopManagement.Components.RjButton btnCapNhat;
    private CoffeeShopManagement.Components.RjButton btnKhoaMo;
    private CoffeeShopManagement.Components.RjButton btnLamMoi;
    private System.Windows.Forms.DataGridView dgvNhanVien;
}
