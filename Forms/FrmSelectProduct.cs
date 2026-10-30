using System.Drawing;
using System.Windows.Forms;
using CoffeeShopManagement.Components;
using CoffeeShopManagement.Models;
using CoffeeShopManagement.Services.Interfaces;

namespace CoffeeShopManagement.Forms;

public class FrmSelectProduct : Form
{
    private readonly IProductService _productService;
    private readonly Table _table;

    public Product? SelectedProduct { get; private set; }
    public int SelectedQuantity { get; private set; } = 1;

    private ComboBox _cbCategories = null!;
    private FlowLayoutPanel _flpProducts = null!;
    private NumericUpDown _nudQuantity = null!;
    private Label _lblSelectedInfo = null!;
    private RjButton _btnAdd = null!;

    public FrmSelectProduct(IProductService productService, Table table)
    {
        _productService = productService;
        _table = table;

        InitializeComponent();
        LoadDataAsync();
    }

    private void InitializeComponent()
    {
        Text = $"Gọi Món - {_table.Name}";
        Size = new Size(720, 560);
        StartPosition = FormStartPosition.CenterParent;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        BackColor = UITheme.CanvasBg;

        // Top Filter Panel
        var pnlTop = new Panel
        {
            Dock = DockStyle.Top,
            Height = 65,
            BackColor = UITheme.Surface,
            Padding = new Padding(16, 12, 16, 12)
        };
        Controls.Add(pnlTop);

        var lblCat = new Label
        {
            Text = "Danh mục:",
            Font = UITheme.FontBold,
            ForeColor = UITheme.TextDark,
            Location = new Point(16, 20),
            AutoSize = true
        };
        pnlTop.Controls.Add(lblCat);

        _cbCategories = new ComboBox
        {
            Location = new Point(100, 16),
            Size = new Size(260, 32),
            DropDownStyle = ComboBoxStyle.DropDownList,
            Font = UITheme.FontRegular
        };
        _cbCategories.SelectedIndexChanged += async (_, _) => await LoadProductsByCategoryAsync();
        pnlTop.Controls.Add(_cbCategories);

        // Bottom Action Panel
        var pnlBottom = new Panel
        {
            Dock = DockStyle.Bottom,
            Height = 70,
            BackColor = UITheme.Surface,
            Padding = new Padding(16, 12, 16, 12)
        };
        Controls.Add(pnlBottom);

        _lblSelectedInfo = new Label
        {
            Text = "Chưa chọn món nào",
            Font = UITheme.FontBold,
            ForeColor = UITheme.Primary,
            Location = new Point(16, 22),
            Size = new Size(320, 26)
        };
        pnlBottom.Controls.Add(_lblSelectedInfo);

        var lblQty = new Label
        {
            Text = "Số lượng:",
            Font = UITheme.FontBold,
            Location = new Point(360, 22),
            AutoSize = true
        };
        pnlBottom.Controls.Add(lblQty);

        _nudQuantity = new NumericUpDown
        {
            Location = new Point(440, 18),
            Size = new Size(70, 30),
            Font = new Font("Segoe UI", 11f),
            Minimum = 1,
            Maximum = 100,
            Value = 1
        };
        pnlBottom.Controls.Add(_nudQuantity);

        _btnAdd = new RjButton
        {
            Text = "THÊM VÀO ĐƠN",
            Location = new Point(530, 14),
            Size = new Size(155, 40),
            BackColor = UITheme.Primary,
            HoverBackColor = UITheme.PrimaryHover,
            Enabled = false,
            BorderRadius = 6
        };
        _btnAdd.Click += (_, _) =>
        {
            SelectedQuantity = (int)_nudQuantity.Value;
            DialogResult = DialogResult.OK;
            Close();
        };
        pnlBottom.Controls.Add(_btnAdd);

        // Center Product List
        _flpProducts = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            AutoScroll = true,
            Padding = new Padding(16),
            BackColor = UITheme.CanvasBg
        };
        Controls.Add(_flpProducts);
    }

    private async void LoadDataAsync()
    {
        var categories = await _productService.GetAllCategoriesAsync();
        _cbCategories.DisplayMember = "Name";
        _cbCategories.ValueMember = "Id";
        _cbCategories.DataSource = categories;
    }

    private async Task LoadProductsByCategoryAsync()
    {
        if (_cbCategories.SelectedValue is not int catId) return;

        _flpProducts.Controls.Clear();
        var products = await _productService.GetProductsByCategoryAsync(catId);

        foreach (var prod in products)
        {
            var btnProd = new Button
            {
                Size = new Size(150, 95),
                Margin = new Padding(8),
                BackColor = UITheme.Surface,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                TextAlign = ContentAlignment.MiddleCenter,
                Text = $"{prod.Name}\n\n{prod.Price:N0} đ / {prod.Unit}",
                Font = UITheme.FontBold,
                ForeColor = UITheme.TextDark,
                Tag = prod
            };
            btnProd.FlatAppearance.BorderColor = UITheme.Border;
            btnProd.FlatAppearance.BorderSize = 1;

            btnProd.Click += (_, _) =>
            {
                SelectedProduct = prod;
                _lblSelectedInfo.Text = $"Món: {prod.Name} ({prod.Price:N0} đ)";
                _btnAdd.Enabled = true;

                // Highlight selected button
                foreach (Control c in _flpProducts.Controls)
                {
                    if (c is Button b)
                    {
                        b.BackColor = (b == btnProd) ? ColorTranslator.FromHtml("#EBE2D8") : UITheme.Surface;
                        b.FlatAppearance.BorderColor = (b == btnProd) ? UITheme.Accent : UITheme.Border;
                        b.FlatAppearance.BorderSize = (b == btnProd) ? 2 : 1;
                    }
                }
            };

            _flpProducts.Controls.Add(btnProd);
        }
    }
}

