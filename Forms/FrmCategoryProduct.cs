using System.Drawing;
using System.Windows.Forms;
using CoffeeShopManagement.Components;
using CoffeeShopManagement.Models;
using CoffeeShopManagement.Services.Interfaces;

namespace CoffeeShopManagement.Forms;

public class FrmCategoryProduct : Form
{
    private readonly IProductService _productService;

    // Tabs
    private TabControl _tabMain = null!;

    // Product Tab Controls
    private DataGridView _dgvProducts = null!;
    private ComboBox _cbProdCategory = null!;
    private TextBox _txtProdName = null!;
    private NumericUpDown _nudProdPrice = null!;
    private TextBox _txtProdUnit = null!;
    private CheckBox _chkProdActive = null!;
    private RjButton _btnProdAdd = null!;
    private RjButton _btnProdUpdate = null!;
    private RjButton _btnProdDelete = null!;
    private int _selectedProdId = 0;

    // Category Tab Controls
    private DataGridView _dgvCategories = null!;
    private TextBox _txtCatName = null!;
    private TextBox _txtCatDesc = null!;
    private RjButton _btnCatAdd = null!;
    private RjButton _btnCatUpdate = null!;
    private RjButton _btnCatDelete = null!;
    private int _selectedCatId = 0;

    public FrmCategoryProduct(IProductService productService)
    {
        _productService = productService;
        InitializeComponent();
        LoadDataAsync();
    }

    private void InitializeComponent()
    {
        Text = "Quản Lý Thực Đơn & Danh Mục Món";
        Size = new Size(1000, 680);
        StartPosition = FormStartPosition.CenterParent;
        BackColor = UITheme.CanvasBg;

        _tabMain = new TabControl
        {
            Dock = DockStyle.Fill,
            Font = UITheme.FontBold,
            Padding = new Point(16, 8)
        };
        Controls.Add(_tabMain);

        var tabProduct = new TabPage("  Món Ăn & Thức Uống  ") { BackColor = UITheme.CanvasBg };
        var tabCategory = new TabPage("  Danh Mục Món  ") { BackColor = UITheme.CanvasBg };

        _tabMain.TabPages.Add(tabProduct);
        _tabMain.TabPages.Add(tabCategory);

        BuildProductTab(tabProduct);
        BuildCategoryTab(tabCategory);
    }

    private void BuildProductTab(TabPage page)
    {
        var pnlLeft = new Panel
        {
            Dock = DockStyle.Left,
            Width = 360,
            BackColor = UITheme.Surface,
            BorderStyle = BorderStyle.FixedSingle,
            Padding = new Padding(16)
        };
        page.Controls.Add(pnlLeft);

        var lblTitle = new Label { Text = "THÔNG TIN MÓN", Font = UITheme.FontHeader, ForeColor = UITheme.Primary, Location = new Point(16, 16), AutoSize = true };
        pnlLeft.Controls.Add(lblTitle);

        int y = 55;
        void AddField(string label, Control ctrl)
        {
            var lbl = new Label { Text = label, Font = UITheme.FontBold, ForeColor = UITheme.TextDark, Location = new Point(16, y), AutoSize = true };
            ctrl.Location = new Point(16, y + 22);
            ctrl.Width = 320;
            pnlLeft.Controls.Add(lbl);
            pnlLeft.Controls.Add(ctrl);
            y += 62;
        }

        _cbProdCategory = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Font = UITheme.FontRegular };
        AddField("Danh mục:", _cbProdCategory);

        _txtProdName = new TextBox { Font = UITheme.FontRegular, BorderStyle = BorderStyle.FixedSingle };
        AddField("Tên món:", _txtProdName);

        _nudProdPrice = new NumericUpDown { Font = UITheme.FontRegular, Minimum = 0, Maximum = 10000000, Increment = 5000 };
        AddField("Đơn giá (VNĐ):", _nudProdPrice);

        _txtProdUnit = new TextBox { Font = UITheme.FontRegular, Text = "Ly", BorderStyle = BorderStyle.FixedSingle };
        AddField("Đơn vị tính:", _txtProdUnit);

        _chkProdActive = new CheckBox { Text = "Đang kinh doanh (phục vụ)", Checked = true, Font = UITheme.FontRegular, Location = new Point(16, y), AutoSize = true };
        pnlLeft.Controls.Add(_chkProdActive);
        y += 40;

        // Action buttons
        _btnProdAdd = new RjButton { Text = "Thêm mới", Location = new Point(16, y), Size = new Size(95, 38), BackColor = UITheme.Primary, BorderRadius = 6 };
        _btnProdAdd.Click += BtnProdAdd_Click;
        pnlLeft.Controls.Add(_btnProdAdd);

        _btnProdUpdate = new RjButton { Text = "Cập nhật", Location = new Point(120, y), Size = new Size(100, 38), BackColor = UITheme.Accent, BorderRadius = 6, Enabled = false };
        _btnProdUpdate.Click += BtnProdUpdate_Click;
        pnlLeft.Controls.Add(_btnProdUpdate);

        _btnProdDelete = new RjButton { Text = "Xóa món", Location = new Point(230, y), Size = new Size(105, 38), BackColor = UITheme.Danger, BorderRadius = 6, Enabled = false };
        _btnProdDelete.Click += BtnProdDelete_Click;
        pnlLeft.Controls.Add(_btnProdDelete);

        var btnProdClear = new RjButton { Text = "Làm mới form", Location = new Point(16, y + 48), Size = new Size(320, 32), BackColor = Color.White, ForeColor = UITheme.TextDark, BorderColor = UITheme.Border, BorderSize = 1, BorderRadius = 6 };
        btnProdClear.Click += (_, _) => ClearProdForm();
        pnlLeft.Controls.Add(btnProdClear);

        // Right Grid
        var pnlRight = new Panel { Dock = DockStyle.Fill, Padding = new Padding(12), BackColor = UITheme.CanvasBg };
        page.Controls.Add(pnlRight);

        _dgvProducts = new DataGridView { Dock = DockStyle.Fill };
        UITheme.ApplyModernGridStyle(_dgvProducts);
        _dgvProducts.Columns.Add("Id", "ID");
        _dgvProducts.Columns["Id"].Visible = false;
        _dgvProducts.Columns.Add("Name", "Tên Món");
        _dgvProducts.Columns["Name"].Width = 180;
        _dgvProducts.Columns.Add("Category", "Danh Mục");
        _dgvProducts.Columns["Category"].Width = 140;
        _dgvProducts.Columns.Add("Price", "Đơn Giá");
        _dgvProducts.Columns["Price"].Width = 100;
        _dgvProducts.Columns.Add("Unit", "ĐVT");
        _dgvProducts.Columns["Unit"].Width = 60;
        _dgvProducts.Columns.Add("Status", "Trạng Thái");
        _dgvProducts.Columns["Status"].Width = 100;

        _dgvProducts.SelectionChanged += DgvProducts_SelectionChanged;
        pnlRight.Controls.Add(_dgvProducts);
    }

    private void BuildCategoryTab(TabPage page)
    {
        var pnlLeft = new Panel
        {
            Dock = DockStyle.Left,
            Width = 360,
            BackColor = UITheme.Surface,
            BorderStyle = BorderStyle.FixedSingle,
            Padding = new Padding(16)
        };
        page.Controls.Add(pnlLeft);

        var lblTitle = new Label { Text = "THÔNG TIN DANH MỤC", Font = UITheme.FontHeader, ForeColor = UITheme.Primary, Location = new Point(16, 16), AutoSize = true };
        pnlLeft.Controls.Add(lblTitle);

        int y = 60;
        var lbl1 = new Label { Text = "Tên danh mục:", Font = UITheme.FontBold, Location = new Point(16, y), AutoSize = true };
        _txtCatName = new TextBox { Location = new Point(16, y + 22), Width = 320, Font = UITheme.FontRegular, BorderStyle = BorderStyle.FixedSingle };
        pnlLeft.Controls.Add(lbl1);
        pnlLeft.Controls.Add(_txtCatName);
        y += 65;

        var lbl2 = new Label { Text = "Mô tả:", Font = UITheme.FontBold, Location = new Point(16, y), AutoSize = true };
        _txtCatDesc = new TextBox { Location = new Point(16, y + 22), Width = 320, Height = 80, Multiline = true, Font = UITheme.FontRegular, BorderStyle = BorderStyle.FixedSingle };
        pnlLeft.Controls.Add(lbl2);
        pnlLeft.Controls.Add(_txtCatDesc);
        y += 120;

        _btnCatAdd = new RjButton { Text = "Thêm mới", Location = new Point(16, y), Size = new Size(95, 38), BackColor = UITheme.Primary, BorderRadius = 6 };
        _btnCatAdd.Click += BtnCatAdd_Click;
        pnlLeft.Controls.Add(_btnCatAdd);

        _btnCatUpdate = new RjButton { Text = "Cập nhật", Location = new Point(120, y), Size = new Size(100, 38), BackColor = UITheme.Accent, BorderRadius = 6, Enabled = false };
        _btnCatUpdate.Click += BtnCatUpdate_Click;
        pnlLeft.Controls.Add(_btnCatUpdate);

        _btnCatDelete = new RjButton { Text = "Xóa", Location = new Point(230, y), Size = new Size(105, 38), BackColor = UITheme.Danger, BorderRadius = 6, Enabled = false };
        _btnCatDelete.Click += BtnCatDelete_Click;
        pnlLeft.Controls.Add(_btnCatDelete);

        var pnlRight = new Panel { Dock = DockStyle.Fill, Padding = new Padding(12), BackColor = UITheme.CanvasBg };
        page.Controls.Add(pnlRight);

        _dgvCategories = new DataGridView { Dock = DockStyle.Fill };
        UITheme.ApplyModernGridStyle(_dgvCategories);
        _dgvCategories.Columns.Add("Id", "ID");
        _dgvCategories.Columns["Id"].Visible = false;
        _dgvCategories.Columns.Add("Name", "Tên Danh Mục");
        _dgvCategories.Columns["Name"].Width = 200;
        _dgvCategories.Columns.Add("Description", "Mô Tả");
        _dgvCategories.Columns["Description"].Width = 280;
        _dgvCategories.Columns.Add("ProductCount", "Số Lượng Món");
        _dgvCategories.Columns["ProductCount"].Width = 110;

        _dgvCategories.SelectionChanged += DgvCategories_SelectionChanged;
        pnlRight.Controls.Add(_dgvCategories);
    }

    private List<Category> _categories = new();
    private List<Product> _products = new();

    private async void LoadDataAsync()
    {
        _categories = await _productService.GetAllCategoriesAsync();
        _products = await _productService.GetAllProductsAsync();

        // Bind Category dropdown for Product form
        _cbProdCategory.DataSource = _categories.ToList();
        _cbProdCategory.DisplayMember = "Name";
        _cbProdCategory.ValueMember = "Id";

        // Bind Category Grid
        _dgvCategories.Rows.Clear();
        foreach (var c in _categories)
        {
            _dgvCategories.Rows.Add(c.Id, c.Name, c.Description ?? "", c.Products.Count);
        }

        // Bind Product Grid
        _dgvProducts.Rows.Clear();
        foreach (var p in _products)
        {
            _dgvProducts.Rows.Add(p.Id, p.Name, p.Category?.Name ?? "", $"{p.Price:N0} đ", p.Unit, p.IsActive ? "Đang bán" : "Ngừng bán");
        }
    }

    private void DgvProducts_SelectionChanged(object? sender, EventArgs e)
    {
        if (_dgvProducts.SelectedRows.Count == 0) return;
        var row = _dgvProducts.SelectedRows[0];
        if (row.Cells["Id"].Value is not int id) return;

        var prod = _products.FirstOrDefault(p => p.Id == id);
        if (prod == null) return;

        _selectedProdId = prod.Id;
        _txtProdName.Text = prod.Name;
        _cbProdCategory.SelectedValue = prod.CategoryId;
        _nudProdPrice.Value = prod.Price;
        _txtProdUnit.Text = prod.Unit;
        _chkProdActive.Checked = prod.IsActive;

        _btnProdAdd.Enabled = false;
        _btnProdUpdate.Enabled = true;
        _btnProdDelete.Enabled = true;
    }

    private void ClearProdForm()
    {
        _selectedProdId = 0;
        _txtProdName.Clear();
        _nudProdPrice.Value = 0;
        _txtProdUnit.Text = "Ly";
        _chkProdActive.Checked = true;
        _btnProdAdd.Enabled = true;
        _btnProdUpdate.Enabled = false;
        _btnProdDelete.Enabled = false;
    }

    private async void BtnProdAdd_Click(object? sender, EventArgs e)
    {
        string name = _txtProdName.Text.Trim();
        if (string.IsNullOrEmpty(name))
        {
            MessageBox.Show("Vui lòng nhập tên món.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (_cbProdCategory.SelectedValue is not int catId) return;

        var newProd = new Product
        {
            CategoryId = catId,
            Name = name,
            Price = _nudProdPrice.Value,
            Unit = _txtProdUnit.Text.Trim(),
            IsActive = _chkProdActive.Checked
        };

        await _productService.CreateProductAsync(newProd);
        ClearProdForm();
        LoadDataAsync();
    }

    private async void BtnProdUpdate_Click(object? sender, EventArgs e)
    {
        if (_selectedProdId == 0) return;
        if (_cbProdCategory.SelectedValue is not int catId) return;

        var prod = await _productService.GetProductByIdAsync(_selectedProdId);
        if (prod == null) return;

        prod.CategoryId = catId;
        prod.Name = _txtProdName.Text.Trim();
        prod.Price = _nudProdPrice.Value;
        prod.Unit = _txtProdUnit.Text.Trim();
        prod.IsActive = _chkProdActive.Checked;

        await _productService.UpdateProductAsync(prod);
        ClearProdForm();
        LoadDataAsync();
    }

    private async void BtnProdDelete_Click(object? sender, EventArgs e)
    {
        if (_selectedProdId == 0) return;

        if (MessageBox.Show("Xóa hoặc ngưng phục vụ món này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        {
            await _productService.DeleteProductAsync(_selectedProdId);
            ClearProdForm();
            LoadDataAsync();
        }
    }

    // Category CRUD
    private void DgvCategories_SelectionChanged(object? sender, EventArgs e)
    {
        if (_dgvCategories.SelectedRows.Count == 0) return;
        var row = _dgvCategories.SelectedRows[0];
        if (row.Cells["Id"].Value is not int id) return;

        var cat = _categories.FirstOrDefault(c => c.Id == id);
        if (cat == null) return;

        _selectedCatId = cat.Id;
        _txtCatName.Text = cat.Name;
        _txtCatDesc.Text = cat.Description ?? "";

        _btnCatAdd.Enabled = false;
        _btnCatUpdate.Enabled = true;
        _btnCatDelete.Enabled = true;
    }

    private async void BtnCatAdd_Click(object? sender, EventArgs e)
    {
        string name = _txtCatName.Text.Trim();
        if (string.IsNullOrEmpty(name))
        {
            MessageBox.Show("Vui lòng nhập tên danh mục.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var cat = new Category
        {
            Name = name,
            Description = _txtCatDesc.Text.Trim()
        };

        await _productService.CreateCategoryAsync(cat);
        _txtCatName.Clear();
        _txtCatDesc.Clear();
        LoadDataAsync();
    }

    private async void BtnCatUpdate_Click(object? sender, EventArgs e)
    {
        if (_selectedCatId == 0) return;

        var cat = await _productService.GetCategoryByIdAsync(_selectedCatId);
        if (cat == null) return;

        cat.Name = _txtCatName.Text.Trim();
        cat.Description = _txtCatDesc.Text.Trim();

        await _productService.UpdateCategoryAsync(cat);
        LoadDataAsync();
    }

    private async void BtnCatDelete_Click(object? sender, EventArgs e)
    {
        if (_selectedCatId == 0) return;

        try
        {
            if (MessageBox.Show("Xác nhận xóa danh mục này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                await _productService.DeleteCategoryAsync(_selectedCatId);
                _txtCatName.Clear();
                _txtCatDesc.Clear();
                LoadDataAsync();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
