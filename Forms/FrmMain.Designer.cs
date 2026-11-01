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
        pnlHeader = new Panel();
        pnlHeaderLeft = new Panel();
        lblTenQuan = new Label();
        lblPhuDe = new Label();
        lblVaiTro = new Label();
        flpHeaderRight = new FlowLayoutPanel();
        btnDangXuat = new CoffeeShopManagement.Components.RjButton();
        pnlBody = new Panel();
        pnlCenter = new Panel();
        flpDanhSachBan = new FlowLayoutPanel();
        pnlLocKhuVuc = new Panel();
        lblThongKeBan = new Label();
        cboKhuVuc = new ComboBox();
        lblLocKhuVuc = new Label();
        pnlBill = new Panel();
        dgvChiTietHoaDon = new DataGridView();
        pnlActions = new Panel();
        btnThanhToan = new CoffeeShopManagement.Components.RjButton();
        tblCacNutThaoTac = new TableLayoutPanel();
        btnThemMon = new CoffeeShopManagement.Components.RjButton();
        btnDoiBan = new CoffeeShopManagement.Components.RjButton();
        btnGopBan = new CoffeeShopManagement.Components.RjButton();
        pnlTongTienRow = new Panel();
        lblTongTamTinh = new Label();
        lblTieuDeTamTinh = new Label();
        pnlBillHeader = new Panel();
        lblTrangThaiBan = new Label();
        lblBanDangChon = new Label();
        pnlSidebar = new Panel();
        flpMenu = new FlowLayoutPanel();
        btnBanHang = new CoffeeShopManagement.Components.RjButton();
        btnThucDon = new CoffeeShopManagement.Components.RjButton();
        btnQuanLyBan = new CoffeeShopManagement.Components.RjButton();
        btnQuanLyNhanVien = new CoffeeShopManagement.Components.RjButton();
        btnBaoCao = new CoffeeShopManagement.Components.RjButton();
        lblGhiChuAdmin = new Label();
        pnlHeader.SuspendLayout();
        pnlHeaderLeft.SuspendLayout();
        flpHeaderRight.SuspendLayout();
        pnlBody.SuspendLayout();
        pnlCenter.SuspendLayout();
        pnlLocKhuVuc.SuspendLayout();
        pnlBill.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvChiTietHoaDon).BeginInit();
        pnlActions.SuspendLayout();
        tblCacNutThaoTac.SuspendLayout();
        pnlTongTienRow.SuspendLayout();
        pnlBillHeader.SuspendLayout();
        pnlSidebar.SuspendLayout();
        flpMenu.SuspendLayout();
        SuspendLayout();
        // 
        // pnlHeader
        // 
        pnlHeader.BackColor = Color.FromArgb(61, 40, 23);
        pnlHeader.Controls.Add(pnlHeaderLeft);
        pnlHeader.Controls.Add(lblVaiTro);
        pnlHeader.Controls.Add(flpHeaderRight);
        pnlHeader.Dock = DockStyle.Top;
        pnlHeader.Location = new Point(0, 0);
        pnlHeader.Margin = new Padding(4, 5, 4, 5);
        pnlHeader.Name = "pnlHeader";
        pnlHeader.Padding = new Padding(34, 0, 29, 0);
        pnlHeader.Size = new Size(1924, 108);
        pnlHeader.TabIndex = 0;
        // 
        // pnlHeaderLeft
        // 
        pnlHeaderLeft.BackColor = Color.Transparent;
        pnlHeaderLeft.Controls.Add(lblTenQuan);
        pnlHeaderLeft.Controls.Add(lblPhuDe);
        pnlHeaderLeft.Dock = DockStyle.Left;
        pnlHeaderLeft.Location = new Point(34, 0);
        pnlHeaderLeft.Margin = new Padding(4, 5, 4, 5);
        pnlHeaderLeft.Name = "pnlHeaderLeft";
        pnlHeaderLeft.Size = new Size(500, 108);
        pnlHeaderLeft.TabIndex = 0;
        // 
        // lblTenQuan
        // 
        lblTenQuan.AutoSize = true;
        lblTenQuan.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
        lblTenQuan.ForeColor = Color.White;
        lblTenQuan.Location = new Point(0, 17);
        lblTenQuan.Margin = new Padding(4, 0, 4, 0);
        lblTenQuan.Name = "lblTenQuan";
        lblTenQuan.Size = new Size(318, 41);
        lblTenQuan.TabIndex = 0;
        lblTenQuan.Text = "CÀ PHÊ HƯƠNG VIỆT";
        // 
        // lblPhuDe
        // 
        lblPhuDe.AutoSize = true;
        lblPhuDe.Font = new Font("Segoe UI", 9F);
        lblPhuDe.ForeColor = Color.FromArgb(212, 199, 186);
        lblPhuDe.Location = new Point(3, 63);
        lblPhuDe.Margin = new Padding(4, 0, 4, 0);
        lblPhuDe.Name = "lblPhuDe";
        lblPhuDe.Size = new Size(325, 25);
        lblPhuDe.TabIndex = 1;
        lblPhuDe.Text = "Hệ thống POS bán hàng & Quản trị quán";
        // 
        // lblVaiTro
        // 
        lblVaiTro.BackColor = Color.FromArgb(198, 139, 89);
        lblVaiTro.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
        lblVaiTro.ForeColor = Color.White;
        lblVaiTro.Location = new Point(1104, 40);
        lblVaiTro.Margin = new Padding(17, 8, 0, 0);
        lblVaiTro.Name = "lblVaiTro";
        lblVaiTro.Size = new Size(164, 43);
        lblVaiTro.TabIndex = 1;
        lblVaiTro.Text = "QUẢN TRỊ VIÊN";
        lblVaiTro.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // flpHeaderRight
        // 
        flpHeaderRight.AutoSize = true;
        flpHeaderRight.BackColor = Color.Transparent;
        flpHeaderRight.Controls.Add(btnDangXuat);
        flpHeaderRight.Dock = DockStyle.Right;
        flpHeaderRight.FlowDirection = FlowDirection.RightToLeft;
        flpHeaderRight.Location = new Point(1735, 0);
        flpHeaderRight.Margin = new Padding(4, 5, 4, 5);
        flpHeaderRight.Name = "flpHeaderRight";
        flpHeaderRight.Padding = new Padding(0, 23, 0, 0);
        flpHeaderRight.Size = new Size(160, 108);
        flpHeaderRight.TabIndex = 1;
        // 
        // btnDangXuat
        // 
        btnDangXuat.BackColor = Color.FromArgb(198, 139, 89);
        btnDangXuat.Cursor = Cursors.Hand;
        btnDangXuat.FlatAppearance.BorderSize = 0;
        btnDangXuat.FlatStyle = FlatStyle.Flat;
        btnDangXuat.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        btnDangXuat.ForeColor = Color.White;
        btnDangXuat.Location = new Point(17, 23);
        btnDangXuat.Margin = new Padding(17, 0, 0, 0);
        btnDangXuat.Name = "btnDangXuat";
        btnDangXuat.Size = new Size(143, 60);
        btnDangXuat.TabIndex = 0;
        btnDangXuat.Text = "Đăng xuất";
        btnDangXuat.UseMnemonic = false;
        btnDangXuat.UseVisualStyleBackColor = false;
        // 
        // pnlBody
        // 
        pnlBody.BackColor = Color.FromArgb(247, 245, 242);
        pnlBody.Controls.Add(pnlCenter);
        pnlBody.Controls.Add(pnlBill);
        pnlBody.Controls.Add(pnlSidebar);
        pnlBody.Dock = DockStyle.Fill;
        pnlBody.Location = new Point(0, 108);
        pnlBody.Margin = new Padding(4, 5, 4, 5);
        pnlBody.Name = "pnlBody";
        pnlBody.Size = new Size(1924, 942);
        pnlBody.TabIndex = 1;
        // 
        // pnlCenter
        // 
        pnlCenter.BackColor = Color.FromArgb(247, 245, 242);
        pnlCenter.Controls.Add(flpDanhSachBan);
        pnlCenter.Controls.Add(pnlLocKhuVuc);
        pnlCenter.Dock = DockStyle.Fill;
        pnlCenter.Location = new Point(328, 0);
        pnlCenter.Margin = new Padding(4, 5, 4, 5);
        pnlCenter.Name = "pnlCenter";
        pnlCenter.Padding = new Padding(29, 27, 29, 27);
        pnlCenter.Size = new Size(940, 942);
        pnlCenter.TabIndex = 2;
        // 
        // flpDanhSachBan
        // 
        flpDanhSachBan.AutoScroll = true;
        flpDanhSachBan.BackColor = Color.Transparent;
        flpDanhSachBan.Dock = DockStyle.Fill;
        flpDanhSachBan.Location = new Point(29, 110);
        flpDanhSachBan.Margin = new Padding(4, 5, 4, 5);
        flpDanhSachBan.Name = "flpDanhSachBan";
        flpDanhSachBan.Padding = new Padding(6, 7, 6, 7);
        flpDanhSachBan.Size = new Size(882, 805);
        flpDanhSachBan.TabIndex = 1;
        // 
        // pnlLocKhuVuc
        // 
        pnlLocKhuVuc.BackColor = Color.Transparent;
        pnlLocKhuVuc.Controls.Add(lblThongKeBan);
        pnlLocKhuVuc.Controls.Add(cboKhuVuc);
        pnlLocKhuVuc.Controls.Add(lblLocKhuVuc);
        pnlLocKhuVuc.Dock = DockStyle.Top;
        pnlLocKhuVuc.Location = new Point(29, 27);
        pnlLocKhuVuc.Margin = new Padding(4, 5, 4, 5);
        pnlLocKhuVuc.Name = "pnlLocKhuVuc";
        pnlLocKhuVuc.Size = new Size(882, 83);
        pnlLocKhuVuc.TabIndex = 0;
        // 
        // lblThongKeBan
        // 
         lblThongKeBan.AutoSize = false;
         lblThongKeBan.AutoEllipsis = true;
         lblThongKeBan.Dock = DockStyle.Right;
        lblThongKeBan.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblThongKeBan.ForeColor = Color.FromArgb(125, 117, 109);
         lblThongKeBan.Location = new Point(457, 0);
        lblThongKeBan.Margin = new Padding(4, 0, 4, 0);
        lblThongKeBan.Name = "lblThongKeBan";
         lblThongKeBan.Size = new Size(400, 83);
        lblThongKeBan.TabIndex = 2;
         lblThongKeBan.TextAlign = ContentAlignment.MiddleRight;
         lblThongKeBan.Text = "Thống kê bàn quán";
        // 
        // cboKhuVuc
        // 
        cboKhuVuc.DropDownStyle = ComboBoxStyle.DropDownList;
        cboKhuVuc.Font = new Font("Segoe UI", 9.5F);
        cboKhuVuc.FormattingEnabled = true;
        cboKhuVuc.Location = new Point(136, 13);
        cboKhuVuc.Margin = new Padding(4, 5, 4, 5);
        cboKhuVuc.Name = "cboKhuVuc";
        cboKhuVuc.Size = new Size(284, 33);
        cboKhuVuc.TabIndex = 1;
        // 
        // lblLocKhuVuc
        // 
        lblLocKhuVuc.AutoSize = true;
        lblLocKhuVuc.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblLocKhuVuc.ForeColor = Color.FromArgb(43, 37, 32);
        lblLocKhuVuc.Location = new Point(0, 18);
        lblLocKhuVuc.Margin = new Padding(4, 0, 4, 0);
        lblLocKhuVuc.Name = "lblLocKhuVuc";
        lblLocKhuVuc.Size = new Size(130, 28);
        lblLocKhuVuc.TabIndex = 0;
        lblLocKhuVuc.Text = "Lọc khu vực:";
        // 
        // pnlBill
        // 
        pnlBill.BackColor = Color.White;
        pnlBill.BorderStyle = BorderStyle.FixedSingle;
        pnlBill.Controls.Add(dgvChiTietHoaDon);
        pnlBill.Controls.Add(pnlActions);
        pnlBill.Controls.Add(pnlBillHeader);
        pnlBill.Dock = DockStyle.Right;
        pnlBill.Location = new Point(1268, 0);
        pnlBill.Margin = new Padding(4, 5, 4, 5);
        pnlBill.Name = "pnlBill";
        pnlBill.Padding = new Padding(23, 27, 23, 27);
        pnlBill.Size = new Size(656, 942);
        pnlBill.TabIndex = 1;
        // 
        // dgvChiTietHoaDon
        // 
        dgvChiTietHoaDon.BackgroundColor = Color.White;
        dgvChiTietHoaDon.BorderStyle = BorderStyle.None;
        dgvChiTietHoaDon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvChiTietHoaDon.Dock = DockStyle.Fill;
        dgvChiTietHoaDon.Location = new Point(23, 102);
        dgvChiTietHoaDon.Margin = new Padding(4, 5, 4, 5);
        dgvChiTietHoaDon.Name = "dgvChiTietHoaDon";
        dgvChiTietHoaDon.RowHeadersWidth = 62;
        dgvChiTietHoaDon.ScrollBars = ScrollBars.Vertical;
        dgvChiTietHoaDon.Size = new Size(608, 478);
        dgvChiTietHoaDon.TabIndex = 1;
        // 
        // pnlActions
        // 
        pnlActions.BackColor = Color.White;
        pnlActions.Controls.Add(btnThanhToan);
        pnlActions.Controls.Add(tblCacNutThaoTac);
        pnlActions.Controls.Add(pnlTongTienRow);
        pnlActions.Dock = DockStyle.Bottom;
        pnlActions.Location = new Point(23, 580);
        pnlActions.Margin = new Padding(4, 5, 4, 5);
        pnlActions.Name = "pnlActions";
        pnlActions.Padding = new Padding(0, 17, 0, 0);
        pnlActions.Size = new Size(608, 333);
        pnlActions.TabIndex = 2;
        // 
        // btnThanhToan
        // 
        btnThanhToan.BackColor = Color.FromArgb(61, 40, 23);
        btnThanhToan.Cursor = Cursors.Hand;
        btnThanhToan.Dock = DockStyle.Bottom;
        btnThanhToan.FlatAppearance.BorderSize = 0;
        btnThanhToan.FlatStyle = FlatStyle.Flat;
        btnThanhToan.Font = new Font("Segoe UI", 11.5F, FontStyle.Bold);
        btnThanhToan.ForeColor = Color.White;
        btnThanhToan.Location = new Point(0, 246);
        btnThanhToan.Margin = new Padding(4, 5, 4, 5);
        btnThanhToan.Name = "btnThanhToan";
        btnThanhToan.Size = new Size(608, 87);
        btnThanhToan.TabIndex = 2;
        btnThanhToan.Text = "THANH TOÁN VÀ IN HÓA ĐƠN";
        btnThanhToan.UseMnemonic = false;
        btnThanhToan.UseVisualStyleBackColor = false;
        // 
        // tblCacNutThaoTac
        // 
        tblCacNutThaoTac.ColumnCount = 3;
        tblCacNutThaoTac.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
        tblCacNutThaoTac.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 32.5F));
        tblCacNutThaoTac.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 32.5F));
        tblCacNutThaoTac.Controls.Add(btnThemMon, 0, 0);
        tblCacNutThaoTac.Controls.Add(btnDoiBan, 1, 0);
        tblCacNutThaoTac.Controls.Add(btnGopBan, 2, 0);
        tblCacNutThaoTac.Dock = DockStyle.Top;
        tblCacNutThaoTac.Location = new Point(0, 84);
        tblCacNutThaoTac.Margin = new Padding(0, 13, 0, 13);
        tblCacNutThaoTac.Name = "tblCacNutThaoTac";
        tblCacNutThaoTac.RowCount = 1;
        tblCacNutThaoTac.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tblCacNutThaoTac.Size = new Size(608, 80);
        tblCacNutThaoTac.TabIndex = 1;
        // 
        // btnThemMon
        // 
        btnThemMon.BackColor = Color.FromArgb(198, 139, 89);
        btnThemMon.Cursor = Cursors.Hand;
        btnThemMon.Dock = DockStyle.Fill;
        btnThemMon.FlatAppearance.BorderSize = 0;
        btnThemMon.FlatStyle = FlatStyle.Flat;
        btnThemMon.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        btnThemMon.ForeColor = Color.White;
        btnThemMon.Location = new Point(4, 5);
        btnThemMon.Margin = new Padding(4, 5, 4, 5);
        btnThemMon.Name = "btnThemMon";
        btnThemMon.Size = new Size(204, 70);
        btnThemMon.TabIndex = 0;
        btnThemMon.Text = "+ THÊM MÓN";
        btnThemMon.UseMnemonic = false;
        btnThemMon.UseVisualStyleBackColor = false;
        // 
        // btnDoiBan
        // 
        btnDoiBan.BackColor = Color.White;
        btnDoiBan.Cursor = Cursors.Hand;
        btnDoiBan.Dock = DockStyle.Fill;
        btnDoiBan.FlatAppearance.BorderSize = 0;
        btnDoiBan.FlatStyle = FlatStyle.Flat;
        btnDoiBan.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        btnDoiBan.ForeColor = Color.FromArgb(43, 37, 32);
        btnDoiBan.Location = new Point(216, 5);
        btnDoiBan.Margin = new Padding(4, 5, 4, 5);
        btnDoiBan.Name = "btnDoiBan";
        btnDoiBan.Size = new Size(189, 70);
        btnDoiBan.TabIndex = 1;
        btnDoiBan.Text = "ĐỔI BÀN";
        btnDoiBan.UseMnemonic = false;
        btnDoiBan.UseVisualStyleBackColor = false;
        // 
        // btnGopBan
        // 
        btnGopBan.BackColor = Color.White;
        btnGopBan.Cursor = Cursors.Hand;
        btnGopBan.Dock = DockStyle.Fill;
        btnGopBan.FlatAppearance.BorderSize = 0;
        btnGopBan.FlatStyle = FlatStyle.Flat;
        btnGopBan.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        btnGopBan.ForeColor = Color.FromArgb(43, 37, 32);
        btnGopBan.Location = new Point(413, 5);
        btnGopBan.Margin = new Padding(4, 5, 4, 5);
        btnGopBan.Name = "btnGopBan";
        btnGopBan.Size = new Size(191, 70);
        btnGopBan.TabIndex = 2;
        btnGopBan.Text = "GỘP BÀN";
        btnGopBan.UseMnemonic = false;
        btnGopBan.UseVisualStyleBackColor = false;
        // 
        // pnlTongTienRow
        // 
        pnlTongTienRow.BackColor = Color.Transparent;
        pnlTongTienRow.Controls.Add(lblTongTamTinh);
        pnlTongTienRow.Controls.Add(lblTieuDeTamTinh);
        pnlTongTienRow.Dock = DockStyle.Top;
        pnlTongTienRow.Location = new Point(0, 17);
        pnlTongTienRow.Margin = new Padding(4, 5, 4, 5);
        pnlTongTienRow.Name = "pnlTongTienRow";
        pnlTongTienRow.Size = new Size(608, 67);
        pnlTongTienRow.TabIndex = 0;
        // 
        // lblTongTamTinh
        // 
        lblTongTamTinh.Dock = DockStyle.Right;
        lblTongTamTinh.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblTongTamTinh.ForeColor = Color.FromArgb(200, 90, 50);
        lblTongTamTinh.Location = new Point(265, 0);
        lblTongTamTinh.Margin = new Padding(4, 0, 4, 0);
        lblTongTamTinh.Name = "lblTongTamTinh";
        lblTongTamTinh.Size = new Size(343, 67);
        lblTongTamTinh.TabIndex = 1;
        lblTongTamTinh.Text = "0 đ";
        lblTongTamTinh.TextAlign = ContentAlignment.MiddleRight;
        // 
        // lblTieuDeTamTinh
        // 
        lblTieuDeTamTinh.AutoSize = true;
        lblTieuDeTamTinh.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        lblTieuDeTamTinh.ForeColor = Color.FromArgb(43, 37, 32);
        lblTieuDeTamTinh.Location = new Point(0, 13);
        lblTieuDeTamTinh.Margin = new Padding(4, 0, 4, 0);
        lblTieuDeTamTinh.Name = "lblTieuDeTamTinh";
        lblTieuDeTamTinh.Size = new Size(216, 32);
        lblTieuDeTamTinh.TabIndex = 0;
        lblTieuDeTamTinh.Text = "TỔNG TẠM TÍNH:";
        // 
        // pnlBillHeader
        // 
        pnlBillHeader.BackColor = Color.Transparent;
        pnlBillHeader.Controls.Add(lblTrangThaiBan);
        pnlBillHeader.Controls.Add(lblBanDangChon);
        pnlBillHeader.Dock = DockStyle.Top;
        pnlBillHeader.Location = new Point(23, 27);
        pnlBillHeader.Margin = new Padding(4, 5, 4, 5);
        pnlBillHeader.Name = "pnlBillHeader";
        pnlBillHeader.Size = new Size(608, 75);
        pnlBillHeader.TabIndex = 0;
        // 
        // lblTrangThaiBan
        // 
        lblTrangThaiBan.Dock = DockStyle.Right;
        lblTrangThaiBan.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblTrangThaiBan.Location = new Point(408, 0);
        lblTrangThaiBan.Margin = new Padding(4, 0, 4, 0);
        lblTrangThaiBan.Name = "lblTrangThaiBan";
        lblTrangThaiBan.Size = new Size(200, 75);
        lblTrangThaiBan.TabIndex = 1;
        lblTrangThaiBan.TextAlign = ContentAlignment.MiddleRight;
        // 
        // lblBanDangChon
        // 
        lblBanDangChon.AutoSize = true;
        lblBanDangChon.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        lblBanDangChon.ForeColor = Color.FromArgb(61, 40, 23);
        lblBanDangChon.Location = new Point(0, 17);
        lblBanDangChon.Margin = new Padding(4, 0, 4, 0);
        lblBanDangChon.Name = "lblBanDangChon";
        lblBanDangChon.Size = new Size(257, 32);
        lblBanDangChon.TabIndex = 0;
        lblBanDangChon.Text = "Chọn bàn để thao tác";
        // 
        // pnlSidebar
        // 
        pnlSidebar.BackColor = Color.White;
        pnlSidebar.BorderStyle = BorderStyle.FixedSingle;
        pnlSidebar.Controls.Add(flpMenu);
        pnlSidebar.Dock = DockStyle.Left;
        pnlSidebar.Location = new Point(0, 0);
        pnlSidebar.Margin = new Padding(4, 5, 4, 5);
        pnlSidebar.Name = "pnlSidebar";
        pnlSidebar.Padding = new Padding(17, 27, 17, 27);
        pnlSidebar.Size = new Size(328, 942);
        pnlSidebar.TabIndex = 0;
        // 
        // flpMenu
        // 
        flpMenu.AutoScroll = true;
        flpMenu.Controls.Add(btnBanHang);
        flpMenu.Controls.Add(btnThucDon);
        flpMenu.Controls.Add(btnQuanLyBan);
        flpMenu.Controls.Add(btnQuanLyNhanVien);
        flpMenu.Controls.Add(btnBaoCao);
        flpMenu.Controls.Add(lblGhiChuAdmin);
        flpMenu.Dock = DockStyle.Fill;
        flpMenu.FlowDirection = FlowDirection.TopDown;
        flpMenu.Location = new Point(17, 27);
        flpMenu.Margin = new Padding(4, 5, 4, 5);
        flpMenu.Name = "flpMenu";
        flpMenu.Size = new Size(292, 886);
        flpMenu.TabIndex = 0;
        flpMenu.WrapContents = false;
        // 
        // btnBanHang
        // 
        btnBanHang.BackColor = Color.FromArgb(247, 245, 242);
        btnBanHang.Cursor = Cursors.Hand;
        btnBanHang.FlatAppearance.BorderSize = 0;
        btnBanHang.FlatStyle = FlatStyle.Flat;
        btnBanHang.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        btnBanHang.ForeColor = Color.FromArgb(43, 37, 32);
        btnBanHang.Location = new Point(0, 0);
        btnBanHang.Margin = new Padding(0, 0, 0, 17);
        btnBanHang.Name = "btnBanHang";
        btnBanHang.Size = new Size(291, 77);
        btnBanHang.TabIndex = 0;
        btnBanHang.Text = "Bán hàng (POS)";
        btnBanHang.UseMnemonic = false;
        btnBanHang.UseVisualStyleBackColor = false;
        // 
        // btnThucDon
        // 
        btnThucDon.BackColor = Color.FromArgb(247, 245, 242);
        btnThucDon.Cursor = Cursors.Hand;
        btnThucDon.FlatAppearance.BorderSize = 0;
        btnThucDon.FlatStyle = FlatStyle.Flat;
        btnThucDon.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        btnThucDon.ForeColor = Color.FromArgb(43, 37, 32);
        btnThucDon.Location = new Point(0, 94);
        btnThucDon.Margin = new Padding(0, 0, 0, 17);
        btnThucDon.Name = "btnThucDon";
        btnThucDon.Size = new Size(291, 77);
        btnThucDon.TabIndex = 1;
        btnThucDon.Text = "Thực đơn món";
        btnThucDon.UseMnemonic = false;
        btnThucDon.UseVisualStyleBackColor = false;
        // 
        // btnQuanLyBan
        // 
        btnQuanLyBan.BackColor = Color.FromArgb(247, 245, 242);
        btnQuanLyBan.Cursor = Cursors.Hand;
        btnQuanLyBan.FlatAppearance.BorderSize = 0;
        btnQuanLyBan.FlatStyle = FlatStyle.Flat;
        btnQuanLyBan.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        btnQuanLyBan.ForeColor = Color.FromArgb(43, 37, 32);
        btnQuanLyBan.Location = new Point(0, 188);
        btnQuanLyBan.Margin = new Padding(0, 0, 0, 17);
        btnQuanLyBan.Name = "btnQuanLyBan";
        btnQuanLyBan.Size = new Size(291, 77);
        btnQuanLyBan.TabIndex = 2;
        btnQuanLyBan.Text = "Quản lý bàn";
        btnQuanLyBan.UseMnemonic = false;
        btnQuanLyBan.UseVisualStyleBackColor = false;
        // 
        // btnQuanLyNhanVien
        // 
        btnQuanLyNhanVien.BackColor = Color.FromArgb(247, 245, 242);
        btnQuanLyNhanVien.Cursor = Cursors.Hand;
        btnQuanLyNhanVien.FlatAppearance.BorderSize = 0;
        btnQuanLyNhanVien.FlatStyle = FlatStyle.Flat;
        btnQuanLyNhanVien.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        btnQuanLyNhanVien.ForeColor = Color.FromArgb(43, 37, 32);
        btnQuanLyNhanVien.Location = new Point(0, 282);
        btnQuanLyNhanVien.Margin = new Padding(0, 0, 0, 17);
        btnQuanLyNhanVien.Name = "btnQuanLyNhanVien";
        btnQuanLyNhanVien.Size = new Size(291, 77);
        btnQuanLyNhanVien.TabIndex = 3;
        btnQuanLyNhanVien.Text = "Quản lý nhân viên";
        btnQuanLyNhanVien.UseMnemonic = false;
        btnQuanLyNhanVien.UseVisualStyleBackColor = false;
        // 
        // btnBaoCao
        // 
        btnBaoCao.BackColor = Color.FromArgb(247, 245, 242);
        btnBaoCao.Cursor = Cursors.Hand;
        btnBaoCao.FlatAppearance.BorderSize = 0;
        btnBaoCao.FlatStyle = FlatStyle.Flat;
        btnBaoCao.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        btnBaoCao.ForeColor = Color.FromArgb(43, 37, 32);
        btnBaoCao.Location = new Point(0, 376);
        btnBaoCao.Margin = new Padding(0, 0, 0, 17);
        btnBaoCao.Name = "btnBaoCao";
        btnBaoCao.Size = new Size(291, 77);
        btnBaoCao.TabIndex = 4;
        btnBaoCao.Text = "Báo cáo doanh thu";
        btnBaoCao.UseMnemonic = false;
        btnBaoCao.UseVisualStyleBackColor = false;
        // 
        // lblGhiChuAdmin
        // 
        lblGhiChuAdmin.Font = new Font("Segoe UI", 8.5F);
        lblGhiChuAdmin.ForeColor = Color.FromArgb(125, 117, 109);
        lblGhiChuAdmin.Location = new Point(0, 470);
        lblGhiChuAdmin.Margin = new Padding(0);
        lblGhiChuAdmin.Name = "lblGhiChuAdmin";
        lblGhiChuAdmin.Size = new Size(291, 67);
        lblGhiChuAdmin.TabIndex = 5;
        lblGhiChuAdmin.Text = "(*) Chỉ tài khoản Admin mới mở được";
        lblGhiChuAdmin.Visible = false;
        // 
        // FrmMain
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(247, 245, 242);
        ClientSize = new Size(1924, 1050);
        Controls.Add(pnlBody);
        Controls.Add(pnlHeader);
        Margin = new Padding(4, 5, 4, 5);
        MinimumSize = new Size(1705, 1078);
        Name = "FrmMain";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Cà Phê Hương Việt - Hệ Thống Bán Hàng & Quản Trị POS";
        WindowState = FormWindowState.Maximized;
        pnlHeader.ResumeLayout(false);
        pnlHeader.PerformLayout();
        pnlHeaderLeft.ResumeLayout(false);
        pnlHeaderLeft.PerformLayout();
        flpHeaderRight.ResumeLayout(false);
        pnlBody.ResumeLayout(false);
        pnlCenter.ResumeLayout(false);
        pnlLocKhuVuc.ResumeLayout(false);
        pnlLocKhuVuc.PerformLayout();
        pnlBill.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvChiTietHoaDon).EndInit();
        pnlActions.ResumeLayout(false);
        tblCacNutThaoTac.ResumeLayout(false);
        pnlTongTienRow.ResumeLayout(false);
        pnlTongTienRow.PerformLayout();
        pnlBillHeader.ResumeLayout(false);
        pnlBillHeader.PerformLayout();
        pnlSidebar.ResumeLayout(false);
        flpMenu.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.Panel pnlHeader;
    private System.Windows.Forms.Panel pnlHeaderLeft;
    private System.Windows.Forms.Label lblTenQuan;
    private System.Windows.Forms.Label lblPhuDe;
    private System.Windows.Forms.FlowLayoutPanel flpHeaderRight;
    private CoffeeShopManagement.Components.RjButton btnDangXuat;
    private System.Windows.Forms.Label lblVaiTro;
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
