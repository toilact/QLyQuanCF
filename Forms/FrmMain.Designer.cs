namespace CoffeeShopManagement.Forms;

partial class FrmMain
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
        this.pnlHeader = new System.Windows.Forms.Panel();
        this.pnlHeaderLeft = new System.Windows.Forms.Panel();
        this.lblTenQuan = new System.Windows.Forms.Label();
        this.lblPhuDe = new System.Windows.Forms.Label();
        this.flpHeaderRight = new System.Windows.Forms.FlowLayoutPanel();
        this.btnDangXuat = new CoffeeShopManagement.Components.RjButton();
        this.lblVaiTro = new System.Windows.Forms.Label();
        this.lblTenNhanVien = new System.Windows.Forms.Label();
        this.pnlBody = new System.Windows.Forms.Panel();
        this.pnlCenter = new System.Windows.Forms.Panel();
        this.flpDanhSachBan = new System.Windows.Forms.FlowLayoutPanel();
        this.pnlLocKhuVuc = new System.Windows.Forms.Panel();
        this.lblThongKeBan = new System.Windows.Forms.Label();
        this.cboKhuVuc = new System.Windows.Forms.ComboBox();
        this.lblLocKhuVuc = new System.Windows.Forms.Label();
        this.pnlBill = new System.Windows.Forms.Panel();
        this.dgvChiTietHoaDon = new System.Windows.Forms.DataGridView();
        this.pnlActions = new System.Windows.Forms.Panel();
        this.btnThanhToan = new CoffeeShopManagement.Components.RjButton();
        this.tblCacNutThaoTac = new System.Windows.Forms.TableLayoutPanel();
        this.btnThemMon = new CoffeeShopManagement.Components.RjButton();
        this.btnDoiBan = new CoffeeShopManagement.Components.RjButton();
        this.btnGopBan = new CoffeeShopManagement.Components.RjButton();
        this.pnlTongTienRow = new System.Windows.Forms.Panel();
        this.lblTongTamTinh = new System.Windows.Forms.Label();
        this.lblTieuDeTamTinh = new System.Windows.Forms.Label();
        this.pnlBillHeader = new System.Windows.Forms.Panel();
        this.lblTrangThaiBan = new System.Windows.Forms.Label();
        this.lblBanDangChon = new System.Windows.Forms.Label();
        this.pnlSidebar = new System.Windows.Forms.Panel();
        this.flpMenu = new System.Windows.Forms.FlowLayoutPanel();
        this.btnBanHang = new CoffeeShopManagement.Components.RjButton();
        this.btnThucDon = new CoffeeShopManagement.Components.RjButton();
        this.btnQuanLyBan = new CoffeeShopManagement.Components.RjButton();
        this.btnQuanLyNhanVien = new CoffeeShopManagement.Components.RjButton();
        this.btnBaoCao = new CoffeeShopManagement.Components.RjButton();
        this.lblGhiChuAdmin = new System.Windows.Forms.Label();
        this.pnlHeader.SuspendLayout();
        this.pnlHeaderLeft.SuspendLayout();
        this.flpHeaderRight.SuspendLayout();
        this.pnlBody.SuspendLayout();
        this.pnlCenter.SuspendLayout();
        this.pnlLocKhuVuc.SuspendLayout();
        this.pnlBill.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHoaDon)).BeginInit();
        this.pnlActions.SuspendLayout();
        this.tblCacNutThaoTac.SuspendLayout();
        this.pnlTongTienRow.SuspendLayout();
        this.pnlBillHeader.SuspendLayout();
        this.pnlSidebar.SuspendLayout();
        this.flpMenu.SuspendLayout();
        this.SuspendLayout();
        // 
        // pnlHeader
        // 
        this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(61, 40, 23);
        this.pnlHeader.Controls.Add(this.pnlHeaderLeft);
        this.pnlHeader.Controls.Add(this.flpHeaderRight);
        this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
        this.pnlHeader.Location = new System.Drawing.Point(0, 0);
        this.pnlHeader.Name = "pnlHeader";
        this.pnlHeader.Padding = new System.Windows.Forms.Padding(24, 0, 20, 0);
        this.pnlHeader.Size = new System.Drawing.Size(1366, 65);
        this.pnlHeader.TabIndex = 0;
        // 
        // pnlHeaderLeft
        // 
        this.pnlHeaderLeft.BackColor = System.Drawing.Color.Transparent;
        this.pnlHeaderLeft.Controls.Add(this.lblTenQuan);
        this.pnlHeaderLeft.Controls.Add(this.lblPhuDe);
        this.pnlHeaderLeft.Dock = System.Windows.Forms.DockStyle.Left;
        this.pnlHeaderLeft.Location = new System.Drawing.Point(24, 0);
        this.pnlHeaderLeft.Name = "pnlHeaderLeft";
        this.pnlHeaderLeft.Size = new System.Drawing.Size(350, 65);
        this.pnlHeaderLeft.TabIndex = 0;
        // 
        // lblTenQuan
        // 
        this.lblTenQuan.AutoSize = true;
        this.lblTenQuan.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
        this.lblTenQuan.ForeColor = System.Drawing.Color.White;
        this.lblTenQuan.Location = new System.Drawing.Point(0, 10);
        this.lblTenQuan.Name = "lblTenQuan";
        this.lblTenQuan.Size = new System.Drawing.Size(206, 28);
        this.lblTenQuan.TabIndex = 0;
        this.lblTenQuan.Text = "CÀ PHÊ HƯƠNG VIỆT";
        // 
        // lblPhuDe
        // 
        this.lblPhuDe.AutoSize = true;
        this.lblPhuDe.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.lblPhuDe.ForeColor = System.Drawing.Color.FromArgb(212, 199, 186);
        this.lblPhuDe.Location = new System.Drawing.Point(2, 38);
        this.lblPhuDe.Name = "lblPhuDe";
        this.lblPhuDe.Size = new System.Drawing.Size(222, 15);
        this.lblPhuDe.TabIndex = 1;
        this.lblPhuDe.Text = "Hệ thống POS bán hàng & Quản trị quán";
        // 
        // flpHeaderRight
        // 
        this.flpHeaderRight.AutoSize = true;
        this.flpHeaderRight.BackColor = System.Drawing.Color.Transparent;
        this.flpHeaderRight.Controls.Add(this.btnDangXuat);
        this.flpHeaderRight.Controls.Add(this.lblVaiTro);
        this.flpHeaderRight.Controls.Add(this.lblTenNhanVien);
        this.flpHeaderRight.Dock = System.Windows.Forms.DockStyle.Right;
        this.flpHeaderRight.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
        this.flpHeaderRight.Location = new System.Drawing.Point(986, 0);
        this.flpHeaderRight.Name = "flpHeaderRight";
        this.flpHeaderRight.Padding = new System.Windows.Forms.Padding(0, 14, 0, 0);
        this.flpHeaderRight.Size = new System.Drawing.Size(360, 65);
        this.flpHeaderRight.TabIndex = 1;
        // 
        // btnDangXuat
        // 
        this.btnDangXuat.BackColor = System.Drawing.Color.FromArgb(198, 139, 89);
        this.btnDangXuat.BorderColor = System.Drawing.Color.FromArgb(232, 226, 217);
        this.btnDangXuat.BorderRadius = 6;
        this.btnDangXuat.BorderSize = 0;
        this.btnDangXuat.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnDangXuat.FlatAppearance.BorderSize = 0;
        this.btnDangXuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnDangXuat.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.btnDangXuat.ForeColor = System.Drawing.Color.White;
        this.btnDangXuat.HoverBackColor = System.Drawing.Color.FromArgb(216, 155, 103);
        this.btnDangXuat.Location = new System.Drawing.Point(248, 14);
        this.btnDangXuat.Margin = new System.Windows.Forms.Padding(12, 0, 0, 0);
        this.btnDangXuat.Name = "btnDangXuat";
        this.btnDangXuat.Size = new System.Drawing.Size(100, 36);
        this.btnDangXuat.TabIndex = 0;
        this.btnDangXuat.Text = "Đăng xuất";
        this.btnDangXuat.UseVisualStyleBackColor = false;
        // 
        // lblVaiTro
        // 
        this.lblVaiTro.BackColor = System.Drawing.Color.FromArgb(198, 139, 89);
        this.lblVaiTro.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
        this.lblVaiTro.ForeColor = System.Drawing.Color.White;
        this.lblVaiTro.Location = new System.Drawing.Point(121, 19);
        this.lblVaiTro.Margin = new System.Windows.Forms.Padding(12, 5, 0, 0);
        this.lblVaiTro.Name = "lblVaiTro";
        this.lblVaiTro.Size = new System.Drawing.Size(115, 26);
        this.lblVaiTro.TabIndex = 1;
        this.lblVaiTro.Text = "QUẢN TRỊ VIÊN";
        this.lblVaiTro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lblTenNhanVien
        // 
        this.lblTenNhanVien.AutoSize = true;
        this.lblTenNhanVien.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
        this.lblTenNhanVien.ForeColor = System.Drawing.Color.White;
        this.lblTenNhanVien.Location = new System.Drawing.Point(15, 22);
        this.lblTenNhanVien.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
        this.lblTenNhanVien.Name = "lblTenNhanVien";
        this.lblTenNhanVien.Size = new System.Drawing.Size(106, 19);
        this.lblTenNhanVien.TabIndex = 2;
        this.lblTenNhanVien.Text = "Quản Trị Viên";
        this.lblTenNhanVien.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // pnlBody
        // 
        this.pnlBody.BackColor = System.Drawing.Color.FromArgb(247, 245, 242);
        this.pnlBody.Controls.Add(this.pnlCenter);
        this.pnlBody.Controls.Add(this.pnlBill);
        this.pnlBody.Controls.Add(this.pnlSidebar);
        this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
        this.pnlBody.Location = new System.Drawing.Point(0, 65);
        this.pnlBody.Name = "pnlBody";
        this.pnlBody.Size = new System.Drawing.Size(1366, 755);
        this.pnlBody.TabIndex = 1;
        // 
        // pnlCenter
        // 
        this.pnlCenter.BackColor = System.Drawing.Color.FromArgb(247, 245, 242);
        this.pnlCenter.Controls.Add(this.flpDanhSachBan);
        this.pnlCenter.Controls.Add(this.pnlLocKhuVuc);
        this.pnlCenter.Dock = System.Windows.Forms.DockStyle.Fill;
        this.pnlCenter.Location = new System.Drawing.Point(230, 0);
        this.pnlCenter.Name = "pnlCenter";
        this.pnlCenter.Padding = new System.Windows.Forms.Padding(20, 16, 20, 16);
        this.pnlCenter.Size = new System.Drawing.Size(676, 755);
        this.pnlCenter.TabIndex = 2;
        // 
        // flpDanhSachBan
        // 
        this.flpDanhSachBan.AutoScroll = true;
        this.flpDanhSachBan.BackColor = System.Drawing.Color.Transparent;
        this.flpDanhSachBan.Dock = System.Windows.Forms.DockStyle.Fill;
        this.flpDanhSachBan.Location = new System.Drawing.Point(20, 66);
        this.flpDanhSachBan.Name = "flpDanhSachBan";
        this.flpDanhSachBan.Padding = new System.Windows.Forms.Padding(4);
        this.flpDanhSachBan.Size = new System.Drawing.Size(636, 673);
        this.flpDanhSachBan.TabIndex = 1;
        // 
        // pnlLocKhuVuc
        // 
        this.pnlLocKhuVuc.BackColor = System.Drawing.Color.Transparent;
        this.pnlLocKhuVuc.Controls.Add(this.lblThongKeBan);
        this.pnlLocKhuVuc.Controls.Add(this.cboKhuVuc);
        this.pnlLocKhuVuc.Controls.Add(this.lblLocKhuVuc);
        this.pnlLocKhuVuc.Dock = System.Windows.Forms.DockStyle.Top;
        this.pnlLocKhuVuc.Location = new System.Drawing.Point(20, 16);
        this.pnlLocKhuVuc.Name = "pnlLocKhuVuc";
        this.pnlLocKhuVuc.Size = new System.Drawing.Size(636, 50);
        this.pnlLocKhuVuc.TabIndex = 0;
        // 
        // lblThongKeBan
        // 
        this.lblThongKeBan.AutoSize = true;
        this.lblThongKeBan.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblThongKeBan.ForeColor = System.Drawing.Color.FromArgb(125, 117, 109);
        this.lblThongKeBan.Location = new System.Drawing.Point(320, 12);
        this.lblThongKeBan.Name = "lblThongKeBan";
        this.lblThongKeBan.Size = new System.Drawing.Size(126, 17);
        this.lblThongKeBan.TabIndex = 2;
        this.lblThongKeBan.Text = "Thống kê bàn quán";
        // 
        // cboKhuVuc
        // 
        this.cboKhuVuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cboKhuVuc.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.cboKhuVuc.FormattingEnabled = true;
        this.cboKhuVuc.Location = new System.Drawing.Point(95, 8);
        this.cboKhuVuc.Name = "cboKhuVuc";
        this.cboKhuVuc.Size = new System.Drawing.Size(200, 25);
        this.cboKhuVuc.TabIndex = 1;
        // 
        // lblLocKhuVuc
        // 
        this.lblLocKhuVuc.AutoSize = true;
        this.lblLocKhuVuc.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.lblLocKhuVuc.ForeColor = System.Drawing.Color.FromArgb(43, 37, 32);
        this.lblLocKhuVuc.Location = new System.Drawing.Point(0, 11);
        this.lblLocKhuVuc.Name = "lblLocKhuVuc";
        this.lblLocKhuVuc.Size = new System.Drawing.Size(89, 19);
        this.lblLocKhuVuc.TabIndex = 0;
        this.lblLocKhuVuc.Text = "Lọc khu vực:";
        // 
        // pnlBill
        // 
        this.pnlBill.BackColor = System.Drawing.Color.White;
        this.pnlBill.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.pnlBill.Controls.Add(this.dgvChiTietHoaDon);
        this.pnlBill.Controls.Add(this.pnlActions);
        this.pnlBill.Controls.Add(this.pnlBillHeader);
        this.pnlBill.Dock = System.Windows.Forms.DockStyle.Right;
        this.pnlBill.Location = new System.Drawing.Point(906, 0);
        this.pnlBill.Name = "pnlBill";
        this.pnlBill.Padding = new System.Windows.Forms.Padding(16);
        this.pnlBill.Size = new System.Drawing.Size(460, 755);
        this.pnlBill.TabIndex = 1;
        // 
        // dgvChiTietHoaDon
        // 
        this.dgvChiTietHoaDon.BackgroundColor = System.Drawing.Color.White;
        this.dgvChiTietHoaDon.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.dgvChiTietHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dgvChiTietHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
        this.dgvChiTietHoaDon.Location = new System.Drawing.Point(16, 61);
        this.dgvChiTietHoaDon.Name = "dgvChiTietHoaDon";
        this.dgvChiTietHoaDon.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        this.dgvChiTietHoaDon.Size = new System.Drawing.Size(426, 476);
        this.dgvChiTietHoaDon.TabIndex = 1;
        // 
        // pnlActions
        // 
        this.pnlActions.BackColor = System.Drawing.Color.White;
        this.pnlActions.Controls.Add(this.btnThanhToan);
        this.pnlActions.Controls.Add(this.tblCacNutThaoTac);
        this.pnlActions.Controls.Add(this.pnlTongTienRow);
        this.pnlActions.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.pnlActions.Location = new System.Drawing.Point(16, 537);
        this.pnlActions.Name = "pnlActions";
        this.pnlActions.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
        this.pnlActions.Size = new System.Drawing.Size(426, 200);
        this.pnlActions.TabIndex = 2;
        // 
        // btnThanhToan
        // 
        this.btnThanhToan.BackColor = System.Drawing.Color.FromArgb(61, 40, 23);
        this.btnThanhToan.BorderColor = System.Drawing.Color.FromArgb(232, 226, 217);
        this.btnThanhToan.BorderRadius = 8;
        this.btnThanhToan.BorderSize = 0;
        this.btnThanhToan.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnThanhToan.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.btnThanhToan.FlatAppearance.BorderSize = 0;
        this.btnThanhToan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnThanhToan.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold);
        this.btnThanhToan.ForeColor = System.Drawing.Color.White;
        this.btnThanhToan.HoverBackColor = System.Drawing.Color.FromArgb(83, 56, 33);
        this.btnThanhToan.Location = new System.Drawing.Point(0, 148);
        this.btnThanhToan.Name = "btnThanhToan";
        this.btnThanhToan.Size = new System.Drawing.Size(426, 52);
        this.btnThanhToan.TabIndex = 2;
        this.btnThanhToan.Text = "THANH TOÁN VÀ IN HÓA ĐƠN";
        this.btnThanhToan.UseVisualStyleBackColor = false;
        // 
        // tblCacNutThaoTac
        // 
        this.tblCacNutThaoTac.ColumnCount = 3;
        this.tblCacNutThaoTac.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
        this.tblCacNutThaoTac.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.5F));
        this.tblCacNutThaoTac.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.5F));
        this.tblCacNutThaoTac.Controls.Add(this.btnThemMon, 0, 0);
        this.tblCacNutThaoTac.Controls.Add(this.btnDoiBan, 1, 0);
        this.tblCacNutThaoTac.Controls.Add(this.btnGopBan, 2, 0);
        this.tblCacNutThaoTac.Dock = System.Windows.Forms.DockStyle.Top;
        this.tblCacNutThaoTac.Location = new System.Drawing.Point(0, 50);
        this.tblCacNutThaoTac.Margin = new System.Windows.Forms.Padding(0, 8, 0, 8);
        this.tblCacNutThaoTac.Name = "tblCacNutThaoTac";
        this.tblCacNutThaoTac.RowCount = 1;
        this.tblCacNutThaoTac.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        this.tblCacNutThaoTac.Size = new System.Drawing.Size(426, 48);
        this.tblCacNutThaoTac.TabIndex = 1;
        // 
        // btnThemMon
        // 
        this.btnThemMon.BackColor = System.Drawing.Color.FromArgb(198, 139, 89);
        this.btnThemMon.BorderColor = System.Drawing.Color.FromArgb(232, 226, 217);
        this.btnThemMon.BorderRadius = 6;
        this.btnThemMon.BorderSize = 0;
        this.btnThemMon.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnThemMon.Dock = System.Windows.Forms.DockStyle.Fill;
        this.btnThemMon.FlatAppearance.BorderSize = 0;
        this.btnThemMon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnThemMon.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.btnThemMon.ForeColor = System.Drawing.Color.White;
        this.btnThemMon.HoverBackColor = System.Drawing.Color.FromArgb(216, 155, 103);
        this.btnThemMon.Location = new System.Drawing.Point(3, 3);
        this.btnThemMon.Name = "btnThemMon";
        this.btnThemMon.Size = new System.Drawing.Size(143, 42);
        this.btnThemMon.TabIndex = 0;
        this.btnThemMon.Text = "+ THÊM MÓN";
        this.btnThemMon.UseVisualStyleBackColor = false;
        // 
        // btnDoiBan
        // 
        this.btnDoiBan.BackColor = System.Drawing.Color.White;
        this.btnDoiBan.BorderColor = System.Drawing.Color.FromArgb(232, 226, 217);
        this.btnDoiBan.BorderRadius = 6;
        this.btnDoiBan.BorderSize = 1;
        this.btnDoiBan.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnDoiBan.Dock = System.Windows.Forms.DockStyle.Fill;
        this.btnDoiBan.FlatAppearance.BorderSize = 0;
        this.btnDoiBan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnDoiBan.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.btnDoiBan.ForeColor = System.Drawing.Color.FromArgb(43, 37, 32);
        this.btnDoiBan.HoverBackColor = System.Drawing.Color.FromArgb(240, 235, 229);
        this.btnDoiBan.Location = new System.Drawing.Point(152, 3);
        this.btnDoiBan.Name = "btnDoiBan";
        this.btnDoiBan.Size = new System.Drawing.Size(132, 42);
        this.btnDoiBan.TabIndex = 1;
        this.btnDoiBan.Text = "ĐỔI BÀN";
        this.btnDoiBan.UseVisualStyleBackColor = false;
        // 
        // btnGopBan
        // 
        this.btnGopBan.BackColor = System.Drawing.Color.White;
        this.btnGopBan.BorderColor = System.Drawing.Color.FromArgb(232, 226, 217);
        this.btnGopBan.BorderRadius = 6;
        this.btnGopBan.BorderSize = 1;
        this.btnGopBan.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnGopBan.Dock = System.Windows.Forms.DockStyle.Fill;
        this.btnGopBan.FlatAppearance.BorderSize = 0;
        this.btnGopBan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnGopBan.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.btnGopBan.ForeColor = System.Drawing.Color.FromArgb(43, 37, 32);
        this.btnGopBan.HoverBackColor = System.Drawing.Color.FromArgb(240, 235, 229);
        this.btnGopBan.Location = new System.Drawing.Point(290, 3);
        this.btnGopBan.Name = "btnGopBan";
        this.btnGopBan.Size = new System.Drawing.Size(133, 42);
        this.btnGopBan.TabIndex = 2;
        this.btnGopBan.Text = "GỘP BÀN";
        this.btnGopBan.UseVisualStyleBackColor = false;
        // 
        // pnlTongTienRow
        // 
        this.pnlTongTienRow.BackColor = System.Drawing.Color.Transparent;
        this.pnlTongTienRow.Controls.Add(this.lblTongTamTinh);
        this.pnlTongTienRow.Controls.Add(this.lblTieuDeTamTinh);
        this.pnlTongTienRow.Dock = System.Windows.Forms.DockStyle.Top;
        this.pnlTongTienRow.Location = new System.Drawing.Point(0, 10);
        this.pnlTongTienRow.Name = "pnlTongTienRow";
        this.pnlTongTienRow.Size = new System.Drawing.Size(426, 40);
        this.pnlTongTienRow.TabIndex = 0;
        // 
        // lblTongTamTinh
        // 
        this.lblTongTamTinh.Dock = System.Windows.Forms.DockStyle.Right;
        this.lblTongTamTinh.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
        this.lblTongTamTinh.ForeColor = System.Drawing.Color.FromArgb(200, 90, 50);
        this.lblTongTamTinh.Location = new System.Drawing.Point(186, 0);
        this.lblTongTamTinh.Name = "lblTongTamTinh";
        this.lblTongTamTinh.Size = new System.Drawing.Size(240, 40);
        this.lblTongTamTinh.TabIndex = 1;
        this.lblTongTamTinh.Text = "0 đ";
        this.lblTongTamTinh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // lblTieuDeTamTinh
        // 
        this.lblTieuDeTamTinh.AutoSize = true;
        this.lblTieuDeTamTinh.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
        this.lblTieuDeTamTinh.ForeColor = System.Drawing.Color.FromArgb(43, 37, 32);
        this.lblTieuDeTamTinh.Location = new System.Drawing.Point(0, 8);
        this.lblTieuDeTamTinh.Name = "lblTieuDeTamTinh";
        this.lblTieuDeTamTinh.Size = new System.Drawing.Size(147, 21);
        this.lblTieuDeTamTinh.TabIndex = 0;
        this.lblTieuDeTamTinh.Text = "TỔNG TẠM TÍNH:";
        // 
        // pnlBillHeader
        // 
        this.pnlBillHeader.BackColor = System.Drawing.Color.Transparent;
        this.pnlBillHeader.Controls.Add(this.lblTrangThaiBan);
        this.pnlBillHeader.Controls.Add(this.lblBanDangChon);
        this.pnlBillHeader.Dock = System.Windows.Forms.DockStyle.Top;
        this.pnlBillHeader.Location = new System.Drawing.Point(16, 16);
        this.pnlBillHeader.Name = "pnlBillHeader";
        this.pnlBillHeader.Size = new System.Drawing.Size(426, 45);
        this.pnlBillHeader.TabIndex = 0;
        // 
        // lblTrangThaiBan
        // 
        this.lblTrangThaiBan.Dock = System.Windows.Forms.DockStyle.Right;
        this.lblTrangThaiBan.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblTrangThaiBan.Location = new System.Drawing.Point(286, 0);
        this.lblTrangThaiBan.Name = "lblTrangThaiBan";
        this.lblTrangThaiBan.Size = new System.Drawing.Size(140, 45);
        this.lblTrangThaiBan.TabIndex = 1;
        this.lblTrangThaiBan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // lblBanDangChon
        // 
        this.lblBanDangChon.AutoSize = true;
        this.lblBanDangChon.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
        this.lblBanDangChon.ForeColor = System.Drawing.Color.FromArgb(61, 40, 23);
        this.lblBanDangChon.Location = new System.Drawing.Point(0, 10);
        this.lblBanDangChon.Name = "lblBanDangChon";
        this.lblBanDangChon.Size = new System.Drawing.Size(175, 21);
        this.lblBanDangChon.TabIndex = 0;
        this.lblBanDangChon.Text = "Chọn bàn để thao tác";
        // 
        // pnlSidebar
        // 
        this.pnlSidebar.BackColor = System.Drawing.Color.White;
        this.pnlSidebar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.pnlSidebar.Controls.Add(this.flpMenu);
        this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
        this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
        this.pnlSidebar.Name = "pnlSidebar";
        this.pnlSidebar.Padding = new System.Windows.Forms.Padding(12, 16, 12, 16);
        this.pnlSidebar.Size = new System.Drawing.Size(230, 755);
        this.pnlSidebar.TabIndex = 0;
        // 
        // flpMenu
        // 
        this.flpMenu.AutoScroll = true;
        this.flpMenu.Controls.Add(this.btnBanHang);
        this.flpMenu.Controls.Add(this.btnThucDon);
        this.flpMenu.Controls.Add(this.btnQuanLyBan);
        this.flpMenu.Controls.Add(this.btnQuanLyNhanVien);
        this.flpMenu.Controls.Add(this.btnBaoCao);
        this.flpMenu.Controls.Add(this.lblGhiChuAdmin);
        this.flpMenu.Dock = System.Windows.Forms.DockStyle.Fill;
        this.flpMenu.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
        this.flpMenu.Location = new System.Drawing.Point(12, 16);
        this.flpMenu.Name = "flpMenu";
        this.flpMenu.Size = new System.Drawing.Size(204, 721);
        this.flpMenu.TabIndex = 0;
        this.flpMenu.WrapContents = false;
        // 
        // btnBanHang
        // 
        this.btnBanHang.BackColor = System.Drawing.Color.FromArgb(247, 245, 242);
        this.btnBanHang.BorderColor = System.Drawing.Color.FromArgb(232, 226, 217);
        this.btnBanHang.BorderRadius = 8;
        this.btnBanHang.BorderSize = 1;
        this.btnBanHang.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnBanHang.FlatAppearance.BorderSize = 0;
        this.btnBanHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnBanHang.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.btnBanHang.ForeColor = System.Drawing.Color.FromArgb(43, 37, 32);
        this.btnBanHang.HoverBackColor = System.Drawing.Color.FromArgb(235, 226, 216);
        this.btnBanHang.Location = new System.Drawing.Point(0, 0);
        this.btnBanHang.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
        this.btnBanHang.Name = "btnBanHang";
        this.btnBanHang.Size = new System.Drawing.Size(204, 46);
        this.btnBanHang.TabIndex = 0;
        this.btnBanHang.Text = "Bán hàng (POS)";
        this.btnBanHang.UseVisualStyleBackColor = false;
        // 
        // btnThucDon
        // 
        this.btnThucDon.BackColor = System.Drawing.Color.FromArgb(247, 245, 242);
        this.btnThucDon.BorderColor = System.Drawing.Color.FromArgb(232, 226, 217);
        this.btnThucDon.BorderRadius = 8;
        this.btnThucDon.BorderSize = 1;
        this.btnThucDon.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnThucDon.FlatAppearance.BorderSize = 0;
        this.btnThucDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnThucDon.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.btnThucDon.ForeColor = System.Drawing.Color.FromArgb(43, 37, 32);
        this.btnThucDon.HoverBackColor = System.Drawing.Color.FromArgb(235, 226, 216);
        this.btnThucDon.Location = new System.Drawing.Point(0, 56);
        this.btnThucDon.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
        this.btnThucDon.Name = "btnThucDon";
        this.btnThucDon.Size = new System.Drawing.Size(204, 46);
        this.btnThucDon.TabIndex = 1;
        this.btnThucDon.Text = "Thực đơn món";
        this.btnThucDon.UseVisualStyleBackColor = false;
        // 
        // btnQuanLyBan
        // 
        this.btnQuanLyBan.BackColor = System.Drawing.Color.FromArgb(247, 245, 242);
        this.btnQuanLyBan.BorderColor = System.Drawing.Color.FromArgb(232, 226, 217);
        this.btnQuanLyBan.BorderRadius = 8;
        this.btnQuanLyBan.BorderSize = 1;
        this.btnQuanLyBan.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnQuanLyBan.FlatAppearance.BorderSize = 0;
        this.btnQuanLyBan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnQuanLyBan.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.btnQuanLyBan.ForeColor = System.Drawing.Color.FromArgb(43, 37, 32);
        this.btnQuanLyBan.HoverBackColor = System.Drawing.Color.FromArgb(235, 226, 216);
        this.btnQuanLyBan.Location = new System.Drawing.Point(0, 112);
        this.btnQuanLyBan.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
        this.btnQuanLyBan.Name = "btnQuanLyBan";
        this.btnQuanLyBan.Size = new System.Drawing.Size(204, 46);
        this.btnQuanLyBan.TabIndex = 2;
        this.btnQuanLyBan.Text = "Quản lý bàn";
        this.btnQuanLyBan.UseVisualStyleBackColor = false;
        // 
        // btnQuanLyNhanVien
        // 
        this.btnQuanLyNhanVien.BackColor = System.Drawing.Color.FromArgb(247, 245, 242);
        this.btnQuanLyNhanVien.BorderColor = System.Drawing.Color.FromArgb(232, 226, 217);
        this.btnQuanLyNhanVien.BorderRadius = 8;
        this.btnQuanLyNhanVien.BorderSize = 1;
        this.btnQuanLyNhanVien.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnQuanLyNhanVien.FlatAppearance.BorderSize = 0;
        this.btnQuanLyNhanVien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnQuanLyNhanVien.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.btnQuanLyNhanVien.ForeColor = System.Drawing.Color.FromArgb(43, 37, 32);
        this.btnQuanLyNhanVien.HoverBackColor = System.Drawing.Color.FromArgb(235, 226, 216);
        this.btnQuanLyNhanVien.Location = new System.Drawing.Point(0, 168);
        this.btnQuanLyNhanVien.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
        this.btnQuanLyNhanVien.Name = "btnQuanLyNhanVien";
        this.btnQuanLyNhanVien.Size = new System.Drawing.Size(204, 46);
        this.btnQuanLyNhanVien.TabIndex = 3;
        this.btnQuanLyNhanVien.Text = "Quản lý nhân viên";
        this.btnQuanLyNhanVien.UseVisualStyleBackColor = false;
        // 
        // btnBaoCao
        // 
        this.btnBaoCao.BackColor = System.Drawing.Color.FromArgb(247, 245, 242);
        this.btnBaoCao.BorderColor = System.Drawing.Color.FromArgb(232, 226, 217);
        this.btnBaoCao.BorderRadius = 8;
        this.btnBaoCao.BorderSize = 1;
        this.btnBaoCao.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnBaoCao.FlatAppearance.BorderSize = 0;
        this.btnBaoCao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnBaoCao.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.btnBaoCao.ForeColor = System.Drawing.Color.FromArgb(43, 37, 32);
        this.btnBaoCao.HoverBackColor = System.Drawing.Color.FromArgb(235, 226, 216);
        this.btnBaoCao.Location = new System.Drawing.Point(0, 224);
        this.btnBaoCao.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
        this.btnBaoCao.Name = "btnBaoCao";
        this.btnBaoCao.Size = new System.Drawing.Size(204, 46);
        this.btnBaoCao.TabIndex = 4;
        this.btnBaoCao.Text = "Báo cáo doanh thu";
        this.btnBaoCao.UseVisualStyleBackColor = false;
        // 
        // lblGhiChuAdmin
        // 
        this.lblGhiChuAdmin.Font = new System.Drawing.Font("Segoe UI", 8.5F);
        this.lblGhiChuAdmin.ForeColor = System.Drawing.Color.FromArgb(125, 117, 109);
        this.lblGhiChuAdmin.Location = new System.Drawing.Point(0, 280);
        this.lblGhiChuAdmin.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
        this.lblGhiChuAdmin.Name = "lblGhiChuAdmin";
        this.lblGhiChuAdmin.Size = new System.Drawing.Size(204, 40);
        this.lblGhiChuAdmin.TabIndex = 5;
        this.lblGhiChuAdmin.Text = "(*) Chỉ tài khoản Admin mới mở được";
        this.lblGhiChuAdmin.Visible = false;
        // 
        // FrmMain
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.FromArgb(247, 245, 242);
        this.ClientSize = new System.Drawing.Size(1366, 820);
        this.Controls.Add(this.pnlBody);
        this.Controls.Add(this.pnlHeader);
        this.MinimumSize = new System.Drawing.Size(1200, 750);
        this.Name = "FrmMain";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Cà Phê Hương Việt - Hệ Thống Bán Hàng & Quản Trị POS";
        this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        this.pnlHeader.ResumeLayout(false);
        this.pnlHeader.PerformLayout();
        this.pnlHeaderLeft.ResumeLayout(false);
        this.pnlHeaderLeft.PerformLayout();
        this.flpHeaderRight.ResumeLayout(false);
        this.flpHeaderRight.PerformLayout();
        this.pnlBody.ResumeLayout(false);
        this.pnlCenter.ResumeLayout(false);
        this.pnlLocKhuVuc.ResumeLayout(false);
        this.pnlLocKhuVuc.PerformLayout();
        this.pnlBill.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHoaDon)).EndInit();
        this.pnlActions.ResumeLayout(false);
        this.tblCacNutThaoTac.ResumeLayout(false);
        this.pnlTongTienRow.ResumeLayout(false);
        this.pnlTongTienRow.PerformLayout();
        this.pnlBillHeader.ResumeLayout(false);
        this.pnlBillHeader.PerformLayout();
        this.pnlSidebar.ResumeLayout(false);
        this.flpMenu.ResumeLayout(false);
        this.ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.Panel pnlHeader;
    private System.Windows.Forms.Panel pnlHeaderLeft;
    private System.Windows.Forms.Label lblTenQuan;
    private System.Windows.Forms.Label lblPhuDe;
    private System.Windows.Forms.FlowLayoutPanel flpHeaderRight;
    private CoffeeShopManagement.Components.RjButton btnDangXuat;
    private System.Windows.Forms.Label lblVaiTro;
    private System.Windows.Forms.Label lblTenNhanVien;
    private System.Windows.Forms.Panel pnlBody;
    private System.Windows.Forms.Panel pnlSidebar;
    private System.Windows.Forms.FlowLayoutPanel flpMenu;
    private CoffeeShopManagement.Components.RjButton btnBanHang;
    private CoffeeShopManagement.Components.RjButton btnThucDon;
    private CoffeeShopManagement.Components.RjButton btnQuanLyBan;
    private CoffeeShopManagement.Components.RjButton btnQuanLyNhanVien;
    private CoffeeShopManagement.Components.RjButton btnBaoCao;
    private System.Windows.Forms.Label lblGhiChuAdmin;
    private System.Windows.Forms.Panel pnlBill;
    private System.Windows.Forms.Panel pnlBillHeader;
    private System.Windows.Forms.Label lblBanDangChon;
    private System.Windows.Forms.Label lblTrangThaiBan;
    private System.Windows.Forms.DataGridView dgvChiTietHoaDon;
    private System.Windows.Forms.Panel pnlActions;
    private System.Windows.Forms.Panel pnlTongTienRow;
    private System.Windows.Forms.Label lblTieuDeTamTinh;
    private System.Windows.Forms.Label lblTongTamTinh;
    private System.Windows.Forms.TableLayoutPanel tblCacNutThaoTac;
    private CoffeeShopManagement.Components.RjButton btnThemMon;
    private CoffeeShopManagement.Components.RjButton btnDoiBan;
    private CoffeeShopManagement.Components.RjButton btnGopBan;
    private CoffeeShopManagement.Components.RjButton btnThanhToan;
    private System.Windows.Forms.Panel pnlCenter;
    private System.Windows.Forms.Panel pnlLocKhuVuc;
    private System.Windows.Forms.Label lblLocKhuVuc;
    private System.Windows.Forms.ComboBox cboKhuVuc;
    private System.Windows.Forms.Label lblThongKeBan;
    private System.Windows.Forms.FlowLayoutPanel flpDanhSachBan;
}
