using System.Windows.Forms;
using CoffeeShopManagement.Components;
using CoffeeShopManagement.Models;
using CoffeeShopManagement.Services.Interfaces;

namespace CoffeeShopManagement.Forms;

public partial class FrmCategoryProduct : Form
{
    private readonly IProductService? _productService;

    private int _selectedProdId = 0;
    private int _selectedCatId = 0;
    private List<Category> _categories = new();
    private List<Product> _products = new();

    public FrmCategoryProduct()
    {
        InitializeComponent();
    }

    public FrmCategoryProduct(IProductService productService) : this()
    {
        _productService = productService;

        // Cấu hình style và cột DataGridView
        UITheme.ApplyModernGridStyle(dgvMonAn);
        SetupProductGridColumns();

        UITheme.ApplyModernGridStyle(dgvDanhMuc);
        SetupCategoryGridColumns();

        // Gắn sự kiện các nút món ăn
        btnThemMon.Click += BtnThemMon_Click;
        btnCapNhatMon.Click += BtnCapNhatMon_Click;
        btnXoaMon.Click += BtnXoaMon_Click;
        btnLamMoiMon.Click += (_, _) => ClearProdForm();
        dgvMonAn.SelectionChanged += DgvMonAn_SelectionChanged;

        // Gắn sự kiện các nút danh mục
        btnThemDanhMuc.Click += BtnThemDanhMuc_Click;
        btnCapNhatDanhMuc.Click += BtnCapNhatDanhMuc_Click;
        btnXoaDanhMuc.Click += BtnXoaDanhMuc_Click;
        btnLamMoiDanhMuc.Click += (_, _) => ClearCatForm();
        dgvDanhMuc.SelectionChanged += DgvDanhMuc_SelectionChanged;

        Load += async (_, _) => await LoadDataAsync();
    }

    private void SetupProductGridColumns()
    {
        dgvMonAn.Columns.Clear();
        dgvMonAn.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        dgvMonAn.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", Visible = false });
        dgvMonAn.Columns.Add(new DataGridViewTextBoxColumn { Name = "Name", HeaderText = "Tên Món", FillWeight = 34 });
        dgvMonAn.Columns.Add(new DataGridViewTextBoxColumn { Name = "Category", HeaderText = "Danh Mục", FillWeight = 26 });

        var colPrice = new DataGridViewTextBoxColumn
        {
            Name = "Price",
            HeaderText = "Đơn Giá",
            FillWeight = 18,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight }
        };
        dgvMonAn.Columns.Add(colPrice);

        var colUnit = new DataGridViewTextBoxColumn
        {
            Name = "Unit",
            HeaderText = "ĐVT",
            FillWeight = 10,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
        };
        dgvMonAn.Columns.Add(colUnit);

        var colStatus = new DataGridViewTextBoxColumn
        {
            Name = "Status",
            HeaderText = "Trạng Thái",
            FillWeight = 12,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
        };
        dgvMonAn.Columns.Add(colStatus);
    }

    private void SetupCategoryGridColumns()
    {
        dgvDanhMuc.Columns.Clear();
        dgvDanhMuc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        dgvDanhMuc.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", Visible = false });
        dgvDanhMuc.Columns.Add(new DataGridViewTextBoxColumn { Name = "Name", HeaderText = "Tên Danh Mục", FillWeight = 35 });
        dgvDanhMuc.Columns.Add(new DataGridViewTextBoxColumn { Name = "Description", HeaderText = "Mô Tả", FillWeight = 45 });

        var colCount = new DataGridViewTextBoxColumn
        {
            Name = "ProductCount",
            HeaderText = "Số Lượng Món",
            FillWeight = 20,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
        };
        dgvDanhMuc.Columns.Add(colCount);
    }

    private async Task LoadDataAsync()
    {
        if (_productService == null) return;

        _categories = await _productService.GetAllCategoriesAsync();
        _products = await _productService.GetAllProductsAsync();

        cboDanhMucMon.DataSource = _categories.ToList();
        cboDanhMucMon.DisplayMember = "Name";
        cboDanhMucMon.ValueMember = "Id";

        dgvDanhMuc.Rows.Clear();
        foreach (var c in _categories)
        {
            dgvDanhMuc.Rows.Add(c.Id, c.Name, c.Description ?? "", c.Products.Count);
        }

        dgvMonAn.Rows.Clear();
        foreach (var p in _products)
        {
            dgvMonAn.Rows.Add(p.Id, p.Name, p.Category?.Name ?? "", $"{p.Price:N0} đ", p.Unit, p.IsActive ? "Đang bán" : "Ngừng bán");
        }
    }

    private void DgvMonAn_SelectionChanged(object? sender, EventArgs e)
    {
        if (dgvMonAn.SelectedRows.Count == 0) return;
        var row = dgvMonAn.SelectedRows[0];
        if (row.Cells["Id"].Value is not int id) return;

        var prod = _products.FirstOrDefault(p => p.Id == id);
        if (prod == null) return;

        _selectedProdId = prod.Id;
        txtTenMon.Text = prod.Name;
        cboDanhMucMon.SelectedValue = prod.CategoryId;
        nudDonGia.Value = prod.Price;
        txtDonViTinh.Text = prod.Unit;
        chkDangKinhDoanh.Checked = prod.IsActive;

        btnThemMon.Enabled = false;
        btnCapNhatMon.Enabled = true;
        btnXoaMon.Enabled = true;
    }

    private void ClearProdForm()
    {
        _selectedProdId = 0;
        txtTenMon.Clear();
        nudDonGia.Value = 0;
        txtDonViTinh.Text = "Ly";
        chkDangKinhDoanh.Checked = true;
        btnThemMon.Enabled = true;
        btnCapNhatMon.Enabled = false;
        btnXoaMon.Enabled = false;
    }

    private async void BtnThemMon_Click(object? sender, EventArgs e)
    {
        if (_productService == null) return;

        string name = txtTenMon.Text.Trim();
        if (string.IsNullOrEmpty(name))
        {
            MessageBox.Show("Vui lòng nhập tên món.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (cboDanhMucMon.SelectedValue is not int catId) return;

        var newProd = new Product
        {
            CategoryId = catId,
            Name = name,
            Price = nudDonGia.Value,
            Unit = txtDonViTinh.Text.Trim(),
            IsActive = chkDangKinhDoanh.Checked
        };

        await _productService.CreateProductAsync(newProd);
        ClearProdForm();
        await LoadDataAsync();
    }

    private async void BtnCapNhatMon_Click(object? sender, EventArgs e)
    {
        if (_productService == null || _selectedProdId == 0) return;
        if (cboDanhMucMon.SelectedValue is not int catId) return;

        var prod = await _productService.GetProductByIdAsync(_selectedProdId);
        if (prod == null) return;

        prod.CategoryId = catId;
        prod.Name = txtTenMon.Text.Trim();
        prod.Price = nudDonGia.Value;
        prod.Unit = txtDonViTinh.Text.Trim();
        prod.IsActive = chkDangKinhDoanh.Checked;

        await _productService.UpdateProductAsync(prod);
        ClearProdForm();
        await LoadDataAsync();
    }

    private async void BtnXoaMon_Click(object? sender, EventArgs e)
    {
        if (_productService == null || _selectedProdId == 0) return;

        if (MessageBox.Show("Xóa hoặc ngưng phục vụ món này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        {
            await _productService.DeleteProductAsync(_selectedProdId);
            ClearProdForm();
            await LoadDataAsync();
        }
    }

    // Category Events
    private void DgvDanhMuc_SelectionChanged(object? sender, EventArgs e)
    {
        if (dgvDanhMuc.SelectedRows.Count == 0) return;
        var row = dgvDanhMuc.SelectedRows[0];
        if (row.Cells["Id"].Value is not int id) return;

        var cat = _categories.FirstOrDefault(c => c.Id == id);
        if (cat == null) return;

        _selectedCatId = cat.Id;
        txtTenDanhMuc.Text = cat.Name;
        txtMoTaDanhMuc.Text = cat.Description ?? "";

        btnThemDanhMuc.Enabled = false;
        btnCapNhatDanhMuc.Enabled = true;
        btnXoaDanhMuc.Enabled = true;
    }

    private void ClearCatForm()
    {
        _selectedCatId = 0;
        txtTenDanhMuc.Clear();
        txtMoTaDanhMuc.Clear();
        btnThemDanhMuc.Enabled = true;
        btnCapNhatDanhMuc.Enabled = false;
        btnXoaDanhMuc.Enabled = false;
    }

    private async void BtnThemDanhMuc_Click(object? sender, EventArgs e)
    {
        if (_productService == null) return;

        string name = txtTenDanhMuc.Text.Trim();
        if (string.IsNullOrEmpty(name))
        {
            MessageBox.Show("Vui lòng nhập tên danh mục.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var cat = new Category
        {
            Name = name,
            Description = txtMoTaDanhMuc.Text.Trim()
        };

        await _productService.CreateCategoryAsync(cat);
        ClearCatForm();
        await LoadDataAsync();
    }

    private async void BtnCapNhatDanhMuc_Click(object? sender, EventArgs e)
    {
        if (_productService == null || _selectedCatId == 0) return;

        var cat = await _productService.GetCategoryByIdAsync(_selectedCatId);
        if (cat == null) return;

        cat.Name = txtTenDanhMuc.Text.Trim();
        cat.Description = txtMoTaDanhMuc.Text.Trim();

        await _productService.UpdateCategoryAsync(cat);
        ClearCatForm();
        await LoadDataAsync();
    }

    private async void BtnXoaDanhMuc_Click(object? sender, EventArgs e)
    {
        if (_productService == null || _selectedCatId == 0) return;

        try
        {
            if (MessageBox.Show("Xác nhận xóa danh mục này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                await _productService.DeleteCategoryAsync(_selectedCatId);
                ClearCatForm();
                await LoadDataAsync();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
