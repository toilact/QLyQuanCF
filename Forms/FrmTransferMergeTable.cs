using System.Windows.Forms;
using CoffeeShopManagement.Models;
using CoffeeShopManagement.Services.Interfaces;

namespace CoffeeShopManagement.Forms;

public partial class FrmTransferMergeTable : Form
{
    private readonly ITableService? _tableService;
    private readonly Table? _sourceTable;
    private List<Table> _allTables = new();

    public int TargetTableId => (int)(cboBanDich.SelectedValue ?? 0);
    public bool IsMergeMode => rdoGopBan.Checked;

    public FrmTransferMergeTable()
    {
        InitializeComponent();
    }

    public FrmTransferMergeTable(ITableService tableService, Table sourceTable) : this()
    {
        _tableService = tableService;
        _sourceTable = sourceTable;

        Text = $"Chuyển / Gộp Bàn - {_sourceTable.Name}";
        lblBanNguon.Text = $"Bàn nguồn: {_sourceTable.Name} ({_sourceTable.Area})";

        rdoChuyenBan.CheckedChanged += (_, _) => FilterTargetTables();
        rdoGopBan.CheckedChanged += (_, _) => FilterTargetTables();

        btnXacNhan.Click += BtnConfirm_Click;
        btnHuy.Click += (_, _) =>
        {
            DialogResult = DialogResult.Cancel;
            Close();
        };

        Load += async (_, _) => await LoadTablesAsync();
    }

    private async Task LoadTablesAsync()
    {
        if (_tableService == null) return;

        _allTables = await _tableService.GetAllTablesAsync();
        FilterTargetTables();
    }

    private void FilterTargetTables()
    {
        if (_sourceTable == null) return;

        var otherTables = _allTables.Where(t => t.Id != _sourceTable.Id).ToList();

        List<Table> filtered;
        if (rdoChuyenBan.Checked)
        {
            // Chỉ hiện các bàn trống
            filtered = otherTables.Where(t => t.Status == 0).ToList();
            lblTrangThaiBanDich.Text = filtered.Any() ? $"{filtered.Count} bàn trống có thể chuyển." : "Không có bàn trống nào!";
        }
        else
        {
            // Chỉ hiện các bàn đang có khách để gộp
            filtered = otherTables.Where(t => t.Status == 1).ToList();
            lblTrangThaiBanDich.Text = filtered.Any() ? $"{filtered.Count} bàn có khách có thể gộp." : "Không có bàn nào khác đang có khách!";
        }

        cboBanDich.DataSource = filtered;
        cboBanDich.DisplayMember = "Name";
        cboBanDich.ValueMember = "Id";
        btnXacNhan.Enabled = filtered.Any();
    }

    private void BtnConfirm_Click(object? sender, EventArgs e)
    {
        if (cboBanDich.SelectedValue == null)
        {
            MessageBox.Show("Vui lòng chọn bàn đích.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        DialogResult = DialogResult.OK;
        Close();
    }
}
