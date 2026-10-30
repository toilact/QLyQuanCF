using System.Drawing;
using System.Windows.Forms;
using CoffeeShopManagement.Components;
using CoffeeShopManagement.Models;
using CoffeeShopManagement.Services.Interfaces;

namespace CoffeeShopManagement.Forms;

public class FrmTransferMergeTable : Form
{
    private readonly ITableService _tableService;
    private readonly Table _sourceTable;

    public int TargetTableId => (int)(_cbTargetTable.SelectedValue ?? 0);
    public bool IsMergeMode => _rbMerge.Checked;

    private ComboBox _cbTargetTable = null!;
    private RadioButton _rbSwitch = null!;
    private RadioButton _rbMerge = null!;
    private Label _lblTargetStatus = null!;
    private RjButton _btnConfirm = null!;

    public FrmTransferMergeTable(ITableService tableService, Table sourceTable)
    {
        _tableService = tableService;
        _sourceTable = sourceTable;

        InitializeComponent();
        LoadTablesAsync();
    }

    private void InitializeComponent()
    {
        Text = $"Chuyển / Gộp Bàn - {_sourceTable.Name}";
        Size = new Size(440, 360);
        StartPosition = FormStartPosition.CenterParent;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        BackColor = UITheme.CanvasBg;

        var pnlCard = new Panel
        {
            Location = new Point(20, 20),
            Size = new Size(385, 275),
            BackColor = UITheme.Surface,
            BorderStyle = BorderStyle.FixedSingle
        };
        Controls.Add(pnlCard);

        var lblSource = new Label
        {
            Text = $"Bàn nguồn: {_sourceTable.Name} ({_sourceTable.Area})",
            Font = UITheme.FontHeader,
            ForeColor = UITheme.Primary,
            Location = new Point(20, 16),
            Size = new Size(345, 25)
        };
        pnlCard.Controls.Add(lblSource);

        // Chế độ thao tác
        _rbSwitch = new RadioButton
        {
            Text = "Chuyển sang bàn trống khác",
            Font = UITheme.FontRegular,
            Location = new Point(25, 55),
            Size = new Size(340, 25),
            Checked = true
        };
        _rbSwitch.CheckedChanged += (_, _) => FilterTargetTables();
        pnlCard.Controls.Add(_rbSwitch);

        _rbMerge = new RadioButton
        {
            Text = "Gộp món vào bàn đang có khách",
            Font = UITheme.FontRegular,
            Location = new Point(25, 85),
            Size = new Size(340, 25)
        };
        _rbMerge.CheckedChanged += (_, _) => FilterTargetTables();
        pnlCard.Controls.Add(_rbMerge);

        // Bàn đích
        var lblTarget = new Label
        {
            Text = "Chọn bàn đích:",
            Font = UITheme.FontBold,
            Location = new Point(25, 125),
            Size = new Size(340, 20)
        };
        pnlCard.Controls.Add(lblTarget);

        _cbTargetTable = new ComboBox
        {
            Location = new Point(25, 150),
            Size = new Size(335, 30),
            DropDownStyle = ComboBoxStyle.DropDownList,
            Font = UITheme.FontRegular
        };
        pnlCard.Controls.Add(_cbTargetTable);

        _lblTargetStatus = new Label
        {
            Location = new Point(25, 185),
            Size = new Size(335, 20),
            Font = UITheme.FontSmall,
            ForeColor = UITheme.TextMuted
        };
        pnlCard.Controls.Add(_lblTargetStatus);

        // Nút bấm
        _btnConfirm = new RjButton
        {
            Text = "XÁC NHẬN",
            Location = new Point(210, 220),
            Size = new Size(150, 40),
            BackColor = UITheme.Primary,
            HoverBackColor = UITheme.PrimaryHover,
            BorderRadius = 6
        };
        _btnConfirm.Click += BtnConfirm_Click;
        pnlCard.Controls.Add(_btnConfirm);

        var btnCancel = new RjButton
        {
            Text = "HỦY",
            Location = new Point(90, 220),
            Size = new Size(110, 40),
            BackColor = Color.White,
            HoverBackColor = ColorTranslator.FromHtml("#F0EBE5"),
            ForeColor = UITheme.TextDark,
            BorderColor = UITheme.Border,
            BorderSize = 1,
            BorderRadius = 6
        };
        btnCancel.Click += (_, _) => { DialogResult = DialogResult.Cancel; Close(); };
        pnlCard.Controls.Add(btnCancel);
    }

    private List<Table> _allTables = new();

    private async void LoadTablesAsync()
    {
        _allTables = await _tableService.GetAllTablesAsync();
        FilterTargetTables();
    }

    private void FilterTargetTables()
    {
        var otherTables = _allTables.Where(t => t.Id != _sourceTable.Id).ToList();

        List<Table> filtered;
        if (_rbSwitch.Checked)
        {
            // Chỉ hiện các bàn trống
            filtered = otherTables.Where(t => t.Status == 0).ToList();
            _lblTargetStatus.Text = filtered.Any() ? $"{filtered.Count} bàn trống có thể chuyển." : "Không có bàn trống nào!";
        }
        else
        {
            // Chỉ hiện các bàn đang có khách để gộp
            filtered = otherTables.Where(t => t.Status == 1).ToList();
            _lblTargetStatus.Text = filtered.Any() ? $"{filtered.Count} bàn có khách có thể gộp." : "Không có bàn nào khác đang có khách!";
        }

        _cbTargetTable.DataSource = filtered;
        _cbTargetTable.DisplayMember = "Name";
        _cbTargetTable.ValueMember = "Id";
        _btnConfirm.Enabled = filtered.Any();
    }

    private void BtnConfirm_Click(object? sender, EventArgs e)
    {
        if (_cbTargetTable.SelectedValue == null)
        {
            MessageBox.Show("Vui lòng chọn bàn đích.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        DialogResult = DialogResult.OK;
        Close();
    }
}

