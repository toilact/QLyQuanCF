using System.Windows.Forms;
using CoffeeShopManagement.Components;
using CoffeeShopManagement.Models;
using CoffeeShopManagement.Services.Interfaces;

namespace CoffeeShopManagement.Forms;

public partial class FrmTableManager : Form
{
    private readonly ITableService? _tableService;
    private int _selectedTableId = 0;
    private List<Table> _tables = new();

    public FrmTableManager()
    {
        InitializeComponent();
    }

    public FrmTableManager(ITableService tableService) : this()
    {
        _tableService = tableService;

        UITheme.ApplyModernGridStyle(dgvBan);
        SetupTableGridColumns();

        btnThem.Click += BtnThem_Click;
        btnCapNhat.Click += BtnCapNhat_Click;
        btnXoa.Click += BtnXoa_Click;
        btnLamMoi.Click += (_, _) => ClearForm();
        dgvBan.SelectionChanged += DgvBan_SelectionChanged;

        Load += async (_, _) => await LoadDataAsync();
    }

    private void SetupTableGridColumns()
    {
        dgvBan.Columns.Clear();
        dgvBan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        dgvBan.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", Visible = false });
        dgvBan.Columns.Add(new DataGridViewTextBoxColumn { Name = "Name", HeaderText = "Tên Bàn", FillWeight = 35 });
        dgvBan.Columns.Add(new DataGridViewTextBoxColumn { Name = "Area", HeaderText = "Khu Vực", FillWeight = 35 });

        var colStatus = new DataGridViewTextBoxColumn
        {
            Name = "Status",
            HeaderText = "Trạng Thái",
            FillWeight = 30,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
        };
        dgvBan.Columns.Add(colStatus);
    }

    private async Task LoadDataAsync()
    {
        if (_tableService == null) return;

        _tables = await _tableService.GetAllTablesAsync();

        var areas = _tables.Select(t => t.Area).Distinct().ToList();
        cboKhuVuc.Items.Clear();
        foreach (var a in areas) cboKhuVuc.Items.Add(a);
        if (cboKhuVuc.Items.Count > 0) cboKhuVuc.SelectedIndex = 0;

        dgvBan.Rows.Clear();
        foreach (var t in _tables)
        {
            dgvBan.Rows.Add(t.Id, t.Name, t.Area, t.Status == 0 ? "Trống" : "Có khách");
        }
    }

    private void DgvBan_SelectionChanged(object? sender, EventArgs e)
    {
        if (dgvBan.SelectedRows.Count == 0) return;
        var row = dgvBan.SelectedRows[0];
        if (row.Cells["Id"].Value is not int id) return;

        var table = _tables.FirstOrDefault(t => t.Id == id);
        if (table == null) return;

        _selectedTableId = table.Id;
        txtTenBan.Text = table.Name;
        cboKhuVuc.Text = table.Area;

        btnThem.Enabled = false;
        btnCapNhat.Enabled = true;
        btnXoa.Enabled = (table.Status == 0);
    }

    private void ClearForm()
    {
        _selectedTableId = 0;
        txtTenBan.Clear();
        btnThem.Enabled = true;
        btnCapNhat.Enabled = false;
        btnXoa.Enabled = false;
    }

    private async void BtnThem_Click(object? sender, EventArgs e)
    {
        if (_tableService == null) return;

        string name = txtTenBan.Text.Trim();
        string area = cboKhuVuc.Text.Trim();

        if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(area))
        {
            MessageBox.Show("Vui lòng nhập tên bàn và khu vực.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var table = new Table { Name = name, Area = area, Status = 0 };
        await _tableService.CreateTableAsync(table);
        ClearForm();
        await LoadDataAsync();
    }

    private async void BtnCapNhat_Click(object? sender, EventArgs e)
    {
        if (_tableService == null || _selectedTableId == 0) return;

        var table = await _tableService.GetTableByIdAsync(_selectedTableId);
        if (table == null) return;

        table.Name = txtTenBan.Text.Trim();
        table.Area = cboKhuVuc.Text.Trim();

        await _tableService.UpdateTableAsync(table);
        ClearForm();
        await LoadDataAsync();
    }

    private async void BtnXoa_Click(object? sender, EventArgs e)
    {
        if (_tableService == null || _selectedTableId == 0) return;

        try
        {
            if (MessageBox.Show("Xác nhận xóa bàn này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                await _tableService.DeleteTableAsync(_selectedTableId);
                ClearForm();
                await LoadDataAsync();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
