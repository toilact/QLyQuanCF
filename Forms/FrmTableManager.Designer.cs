namespace CoffeeShopManagement.Forms;

partial class FrmTableManager
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
        this.lblTenBan = new System.Windows.Forms.Label();
        this.txtTenBan = new System.Windows.Forms.TextBox();
        this.lblKhuVuc = new System.Windows.Forms.Label();
        this.cboKhuVuc = new System.Windows.Forms.ComboBox();
        this.tblNutThaoTac = new System.Windows.Forms.TableLayoutPanel();
        this.btnThem = new CoffeeShopManagement.Components.RjButton();
        this.btnCapNhat = new CoffeeShopManagement.Components.RjButton();
        this.btnXoa = new CoffeeShopManagement.Components.RjButton();
        this.btnLamMoi = new CoffeeShopManagement.Components.RjButton();
        this.lblTieuDe = new System.Windows.Forms.Label();
        this.dgvBan = new System.Windows.Forms.DataGridView();
        ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
        this.splitMain.Panel1.SuspendLayout();
        this.splitMain.Panel2.SuspendLayout();
        this.splitMain.SuspendLayout();
        this.flpInputs.SuspendLayout();
        this.tblNutThaoTac.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.dgvBan)).BeginInit();
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
        this.splitMain.Panel2.Controls.Add(this.dgvBan);
        this.splitMain.Panel2.Padding = new System.Windows.Forms.Padding(16);
        this.splitMain.Size = new System.Drawing.Size(980, 620);
        this.splitMain.SplitterDistance = 350;
        this.splitMain.TabIndex = 0;
        // 
        // flpInputs
        // 
        this.flpInputs.Controls.Add(this.lblTenBan);
        this.flpInputs.Controls.Add(this.txtTenBan);
        this.flpInputs.Controls.Add(this.lblKhuVuc);
        this.flpInputs.Controls.Add(this.cboKhuVuc);
        this.flpInputs.Controls.Add(this.tblNutThaoTac);
        this.flpInputs.Controls.Add(this.btnLamMoi);
        this.flpInputs.Dock = System.Windows.Forms.DockStyle.Fill;
        this.flpInputs.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
        this.flpInputs.Location = new System.Drawing.Point(24, 55);
        this.flpInputs.Name = "flpInputs";
        this.flpInputs.Size = new System.Drawing.Size(302, 545);
        this.flpInputs.TabIndex = 1;
        this.flpInputs.WrapContents = false;
        // 
        // lblTenBan
        // 
        this.lblTenBan.AutoSize = true;
        this.lblTenBan.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblTenBan.ForeColor = System.Drawing.Color.FromArgb(43, 37, 32);
        this.lblTenBan.Location = new System.Drawing.Point(0, 10);
        this.lblTenBan.Margin = new System.Windows.Forms.Padding(0, 10, 0, 4);
        this.lblTenBan.Name = "lblTenBan";
        this.lblTenBan.Size = new System.Drawing.Size(61, 17);
        this.lblTenBan.TabIndex = 0;
        this.lblTenBan.Text = "Tên bàn:";
        // 
        // txtTenBan
        // 
        this.txtTenBan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.txtTenBan.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.txtTenBan.Location = new System.Drawing.Point(0, 31);
        this.txtTenBan.Margin = new System.Windows.Forms.Padding(0, 0, 0, 16);
        this.txtTenBan.Name = "txtTenBan";
        this.txtTenBan.Size = new System.Drawing.Size(300, 24);
        this.txtTenBan.TabIndex = 1;
        // 
        // lblKhuVuc
        // 
        this.lblKhuVuc.AutoSize = true;
        this.lblKhuVuc.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblKhuVuc.ForeColor = System.Drawing.Color.FromArgb(43, 37, 32);
        this.lblKhuVuc.Location = new System.Drawing.Point(0, 71);
        this.lblKhuVuc.Margin = new System.Windows.Forms.Padding(0, 0, 0, 4);
        this.lblKhuVuc.Name = "lblKhuVuc";
        this.lblKhuVuc.Size = new System.Drawing.Size(189, 17);
        this.lblKhuVuc.TabIndex = 2;
        this.lblKhuVuc.Text = "Khu vực (Tầng 1, Sân vườn):";
        // 
        // cboKhuVuc
        // 
        this.cboKhuVuc.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.cboKhuVuc.FormattingEnabled = true;
        this.cboKhuVuc.Location = new System.Drawing.Point(0, 92);
        this.cboKhuVuc.Margin = new System.Windows.Forms.Padding(0, 0, 0, 24);
        this.cboKhuVuc.Name = "cboKhuVuc";
        this.cboKhuVuc.Size = new System.Drawing.Size(300, 25);
        this.cboKhuVuc.TabIndex = 3;
        // 
        // tblNutThaoTac
        // 
        this.tblNutThaoTac.ColumnCount = 3;
        this.tblNutThaoTac.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3F));
        this.tblNutThaoTac.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3F));
        this.tblNutThaoTac.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.4F));
        this.tblNutThaoTac.Controls.Add(this.btnThem, 0, 0);
        this.tblNutThaoTac.Controls.Add(this.btnCapNhat, 1, 0);
        this.tblNutThaoTac.Controls.Add(this.btnXoa, 2, 0);
        this.tblNutThaoTac.Location = new System.Drawing.Point(0, 141);
        this.tblNutThaoTac.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
        this.tblNutThaoTac.Name = "tblNutThaoTac";
        this.tblNutThaoTac.RowCount = 1;
        this.tblNutThaoTac.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
        this.tblNutThaoTac.Size = new System.Drawing.Size(300, 44);
        this.tblNutThaoTac.TabIndex = 4;
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
        this.btnThem.Size = new System.Drawing.Size(93, 38);
        this.btnThem.TabIndex = 0;
        this.btnThem.Text = "Thêm bàn";
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
        this.btnCapNhat.Location = new System.Drawing.Point(102, 3);
        this.btnCapNhat.Name = "btnCapNhat";
        this.btnCapNhat.Size = new System.Drawing.Size(93, 38);
        this.btnCapNhat.TabIndex = 1;
        this.btnCapNhat.Text = "Cập nhật";
        this.btnCapNhat.UseVisualStyleBackColor = false;
        // 
        // btnXoa
        // 
        this.btnXoa.BackColor = System.Drawing.Color.FromArgb(200, 90, 50);
        this.btnXoa.BorderColor = System.Drawing.Color.FromArgb(232, 226, 217);
        this.btnXoa.BorderRadius = 6;
        this.btnXoa.BorderSize = 0;
        this.btnXoa.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnXoa.Dock = System.Windows.Forms.DockStyle.Fill;
        this.btnXoa.Enabled = false;
        this.btnXoa.FlatAppearance.BorderSize = 0;
        this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.btnXoa.ForeColor = System.Drawing.Color.White;
        this.btnXoa.HoverBackColor = System.Drawing.Color.FromArgb(178, 75, 39);
        this.btnXoa.Location = new System.Drawing.Point(201, 3);
        this.btnXoa.Name = "btnXoa";
        this.btnXoa.Size = new System.Drawing.Size(96, 38);
        this.btnXoa.TabIndex = 2;
        this.btnXoa.Text = "Xóa bàn";
        this.btnXoa.UseVisualStyleBackColor = false;
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
        this.btnLamMoi.Location = new System.Drawing.Point(0, 195);
        this.btnLamMoi.Margin = new System.Windows.Forms.Padding(0);
        this.btnLamMoi.Name = "btnLamMoi";
        this.btnLamMoi.Size = new System.Drawing.Size(300, 38);
        this.btnLamMoi.TabIndex = 5;
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
        this.lblTieuDe.Size = new System.Drawing.Size(302, 35);
        this.lblTieuDe.TabIndex = 0;
        this.lblTieuDe.Text = "THÔNG TIN BÀN ĂN";
        // 
        // dgvBan
        // 
        this.dgvBan.BackgroundColor = System.Drawing.Color.White;
        this.dgvBan.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.dgvBan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dgvBan.Dock = System.Windows.Forms.DockStyle.Fill;
        this.dgvBan.Location = new System.Drawing.Point(16, 16);
        this.dgvBan.Name = "dgvBan";
        this.dgvBan.Size = new System.Drawing.Size(594, 588);
        this.dgvBan.TabIndex = 0;
        // 
        // FrmTableManager
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.FromArgb(247, 245, 242);
        this.ClientSize = new System.Drawing.Size(980, 620);
        this.Controls.Add(this.splitMain);
        this.MinimumSize = new System.Drawing.Size(880, 520);
        this.Name = "FrmTableManager";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Quản Lý Bàn và Khu Vực";
        this.splitMain.Panel1.ResumeLayout(false);
        this.splitMain.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
        this.splitMain.ResumeLayout(false);
        this.flpInputs.ResumeLayout(false);
        this.flpInputs.PerformLayout();
        this.tblNutThaoTac.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.dgvBan)).EndInit();
        this.ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.SplitContainer splitMain;
    private System.Windows.Forms.Label lblTieuDe;
    private System.Windows.Forms.FlowLayoutPanel flpInputs;
    private System.Windows.Forms.Label lblTenBan;
    private System.Windows.Forms.TextBox txtTenBan;
    private System.Windows.Forms.Label lblKhuVuc;
    private System.Windows.Forms.ComboBox cboKhuVuc;
    private System.Windows.Forms.TableLayoutPanel tblNutThaoTac;
    private CoffeeShopManagement.Components.RjButton btnThem;
    private CoffeeShopManagement.Components.RjButton btnCapNhat;
    private CoffeeShopManagement.Components.RjButton btnXoa;
    private CoffeeShopManagement.Components.RjButton btnLamMoi;
    private System.Windows.Forms.DataGridView dgvBan;
}
