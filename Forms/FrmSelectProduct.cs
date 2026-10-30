using System.Drawing;
using System.Windows.Forms;
using CoffeeShopManagement.Components;
using CoffeeShopManagement.Models;
using CoffeeShopManagement.Services.Interfaces;

namespace CoffeeShopManagement.Forms;

public partial class FrmSelectProduct : Form
{
    private readonly IProductService? _productService;
    private readonly Table? _table;

    public Product? SelectedProduct { get; private set; }
    public int SelectedQuantity { get; private set; } = 1;

    public FrmSelectProduct()
    {
        InitializeComponent();
    }

    public FrmSelectProduct(IProductService productService, Table table) : this()
    {
        _productService = productService;
        _table = table;

        Text = $"Gọi Món - {_table.Name}";

        cboDanhMuc.SelectedIndexChanged += async (_, _) => await LoadProductsByCategoryAsync();

        btnThemVaoDon.Click += (_, _) =>
        {
            SelectedQuantity = (int)nudSoLuong.Value;
            DialogResult = DialogResult.OK;
            Close();
        };

        Load += async (_, _) => await LoadDataAsync();
    }

    private async Task LoadDataAsync()
    {
        if (_productService == null) return;

        var categories = await _productService.GetAllCategoriesAsync();
        cboDanhMuc.DisplayMember = "Name";
        cboDanhMuc.ValueMember = "Id";
        cboDanhMuc.DataSource = categories;
    }

    private async Task LoadProductsByCategoryAsync()
    {
        if (_productService == null) return;
        if (cboDanhMuc.SelectedValue is not int catId) return;

        flpDanhSachMon.Controls.Clear();
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
                lblMonDaChon.Text = $"Món: {prod.Name} ({prod.Price:N0} đ)";
                btnThemVaoDon.Enabled = true;

                // Highlight selected button
                foreach (Control c in flpDanhSachMon.Controls)
                {
                    if (c is Button b)
                    {
                        b.BackColor = (b == btnProd) ? ColorTranslator.FromHtml("#EBE2D8") : UITheme.Surface;
                        b.FlatAppearance.BorderColor = (b == btnProd) ? UITheme.Accent : UITheme.Border;
                        b.FlatAppearance.BorderSize = (b == btnProd) ? 2 : 1;
                    }
                }
            };

            flpDanhSachMon.Controls.Add(btnProd);
        }
    }
}
