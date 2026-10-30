using System.Windows.Forms;
using CoffeeShopManagement.Models;
using CoffeeShopManagement.Services.Interfaces;

namespace CoffeeShopManagement.Forms;

public partial class FrmLogin : Form
{
    private readonly IAuthService? _authService;
    private readonly Func<User, FrmMain>? _mainFormFactory;

    // Parameterless constructor cho Visual Studio WinForms Designer
    public FrmLogin()
    {
        InitializeComponent();
    }

    public FrmLogin(IAuthService authService, Func<User, FrmMain> mainFormFactory) : this()
    {
        _authService = authService;
        _mainFormFactory = mainFormFactory;

        btnDangNhap.Click += BtnDangNhap_Click;
    }

    private async void BtnDangNhap_Click(object? sender, EventArgs e)
    {
        if (_authService == null || _mainFormFactory == null) return;

        lblThongBaoLoi.Text = "";
        string username = txtTenDangNhap.Text.Trim();
        string password = txtMatKhau.Text;

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            lblThongBaoLoi.Text = "Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu.";
            return;
        }

        btnDangNhap.Enabled = false;
        btnDangNhap.Text = "Đang kiểm tra...";

        try
        {
            var user = await _authService.LoginAsync(username, password);
            if (user == null)
            {
                lblThongBaoLoi.Text = "Sai tài khoản, mật khẩu hoặc tài khoản đã bị khóa!";
                btnDangNhap.Enabled = true;
                btnDangNhap.Text = "ĐĂNG NHẬP";
                return;
            }

            Hide();
            var mainForm = _mainFormFactory(user);
            mainForm.FormClosed += (_, _) =>
            {
                txtMatKhau.Clear();
                btnDangNhap.Enabled = true;
                btnDangNhap.Text = "ĐĂNG NHẬP";
                Show();
                txtTenDangNhap.Focus();
            };
            mainForm.Show();
        }
        catch (Exception ex)
        {
            lblThongBaoLoi.Text = $"Lỗi kết nối cơ sở dữ liệu: {ex.Message}";
            btnDangNhap.Enabled = true;
            btnDangNhap.Text = "ĐĂNG NHẬP";
        }
    }
}
