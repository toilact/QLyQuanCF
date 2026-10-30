namespace CoffeeShopManagement.Forms;

partial class FrmCategoryProduct
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
        this.tabMain = new System.Windows.Forms.TabControl();
        this.tabMonAn = new System.Windows.Forms.TabPage();
        this.splitMonAn = new System.Windows.Forms.SplitContainer();
        this.flpInputsMon = new System.Windows.Forms.FlowLayoutPanel();
        this.lblDanhMucMon = new System.Windows.Forms.Label();
        this.cboDanhMucMon = new System.Windows.Forms.ComboBox();
        this.lblTenMon = new System.Windows.Forms.Label();
        this.txtTenMon = new System.Windows.Forms.TextBox();
        this.lblDonGia = new System.Windows.Forms.Label();
        this.nudDonGia = new System.Windows.Forms.NumericUpDown();
        this.lblDonViTinh = new System.Windows.Forms.Label();
        this.txtDonViTinh = new System.Windows.Forms.TextBox();
        this.chkDangKinhDoanh = new System.Windows.Forms.CheckBox();
        this.tblNutMon = new System.Windows.Forms.TableLayoutPanel();
        this.btnThemMon = new CoffeeShopManagement.Components.RjButton();
        this.btnCapNhatMon = new CoffeeShopManagement.Components.RjButton();
        this.btnXoaMon = new CoffeeShopManagement.Components.RjButton();
        this.btnLamMoiMon = new CoffeeShopManagement.Components.RjButton();
        this.lblTieuDeMon = new System.Windows.Forms.Label();
        this.dgvMonAn = new System.Windows.Forms.DataGridView();
        this.tabDanhMuc = new System.Windows.Forms.TabPage();
        this.splitDanhMuc = new System.Windows.Forms.SplitContainer();
        this.flpInputsDanhMuc = new System.Windows.Forms.FlowLayoutPanel();
        this.lblTenDanhMuc = new System.Windows.Forms.Label();
        this.txtTenDanhMuc = new System.Windows.Forms.TextBox();
        this.lblMoTaDanhMuc = new System.Windows.Forms.Label();
        this.txtMoTaDanhMuc = new System.Windows.Forms.TextBox();
        this.tblNutDanhMuc = new System.Windows.Forms.TableLayoutPanel();
        this.btnThemDanhMuc = new CoffeeShopManagement.Components.RjButton();
        this.btnCapNhatDanhMuc = new CoffeeShopManagement.Components.RjButton();
        this.btnXoaDanhMuc = new CoffeeShopManagement.Components.RjButton();
        this.btnLamMoiDanhMuc = new CoffeeShopManagement.Components.RjButton();
        this.lblTieuDeDanhMuc = new System.Windows.Forms.Label();
        this.dgvDanhMuc = new System.Windows.Forms.DataGridView();
        this.tabMain.SuspendLayout();
        this.tabMonAn.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.splitMonAn)).BeginInit();
        this.splitMonAn.Panel1.SuspendLayout();
        this.splitMonAn.Panel2.SuspendLayout();
        this.splitMonAn.SuspendLayout();
        this.flpInputsMon.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.nudDonGia)).BeginInit();
        this.tblNutMon.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvMonAn)).BeginInit();
        this.tabDanhMuc.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.splitDanhMuc)).BeginInit();
        this.splitDanhMuc.Panel1.SuspendLayout();
        this.splitDanhMuc.Panel2.SuspendLayout();
        this.splitDanhMuc.SuspendLayout();
        this.flpInputsDanhMuc.SuspendLayout();
        this.tblNutDanhMuc.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvDanhMuc)).BeginInit();
        this.SuspendLayout();
        // 
        // tabMain
        // 
        this.tabMain.Controls.Add(this.tabMonAn);
        this.tabMain.Controls.Add(this.tabDanhMuc);
        this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
        this.tabMain.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.tabMain.Location = new System.Drawing.Point(0, 0);
        this.tabMain.Name = "tabMain";
        this.tabMain.Padding = new System.Drawing.Point(20, 10);
        this.tabMain.SelectedIndex = 0;
        this.tabMain.Size = new System.Drawing.Size(1150, 720);
        this.tabMain.TabIndex = 0;
        // 
        // tabMonAn
        // 
        this.tabMonAn.BackColor = System.Drawing.Color.FromArgb(247, 245, 242);
        this.tabMonAn.Controls.Add(this.splitMonAn);
        this.tabMonAn.Location = new System.Drawing.Point(4, 38);
        this.tabMonAn.Name = "tabMonAn";
        this.tabMonAn.Size = new System.Drawing.Size(1142, 678);
        this.tabMonAn.TabIndex = 0;
        this.tabMonAn.Text = "  Món Ăn & Thức Uống  ";
        // 
        // splitMonAn
        // 
        this.splitMonAn.BackColor = System.Drawing.Color.FromArgb(232, 226, 217);
        this.splitMonAn.Dock = System.Windows.Forms.DockStyle.Fill;
        this.splitMonAn.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
        this.splitMonAn.IsSplitterFixed = true;
        this.splitMonAn.Location = new System.Drawing.Point(0, 0);
        this.splitMonAn.Name = "splitMonAn";
        // 
        // splitMonAn.Panel1
        // 
        this.splitMonAn.Panel1.BackColor = System.Drawing.Color.White;
        this.splitMonAn.Panel1.Controls.Add(this.flpInputsMon);
        this.splitMonAn.Panel1.Controls.Add(this.lblTieuDeMon);
        this.splitMonAn.Panel1.Padding = new System.Windows.Forms.Padding(24, 20, 24, 20);
        // 
        // splitMonAn.Panel2
        // 
        this.splitMonAn.Panel2.BackColor = System.Drawing.Color.FromArgb(247, 245, 242);
        this.splitMonAn.Panel2.Controls.Add(this.dgvMonAn);
        this.splitMonAn.Panel2.Padding = new System.Windows.Forms.Padding(16);
        this.splitMonAn.Size = new System.Drawing.Size(1142, 678);
        this.splitMonAn.SplitterDistance = 380;
        this.splitMonAn.TabIndex = 0;
        // 
        // flpInputsMon
        // 
        this.flpInputsMon.AutoScroll = true;
        this.flpInputsMon.Controls.Add(this.lblDanhMucMon);
        this.flpInputsMon.Controls.Add(this.cboDanhMucMon);
        this.flpInputsMon.Controls.Add(this.lblTenMon);
        this.flpInputsMon.Controls.Add(this.txtTenMon);
        this.flpInputsMon.Controls.Add(this.lblDonGia);
        this.flpInputsMon.Controls.Add(this.nudDonGia);
        this.flpInputsMon.Controls.Add(this.lblDonViTinh);
        this.flpInputsMon.Controls.Add(this.txtDonViTinh);
        this.flpInputsMon.Controls.Add(this.chkDangKinhDoanh);
        this.flpInputsMon.Controls.Add(this.tblNutMon);
        this.flpInputsMon.Controls.Add(this.btnLamMoiMon);
        this.flpInputsMon.Dock = System.Windows.Forms.DockStyle.Fill;
        this.flpInputsMon.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
        this.flpInputsMon.Location = new System.Drawing.Point(24, 55);
        this.flpInputsMon.Name = "flpInputsMon";
        this.flpInputsMon.Size = new System.Drawing.Size(332, 603);
        this.flpInputsMon.TabIndex = 1;
        this.flpInputsMon.WrapContents = false;
        // 
        // lblDanhMucMon
        // 
        this.lblDanhMucMon.AutoSize = true;
        this.lblDanhMucMon.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblDanhMucMon.ForeColor = System.Drawing.Color.FromArgb(43, 37, 32);
        this.lblDanhMucMon.Location = new System.Drawing.Point(0, 8);
        this.lblDanhMucMon.Margin = new System.Windows.Forms.Padding(0, 8, 0, 4);
        this.lblDanhMucMon.Name = "lblDanhMucMon";
        this.lblDanhMucMon.Size = new System.Drawing.Size(107, 17);
        this.lblDanhMucMon.TabIndex = 0;
        this.lblDanhMucMon.Text = "Danh mục món:";
        // 
        // cboDanhMucMon
        // 
        this.cboDanhMucMon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cboDanhMucMon.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.cboDanhMucMon.FormattingEnabled = true;
        this.cboDanhMucMon.Location = new System.Drawing.Point(0, 29);
        this.cboDanhMucMon.Margin = new System.Windows.Forms.Padding(0, 0, 0, 12);
        this.cboDanhMucMon.Name = "cboDanhMucMon";
        this.cboDanhMucMon.Size = new System.Drawing.Size(330, 25);
        this.cboDanhMucMon.TabIndex = 1;
        // 
        // lblTenMon
        // 
        this.lblTenMon.AutoSize = true;
        this.lblTenMon.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblTenMon.ForeColor = System.Drawing.Color.FromArgb(43, 37, 32);
        this.lblTenMon.Location = new System.Drawing.Point(0, 74);
        this.lblTenMon.Margin = new System.Windows.Forms.Padding(0, 8, 0, 4);
        this.lblTenMon.Name = "lblTenMon";
        this.lblTenMon.Size = new System.Drawing.Size(164, 17);
        this.lblTenMon.TabIndex = 2;
        this.lblTenMon.Text = "Tên món ăn / thức uống:";
        // 
        // txtTenMon
        // 
        this.txtTenMon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.txtTenMon.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.txtTenMon.Location = new System.Drawing.Point(0, 95);
        this.txtTenMon.Margin = new System.Windows.Forms.Padding(0, 0, 0, 12);
        this.txtTenMon.Name = "txtTenMon";
        this.txtTenMon.Size = new System.Drawing.Size(330, 24);
        this.txtTenMon.TabIndex = 3;
        // 
        // lblDonGia
        // 
        this.lblDonGia.AutoSize = true;
        this.lblDonGia.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblDonGia.ForeColor = System.Drawing.Color.FromArgb(43, 37, 32);
        this.lblDonGia.Location = new System.Drawing.Point(0, 139);
        this.lblDonGia.Margin = new System.Windows.Forms.Padding(0, 8, 0, 4);
        this.lblDonGia.Name = "lblDonGia";
        this.lblDonGia.Size = new System.Drawing.Size(99, 17);
        this.lblDonGia.TabIndex = 4;
        this.lblDonGia.Text = "Đơn giá (VNĐ):";
        // 
        // nudDonGia
        // 
        this.nudDonGia.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.nudDonGia.Increment = new decimal(new int[] { 5000, 0, 0, 0 });
        this.nudDonGia.Location = new System.Drawing.Point(0, 160);
        this.nudDonGia.Margin = new System.Windows.Forms.Padding(0, 0, 0, 12);
        this.nudDonGia.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
        this.nudDonGia.Name = "nudDonGia";
        this.nudDonGia.Size = new System.Drawing.Size(330, 24);
        this.nudDonGia.TabIndex = 5;
        // 
        // lblDonViTinh
        // 
        this.lblDonViTinh.AutoSize = true;
        this.lblDonViTinh.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblDonViTinh.ForeColor = System.Drawing.Color.FromArgb(43, 37, 32);
        this.lblDonViTinh.Location = new System.Drawing.Point(0, 204);
        this.lblDonViTinh.Margin = new System.Windows.Forms.Padding(0, 8, 0, 4);
        this.lblDonViTinh.Name = "lblDonViTinh";
        this.lblDonViTinh.Size = new System.Drawing.Size(182, 17);
        this.lblDonViTinh.TabIndex = 6;
        this.lblDonViTinh.Text = "Đơn vị tính (Ly, Tách, Đĩa...):";
        // 
        // txtDonViTinh
        // 
        this.txtDonViTinh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.txtDonViTinh.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.txtDonViTinh.Location = new System.Drawing.Point(0, 225);
        this.txtDonViTinh.Margin = new System.Windows.Forms.Padding(0, 0, 0, 12);
        this.txtDonViTinh.Name = "txtDonViTinh";
        this.txtDonViTinh.Size = new System.Drawing.Size(330, 24);
        this.txtDonViTinh.TabIndex = 7;
        this.txtDonViTinh.Text = "Ly";
        // 
        // chkDangKinhDoanh
        // 
        this.chkDangKinhDoanh.Checked = true;
        this.chkDangKinhDoanh.CheckState = System.Windows.Forms.CheckState.Checked;
        this.chkDangKinhDoanh.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.chkDangKinhDoanh.Location = new System.Drawing.Point(0, 265);
        this.chkDangKinhDoanh.Margin = new System.Windows.Forms.Padding(0, 4, 0, 16);
        this.chkDangKinhDoanh.Name = "chkDangKinhDoanh";
        this.chkDangKinhDoanh.Size = new System.Drawing.Size(330, 28);
        this.chkDangKinhDoanh.TabIndex = 8;
        this.chkDangKinhDoanh.Text = "Đang phục vụ (Có sẵn trong menu)";
        this.chkDangKinhDoanh.UseVisualStyleBackColor = true;
        // 
        // tblNutMon
        // 
        this.tblNutMon.ColumnCount = 3;
        this.tblNutMon.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3F));
        this.tblNutMon.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3F));
        this.tblNutMon.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.4F));
        this.tblNutMon.Controls.Add(this.btnThemMon, 0, 0);
        this.tblNutMon.Controls.Add(this.btnCapNhatMon, 1, 0);
        this.tblNutMon.Controls.Add(this.btnXoaMon, 2, 0);
        this.tblNutMon.Location = new System.Drawing.Point(0, 309);
        this.tblNutMon.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
        this.tblNutMon.Name = "tblNutMon";
        this.tblNutMon.RowCount = 1;
        this.tblNutMon.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        this.tblNutMon.Size = new System.Drawing.Size(330, 44);
        this.tblNutMon.TabIndex = 9;
        // 
        // btnThemMon
        // 
        this.btnThemMon.BackColor = System.Drawing.Color.FromArgb(61, 40, 23);
        this.btnThemMon.BorderColor = System.Drawing.Color.FromArgb(232, 226, 217);
        this.btnThemMon.BorderRadius = 6;
        this.btnThemMon.BorderSize = 0;
        this.btnThemMon.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnThemMon.Dock = System.Windows.Forms.DockStyle.Fill;
        this.btnThemMon.FlatAppearance.BorderSize = 0;
        this.btnThemMon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnThemMon.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.btnThemMon.ForeColor = System.Drawing.Color.White;
        this.btnThemMon.HoverBackColor = System.Drawing.Color.FromArgb(83, 56, 33);
        this.btnThemMon.Location = new System.Drawing.Point(3, 3);
        this.btnThemMon.Name = "btnThemMon";
        this.btnThemMon.Size = new System.Drawing.Size(103, 38);
        this.btnThemMon.TabIndex = 0;
        this.btnThemMon.Text = "Thêm mới";
        this.btnThemMon.UseVisualStyleBackColor = false;
        // 
        // btnCapNhatMon
        // 
        this.btnCapNhatMon.BackColor = System.Drawing.Color.FromArgb(198, 139, 89);
        this.btnCapNhatMon.BorderColor = System.Drawing.Color.FromArgb(232, 226, 217);
        this.btnCapNhatMon.BorderRadius = 6;
        this.btnCapNhatMon.BorderSize = 0;
        this.btnCapNhatMon.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnCapNhatMon.Dock = System.Windows.Forms.DockStyle.Fill;
        this.btnCapNhatMon.Enabled = false;
        this.btnCapNhatMon.FlatAppearance.BorderSize = 0;
        this.btnCapNhatMon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnCapNhatMon.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.btnCapNhatMon.ForeColor = System.Drawing.Color.White;
        this.btnCapNhatMon.HoverBackColor = System.Drawing.Color.FromArgb(216, 155, 103);
        this.btnCapNhatMon.Location = new System.Drawing.Point(112, 3);
        this.btnCapNhatMon.Name = "btnCapNhatMon";
        this.btnCapNhatMon.Size = new System.Drawing.Size(103, 38);
        this.btnCapNhatMon.TabIndex = 1;
        this.btnCapNhatMon.Text = "Cập nhật";
        this.btnCapNhatMon.UseVisualStyleBackColor = false;
        // 
        // btnXoaMon
        // 
        this.btnXoaMon.BackColor = System.Drawing.Color.FromArgb(200, 90, 50);
        this.btnXoaMon.BorderColor = System.Drawing.Color.FromArgb(232, 226, 217);
        this.btnXoaMon.BorderRadius = 6;
        this.btnXoaMon.BorderSize = 0;
        this.btnXoaMon.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnXoaMon.Dock = System.Windows.Forms.DockStyle.Fill;
        this.btnXoaMon.Enabled = false;
        this.btnXoaMon.FlatAppearance.BorderSize = 0;
        this.btnXoaMon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnXoaMon.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.btnXoaMon.ForeColor = System.Drawing.Color.White;
        this.btnXoaMon.HoverBackColor = System.Drawing.Color.FromArgb(178, 75, 39);
        this.btnXoaMon.Location = new System.Drawing.Point(221, 3);
        this.btnXoaMon.Name = "btnXoaMon";
        this.btnXoaMon.Size = new System.Drawing.Size(106, 38);
        this.btnXoaMon.TabIndex = 2;
        this.btnXoaMon.Text = "Xóa món";
        this.btnXoaMon.UseVisualStyleBackColor = false;
        // 
        // btnLamMoiMon
        // 
        this.btnLamMoiMon.BackColor = System.Drawing.Color.White;
        this.btnLamMoiMon.BorderColor = System.Drawing.Color.FromArgb(232, 226, 217);
        this.btnLamMoiMon.BorderRadius = 6;
        this.btnLamMoiMon.BorderSize = 1;
        this.btnLamMoiMon.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnLamMoiMon.FlatAppearance.BorderSize = 0;
        this.btnLamMoiMon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnLamMoiMon.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.btnLamMoiMon.ForeColor = System.Drawing.Color.FromArgb(43, 37, 32);
        this.btnLamMoiMon.HoverBackColor = System.Drawing.Color.FromArgb(240, 235, 229);
        this.btnLamMoiMon.Location = new System.Drawing.Point(0, 363);
        this.btnLamMoiMon.Margin = new System.Windows.Forms.Padding(0);
        this.btnLamMoiMon.Name = "btnLamMoiMon";
        this.btnLamMoiMon.Size = new System.Drawing.Size(330, 38);
        this.btnLamMoiMon.TabIndex = 10;
        this.btnLamMoiMon.Text = "Làm mới Form";
        this.btnLamMoiMon.UseVisualStyleBackColor = false;
        // 
        // lblTieuDeMon
        // 
        this.lblTieuDeMon.Dock = System.Windows.Forms.DockStyle.Top;
        this.lblTieuDeMon.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
        this.lblTieuDeMon.ForeColor = System.Drawing.Color.FromArgb(61, 40, 23);
        this.lblTieuDeMon.Location = new System.Drawing.Point(24, 20);
        this.lblTieuDeMon.Name = "lblTieuDeMon";
        this.lblTieuDeMon.Size = new System.Drawing.Size(332, 35);
        this.lblTieuDeMon.TabIndex = 0;
        this.lblTieuDeMon.Text = "THÔNG TIN MÓN ĂN";
        // 
        // dgvMonAn
        // 
        this.dgvMonAn.BackgroundColor = System.Drawing.Color.White;
        this.dgvMonAn.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.dgvMonAn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dgvMonAn.Dock = System.Windows.Forms.DockStyle.Fill;
        this.dgvMonAn.Location = new System.Drawing.Point(16, 16);
        this.dgvMonAn.Name = "dgvMonAn";
        this.dgvMonAn.Size = new System.Drawing.Size(726, 646);
        this.dgvMonAn.TabIndex = 0;
        // 
        // tabDanhMuc
        // 
        this.tabDanhMuc.BackColor = System.Drawing.Color.FromArgb(247, 245, 242);
        this.tabDanhMuc.Controls.Add(this.splitDanhMuc);
        this.tabDanhMuc.Location = new System.Drawing.Point(4, 38);
        this.tabDanhMuc.Name = "tabDanhMuc";
        this.tabDanhMuc.Size = new System.Drawing.Size(1142, 678);
        this.tabDanhMuc.TabIndex = 1;
        this.tabDanhMuc.Text = "  Danh Mục Món  ";
        // 
        // splitDanhMuc
        // 
        this.splitDanhMuc.BackColor = System.Drawing.Color.FromArgb(232, 226, 217);
        this.splitDanhMuc.Dock = System.Windows.Forms.DockStyle.Fill;
        this.splitDanhMuc.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
        this.splitDanhMuc.IsSplitterFixed = true;
        this.splitDanhMuc.Location = new System.Drawing.Point(0, 0);
        this.splitDanhMuc.Name = "splitDanhMuc";
        // 
        // splitDanhMuc.Panel1
        // 
        this.splitDanhMuc.Panel1.BackColor = System.Drawing.Color.White;
        this.splitDanhMuc.Panel1.Controls.Add(this.flpInputsDanhMuc);
        this.splitDanhMuc.Panel1.Controls.Add(this.lblTieuDeDanhMuc);
        this.splitDanhMuc.Panel1.Padding = new System.Windows.Forms.Padding(24, 20, 24, 20);
        // 
        // splitDanhMuc.Panel2
        // 
        this.splitDanhMuc.Panel2.BackColor = System.Drawing.Color.FromArgb(247, 245, 242);
        this.splitDanhMuc.Panel2.Controls.Add(this.dgvDanhMuc);
        this.splitDanhMuc.Panel2.Padding = new System.Windows.Forms.Padding(16);
        this.splitDanhMuc.Size = new System.Drawing.Size(1142, 678);
        this.splitDanhMuc.SplitterDistance = 380;
        this.splitDanhMuc.TabIndex = 0;
        // 
        // flpInputsDanhMuc
        // 
        this.flpInputsDanhMuc.Controls.Add(this.lblTenDanhMuc);
        this.flpInputsDanhMuc.Controls.Add(this.txtTenDanhMuc);
        this.flpInputsDanhMuc.Controls.Add(this.lblMoTaDanhMuc);
        this.flpInputsDanhMuc.Controls.Add(this.txtMoTaDanhMuc);
        this.flpInputsDanhMuc.Controls.Add(this.tblNutDanhMuc);
        this.flpInputsDanhMuc.Controls.Add(this.btnLamMoiDanhMuc);
        this.flpInputsDanhMuc.Dock = System.Windows.Forms.DockStyle.Fill;
        this.flpInputsDanhMuc.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
        this.flpInputsDanhMuc.Location = new System.Drawing.Point(24, 55);
        this.flpInputsDanhMuc.Name = "flpInputsDanhMuc";
        this.flpInputsDanhMuc.Size = new System.Drawing.Size(332, 603);
        this.flpInputsDanhMuc.TabIndex = 1;
        this.flpInputsDanhMuc.WrapContents = false;
        // 
        // lblTenDanhMuc
        // 
        this.lblTenDanhMuc.AutoSize = true;
        this.lblTenDanhMuc.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblTenDanhMuc.ForeColor = System.Drawing.Color.FromArgb(43, 37, 32);
        this.lblTenDanhMuc.Location = new System.Drawing.Point(0, 10);
        this.lblTenDanhMuc.Margin = new System.Windows.Forms.Padding(0, 10, 0, 4);
        this.lblTenDanhMuc.Name = "lblTenDanhMuc";
        this.lblTenDanhMuc.Size = new System.Drawing.Size(102, 17);
        this.lblTenDanhMuc.TabIndex = 0;
        this.lblTenDanhMuc.Text = "Tên danh mục:";
        // 
        // txtTenDanhMuc
        // 
        this.txtTenDanhMuc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.txtTenDanhMuc.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.txtTenDanhMuc.Location = new System.Drawing.Point(0, 31);
        this.txtTenDanhMuc.Margin = new System.Windows.Forms.Padding(0, 0, 0, 16);
        this.txtTenDanhMuc.Name = "txtTenDanhMuc";
        this.txtTenDanhMuc.Size = new System.Drawing.Size(330, 24);
        this.txtTenDanhMuc.TabIndex = 1;
        // 
        // lblMoTaDanhMuc
        // 
        this.lblMoTaDanhMuc.AutoSize = true;
        this.lblMoTaDanhMuc.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblMoTaDanhMuc.ForeColor = System.Drawing.Color.FromArgb(43, 37, 32);
        this.lblMoTaDanhMuc.Location = new System.Drawing.Point(0, 71);
        this.lblMoTaDanhMuc.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
        this.lblMoTaDanhMuc.Name = "lblMoTaDanhMuc";
        this.lblMoTaDanhMuc.Size = new System.Drawing.Size(116, 17);
        this.lblMoTaDanhMuc.TabIndex = 2;
        this.lblMoTaDanhMuc.Text = "Mô tả danh mục:";
        // 
        // txtMoTaDanhMuc
        // 
        this.txtMoTaDanhMuc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.txtMoTaDanhMuc.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.txtMoTaDanhMuc.Location = new System.Drawing.Point(0, 92);
        this.txtMoTaDanhMuc.Margin = new System.Windows.Forms.Padding(0, 0, 0, 20);
        this.txtMoTaDanhMuc.Multiline = true;
        this.txtMoTaDanhMuc.Name = "txtMoTaDanhMuc";
        this.txtMoTaDanhMuc.Size = new System.Drawing.Size(330, 90);
        this.txtMoTaDanhMuc.TabIndex = 3;
        // 
        // tblNutDanhMuc
        // 
        this.tblNutDanhMuc.ColumnCount = 3;
        this.tblNutDanhMuc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3F));
        this.tblNutDanhMuc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3F));
        this.tblNutDanhMuc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.4F));
        this.tblNutDanhMuc.Controls.Add(this.btnThemDanhMuc, 0, 0);
        this.tblNutDanhMuc.Controls.Add(this.btnCapNhatDanhMuc, 1, 0);
        this.tblNutDanhMuc.Controls.Add(this.btnXoaDanhMuc, 2, 0);
        this.tblNutDanhMuc.Location = new System.Drawing.Point(0, 202);
        this.tblNutDanhMuc.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
        this.tblNutDanhMuc.Name = "tblNutDanhMuc";
        this.tblNutDanhMuc.RowCount = 1;
        this.tblNutDanhMuc.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        this.tblNutDanhMuc.Size = new System.Drawing.Size(330, 44);
        this.tblNutDanhMuc.TabIndex = 4;
        // 
        // btnThemDanhMuc
        // 
        this.btnThemDanhMuc.BackColor = System.Drawing.Color.FromArgb(61, 40, 23);
        this.btnThemDanhMuc.BorderColor = System.Drawing.Color.FromArgb(232, 226, 217);
        this.btnThemDanhMuc.BorderRadius = 6;
        this.btnThemDanhMuc.BorderSize = 0;
        this.btnThemDanhMuc.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnThemDanhMuc.Dock = System.Windows.Forms.DockStyle.Fill;
        this.btnThemDanhMuc.FlatAppearance.BorderSize = 0;
        this.btnThemDanhMuc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnThemDanhMuc.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.btnThemDanhMuc.ForeColor = System.Drawing.Color.White;
        this.btnThemDanhMuc.HoverBackColor = System.Drawing.Color.FromArgb(83, 56, 33);
        this.btnThemDanhMuc.Location = new System.Drawing.Point(3, 3);
        this.btnThemDanhMuc.Name = "btnThemDanhMuc";
        this.btnThemDanhMuc.Size = new System.Drawing.Size(103, 38);
        this.btnThemDanhMuc.TabIndex = 0;
        this.btnThemDanhMuc.Text = "Thêm mới";
        this.btnThemDanhMuc.UseVisualStyleBackColor = false;
        // 
        // btnCapNhatDanhMuc
        // 
        this.btnCapNhatDanhMuc.BackColor = System.Drawing.Color.FromArgb(198, 139, 89);
        this.btnCapNhatDanhMuc.BorderColor = System.Drawing.Color.FromArgb(232, 226, 217);
        this.btnCapNhatDanhMuc.BorderRadius = 6;
        this.btnCapNhatDanhMuc.BorderSize = 0;
        this.btnCapNhatDanhMuc.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnCapNhatDanhMuc.Dock = System.Windows.Forms.DockStyle.Fill;
        this.btnCapNhatDanhMuc.Enabled = false;
        this.btnCapNhatDanhMuc.FlatAppearance.BorderSize = 0;
        this.btnCapNhatDanhMuc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnCapNhatDanhMuc.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.btnCapNhatDanhMuc.ForeColor = System.Drawing.Color.White;
        this.btnCapNhatDanhMuc.HoverBackColor = System.Drawing.Color.FromArgb(216, 155, 103);
        this.btnCapNhatDanhMuc.Location = new System.Drawing.Point(112, 3);
        this.btnCapNhatDanhMuc.Name = "btnCapNhatDanhMuc";
        this.btnCapNhatDanhMuc.Size = new System.Drawing.Size(103, 38);
        this.btnCapNhatDanhMuc.TabIndex = 1;
        this.btnCapNhatDanhMuc.Text = "Cập nhật";
        this.btnCapNhatDanhMuc.UseVisualStyleBackColor = false;
        // 
        // btnXoaDanhMuc
        // 
        this.btnXoaDanhMuc.BackColor = System.Drawing.Color.FromArgb(200, 90, 50);
        this.btnXoaDanhMuc.BorderColor = System.Drawing.Color.FromArgb(232, 226, 217);
        this.btnXoaDanhMuc.BorderRadius = 6;
        this.btnXoaDanhMuc.BorderSize = 0;
        this.btnXoaDanhMuc.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnXoaDanhMuc.Dock = System.Windows.Forms.DockStyle.Fill;
        this.btnXoaDanhMuc.Enabled = false;
        this.btnXoaDanhMuc.FlatAppearance.BorderSize = 0;
        this.btnXoaDanhMuc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnXoaDanhMuc.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.btnXoaDanhMuc.ForeColor = System.Drawing.Color.White;
        this.btnXoaDanhMuc.HoverBackColor = System.Drawing.Color.FromArgb(178, 75, 39);
        this.btnXoaDanhMuc.Location = new System.Drawing.Point(221, 3);
        this.btnXoaDanhMuc.Name = "btnXoaDanhMuc";
        this.btnXoaDanhMuc.Size = new System.Drawing.Size(106, 38);
        this.btnXoaDanhMuc.TabIndex = 2;
        this.btnXoaDanhMuc.Text = "Xóa";
        this.btnXoaDanhMuc.UseVisualStyleBackColor = false;
        // 
        // btnLamMoiDanhMuc
        // 
        this.btnLamMoiDanhMuc.BackColor = System.Drawing.Color.White;
        this.btnLamMoiDanhMuc.BorderColor = System.Drawing.Color.FromArgb(232, 226, 217);
        this.btnLamMoiDanhMuc.BorderRadius = 6;
        this.btnLamMoiDanhMuc.BorderSize = 1;
        this.btnLamMoiDanhMuc.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnLamMoiDanhMuc.FlatAppearance.BorderSize = 0;
        this.btnLamMoiDanhMuc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnLamMoiDanhMuc.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.btnLamMoiDanhMuc.ForeColor = System.Drawing.Color.FromArgb(43, 37, 32);
        this.btnLamMoiDanhMuc.HoverBackColor = System.Drawing.Color.FromArgb(240, 235, 229);
        this.btnLamMoiDanhMuc.Location = new System.Drawing.Point(0, 256);
        this.btnLamMoiDanhMuc.Margin = new System.Windows.Forms.Padding(0);
        this.btnLamMoiDanhMuc.Name = "btnLamMoiDanhMuc";
        this.btnLamMoiDanhMuc.Size = new System.Drawing.Size(330, 38);
        this.btnLamMoiDanhMuc.TabIndex = 5;
        this.btnLamMoiDanhMuc.Text = "Làm mới Form";
        this.btnLamMoiDanhMuc.UseVisualStyleBackColor = false;
        // 
        // lblTieuDeDanhMuc
        // 
        this.lblTieuDeDanhMuc.Dock = System.Windows.Forms.DockStyle.Top;
        this.lblTieuDeDanhMuc.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
        this.lblTieuDeDanhMuc.ForeColor = System.Drawing.Color.FromArgb(61, 40, 23);
        this.lblTieuDeDanhMuc.Location = new System.Drawing.Point(24, 20);
        this.lblTieuDeDanhMuc.Name = "lblTieuDeDanhMuc";
        this.lblTieuDeDanhMuc.Size = new System.Drawing.Size(332, 35);
        this.lblTieuDeDanhMuc.TabIndex = 0;
        this.lblTieuDeDanhMuc.Text = "THÔNG TIN DANH MỤC";
        // 
        // dgvDanhMuc
        // 
        this.dgvDanhMuc.BackgroundColor = System.Drawing.Color.White;
        this.dgvDanhMuc.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.dgvDanhMuc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dgvDanhMuc.Dock = System.Windows.Forms.DockStyle.Fill;
        this.dgvDanhMuc.Location = new System.Drawing.Point(16, 16);
        this.dgvDanhMuc.Name = "dgvDanhMuc";
        this.dgvDanhMuc.Size = new System.Drawing.Size(726, 646);
        this.dgvDanhMuc.TabIndex = 0;
        // 
        // FrmCategoryProduct
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.FromArgb(247, 245, 242);
        this.ClientSize = new System.Drawing.Size(1150, 720);
        this.Controls.Add(this.tabMain);
        this.MinimumSize = new System.Drawing.Size(1000, 650);
        this.Name = "FrmCategoryProduct";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Quản Lý Thực Đơn và Danh Mục Món";
        this.tabMain.ResumeLayout(false);
        this.tabMonAn.ResumeLayout(false);
        this.splitMonAn.Panel1.ResumeLayout(false);
        this.splitMonAn.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.splitMonAn)).EndInit();
        this.splitMonAn.ResumeLayout(false);
        this.flpInputsMon.ResumeLayout(false);
        this.flpInputsMon.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.nudDonGia)).EndInit();
        this.tblNutMon.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.dgvMonAn)).EndInit();
        this.tabDanhMuc.ResumeLayout(false);
        this.splitDanhMuc.Panel1.ResumeLayout(false);
        this.splitDanhMuc.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.splitDanhMuc)).EndInit();
        this.splitDanhMuc.ResumeLayout(false);
        this.flpInputsDanhMuc.ResumeLayout(false);
        this.flpInputsDanhMuc.PerformLayout();
        this.tblNutDanhMuc.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.dgvDanhMuc)).EndInit();
        this.ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.TabControl tabMain;
    private System.Windows.Forms.TabPage tabMonAn;
    private System.Windows.Forms.SplitContainer splitMonAn;
    private System.Windows.Forms.Label lblTieuDeMon;
    private System.Windows.Forms.FlowLayoutPanel flpInputsMon;
    private System.Windows.Forms.Label lblDanhMucMon;
    private System.Windows.Forms.ComboBox cboDanhMucMon;
    private System.Windows.Forms.Label lblTenMon;
    private System.Windows.Forms.TextBox txtTenMon;
    private System.Windows.Forms.Label lblDonGia;
    private System.Windows.Forms.NumericUpDown nudDonGia;
    private System.Windows.Forms.Label lblDonViTinh;
    private System.Windows.Forms.TextBox txtDonViTinh;
    private System.Windows.Forms.CheckBox chkDangKinhDoanh;
    private System.Windows.Forms.TableLayoutPanel tblNutMon;
    private CoffeeShopManagement.Components.RjButton btnThemMon;
    private CoffeeShopManagement.Components.RjButton btnCapNhatMon;
    private CoffeeShopManagement.Components.RjButton btnXoaMon;
    private CoffeeShopManagement.Components.RjButton btnLamMoiMon;
    private System.Windows.Forms.DataGridView dgvMonAn;
    private System.Windows.Forms.TabPage tabDanhMuc;
    private System.Windows.Forms.SplitContainer splitDanhMuc;
    private System.Windows.Forms.Label lblTieuDeDanhMuc;
    private System.Windows.Forms.FlowLayoutPanel flpInputsDanhMuc;
    private System.Windows.Forms.Label lblTenDanhMuc;
    private System.Windows.Forms.TextBox txtTenDanhMuc;
    private System.Windows.Forms.Label lblMoTaDanhMuc;
    private System.Windows.Forms.TextBox txtMoTaDanhMuc;
    private System.Windows.Forms.TableLayoutPanel tblNutDanhMuc;
    private CoffeeShopManagement.Components.RjButton btnThemDanhMuc;
    private CoffeeShopManagement.Components.RjButton btnCapNhatDanhMuc;
    private CoffeeShopManagement.Components.RjButton btnXoaDanhMuc;
    private CoffeeShopManagement.Components.RjButton btnLamMoiDanhMuc;
    private System.Windows.Forms.DataGridView dgvDanhMuc;
}
