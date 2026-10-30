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
        Text = "Quản Lý Bàn và Khu Vực";
        Size = new Size(980, 620);
        MinimumSize = new Size(880, 520);
        StartPosition = FormStartPosition.CenterParent;
        BackColor = UITheme.CanvasBg;

        var split = new SplitContainer
        {
            Dock = DockStyle.Fill,
            FixedPanel = FixedPanel.Panel1,
            SplitterDistance = 350,
            IsSplitterFixed = true,
            BackColor = UITheme.Border
        };
        Controls.Add(split);

        // Left Panel (Input Form)
        var pnlLeft = split.Panel1;
        pnlLeft.BackColor = UITheme.Surface;
        pnlLeft.Padding = new Padding(24, 20, 24, 20);

        var lblTitle = new Label
        {
            Text = "THÔNG TIN BÀN ĂN",
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

        var lbl1 = new Label { Text = "Tên bàn:", Font = UITheme.FontBold, Size = new Size(300, 20), Margin = new Padding(0, 10, 0, 4) };
        _txtTableName = new TextBox { Size = new Size(300, 32), Font = UITheme.FontRegular, BorderStyle = BorderStyle.FixedSingle, Margin = new Padding(0, 0, 0, 16) };
        flpInputs.Controls.Add(lbl1);
        flpInputs.Controls.Add(_txtTableName);

        var lbl2 = new Label { Text = "Khu vực (Tầng 1, Sân vườn,...):", Font = UITheme.FontBold, Size = new Size(300, 20), Margin = new Padding(0, 0, 0, 4) };
        _cbTableArea = new ComboBox { Size = new Size(300, 32), Font = UITheme.FontRegular, Margin = new Padding(0, 0, 0, 24) };
        flpInputs.Controls.Add(lbl2);
        flpInputs.Controls.Add(_cbTableArea);

        // Action Buttons Table
        var tblBtns = new TableLayoutPanel
        {
            Size = new Size(300, 44),
            ColumnCount = 3,
            RowCount = 1,
            Margin = new Padding(0, 0, 0, 10)
        };
        tblBtns.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3F));
        tblBtns.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3F));
        tblBtns.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3F));
        flpInputs.Controls.Add(tblBtns);

        _btnAdd = new RjButton { Text = "Thêm bàn", Dock = DockStyle.Fill, BackColor = UITheme.Primary, BorderRadius = 6 };
        _btnAdd.Click += BtnAdd_Click;
        tblBtns.Controls.Add(_btnAdd, 0, 0);

        _btnUpdate = new RjButton { Text = "Cập nhật", Dock = DockStyle.Fill, BackColor = UITheme.Accent, BorderRadius = 6, Enabled = false };
        _btnUpdate.Click += BtnUpdate_Click;
        tblBtns.Controls.Add(_btnUpdate, 1, 0);

        _btnDelete = new RjButton { Text = "Xóa bàn", Dock = DockStyle.Fill, BackColor = UITheme.Danger, BorderRadius = 6, Enabled = false };
        _btnDelete.Click += BtnDelete_Click;
        tblBtns.Controls.Add(_btnDelete, 2, 0);

        var btnClear = new RjButton
        {
            Text = "Làm mới Form",
            Size = new Size(300, 38),
            BackColor = Color.White,
            ForeColor = UITheme.TextDark,
            BorderColor = UITheme.Border,
            BorderSize = 1,
            BorderRadius = 6
        };
        btnClear.Click += (_, _) => ClearForm();
        flpInputs.Controls.Add(btnClear);

        // Right DataGridView
        var pnlRight = split.Panel2;
        pnlRight.BackColor = UITheme.CanvasBg;
        pnlRight.Padding = new Padding(16);

        _dgvTables = new DataGridView
        {
            Dock = DockStyle.Fill,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        };
        UITheme.ApplyModernGridStyle(_dgvTables);

        _dgvTables.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", Visible = false });
        _dgvTables.Columns.Add(new DataGridViewTextBoxColumn { Name = "Name", HeaderText = "Tên Bàn", FillWeight = 35 });
        _dgvTables.Columns.Add(new DataGridViewTextBoxColumn { Name = "Area", HeaderText = "Khu Vực", FillWeight = 35 });

        var colStatus = new DataGridViewTextBoxColumn
        {
            Name = "Status",
            HeaderText = "Trạng Thái",
            FillWeight = 30,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
        };
        _dgvTables.Columns.Add(colStatus);

        _dgvTables.SelectionChanged += DgvTables_SelectionChanged;
        pnlRight.Controls.Add(_dgvTables);
    }

    private List<Table> _tables = new();

    private async void LoadDataAsync()
    {
        _tables = await _tableService.GetAllTablesAsync();

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
        _btnDelete.Enabled = (table.Status == 0);
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
