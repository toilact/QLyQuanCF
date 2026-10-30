namespace CoffeeShopManagement.Forms;

partial class FrmSelectProduct
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
        this.pnlTop = new System.Windows.Forms.Panel();
        this.lblDanhMuc = new System.Windows.Forms.Label();
        this.cboDanhMuc = new System.Windows.Forms.ComboBox();
        this.pnlBottom = new System.Windows.Forms.Panel();
        this.lblMonDaChon = new System.Windows.Forms.Label();
        this.lblSoLuong = new System.Windows.Forms.Label();
        this.nudSoLuong = new System.Windows.Forms.NumericUpDown();
        this.btnThemVaoDon = new CoffeeShopManagement.Components.RjButton();
        this.flpDanhSachMon = new System.Windows.Forms.FlowLayoutPanel();
        this.pnlTop.SuspendLayout();
        this.pnlBottom.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).BeginInit();
        this.SuspendLayout();
        // 
        // pnlTop
        // 
        this.pnlTop.BackColor = System.Drawing.Color.White;
        this.pnlTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.pnlTop.Controls.Add(this.lblDanhMuc);
        this.pnlTop.Controls.Add(this.cboDanhMuc);
        this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
        this.pnlTop.Location = new System.Drawing.Point(0, 0);
        this.pnlTop.Name = "pnlTop";
        this.pnlTop.Padding = new System.Windows.Forms.Padding(16, 12, 16, 12);
        this.pnlTop.Size = new System.Drawing.Size(720, 65);
        this.pnlTop.TabIndex = 0;
        // 
        // lblDanhMuc
        // 
        this.lblDanhMuc.AutoSize = true;
        this.lblDanhMuc.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblDanhMuc.ForeColor = System.Drawing.Color.FromArgb(43, 37, 32);
        this.lblDanhMuc.Location = new System.Drawing.Point(16, 22);
        this.lblDanhMuc.Name = "lblDanhMuc";
        this.lblDanhMuc.Size = new System.Drawing.Size(74, 17);
        this.lblDanhMuc.TabIndex = 0;
        this.lblDanhMuc.Text = "Danh mục:";
        // 
        // cboDanhMuc
        // 
        this.cboDanhMuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cboDanhMuc.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.cboDanhMuc.FormattingEnabled = true;
        this.cboDanhMuc.Location = new System.Drawing.Point(100, 18);
        this.cboDanhMuc.Name = "cboDanhMuc";
        this.cboDanhMuc.Size = new System.Drawing.Size(260, 25);
        this.cboDanhMuc.TabIndex = 1;
        // 
        // pnlBottom
        // 
        this.pnlBottom.BackColor = System.Drawing.Color.White;
        this.pnlBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.pnlBottom.Controls.Add(this.lblMonDaChon);
        this.pnlBottom.Controls.Add(this.lblSoLuong);
        this.pnlBottom.Controls.Add(this.nudSoLuong);
        this.pnlBottom.Controls.Add(this.btnThemVaoDon);
        this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.pnlBottom.Location = new System.Drawing.Point(0, 490);
        this.pnlBottom.Name = "pnlBottom";
        this.pnlBottom.Padding = new System.Windows.Forms.Padding(16, 12, 16, 12);
        this.pnlBottom.Size = new System.Drawing.Size(720, 70);
        this.pnlBottom.TabIndex = 1;
        // 
        // lblMonDaChon
        // 
        this.lblMonDaChon.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblMonDaChon.ForeColor = System.Drawing.Color.FromArgb(61, 40, 23);
        this.lblMonDaChon.Location = new System.Drawing.Point(16, 22);
        this.lblMonDaChon.Name = "lblMonDaChon";
        this.lblMonDaChon.Size = new System.Drawing.Size(320, 26);
        this.lblMonDaChon.TabIndex = 0;
        this.lblMonDaChon.Text = "Chưa chọn món nào";
        this.lblMonDaChon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // lblSoLuong
        // 
        this.lblSoLuong.AutoSize = true;
        this.lblSoLuong.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblSoLuong.ForeColor = System.Drawing.Color.FromArgb(43, 37, 32);
        this.lblSoLuong.Location = new System.Drawing.Point(355, 25);
        this.lblSoLuong.Name = "lblSoLuong";
        this.lblSoLuong.Size = new System.Drawing.Size(68, 17);
        this.lblSoLuong.TabIndex = 1;
        this.lblSoLuong.Text = "Số lượng:";
        // 
        // nudSoLuong
        // 
        this.nudSoLuong.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.nudSoLuong.Location = new System.Drawing.Point(430, 21);
        this.nudSoLuong.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        this.nudSoLuong.Name = "nudSoLuong";
        this.nudSoLuong.Size = new System.Drawing.Size(70, 25);
        this.nudSoLuong.TabIndex = 2;
        this.nudSoLuong.Value = new decimal(new int[] { 1, 0, 0, 0 });
        // 
        // btnThemVaoDon
        // 
        this.btnThemVaoDon.BackColor = System.Drawing.Color.FromArgb(61, 40, 23);
        this.btnThemVaoDon.BorderColor = System.Drawing.Color.FromArgb(232, 226, 217);
        this.btnThemVaoDon.BorderRadius = 6;
        this.btnThemVaoDon.BorderSize = 0;
        this.btnThemVaoDon.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnThemVaoDon.Enabled = false;
        this.btnThemVaoDon.FlatAppearance.BorderSize = 0;
        this.btnThemVaoDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnThemVaoDon.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.btnThemVaoDon.ForeColor = System.Drawing.Color.White;
        this.btnThemVaoDon.HoverBackColor = System.Drawing.Color.FromArgb(83, 56, 33);
        this.btnThemVaoDon.Location = new System.Drawing.Point(525, 14);
        this.btnThemVaoDon.Name = "btnThemVaoDon";
        this.btnThemVaoDon.Size = new System.Drawing.Size(175, 40);
        this.btnThemVaoDon.TabIndex = 3;
        this.btnThemVaoDon.Text = "THÊM VÀO ĐƠN";
        this.btnThemVaoDon.UseVisualStyleBackColor = false;
        // 
        // flpDanhSachMon
        // 
        this.flpDanhSachMon.AutoScroll = true;
        this.flpDanhSachMon.BackColor = System.Drawing.Color.FromArgb(247, 245, 242);
        this.flpDanhSachMon.Dock = System.Windows.Forms.DockStyle.Fill;
        this.flpDanhSachMon.Location = new System.Drawing.Point(0, 65);
        this.flpDanhSachMon.Name = "flpDanhSachMon";
        this.flpDanhSachMon.Padding = new System.Windows.Forms.Padding(16);
        this.flpDanhSachMon.Size = new System.Drawing.Size(720, 425);
        this.flpDanhSachMon.TabIndex = 2;
        // 
        // FrmSelectProduct
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.FromArgb(247, 245, 242);
        this.ClientSize = new System.Drawing.Size(720, 560);
        this.Controls.Add(this.flpDanhSachMon);
        this.Controls.Add(this.pnlBottom);
        this.Controls.Add(this.pnlTop);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "FrmSelectProduct";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Gọi Món Cho Bàn";
        this.pnlTop.ResumeLayout(false);
        this.pnlTop.PerformLayout();
        this.pnlBottom.ResumeLayout(false);
        this.pnlBottom.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).EndInit();
        this.ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.Panel pnlTop;
    private System.Windows.Forms.Label lblDanhMuc;
    private System.Windows.Forms.ComboBox cboDanhMuc;
    private System.Windows.Forms.Panel pnlBottom;
    private System.Windows.Forms.Label lblMonDaChon;
    private System.Windows.Forms.Label lblSoLuong;
    private System.Windows.Forms.NumericUpDown nudSoLuong;
    private CoffeeShopManagement.Components.RjButton btnThemVaoDon;
    private System.Windows.Forms.FlowLayoutPanel flpDanhSachMon;
}
