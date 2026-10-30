using System.Windows.Forms;
using CoffeeShopManagement.Components;
using CoffeeShopManagement.Models;
using CoffeeShopManagement.Services.Interfaces;

namespace CoffeeShopManagement.Forms;

public partial class FrmUserManager : Form
{
    private readonly IAuthService? _authService;
    private readonly User? _currentUser;
    private int _selectedUserId = 0;
    private List<User> _users = new();

    public FrmUserManager()
    {
        InitializeComponent();
    }

    public FrmUserManager(IAuthService authService, User currentUser) : this()
    {
        _authService = authService;
        _currentUser = currentUser;

        UITheme.ApplyModernGridStyle(dgvNhanVien);
        SetupUserGridColumns();

        btnThem.Click += BtnThem_Click;
        btnCapNhat.Click += BtnCapNhat_Click;
        btnKhoaMo.Click += BtnKhoaMo_Click;
        btnLamMoi.Click += (_, _) => ClearForm();
        dgvNhanVien.SelectionChanged += DgvNhanVien_SelectionChanged;

        Load += async (_, _) => await LoadDataAsync();
    }

    private void SetupUserGridColumns()
    {
        dgvNhanVien.Columns.Clear();
        dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", Visible = false });
        dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn { Name = "Username", HeaderText = "Tên Đăng Nhập", FillWeight = 26 });
        dgvNhanVien.Columns.Add(new DataGridViewTextBoxColumn { Name = "FullName", HeaderText = "Họ Và Tên", FillWeight = 38 });

        var colRole = new DataGridViewTextBoxColumn
        {
            Name = "Role",
            HeaderText = "Vai Trò",
            FillWeight = 18,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
        };
        dgvNhanVien.Columns.Add(colRole);

        var colStatus = new DataGridViewTextBoxColumn
        {
            Name = "Status",
            HeaderText = "Trạng Thái",
            FillWeight = 18,
            DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
        };
        dgvNhanVien.Columns.Add(colStatus);
    }

    private async Task LoadDataAsync()
    {
        if (_authService == null) return;

        _users = await _authService.GetAllUsersAsync();
        dgvNhanVien.Rows.Clear();
        foreach (var u in _users)
        {
            dgvNhanVien.Rows.Add(u.Id, u.Username, u.FullName, u.Role, u.IsActive ? "Đang hoạt động" : "Đã khóa");
        }
    }

    private void DgvNhanVien_SelectionChanged(object? sender, EventArgs e)
    {
        if (dgvNhanVien.SelectedRows.Count == 0) return;
        var row = dgvNhanVien.SelectedRows[0];
        if (row.Cells["Id"].Value is not int id) return;

        var user = _users.FirstOrDefault(u => u.Id == id);
        if (user == null) return;

        _selectedUserId = user.Id;
        txtTenDangNhap.Text = user.Username;
        txtTenDangNhap.ReadOnly = true;
        txtHoTen.Text = user.FullName;
        cboVaiTro.SelectedItem = user.Role;
        chkHoatDong.Checked = user.IsActive;
        txtMatKhau.Clear();

        btnThem.Enabled = false;
        btnCapNhat.Enabled = true;
        btnKhoaMo.Enabled = (_currentUser != null && user.Id != _currentUser.Id);
        btnKhoaMo.Text = user.IsActive ? "Khóa" : "Mở khóa";
    }

    private void ClearForm()
    {
        _selectedUserId = 0;
        txtTenDangNhap.Clear();
        txtTenDangNhap.ReadOnly = false;
        txtMatKhau.Clear();
        txtHoTen.Clear();
        cboVaiTro.SelectedIndex = 0;
        chkHoatDong.Checked = true;
        btnThem.Enabled = true;
        btnCapNhat.Enabled = false;
        btnKhoaMo.Enabled = false;
    }

    private async void BtnThem_Click(object? sender, EventArgs e)
    {
        if (_authService == null) return;

        string username = txtTenDangNhap.Text.Trim();
        string password = txtMatKhau.Text;
        string fullName = txtHoTen.Text.Trim();

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
                Role = cboVaiTro.SelectedItem?.ToString() ?? "Staff",
                IsActive = chkHoatDong.Checked
            };

            await _authService.CreateUserAsync(newUser, password);
            ClearForm();
            await LoadDataAsync();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Lỗi tạo tài khoản: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void BtnCapNhat_Click(object? sender, EventArgs e)
    {
        if (_authService == null || _selectedUserId == 0) return;

        var user = _users.FirstOrDefault(u => u.Id == _selectedUserId);
        if (user == null) return;

        user.FullName = txtHoTen.Text.Trim();
        user.Role = cboVaiTro.SelectedItem?.ToString() ?? "Staff";
        user.IsActive = chkHoatDong.Checked;

        string? newPass = string.IsNullOrWhiteSpace(txtMatKhau.Text) ? null : txtMatKhau.Text;
        await _authService.UpdateUserAsync(user, newPass);

        ClearForm();
        await LoadDataAsync();
    }

    private async void BtnKhoaMo_Click(object? sender, EventArgs e)
    {
        if (_authService == null || _selectedUserId == 0 || (_currentUser != null && _selectedUserId == _currentUser.Id)) return;

        await _authService.ToggleUserStatusAsync(_selectedUserId);
        ClearForm();
        await LoadDataAsync();
    }
}
