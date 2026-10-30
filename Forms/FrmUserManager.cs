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
        Text = "Quản Trị Người Dùng & Phân Quyền";
        Size = new Size(960, 600);
        StartPosition = FormStartPosition.CenterParent;
        BackColor = UITheme.CanvasBg;

        // Left Panel (Form)
        var pnlLeft = new Panel
        {
            Dock = DockStyle.Left,
            Width = 340,
            BackColor = UITheme.Surface,
            BorderStyle = BorderStyle.FixedSingle,
            Padding = new Padding(16)
        };
        Controls.Add(pnlLeft);

        var lblTitle = new Label { Text = "THÔNG TIN TÀI KHOẢN", Font = UITheme.FontHeader, ForeColor = UITheme.Primary, Location = new Point(16, 16), AutoSize = true };
        pnlLeft.Controls.Add(lblTitle);

        int y = 55;
        void AddField(string label, Control ctrl)
        {
            var lbl = new Label { Text = label, Font = UITheme.FontBold, Location = new Point(16, y), AutoSize = true };
            ctrl.Location = new Point(16, y + 22);
            ctrl.Width = 300;
            pnlLeft.Controls.Add(lbl);
            pnlLeft.Controls.Add(ctrl);
            y += 62;
        }

        _txtUsername = new TextBox { Font = UITheme.FontRegular, BorderStyle = BorderStyle.FixedSingle };
        AddField("Tên đăng nhập:", _txtUsername);

        _txtPassword = new TextBox { Font = UITheme.FontRegular, UseSystemPasswordChar = true, BorderStyle = BorderStyle.FixedSingle };
        AddField("Mật khẩu (để trống nếu không đổi):", _txtPassword);

        _txtFullName = new TextBox { Font = UITheme.FontRegular, BorderStyle = BorderStyle.FixedSingle };
        AddField("Họ và tên:", _txtFullName);

        _cbRole = new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Font = UITheme.FontRegular };
        _cbRole.Items.AddRange(new object[] { "Staff", "Admin" });
        _cbRole.SelectedIndex = 0;
        AddField("Vai trò (Phân quyền):", _cbRole);

        _chkActive = new CheckBox { Text = "Tài khoản đang hoạt động", Checked = true, Font = UITheme.FontRegular, Location = new Point(16, y), AutoSize = true };
        pnlLeft.Controls.Add(_chkActive);
        y += 40;

        _btnAdd = new RjButton { Text = "Thêm mới", Location = new Point(16, y), Size = new Size(95, 38), BackColor = UITheme.Primary, BorderRadius = 6 };
        _btnAdd.Click += BtnAdd_Click;
        pnlLeft.Controls.Add(_btnAdd);

        _btnUpdate = new RjButton { Text = "Cập nhật", Location = new Point(118, y), Size = new Size(95, 38), BackColor = UITheme.Accent, BorderRadius = 6, Enabled = false };
        _btnUpdate.Click += BtnUpdate_Click;
        pnlLeft.Controls.Add(_btnUpdate);

        _btnToggleStatus = new RjButton { Text = "Khóa/Mở", Location = new Point(220, y), Size = new Size(95, 38), BackColor = UITheme.Danger, BorderRadius = 6, Enabled = false };
        _btnToggleStatus.Click += BtnToggleStatus_Click;
        pnlLeft.Controls.Add(_btnToggleStatus);

        var btnClear = new RjButton { Text = "Làm mới form", Location = new Point(16, y + 48), Size = new Size(300, 34), BackColor = Color.White, ForeColor = UITheme.TextDark, BorderColor = UITheme.Border, BorderSize = 1, BorderRadius = 6 };
        btnClear.Click += (_, _) => ClearForm();
        pnlLeft.Controls.Add(btnClear);

        // Right DataGridView
        var pnlRight = new Panel { Dock = DockStyle.Fill, Padding = new Padding(12), BackColor = UITheme.CanvasBg };
        Controls.Add(pnlRight);

        _dgvUsers = new DataGridView { Dock = DockStyle.Fill };
        UITheme.ApplyModernGridStyle(_dgvUsers);
        _dgvUsers.Columns.Add("Id", "ID");
        _dgvUsers.Columns["Id"].Visible = false;
        _dgvUsers.Columns.Add("Username", "Tên Đăng Nhập");
        _dgvUsers.Columns["Username"].Width = 140;
        _dgvUsers.Columns.Add("FullName", "Họ Và Tên");
        _dgvUsers.Columns["FullName"].Width = 180;
        _dgvUsers.Columns.Add("Role", "Vai Trò");
        _dgvUsers.Columns["Role"].Width = 100;
        _dgvUsers.Columns.Add("Status", "Trạng Thái");
        _dgvUsers.Columns["Status"].Width = 110;

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
        _btnToggleStatus.Enabled = (user.Id != _currentUser.Id); // Không tự khóa chính mình
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
            MessageBox.Show($"Lỗi tạo tài khoản (có thể username đã tồn tại): {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

