namespace CoffeeShopManagement.Forms;

partial class FrmTransferMergeTable
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
        this.lblBanNguon = new System.Windows.Forms.Label();
        this.rdoChuyenBan = new System.Windows.Forms.RadioButton();
        this.rdoGopBan = new System.Windows.Forms.RadioButton();
        this.lblTieuDeBanDich = new System.Windows.Forms.Label();
        this.cboBanDich = new System.Windows.Forms.ComboBox();
        this.lblTrangThaiBanDich = new System.Windows.Forms.Label();
        this.btnXacNhan = new CoffeeShopManagement.Components.RjButton();
        this.btnHuy = new CoffeeShopManagement.Components.RjButton();
        this.pnlCard.SuspendLayout();
        this.SuspendLayout();
        // 
        // pnlCard
        // 
        this.pnlCard.Anchor = System.Windows.Forms.AnchorStyles.None;
        this.pnlCard.BackColor = System.Drawing.Color.White;
        this.pnlCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.pnlCard.Controls.Add(this.btnHuy);
        this.pnlCard.Controls.Add(this.btnXacNhan);
        this.pnlCard.Controls.Add(this.lblTrangThaiBanDich);
        this.pnlCard.Controls.Add(this.cboBanDich);
        this.pnlCard.Controls.Add(this.lblTieuDeBanDich);
        this.pnlCard.Controls.Add(this.rdoGopBan);
        this.pnlCard.Controls.Add(this.rdoChuyenBan);
        this.pnlCard.Controls.Add(this.lblBanNguon);
        this.pnlCard.Location = new System.Drawing.Point(20, 20);
        this.pnlCard.Name = "pnlCard";
        this.pnlCard.Size = new System.Drawing.Size(385, 275);
        this.pnlCard.TabIndex = 0;
        // 
        // lblBanNguon
        // 
        this.lblBanNguon.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
        this.lblBanNguon.ForeColor = System.Drawing.Color.FromArgb(61, 40, 23);
        this.lblBanNguon.Location = new System.Drawing.Point(20, 16);
        this.lblBanNguon.Name = "lblBanNguon";
        this.lblBanNguon.Size = new System.Drawing.Size(345, 25);
        this.lblBanNguon.TabIndex = 0;
        this.lblBanNguon.Text = "Bàn nguồn: --";
        // 
        // rdoChuyenBan
        // 
        this.rdoChuyenBan.Checked = true;
        this.rdoChuyenBan.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.rdoChuyenBan.ForeColor = System.Drawing.Color.FromArgb(43, 37, 32);
        this.rdoChuyenBan.Location = new System.Drawing.Point(25, 55);
        this.rdoChuyenBan.Name = "rdoChuyenBan";
        this.rdoChuyenBan.Size = new System.Drawing.Size(340, 25);
        this.rdoChuyenBan.TabIndex = 1;
        this.rdoChuyenBan.TabStop = true;
        this.rdoChuyenBan.Text = "Chuyển sang bàn trống khác";
        this.rdoChuyenBan.UseVisualStyleBackColor = true;
        // 
        // rdoGopBan
        // 
        this.rdoGopBan.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.rdoGopBan.ForeColor = System.Drawing.Color.FromArgb(43, 37, 32);
        this.rdoGopBan.Location = new System.Drawing.Point(25, 85);
        this.rdoGopBan.Name = "rdoGopBan";
        this.rdoGopBan.Size = new System.Drawing.Size(340, 25);
        this.rdoGopBan.TabIndex = 2;
        this.rdoGopBan.Text = "Gộp món vào bàn đang có khách";
        this.rdoGopBan.UseVisualStyleBackColor = true;
        // 
        // lblTieuDeBanDich
        // 
        this.lblTieuDeBanDich.AutoSize = true;
        this.lblTieuDeBanDich.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.lblTieuDeBanDich.ForeColor = System.Drawing.Color.FromArgb(43, 37, 32);
        this.lblTieuDeBanDich.Location = new System.Drawing.Point(25, 125);
        this.lblTieuDeBanDich.Name = "lblTieuDeBanDich";
        this.lblTieuDeBanDich.Size = new System.Drawing.Size(103, 17);
        this.lblTieuDeBanDich.TabIndex = 3;
        this.lblTieuDeBanDich.Text = "Chọn bàn đích:";
        // 
        // cboBanDich
        // 
        this.cboBanDich.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cboBanDich.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.cboBanDich.FormattingEnabled = true;
        this.cboBanDich.Location = new System.Drawing.Point(25, 148);
        this.cboBanDich.Name = "cboBanDich";
        this.cboBanDich.Size = new System.Drawing.Size(335, 25);
        this.cboBanDich.TabIndex = 4;
        // 
        // lblTrangThaiBanDich
        // 
        this.lblTrangThaiBanDich.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.lblTrangThaiBanDich.ForeColor = System.Drawing.Color.FromArgb(125, 117, 109);
        this.lblTrangThaiBanDich.Location = new System.Drawing.Point(25, 182);
        this.lblTrangThaiBanDich.Name = "lblTrangThaiBanDich";
        this.lblTrangThaiBanDich.Size = new System.Drawing.Size(335, 20);
        this.lblTrangThaiBanDich.TabIndex = 5;
        this.lblTrangThaiBanDich.Text = "--";
        // 
        // btnXacNhan
        // 
        this.btnXacNhan.BackColor = System.Drawing.Color.FromArgb(61, 40, 23);
        this.btnXacNhan.BorderColor = System.Drawing.Color.FromArgb(232, 226, 217);
        this.btnXacNhan.BorderRadius = 6;
        this.btnXacNhan.BorderSize = 0;
        this.btnXacNhan.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnXacNhan.FlatAppearance.BorderSize = 0;
        this.btnXacNhan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnXacNhan.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.btnXacNhan.ForeColor = System.Drawing.Color.White;
        this.btnXacNhan.HoverBackColor = System.Drawing.Color.FromArgb(83, 56, 33);
        this.btnXacNhan.Location = new System.Drawing.Point(210, 218);
        this.btnXacNhan.Name = "btnXacNhan";
        this.btnXacNhan.Size = new System.Drawing.Size(150, 40);
        this.btnXacNhan.TabIndex = 6;
        this.btnXacNhan.Text = "XÁC NHẬN";
        this.btnXacNhan.UseVisualStyleBackColor = false;
        // 
        // btnHuy
        // 
        this.btnHuy.BackColor = System.Drawing.Color.White;
        this.btnHuy.BorderColor = System.Drawing.Color.FromArgb(232, 226, 217);
        this.btnHuy.BorderRadius = 6;
        this.btnHuy.BorderSize = 1;
        this.btnHuy.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnHuy.FlatAppearance.BorderSize = 0;
        this.btnHuy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.btnHuy.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
        this.btnHuy.ForeColor = System.Drawing.Color.FromArgb(43, 37, 32);
        this.btnHuy.HoverBackColor = System.Drawing.Color.FromArgb(240, 235, 229);
        this.btnHuy.Location = new System.Drawing.Point(90, 218);
        this.btnHuy.Name = "btnHuy";
        this.btnHuy.Size = new System.Drawing.Size(110, 40);
        this.btnHuy.TabIndex = 7;
        this.btnHuy.Text = "HỦY";
        this.btnHuy.UseVisualStyleBackColor = false;
        // 
        // FrmTransferMergeTable
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.FromArgb(247, 245, 242);
        this.ClientSize = new System.Drawing.Size(424, 321);
        this.Controls.Add(this.pnlCard);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "FrmTransferMergeTable";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Chuyển / Gộp Bàn";
        this.pnlCard.ResumeLayout(false);
        this.pnlCard.PerformLayout();
        this.ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.Panel pnlCard;
    private System.Windows.Forms.Label lblBanNguon;
    private System.Windows.Forms.RadioButton rdoChuyenBan;
    private System.Windows.Forms.RadioButton rdoGopBan;
    private System.Windows.Forms.Label lblTieuDeBanDich;
    private System.Windows.Forms.ComboBox cboBanDich;
    private System.Windows.Forms.Label lblTrangThaiBanDich;
    private CoffeeShopManagement.Components.RjButton btnXacNhan;
    private CoffeeShopManagement.Components.RjButton btnHuy;
}
