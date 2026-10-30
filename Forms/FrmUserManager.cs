using System.Drawing;
using System.Windows.Forms;
using CoffeeShopManagement.Components;
using CoffeeShopManagement.Models;
using CoffeeShopManagement.Services.Interfaces;

namespace CoffeeShopManagement.Forms;

public class FrmUserManager : Form
{
    private readonly IAuthService _authService;
    private readonly User _currentUser;

    private DataGridView _dgvUsers = null!;
    private TextBox _txtUsername = null!;
    private TextBox _txtPassword = null!;
    private TextBox _txtFullName = null!;
    private ComboBox _cbRole = null!;
    private CheckBox _chkActive = null!;
    private RjButton _btnAdd = null!;
    private RjButton _btnUpdate = null!;
    private RjButton _btnToggleStatus = null!;
    private int _selectedUserId = 0;

    public FrmUserManager(IAuthService authService, User currentUser)
    {
        _authService = authService;
        _currentUser = currentUser;

        InitializeComponent();
        LoadDataAsync();
    }

    private void InitializeComponent()
    {
        Text = "Quản Trị Người Dùng và Phân Quyền";
        Size = new Size(1080, 650);
        MinimumSize = new Size(950, 550);
        StartPosition = FormStartPosition.CenterParent;
        BackColor = UITheme.CanvasBg;

        var split = new SplitContainer
        {
            Dock = DockStyle.Fill,
            FixedPanel = FixedPanel.Panel1,
            SplitterDistance = 370,
            IsSplitterFixed = true,
            BackColor = UITheme.Border
        };
        Controls.Add(split);

        // Left Panel (Form)
        var pnlLeft = split.Panel1;
        pnlLeft.BackColor = UITheme.Surface;
        pnlLeft.Padding = new Padding(24, 20, 24, 20);

        var lblTitle = new Label
        {
            Text = "THÔNG TIN TÀI KHOẢN",
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

        void AddField(string label, Control ctrl)
        {
            var lbl = new Label
            {
                Text = label,
                Font = UITheme.FontBold,
                ForeColor = UITheme.TextDark,
                Size = new Size(320, 20),
                Margin = new Padding(0, 8, 0, 4)
            };
            ctrl.Size = new Size(320, 32);
            ctrl.Margin = new Padding(0, 0, 0, 12);

            flpInputs.Controls.Add(lbl);
            flpInputs.Controls.Add(ctrl);
        }

        _txtUsername = new TextBox { Font = UITheme.FontRegular, BorderStyle = BorderStyle.FixedSingle };
        AddField("Tên đăng nhập:", _txtUsername);

        _txtPassword = new TextBox { Font = UITheme.FontRegular, UseSystemPasswordChar = true, BorderStyle = BorderStyle.FixedSingle };
        AddField("Mật khẩu (để trống nếu không đổi):", _txtPassword);

        _txtFullName = new TextBox { Font = UITheme.FontRegular, BorderStyle = BorderStyle.FixedSingle };
        AddField("Họ và tên nhân viên:", _txtFullName);

        _cbRole = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Font = UITheme.FontRegular };
        _cbRole.Items.AddRange(new object[] { "Staff", "Admin" });
        _cbRole.SelectedIndex = 0;
        AddField("Vai trò phân quyền:", _cbRole);

        _chkActive = new CheckBox
        {
            Text = "Tài khoản đang hoạt động",
            Checked = true,
            Font = UITheme.FontRegular,
            Size = new Size(320, 28),
            Margin = new Padding(0, 4, 0, 16)
        };
        flpInputs.Controls.Add(_chkActive);

        // Buttons Table
        var tblBtns = new TableLayoutPanel
        {
            Size = new Size(320, 44),
            ColumnCount = 3,
            RowCount = 1,
            Margin = new Padding(0, 0, 0, 10)
        };
        tblBtns.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3F));
        tblBtns.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3F));
        tblBtns.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3F));
        flpInputs.Controls.Add(tblBtns);

        _btnAdd = new RjButton { Text = "Thêm mới", Dock = DockStyle.Fill, BackColor = UITheme.Primary, BorderRadius = 6 };
        _btnAdd.Click += BtnAdd_Click;
        tblBtns.Controls.Add(_btnAdd, 0, 0);

        _btnUpdate = new RjButton { Text = "Cập nhật", Dock = DockStyle.Fill, BackColor = UITheme.Accent, BorderRadius = 6, Enabled = false };
        _btnUpdate.Click += BtnUpdate_Click;
        tblBtns.Controls.Add(_btnUpdate, 1, 0);

        _btnToggleStatus = new RjButton { Text = "Khóa/Mở", Dock = DockStyle.Fill, BackColor = UITheme.Danger, BorderRadius = 6, Enabled = false };
        _btnToggleStatus.Click += BtnToggleStatus_Click;
        tblBtns.Controls.Add(_btnToggleStatus, 2, 0);

        var btnClear = new RjButton
        {
            Text = "Làm mới Form",
            Size = new Size(320, 38),
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

        _dgvUsers = new DataGridView
        {
            Dock = DockStyle.Fill,
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        };
        UITheme.ApplyModernGridStyle(_dgvUsers);

        _dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", Visible = false });
        _dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { Name = "Username", HeaderText = "Tên Đăng Nhập", FillWeight = 26 });
        _dgvUsers.Columns.Add(new DataGridViewTextBoxColumn { Name = "FullName", HeaderText = "Họ Và Tên", FillWeight = 38 });

        var colRole = new DataGridViewTextBoxColumn
        {
            Name = "Role",
            HeaderText = "Vai Trò",
            FillWeight = 18,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
        };
        _dgvUsers.Columns.Add(colRole);

        var colStatus = new DataGridViewTextBoxColumn
        {
            Name = "Status",
            HeaderText = "Trạng Thái",
            FillWeight = 18,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
        };
        _dgvUsers.Columns.Add(colStatus);

        _dgvUsers.SelectionChanged += DgvUsers_SelectionChanged;
        pnlRight.Controls.Add(_dgvUsers);
    }

    private List<User> _users = new();

    private async void LoadDataAsync()
    {
        _users = await _authService.GetAllUsersAsync();
        _dgvUsers.Rows.Clear();
        foreach (var u in _users)
        {
            _dgvUsers.Rows.Add(u.Id, u.Username, u.FullName, u.Role, u.IsActive ? "Đang hoạt động" : "Đã khóa");
        }
    }

    private void DgvUsers_SelectionChanged(object? sender, EventArgs e)
    {
        if (_dgvUsers.SelectedRows.Count == 0) return;
        var row = _dgvUsers.SelectedRows[0];
        if (row.Cells["Id"].Value is not int id) return;

        var user = _users.FirstOrDefault(u => u.Id == id);
        if (user == null) return;

        _selectedUserId = user.Id;
        _txtUsername.Text = user.Username;
        _txtUsername.ReadOnly = true;
        _txtFullName.Text = user.FullName;
        _cbRole.SelectedItem = user.Role;
        _chkActive.Checked = user.IsActive;
        _txtPassword.Clear();

        _btnAdd.Enabled = false;
        _btnUpdate.Enabled = true;
        _btnToggleStatus.Enabled = (user.Id != _currentUser.Id);
        _btnToggleStatus.Text = user.IsActive ? "Khóa" : "Mở khóa";
    }

    private void ClearForm()
    {
        _selectedUserId = 0;
        _txtUsername.Clear();
        _txtUsername.ReadOnly = false;
        _txtPassword.Clear();
        _txtFullName.Clear();
        _cbRole.SelectedIndex = 0;
        _chkActive.Checked = true;
        _btnAdd.Enabled = true;
        _btnUpdate.Enabled = false;
        _btnToggleStatus.Enabled = false;
    }

    private async void BtnAdd_Click(object? sender, EventArgs e)
    {
        string username = _txtUsername.Text.Trim();
        string password = _txtPassword.Text;
        string fullName = _txtFullName.Text.Trim();

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(fullName))
        {
            MessageBox.Show("Vui lòng điền đầy đủ tên đăng nhập, mật khẩu và họ tên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            var newUser = new User
            {
                Username = username,
                FullName = fullName,
                Role = _cbRole.SelectedItem?.ToString() ?? "Staff",
                IsActive = _chkActive.Checked
            };

            await _authService.CreateUserAsync(newUser, password);
            ClearForm();
            LoadDataAsync();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi tạo tài khoản: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void BtnUpdate_Click(object? sender, EventArgs e)
    {
        if (_selectedUserId == 0) return;

        var user = _users.FirstOrDefault(u => u.Id == _selectedUserId);
        if (user == null) return;

        user.FullName = _txtFullName.Text.Trim();
        user.Role = _cbRole.SelectedItem?.ToString() ?? "Staff";
        user.IsActive = _chkActive.Checked;

        string? newPass = string.IsNullOrWhiteSpace(_txtPassword.Text) ? null : _txtPassword.Text;
        await _authService.UpdateUserAsync(user, newPass);

        ClearForm();
        LoadDataAsync();
    }

    private async void BtnToggleStatus_Click(object? sender, EventArgs e)
    {
        if (_selectedUserId == 0 || _selectedUserId == _currentUser.Id) return;

        await _authService.ToggleUserStatusAsync(_selectedUserId);
        ClearForm();
        LoadDataAsync();
    }
}
