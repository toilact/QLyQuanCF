using System.Drawing;
using System.Windows.Forms;
using CoffeeShopManagement.Components;
using CoffeeShopManagement.Models;
using CoffeeShopManagement.Services.Interfaces;

namespace CoffeeShopManagement.Forms;

public class FrmTableManager : Form
{
    private readonly ITableService _tableService;

    private DataGridView _dgvTables = null!;
    private TextBox _txtTableName = null!;
    private ComboBox _cbTableArea = null!;
    private RjButton _btnAdd = null!;
    private RjButton _btnUpdate = null!;
    private RjButton _btnDelete = null!;
    private int _selectedTableId = 0;

    public FrmTableManager(ITableService tableService)
    {
        _tableService = tableService;
        InitializeComponent();
        LoadDataAsync();
    }

    private void InitializeComponent()
    {
        Text = "Quản Lý Bàn & Khu Vực";
        Size = new Size(880, 560);
        StartPosition = FormStartPosition.CenterParent;
        BackColor = UITheme.CanvasBg;

        // Left Panel (Input Form)
        var pnlLeft = new Panel
        {
            Dock = DockStyle.Left,
            Width = 320,
            BackColor = UITheme.Surface,
            BorderStyle = BorderStyle.FixedSingle,
            Padding = new Padding(16)
        };
        Controls.Add(pnlLeft);

        var lblTitle = new Label
        {
            Text = "THÔNG TIN BÀN",
            Font = UITheme.FontHeader,
            ForeColor = UITheme.Primary,
            Location = new Point(16, 16),
            AutoSize = true
        };
        pnlLeft.Controls.Add(lblTitle);

        var lbl1 = new Label { Text = "Tên bàn:", Font = UITheme.FontBold, Location = new Point(16, 60), AutoSize = true };
        _txtTableName = new TextBox { Location = new Point(16, 85), Width = 280, Font = UITheme.FontRegular, BorderStyle = BorderStyle.FixedSingle };
        pnlLeft.Controls.Add(lbl1);
        pnlLeft.Controls.Add(_txtTableName);

        var lbl2 = new Label { Text = "Khu vực:", Font = UITheme.FontBold, Location = new Point(16, 125), AutoSize = true };
        _cbTableArea = new ComboBox { Location = new Point(16, 150), Width = 280, Font = UITheme.FontRegular };
        pnlLeft.Controls.Add(lbl2);
        pnlLeft.Controls.Add(_cbTableArea);

        // Buttons
        _btnAdd = new RjButton { Text = "Thêm bàn", Location = new Point(16, 210), Size = new Size(85, 38), BackColor = UITheme.Primary, BorderRadius = 6 };
        _btnAdd.Click += BtnAdd_Click;
        pnlLeft.Controls.Add(_btnAdd);

        _btnUpdate = new RjButton { Text = "Cập nhật", Location = new Point(108, 210), Size = new Size(90, 38), BackColor = UITheme.Accent, BorderRadius = 6, Enabled = false };
        _btnUpdate.Click += BtnUpdate_Click;
        pnlLeft.Controls.Add(_btnUpdate);

        _btnDelete = new RjButton { Text = "Xóa bàn", Location = new Point(205, 210), Size = new Size(90, 38), BackColor = UITheme.Danger, BorderRadius = 6, Enabled = false };
        _btnDelete.Click += BtnDelete_Click;
        pnlLeft.Controls.Add(_btnDelete);

        var btnClear = new RjButton { Text = "Làm mới form", Location = new Point(16, 260), Size = new Size(280, 34), BackColor = Color.White, ForeColor = UITheme.TextDark, BorderColor = UITheme.Border, BorderSize = 1, BorderRadius = 6 };
        btnClear.Click += (_, _) => ClearForm();
        pnlLeft.Controls.Add(btnClear);

        // Right DataGridView
        var pnlRight = new Panel { Dock = DockStyle.Fill, Padding = new Padding(12), BackColor = UITheme.CanvasBg };
        Controls.Add(pnlRight);

        _dgvTables = new DataGridView { Dock = DockStyle.Fill };
        UITheme.ApplyModernGridStyle(_dgvTables);
        _dgvTables.Columns.Add("Id", "ID");
        _dgvTables.Columns["Id"].Visible = false;
        _dgvTables.Columns.Add("Name", "Tên Bàn");
        _dgvTables.Columns["Name"].Width = 160;
        _dgvTables.Columns.Add("Area", "Khu Vực");
        _dgvTables.Columns["Area"].Width = 180;
        _dgvTables.Columns.Add("Status", "Trạng Thái");
        _dgvTables.Columns["Status"].Width = 140;

        _dgvTables.SelectionChanged += DgvTables_SelectionChanged;
        pnlRight.Controls.Add(_dgvTables);
    }

    private List<Table> _tables = new();

    private async void LoadDataAsync()
    {
        _tables = await _tableService.GetAllTablesAsync();

        // Load distinct areas into combobox
        var areas = _tables.Select(t => t.Area).Distinct().ToList();
        _cbTableArea.Items.Clear();
        foreach (var a in areas) _cbTableArea.Items.Add(a);
        if (_cbTableArea.Items.Count > 0) _cbTableArea.SelectedIndex = 0;

        _dgvTables.Rows.Clear();
        foreach (var t in _tables)
        {
            _dgvTables.Rows.Add(t.Id, t.Name, t.Area, t.Status == 0 ? "Trống" : "Có khách");
        }
    }

    private void DgvTables_SelectionChanged(object? sender, EventArgs e)
    {
        if (_dgvTables.SelectedRows.Count == 0) return;
        var row = _dgvTables.SelectedRows[0];
        if (row.Cells["Id"].Value is not int id) return;

        var table = _tables.FirstOrDefault(t => t.Id == id);
        if (table == null) return;

        _selectedTableId = table.Id;
        _txtTableName.Text = table.Name;
        _cbTableArea.Text = table.Area;

        _btnAdd.Enabled = false;
        _btnUpdate.Enabled = true;
        _btnDelete.Enabled = (table.Status == 0); // Chỉ cho xóa nếu bàn trống
    }

    private void ClearForm()
    {
        _selectedTableId = 0;
        _txtTableName.Clear();
        _btnAdd.Enabled = true;
        _btnUpdate.Enabled = false;
        _btnDelete.Enabled = false;
    }

    private async void BtnAdd_Click(object? sender, EventArgs e)
    {
        string name = _txtTableName.Text.Trim();
        string area = _cbTableArea.Text.Trim();

        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(area))
        {
            MessageBox.Show("Vui lòng nhập tên bàn và khu vực.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var table = new Table { Name = name, Area = area, Status = 0 };
        await _tableService.CreateTableAsync(table);
        ClearForm();
        LoadDataAsync();
    }

    private async void BtnUpdate_Click(object? sender, EventArgs e)
    {
        if (_selectedTableId == 0) return;

        var table = await _tableService.GetTableByIdAsync(_selectedTableId);
        if (table == null) return;

        table.Name = _txtTableName.Text.Trim();
        table.Area = _cbTableArea.Text.Trim();

        await _tableService.UpdateTableAsync(table);
        ClearForm();
        LoadDataAsync();
    }

    private async void BtnDelete_Click(object? sender, EventArgs e)
    {
        if (_selectedTableId == 0) return;

        try
        {
            if (MessageBox.Show("Xác nhận xóa bàn này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                await _tableService.DeleteTableAsync(_selectedTableId);
                ClearForm();
                LoadDataAsync();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
