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
        Text = "Quản Lý Thực Đơn và Danh Mục Món";
        Size = new Size(1150, 720);
        MinimumSize = new Size(1000, 650);
        StartPosition = FormStartPosition.CenterParent;
        BackColor = UITheme.CanvasBg;

        _tabMain = new TabControl
        {
            Dock = DockStyle.Fill,
            Font = UITheme.FontBold,
            Padding = new Point(20, 10)
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
        var split = new SplitContainer
        {
            Dock = DockStyle.Fill,
            FixedPanel = FixedPanel.Panel1,
            SplitterDistance = 380,
            IsSplitterFixed = true,
            BackColor = UITheme.Border
        };
        page.Controls.Add(split);

        // Panel 1: Left Form
        var pnlLeft = split.Panel1;
        pnlLeft.BackColor = UITheme.Surface;
        pnlLeft.Padding = new Padding(24, 20, 24, 20);

        var lblTitle = new Label
        {
            Text = "THÔNG TIN MÓN ĂN",
            Font = UITheme.FontHeader,
            ForeColor = UITheme.Primary,
            Dock = DockStyle.Top,
            Height = 35
        };
        pnlLeft.Controls.Add(lblTitle);

        var flpInputs = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.TopDown,
            WrapContents = false,
            AutoScroll = true
        };
        pnlLeft.Controls.Add(flpInputs);
        flpInputs.BringToFront();

        void AddFormField(string label, Control ctrl)
        {
            var lbl = new Label
            {
                Text = label,
                Font = UITheme.FontBold,
                ForeColor = UITheme.TextDark,
                Size = new Size(330, 20),
                Margin = new Padding(0, 8, 0, 4)
            };
            ctrl.Size = new Size(330, 32);
            ctrl.Margin = new Padding(0, 0, 0, 12);

            flpInputs.Controls.Add(lbl);
            flpInputs.Controls.Add(ctrl);
        }

        _cbProdCategory = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Font = UITheme.FontRegular };
        AddFormField("Danh mục món:", _cbProdCategory);

        _txtProdName = new TextBox { Font = UITheme.FontRegular, BorderStyle = BorderStyle.FixedSingle };
        AddFormField("Tên món ăn / thức uống:", _txtProdName);

        _nudProdPrice = new NumericUpDown { Font = UITheme.FontRegular, Minimum = 0, Maximum = 10000000, Increment = 5000 };
        AddFormField("Đơn giá (VNĐ):", _nudProdPrice);

        _txtProdUnit = new TextBox { Font = UITheme.FontRegular, Text = "Ly", BorderStyle = BorderStyle.FixedSingle };
        AddFormField("Đơn vị tính (Ly, Tách, Đĩa,...):", _txtProdUnit);

        _chkProdActive = new CheckBox
        {
            Text = "Đang phục vụ (Có sẵn trong menu)",
            Checked = true,
            Font = UITheme.FontRegular,
            Size = new Size(330, 28),
            Margin = new Padding(0, 4, 0, 16)
        };
        flpInputs.Controls.Add(_chkProdActive);

        // Buttons Grid
        var tblBtns = new TableLayoutPanel
        {
            Size = new Size(330, 44),
            ColumnCount = 3,
            RowCount = 1,
            Margin = new Padding(0, 0, 0, 10)
        };
        tblBtns.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3F));
        tblBtns.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3F));
        tblBtns.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3F));
        flpInputs.Controls.Add(tblBtns);

        _btnProdAdd = new RjButton { Text = "Thêm mới", Dock = DockStyle.Fill, BackColor = UITheme.Primary, BorderRadius = 6 };
        _btnProdAdd.Click += BtnProdAdd_Click;
        tblBtns.Controls.Add(_btnProdAdd, 0, 0);

        _btnProdUpdate = new RjButton { Text = "Cập nhật", Dock = DockStyle.Fill, BackColor = UITheme.Accent, BorderRadius = 6, Enabled = false };
        _btnProdUpdate.Click += BtnProdUpdate_Click;
        tblBtns.Controls.Add(_btnProdUpdate, 1, 0);

        _btnProdDelete = new RjButton { Text = "Xóa món", Dock = DockStyle.Fill, BackColor = UITheme.Danger, BorderRadius = 6, Enabled = false };
        _btnProdDelete.Click += BtnProdDelete_Click;
        tblBtns.Controls.Add(_btnProdDelete, 2, 0);

        var btnClear = new RjButton
        {
            Text = "Làm mới Form",
            Size = new Size(330, 38),
            BackColor = Color.White,
            ForeColor = UITheme.TextDark,
            BorderColor = UITheme.Border,
            BorderSize = 1,
            BorderRadius = 6,
            Margin = new Padding(0, 0, 0, 0)
        };
        btnClear.Click += (_, _) => ClearProdForm();
        flpInputs.Controls.Add(btnClear);

        // Panel 2: Right Grid
        var pnlRight = split.Panel2;
        pnlRight.BackColor = UITheme.CanvasBg;
        pnlRight.Padding = new Padding(16);

        _dgvProducts = new DataGridView
        {
            Dock = DockStyle.Fill,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        };
        UITheme.ApplyModernGridStyle(_dgvProducts);

        _dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", Visible = false });
        _dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { Name = "Name", HeaderText = "Tên Món", FillWeight = 34 });
        _dgvProducts.Columns.Add(new DataGridViewTextBoxColumn { Name = "Category", HeaderText = "Danh Mục", FillWeight = 26 });

        var colPrice = new DataGridViewTextBoxColumn
        {
            Name = "Price",
            HeaderText = "Đơn Giá",
            FillWeight = 18,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleRight }
        };
        _dgvProducts.Columns.Add(colPrice);

        var colUnit = new DataGridViewTextBoxColumn
        {
            Name = "Unit",
            HeaderText = "ĐVT",
            FillWeight = 10,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
        };
        _dgvProducts.Columns.Add(colUnit);

        var colStatus = new DataGridViewTextBoxColumn
        {
            Name = "Status",
            HeaderText = "Trạng Thái",
            FillWeight = 12,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
        };
        _dgvProducts.Columns.Add(colStatus);

        _dgvProducts.SelectionChanged += DgvProducts_SelectionChanged;
        pnlRight.Controls.Add(_dgvProducts);
    }

    private void BuildCategoryTab(TabPage page)
    {
        var split = new SplitContainer
        {
            Dock = DockStyle.Fill,
            FixedPanel = FixedPanel.Panel1,
            SplitterDistance = 380,
            IsSplitterFixed = true,
            BackColor = UITheme.Border
        };
        page.Controls.Add(split);

        // Panel 1: Left Form
        var pnlLeft = split.Panel1;
        pnlLeft.BackColor = UITheme.Surface;
        pnlLeft.Padding = new Padding(24, 20, 24, 20);

        var lblTitle = new Label
        {
            Text = "THÔNG TIN DANH MỤC",
            Font = UITheme.FontHeader,
            ForeColor = UITheme.Primary,
            Dock = DockStyle.Top,
            Height = 35
        };
        pnlLeft.Controls.Add(lblTitle);

        var flpInputs = new FlowLayoutPanel
        {
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.TopDown,
            WrapContents = false
        };
        pnlLeft.Controls.Add(flpInputs);
        flpInputs.BringToFront();

        var lbl1 = new Label { Text = "Tên danh mục:", Font = UITheme.FontBold, Size = new Size(330, 20), Margin = new Padding(0, 10, 0, 4) };
        _txtCatName = new TextBox { Size = new Size(330, 32), Font = UITheme.FontRegular, BorderStyle = BorderStyle.FixedSingle, Margin = new Padding(0, 0, 0, 16) };
        flpInputs.Controls.Add(lbl1);
        flpInputs.Controls.Add(_txtCatName);

        var lbl2 = new Label { Text = "Mô tả danh mục:", Font = UITheme.FontBold, Size = new Size(330, 20), Margin = new Padding(0, 0, 0, 4) };
        _txtCatDesc = new TextBox { Size = new Size(330, 90), Multiline = true, Font = UITheme.FontRegular, BorderStyle = BorderStyle.FixedSingle, Margin = new Padding(0, 0, 0, 20) };
        flpInputs.Controls.Add(lbl2);
        flpInputs.Controls.Add(_txtCatDesc);

        // Buttons
        var tblBtns = new TableLayoutPanel
        {
            Size = new Size(330, 44),
            ColumnCount = 3,
            RowCount = 1,
            Margin = new Padding(0, 0, 0, 10)
        };
        tblBtns.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3F));
        tblBtns.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3F));
        tblBtns.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3F));
        flpInputs.Controls.Add(tblBtns);

        _btnCatAdd = new RjButton { Text = "Thêm mới", Dock = DockStyle.Fill, BackColor = UITheme.Primary, BorderRadius = 6 };
        _btnCatAdd.Click += BtnCatAdd_Click;
        tblBtns.Controls.Add(_btnCatAdd, 0, 0);

        _btnCatUpdate = new RjButton { Text = "Cập nhật", Dock = DockStyle.Fill, BackColor = UITheme.Accent, BorderRadius = 6, Enabled = false };
        _btnCatUpdate.Click += BtnCatUpdate_Click;
        tblBtns.Controls.Add(_btnCatUpdate, 1, 0);

        _btnCatDelete = new RjButton { Text = "Xóa", Dock = DockStyle.Fill, BackColor = UITheme.Danger, BorderRadius = 6, Enabled = false };
        _btnCatDelete.Click += BtnCatDelete_Click;
        tblBtns.Controls.Add(_btnCatDelete, 2, 0);

        var btnClear = new RjButton
        {
            Text = "Làm mới Form",
            Size = new Size(330, 38),
            BackColor = Color.White,
            ForeColor = UITheme.TextDark,
            BorderColor = UITheme.Border,
            BorderSize = 1,
            BorderRadius = 6
        };
        btnClear.Click += (_, _) => { _selectedCatId = 0; _txtCatName.Clear(); _txtCatDesc.Clear(); _btnCatAdd.Enabled = true; _btnCatUpdate.Enabled = false; _btnCatDelete.Enabled = false; };
        flpInputs.Controls.Add(btnClear);

        // Panel 2: Right Grid
        var pnlRight = split.Panel2;
        pnlRight.BackColor = UITheme.CanvasBg;
        pnlRight.Padding = new Padding(16);

        _dgvCategories = new DataGridView
        {
            Dock = DockStyle.Fill,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        };
        UITheme.ApplyModernGridStyle(_dgvCategories);
        _dgvCategories.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", Visible = false });
        _dgvCategories.Columns.Add(new DataGridViewTextBoxColumn { Name = "Name", HeaderText = "Tên Danh Mục", FillWeight = 35 });
        _dgvCategories.Columns.Add(new DataGridViewTextBoxColumn { Name = "Description", HeaderText = "Mô Tả", FillWeight = 45 });

        var colCount = new DataGridViewTextBoxColumn
        {
            Name = "ProductCount",
            HeaderText = "Số Lượng Món",
            FillWeight = 20,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
        };
        _dgvCategories.Columns.Add(colCount);

        _dgvCategories.SelectionChanged += DgvCategories_SelectionChanged;
        pnlRight.Controls.Add(_dgvCategories);
    }

    private List<Category> _categories = new();
    private List<Product> _products = new();

    private async void LoadDataAsync()
    {
        _categories = await _productService.GetAllCategoriesAsync();
        _products = await _productService.GetAllProductsAsync();

        _cbProdCategory.DataSource = _categories.ToList();
        _cbProdCategory.DisplayMember = "Name";
        _cbProdCategory.ValueMember = "Id";

        _dgvCategories.Rows.Clear();
        foreach (var c in _categories)
        {
            _dgvCategories.Rows.Add(c.Id, c.Name, c.Description ?? "", c.Products.Count);
        }

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
