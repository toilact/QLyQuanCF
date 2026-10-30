namespace CoffeeShopManagement.Forms;

partial class FrmReport
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
        this.pnlFilter = new System.Windows.Forms.Panel();
        this.btnXuatExcel = new CoffeeShopManagement.Components.RjButton();
        this.flpFilterLeft = new System.Windows.Forms.FlowLayoutPanel();
        this.lblTuNgay = new System.Windows.Forms.Label();
        this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
        this.lblDenNgay = new System.Windows.Forms.Label();
        this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
        this.btnThongKe = new CoffeeShopManagement.Components.RjButton();
        this.btnHomNay = new CoffeeShopManagement.Components.RjButton();
        this.btnThangNay = new CoffeeShopManagement.Components.RjButton();
        this.pnlKpiContainer = new System.Windows.Forms.Panel();
        this.tblKpi = new System.Windows.Forms.TableLayoutPanel();
        this.pnlCardDoanhThu = new System.Windows.Forms.Panel();
        this.lblTongDoanhThu = new System.Windows.Forms.Label();
        this.lblTieuDeDoanhThu = new System.Windows.Forms.Label();
        this.pnlCardHoaDon = new System.Windows.Forms.Panel();
        this.lblTongHoaDon = new System.Windows.Forms.Label();
        this.lblTieuDeHoaDon = new System.Windows.Forms.Label();
        this.pnlCardTrungBinh = new System.Windows.Forms.Panel();
        this.lblGiaTriTrungBinh = new System.Windows.Forms.Label();
        this.lblTieuDeTrungBinh = new System.Windows.Forms.Label();
        this.pnlTabsContainer = new System.Windows.Forms.Panel();
        this.tabBaoCao = new System.Windows.Forms.TabControl();
        this.tabHoaDon = new System.Windows.Forms.TabPage();
        this.dgvHoaDon = new System.Windows.Forms.DataGridView();
        this.tabTopSanPham = new System.Windows.Forms.TabPage();
        this.dgvTopSanPham = new System.Windows.Forms.DataGridView();
        this.pnlFilter.SuspendLayout();
        this.flpFilterLeft.SuspendLayout();
        this.pnlKpiContainer.SuspendLayout();
        this.tblKpi.SuspendLayout();
        this.pnlCardDoanhThu.SuspendLayout();
        this.pnlCardHoaDon.SuspendLayout();
        this.pnlCardTrungBinh.SuspendLayout();
        this.pnlTabsContainer.SuspendLayout();
        this.tabBaoCao.SuspendLayout();
        this.tabHoaDon.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
        this.tabTopSanPham.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvTopSanPham)).BeginInit();
        this.SuspendLayout();
        // 
        // pnlFilter
        // 
        this.pnlFilter.BackColor = System.Drawing.Color.White;
        this.pnlFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.pnlFilter.Controls.Add(this.btnXuatExcel);
        this.pnlFilter.Controls.Add(this.flpFilterLeft);
        this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
        this.pnlFilter.Location = new System.Drawing.Point(0, 0);
        this.pnlFilter.Name = "pnlFilter";
        this.pnlFilter.Padding = new System.Windows.Forms.Padding(20, 12, 20, 12);
        this.pnlFilter.Size = new System.Drawing.Size(1220, 65);
        this.pnlFilter.TabIndex = 0;
        // 
        // btnXuatExcel
        // 
        this.btnXuatExcel.BackColor = System.Drawing.Color.FromArgb(29, 111, 66);
        this.btnXuatExcel.BorderColor = System.Drawing.Color.FromArgb(232, 226, 217);
        this.btnXuatExcel.BorderRadius = 6;
        this.btnXuatExcel.BorderSize = 0;
        this.btnXuatExcel.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnXuatExcel.Dock = System.Windows.Forms.DockStyle.Right;
        this.btnXuatExcel.FlatAppearance.BorderSize = 0;
        this.btnXuatExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnXuatExcel.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.btnXuatExcel.ForeColor = System.Drawing.Color.White;
        this.btnXuatExcel.HoverBackColor = System.Drawing.Color.FromArgb(38, 135, 82);
        this.btnXuatExcel.Location = new System.Drawing.Point(988, 12);
        this.btnXuatExcel.Name = "btnXuatExcel";
        this.btnXuatExcel.Size = new System.Drawing.Size(210, 39);
        this.btnXuatExcel.TabIndex = 1;
        this.btnXuatExcel.Text = "XUẤT BÁO CÁO EXCEL";
        this.btnXuatExcel.UseVisualStyleBackColor = false;
        // 
        // flpFilterLeft
        // 
        this.flpFilterLeft.AutoSize = true;
        this.flpFilterLeft.BackColor = System.Drawing.Color.Transparent;
        this.flpFilterLeft.Controls.Add(this.lblTuNgay);
        this.flpFilterLeft.Controls.Add(this.dtpTuNgay);
        this.flpFilterLeft.Controls.Add(this.lblDenNgay);
        this.flpFilterLeft.Controls.Add(this.dtpDenNgay);
        this.flpFilterLeft.Controls.Add(this.btnThongKe);
        this.flpFilterLeft.Controls.Add(this.btnHomNay);
        this.flpFilterLeft.Controls.Add(this.btnThangNay);
        this.flpFilterLeft.Dock = System.Windows.Forms.DockStyle.Left;
        this.flpFilterLeft.Location = new System.Drawing.Point(20, 12);
        this.flpFilterLeft.Name = "flpFilterLeft";
        this.flpFilterLeft.Size = new System.Drawing.Size(760, 39);
        this.flpFilterLeft.TabIndex = 0;
        this.flpFilterLeft.WrapContents = false;
        // 
        // lblTuNgay
        // 
        this.lblTuNgay.AutoSize = true;
        this.lblTuNgay.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblTuNgay.Location = new System.Drawing.Point(0, 8);
        this.lblTuNgay.Margin = new System.Windows.Forms.Padding(0, 8, 4, 0);
        this.lblTuNgay.Name = "lblTuNgay";
        this.lblTuNgay.Size = new System.Drawing.Size(62, 17);
        this.lblTuNgay.TabIndex = 0;
        this.lblTuNgay.Text = "Từ ngày:";
        // 
        // dtpTuNgay
        // 
        this.dtpTuNgay.CustomFormat = "dd/MM/yyyy";
        this.dtpTuNgay.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
        this.dtpTuNgay.Location = new System.Drawing.Point(66, 4);
        this.dtpTuNgay.Margin = new System.Windows.Forms.Padding(0, 4, 16, 0);
        this.dtpTuNgay.Name = "dtpTuNgay";
        this.dtpTuNgay.Size = new System.Drawing.Size(130, 24);
        this.dtpTuNgay.TabIndex = 1;
        // 
        // lblDenNgay
        // 
        this.lblDenNgay.AutoSize = true;
        this.lblDenNgay.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblDenNgay.Location = new System.Drawing.Point(212, 8);
        this.lblDenNgay.Margin = new System.Windows.Forms.Padding(0, 8, 4, 0);
        this.lblDenNgay.Name = "lblDenNgay";
        this.lblDenNgay.Size = new System.Drawing.Size(70, 17);
        this.lblDenNgay.TabIndex = 2;
        this.lblDenNgay.Text = "Đến ngày:";
        // 
        // dtpDenNgay
        // 
        this.dtpDenNgay.CustomFormat = "dd/MM/yyyy";
        this.dtpDenNgay.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
        this.dtpDenNgay.Location = new System.Drawing.Point(286, 4);
        this.dtpDenNgay.Margin = new System.Windows.Forms.Padding(0, 4, 16, 0);
        this.dtpDenNgay.Name = "dtpDenNgay";
        this.dtpDenNgay.Size = new System.Drawing.Size(130, 24);
        this.dtpDenNgay.TabIndex = 3;
        // 
        // btnThongKe
        // 
        this.btnThongKe.BackColor = System.Drawing.Color.FromArgb(61, 40, 23);
        this.btnThongKe.BorderColor = System.Drawing.Color.FromArgb(232, 226, 217);
        this.btnThongKe.BorderRadius = 6;
        this.btnThongKe.BorderSize = 0;
        this.btnThongKe.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnThongKe.FlatAppearance.BorderSize = 0;
        this.btnThongKe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnThongKe.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.btnThongKe.ForeColor = System.Drawing.Color.White;
        this.btnThongKe.HoverBackColor = System.Drawing.Color.FromArgb(83, 56, 33);
        this.btnThongKe.Location = new System.Drawing.Point(432, 2);
        this.btnThongKe.Margin = new System.Windows.Forms.Padding(0, 2, 10, 0);
        this.btnThongKe.Name = "btnThongKe";
        this.btnThongKe.Size = new System.Drawing.Size(115, 34);
        this.btnThongKe.TabIndex = 4;
        this.btnThongKe.Text = "THỐNG KÊ";
        this.btnThongKe.UseVisualStyleBackColor = false;
        // 
        // btnHomNay
        // 
        this.btnHomNay.BackColor = System.Drawing.Color.FromArgb(247, 245, 242);
        this.btnHomNay.BorderColor = System.Drawing.Color.FromArgb(232, 226, 217);
        this.btnHomNay.BorderRadius = 6;
        this.btnHomNay.BorderSize = 1;
        this.btnHomNay.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnHomNay.FlatAppearance.BorderSize = 0;
        this.btnHomNay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnHomNay.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.btnHomNay.ForeColor = System.Drawing.Color.FromArgb(43, 37, 32);
        this.btnHomNay.HoverBackColor = System.Drawing.Color.FromArgb(235, 226, 216);
        this.btnHomNay.Location = new System.Drawing.Point(557, 2);
        this.btnHomNay.Margin = new System.Windows.Forms.Padding(0, 2, 8, 0);
        this.btnHomNay.Name = "btnHomNay";
        this.btnHomNay.Size = new System.Drawing.Size(95, 34);
        this.btnHomNay.TabIndex = 5;
        this.btnHomNay.Text = "Hôm nay";
        this.btnHomNay.UseVisualStyleBackColor = false;
        // 
        // btnThangNay
        // 
        this.btnThangNay.BackColor = System.Drawing.Color.FromArgb(247, 245, 242);
        this.btnThangNay.BorderColor = System.Drawing.Color.FromArgb(232, 226, 217);
        this.btnThangNay.BorderRadius = 6;
        this.btnThangNay.BorderSize = 1;
        this.btnThangNay.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnThangNay.FlatAppearance.BorderSize = 0;
        this.btnThangNay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnThangNay.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.btnThangNay.ForeColor = System.Drawing.Color.FromArgb(43, 37, 32);
        this.btnThangNay.HoverBackColor = System.Drawing.Color.FromArgb(235, 226, 216);
        this.btnThangNay.Location = new System.Drawing.Point(660, 2);
        this.btnThangNay.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
        this.btnThangNay.Name = "btnThangNay";
        this.btnThangNay.Size = new System.Drawing.Size(100, 34);
        this.btnThangNay.TabIndex = 6;
        this.btnThangNay.Text = "Tháng này";
        this.btnThangNay.UseVisualStyleBackColor = false;
        // 
        // pnlKpiContainer
        // 
        this.pnlKpiContainer.BackColor = System.Drawing.Color.FromArgb(247, 245, 242);
        this.pnlKpiContainer.Controls.Add(this.tblKpi);
        this.pnlKpiContainer.Dock = System.Windows.Forms.DockStyle.Top;
        this.pnlKpiContainer.Location = new System.Drawing.Point(0, 65);
        this.pnlKpiContainer.Name = "pnlKpiContainer";
        this.pnlKpiContainer.Padding = new System.Windows.Forms.Padding(20, 12, 20, 10);
        this.pnlKpiContainer.Size = new System.Drawing.Size(1220, 115);
        this.pnlKpiContainer.TabIndex = 1;
        // 
        // tblKpi
        // 
        this.tblKpi.ColumnCount = 3;
        this.tblKpi.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
        this.tblKpi.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
        this.tblKpi.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
        this.tblKpi.Controls.Add(this.pnlCardDoanhThu, 0, 0);
        this.tblKpi.Controls.Add(this.pnlCardHoaDon, 1, 0);
        this.tblKpi.Controls.Add(this.pnlCardTrungBinh, 2, 0);
        this.tblKpi.Dock = System.Windows.Forms.DockStyle.Fill;
        this.tblKpi.Location = new System.Drawing.Point(20, 12);
        this.tblKpi.Name = "tblKpi";
        this.tblKpi.RowCount = 1;
        this.tblKpi.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        this.tblKpi.Size = new System.Drawing.Size(1180, 93);
        this.tblKpi.TabIndex = 0;
        // 
        // pnlCardDoanhThu
        // 
        this.pnlCardDoanhThu.BackColor = System.Drawing.Color.White;
        this.pnlCardDoanhThu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.pnlCardDoanhThu.Controls.Add(this.lblTongDoanhThu);
        this.pnlCardDoanhThu.Controls.Add(this.lblTieuDeDoanhThu);
        this.pnlCardDoanhThu.Dock = System.Windows.Forms.DockStyle.Fill;
        this.pnlCardDoanhThu.Location = new System.Drawing.Point(6, 6);
        this.pnlCardDoanhThu.Margin = new System.Windows.Forms.Padding(6);
        this.pnlCardDoanhThu.Name = "pnlCardDoanhThu";
        this.pnlCardDoanhThu.Padding = new System.Windows.Forms.Padding(16, 12, 16, 12);
        this.pnlCardDoanhThu.Size = new System.Drawing.Size(381, 81);
        this.pnlCardDoanhThu.TabIndex = 0;
        // 
        // lblTongDoanhThu
        // 
        this.lblTongDoanhThu.Dock = System.Windows.Forms.DockStyle.Fill;
        this.lblTongDoanhThu.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
        this.lblTongDoanhThu.ForeColor = System.Drawing.Color.FromArgb(200, 90, 50);
        this.lblTongDoanhThu.Location = new System.Drawing.Point(16, 32);
        this.lblTongDoanhThu.Name = "lblTongDoanhThu";
        this.lblTongDoanhThu.Size = new System.Drawing.Size(347, 35);
        this.lblTongDoanhThu.TabIndex = 1;
        this.lblTongDoanhThu.Text = "0 đ";
        this.lblTongDoanhThu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lblTieuDeDoanhThu
        // 
        this.lblTieuDeDoanhThu.Dock = System.Windows.Forms.DockStyle.Top;
        this.lblTieuDeDoanhThu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        this.lblTieuDeDoanhThu.ForeColor = System.Drawing.Color.FromArgb(125, 117, 109);
        this.lblTieuDeDoanhThu.Location = new System.Drawing.Point(16, 12);
        this.lblTieuDeDoanhThu.Name = "lblTieuDeDoanhThu";
        this.lblTieuDeDoanhThu.Size = new System.Drawing.Size(347, 20);
        this.lblTieuDeDoanhThu.TabIndex = 0;
        this.lblTieuDeDoanhThu.Text = "TỔNG DOANH THU";
        // 
        // pnlCardHoaDon
        // 
        this.pnlCardHoaDon.BackColor = System.Drawing.Color.White;
        this.pnlCardHoaDon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.pnlCardHoaDon.Controls.Add(this.lblTongHoaDon);
        this.pnlCardHoaDon.Controls.Add(this.lblTieuDeHoaDon);
        this.pnlCardHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
        this.pnlCardHoaDon.Location = new System.Drawing.Point(399, 6);
        this.pnlCardHoaDon.Margin = new System.Windows.Forms.Padding(6);
        this.pnlCardHoaDon.Name = "pnlCardHoaDon";
        this.pnlCardHoaDon.Padding = new System.Windows.Forms.Padding(16, 12, 16, 12);
        this.pnlCardHoaDon.Size = new System.Drawing.Size(381, 81);
        this.pnlCardHoaDon.TabIndex = 1;
        // 
        // lblTongHoaDon
        // 
        this.lblTongHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
        this.lblTongHoaDon.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
        this.lblTongHoaDon.ForeColor = System.Drawing.Color.FromArgb(61, 40, 23);
        this.lblTongHoaDon.Location = new System.Drawing.Point(16, 32);
        this.lblTongHoaDon.Name = "lblTongHoaDon";
        this.lblTongHoaDon.Size = new System.Drawing.Size(347, 35);
        this.lblTongHoaDon.TabIndex = 1;
        this.lblTongHoaDon.Text = "0 đơn";
        this.lblTongHoaDon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lblTieuDeHoaDon
        // 
        this.lblTieuDeHoaDon.Dock = System.Windows.Forms.DockStyle.Top;
        this.lblTieuDeHoaDon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        this.lblTieuDeHoaDon.ForeColor = System.Drawing.Color.FromArgb(125, 117, 109);
        this.lblTieuDeHoaDon.Location = new System.Drawing.Point(16, 12);
        this.lblTieuDeHoaDon.Name = "lblTieuDeHoaDon";
        this.lblTieuDeHoaDon.Size = new System.Drawing.Size(347, 20);
        this.lblTieuDeHoaDon.TabIndex = 0;
        this.lblTieuDeHoaDon.Text = "TỔNG SỐ HÓA ĐƠN ĐÃ BÁN";
        // 
        // pnlCardTrungBinh
        // 
        this.pnlCardTrungBinh.BackColor = System.Drawing.Color.White;
        this.pnlCardTrungBinh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.pnlCardTrungBinh.Controls.Add(this.lblGiaTriTrungBinh);
        this.pnlCardTrungBinh.Controls.Add(this.lblTieuDeTrungBinh);
        this.pnlCardTrungBinh.Dock = System.Windows.Forms.DockStyle.Fill;
        this.pnlCardTrungBinh.Location = new System.Drawing.Point(792, 6);
        this.pnlCardTrungBinh.Margin = new System.Windows.Forms.Padding(6);
        this.pnlCardTrungBinh.Name = "pnlCardTrungBinh";
        this.pnlCardTrungBinh.Padding = new System.Windows.Forms.Padding(16, 12, 16, 12);
        this.pnlCardTrungBinh.Size = new System.Drawing.Size(382, 81);
        this.pnlCardTrungBinh.TabIndex = 2;
        // 
        // lblGiaTriTrungBinh
        // 
        this.lblGiaTriTrungBinh.Dock = System.Windows.Forms.DockStyle.Fill;
        this.lblGiaTriTrungBinh.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
        this.lblGiaTriTrungBinh.ForeColor = System.Drawing.Color.FromArgb(198, 139, 89);
        this.lblGiaTriTrungBinh.Location = new System.Drawing.Point(16, 32);
        this.lblGiaTriTrungBinh.Name = "lblGiaTriTrungBinh";
        this.lblGiaTriTrungBinh.Size = new System.Drawing.Size(348, 35);
        this.lblGiaTriTrungBinh.TabIndex = 1;
        this.lblGiaTriTrungBinh.Text = "0 đ";
        this.lblGiaTriTrungBinh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lblTieuDeTrungBinh
        // 
        this.lblTieuDeTrungBinh.Dock = System.Windows.Forms.DockStyle.Top;
        this.lblTieuDeTrungBinh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        this.lblTieuDeTrungBinh.ForeColor = System.Drawing.Color.FromArgb(125, 117, 109);
        this.lblTieuDeTrungBinh.Location = new System.Drawing.Point(16, 12);
        this.lblTieuDeTrungBinh.Name = "lblTieuDeTrungBinh";
        this.lblTieuDeTrungBinh.Size = new System.Drawing.Size(348, 20);
        this.lblTieuDeTrungBinh.TabIndex = 0;
        this.lblTieuDeTrungBinh.Text = "GIÁ TRỊ ĐƠN TRUNG BÌNH";
        // 
        // pnlTabsContainer
        // 
        this.pnlTabsContainer.BackColor = System.Drawing.Color.FromArgb(247, 245, 242);
        this.pnlTabsContainer.Controls.Add(this.tabBaoCao);
        this.pnlTabsContainer.Dock = System.Windows.Forms.DockStyle.Fill;
        this.pnlTabsContainer.Location = new System.Drawing.Point(0, 180);
        this.pnlTabsContainer.Name = "pnlTabsContainer";
        this.pnlTabsContainer.Padding = new System.Windows.Forms.Padding(20, 0, 20, 20);
        this.pnlTabsContainer.Size = new System.Drawing.Size(1220, 600);
        this.pnlTabsContainer.TabIndex = 2;
        // 
        // tabBaoCao
        // 
        this.tabBaoCao.Controls.Add(this.tabHoaDon);
        this.tabBaoCao.Controls.Add(this.tabTopSanPham);
        this.tabBaoCao.Dock = System.Windows.Forms.DockStyle.Fill;
        this.tabBaoCao.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.tabBaoCao.Location = new System.Drawing.Point(20, 0);
        this.tabBaoCao.Name = "tabBaoCao";
        this.tabBaoCao.Padding = new System.Drawing.Point(20, 8);
        this.tabBaoCao.SelectedIndex = 0;
        this.tabBaoCao.Size = new System.Drawing.Size(1180, 580);
        this.tabBaoCao.TabIndex = 0;
        // 
        // tabHoaDon
        // 
        this.tabHoaDon.BackColor = System.Drawing.Color.FromArgb(247, 245, 242);
        this.tabHoaDon.Controls.Add(this.dgvHoaDon);
        this.tabHoaDon.Location = new System.Drawing.Point(4, 34);
        this.tabHoaDon.Name = "tabHoaDon";
        this.tabHoaDon.Padding = new System.Windows.Forms.Padding(12);
        this.tabHoaDon.Size = new System.Drawing.Size(1172, 542);
        this.tabHoaDon.TabIndex = 0;
        this.tabHoaDon.Text = "  Danh Sách Hóa Đơn Thanh Toán  ";
        // 
        // dgvHoaDon
        // 
        this.dgvHoaDon.BackgroundColor = System.Drawing.Color.White;
        this.dgvHoaDon.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.dgvHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dgvHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
        this.dgvHoaDon.Location = new System.Drawing.Point(12, 12);
        this.dgvHoaDon.Name = "dgvHoaDon";
        this.dgvHoaDon.Size = new System.Drawing.Size(1148, 518);
        this.dgvHoaDon.TabIndex = 0;
        // 
        // tabTopSanPham
        // 
        this.tabTopSanPham.BackColor = System.Drawing.Color.FromArgb(247, 245, 242);
        this.tabTopSanPham.Controls.Add(this.dgvTopSanPham);
        this.tabTopSanPham.Location = new System.Drawing.Point(4, 34);
        this.tabTopSanPham.Name = "tabTopSanPham";
        this.tabTopSanPham.Padding = new System.Windows.Forms.Padding(12);
        this.tabTopSanPham.Size = new System.Drawing.Size(1172, 542);
        this.tabTopSanPham.TabIndex = 1;
        this.tabTopSanPham.Text = "  Top Sản Phẩm Bán Chạy  ";
        // 
        // dgvTopSanPham
        // 
        this.dgvTopSanPham.BackgroundColor = System.Drawing.Color.White;
        this.dgvTopSanPham.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.dgvTopSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dgvTopSanPham.Dock = System.Windows.Forms.DockStyle.Fill;
        this.dgvTopSanPham.Location = new System.Drawing.Point(12, 12);
        this.dgvTopSanPham.Name = "dgvTopSanPham";
        this.dgvTopSanPham.Size = new System.Drawing.Size(1148, 518);
        this.dgvTopSanPham.TabIndex = 0;
        // 
        // FrmReport
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.FromArgb(247, 245, 242);
        this.ClientSize = new System.Drawing.Size(1220, 780);
        this.Controls.Add(this.pnlTabsContainer);
        this.Controls.Add(this.pnlKpiContainer);
        this.Controls.Add(this.pnlFilter);
        this.MinimumSize = new System.Drawing.Size(1050, 680);
        this.Name = "FrmReport";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Báo Cáo Doanh Thu và Thống Kê Bán Hàng";
        this.pnlFilter.ResumeLayout(false);
        this.pnlFilter.PerformLayout();
        this.flpFilterLeft.ResumeLayout(false);
        this.flpFilterLeft.PerformLayout();
        this.pnlKpiContainer.ResumeLayout(false);
        this.tblKpi.ResumeLayout(false);
        this.pnlCardDoanhThu.ResumeLayout(false);
        this.pnlCardHoaDon.ResumeLayout(false);
        this.pnlCardTrungBinh.ResumeLayout(false);
        this.pnlTabsContainer.ResumeLayout(false);
        this.tabBaoCao.ResumeLayout(false);
        this.tabHoaDon.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
        this.tabTopSanPham.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.dgvTopSanPham)).EndInit();
        this.ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.Panel pnlFilter;
    private System.Windows.Forms.FlowLayoutPanel flpFilterLeft;
    private System.Windows.Forms.Label lblTuNgay;
    private System.Windows.Forms.DateTimePicker dtpTuNgay;
    private System.Windows.Forms.Label lblDenNgay;
    private System.Windows.Forms.DateTimePicker dtpDenNgay;
    private CoffeeShopManagement.Components.RjButton btnThongKe;
    private CoffeeShopManagement.Components.RjButton btnHomNay;
    private CoffeeShopManagement.Components.RjButton btnThangNay;
    private CoffeeShopManagement.Components.RjButton btnXuatExcel;
    private System.Windows.Forms.Panel pnlKpiContainer;
    private System.Windows.Forms.TableLayoutPanel tblKpi;
    private System.Windows.Forms.Panel pnlCardDoanhThu;
    private System.Windows.Forms.Label lblTieuDeDoanhThu;
    private System.Windows.Forms.Label lblTongDoanhThu;
    private System.Windows.Forms.Panel pnlCardHoaDon;
    private System.Windows.Forms.Label lblTieuDeHoaDon;
    private System.Windows.Forms.Label lblTongHoaDon;
    private System.Windows.Forms.Panel pnlCardTrungBinh;
    private System.Windows.Forms.Label lblTieuDeTrungBinh;
    private System.Windows.Forms.Label lblGiaTriTrungBinh;
    private System.Windows.Forms.Panel pnlTabsContainer;
    private System.Windows.Forms.TabControl tabBaoCao;
    private System.Windows.Forms.TabPage tabHoaDon;
    private System.Windows.Forms.DataGridView dgvHoaDon;
    private System.Windows.Forms.TabPage tabTopSanPham;
    private System.Windows.Forms.DataGridView dgvTopSanPham;
}
