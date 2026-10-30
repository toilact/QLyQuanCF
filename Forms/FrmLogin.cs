using System.Drawing;
using System.Windows.Forms;
using CoffeeShopManagement.Components;
using CoffeeShopManagement.Models;
using CoffeeShopManagement.Services.Interfaces;

namespace CoffeeShopManagement.Forms;

public class FrmLogin : Form
{
    private readonly IAuthService _authService;
    private readonly Func<User, FrmMain> _mainFormFactory;

    private TextBox _txtUsername = null!;
    private TextBox _txtPassword = null!;
    private Label _lblError = null!;
    private RjButton _btnLogin = null!;

    public FrmLogin(IAuthService authService, Func<User, FrmMain> mainFormFactory)
    {
        _authService = authService;
        _mainFormFactory = mainFormFactory;

        InitializeComponent();
    }

    private void InitializeComponent()
    {
        Text = "Đăng Nhập - Quản Lý Quán Cà Phê";
        StartPosition = FormStartPosition.CenterScreen;
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        ClientSize = new Size(420, 480);
        BackColor = UITheme.CanvasBg;

        // Container Panel (Card)
        var card = new Panel
        {
            Size = new Size(360, 420),
            Location = new Point(30, 30),
            BackColor = UITheme.Surface,
            BorderStyle = BorderStyle.FixedSingle
        };
        Controls.Add(card);

        // Header Title
        var lblBrand = new Label
        {
            Text = "CÀ PHÊ HƯƠNG VIỆT",
            Font = new Font("Segoe UI", 16f, FontStyle.Bold),
            ForeColor = UITheme.Primary,
            TextAlign = ContentAlignment.MiddleCenter,
            Location = new Point(20, 25),
            Size = new Size(320, 32)
        };
        card.Controls.Add(lblBrand);

        var lblSub = new Label
        {
            Text = "Hệ Thống Bán Hàng & Quản Trị",
            Font = UITheme.FontRegular,
            ForeColor = UITheme.TextMuted,
            TextAlign = ContentAlignment.MiddleCenter,
            Location = new Point(20, 60),
            Size = new Size(320, 20)
        };
        card.Controls.Add(lblSub);

        // Username Label & Input
        var lblUser = new Label
        {
            Text = "Tên đăng nhập",
            Font = UITheme.FontBold,
            ForeColor = UITheme.TextDark,
            Location = new Point(30, 110),
            Size = new Size(300, 20)
        };
        card.Controls.Add(lblUser);

        _txtUsername = new TextBox
        {
            Location = new Point(30, 135),
            Size = new Size(300, 30),
            Font = new Font("Segoe UI", 11f),
            BorderStyle = BorderStyle.FixedSingle
        };
        card.Controls.Add(_txtUsername);

        // Password Label & Input
        var lblPass = new Label
        {
            Text = "Mật khẩu",
            Font = UITheme.FontBold,
            ForeColor = UITheme.TextDark,
            Location = new Point(30, 180),
            Size = new Size(300, 20)
        };
        card.Controls.Add(lblPass);

        _txtPassword = new TextBox
        {
            Location = new Point(30, 205),
            Size = new Size(300, 30),
            Font = new Font("Segoe UI", 11f),
            UseSystemPasswordChar = true,
            BorderStyle = BorderStyle.FixedSingle
        };
        card.Controls.Add(_txtPassword);

        // Error message label
        _lblError = new Label
        {
            Location = new Point(30, 245),
            Size = new Size(300, 36),
            Font = UITheme.FontSmall,
            ForeColor = UITheme.Danger,
            TextAlign = ContentAlignment.MiddleLeft,
            Text = ""
        };
        card.Controls.Add(_lblError);

        // Login Button
        _btnLogin = new RjButton
        {
            Text = "ĐĂNG NHẬP",
            Location = new Point(30, 290),
            Size = new Size(300, 42),
            BackColor = UITheme.Primary,
            HoverBackColor = UITheme.PrimaryHover,
            Font = UITheme.FontBold,
            BorderRadius = 8
        };
        _btnLogin.Click += BtnLogin_Click;
        card.Controls.Add(_btnLogin);

        // Gợi ý đăng nhập mặc định
        var lblHint = new Label
        {
            Text = "Mặc định: admin / admin123 | staff / staff123",
            Font = UITheme.FontSmall,
            ForeColor = UITheme.TextMuted,
            TextAlign = ContentAlignment.MiddleCenter,
            Location = new Point(20, 355),
            Size = new Size(320, 40)
        };
        card.Controls.Add(lblHint);

        AcceptButton = _btnLogin;
    }

    private async void BtnLogin_Click(object? sender, EventArgs e)
    {
        _lblError.Text = "";
        string username = _txtUsername.Text.Trim();
        string password = _txtPassword.Text;

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            _lblError.Text = "Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu.";
            return;
        }

        _btnLogin.Enabled = false;
        _btnLogin.Text = "Đang kiểm tra...";

        try
        {
            var user = await _authService.LoginAsync(username, password);
            if (user == null)
            {
                _lblError.Text = "Sai tài khoản, mật khẩu hoặc tài khoản đã bị khóa!";
                _btnLogin.Enabled = true;
                _btnLogin.Text = "ĐĂNG NHẬP";
                return;
            }

            // Đăng nhập thành công -> Mở Form Chính
            Hide();
            var mainForm = _mainFormFactory(user);
            mainForm.FormClosed += (_, _) =>
            {
                _txtPassword.Clear();
                _btnLogin.Enabled = true;
                _btnLogin.Text = "ĐĂNG NHẬP";
                Show();
                _txtUsername.Focus();
            };
            mainForm.Show();
        }
        catch (Exception ex)
        {
            _lblError.Text = $"Lỗi kết nối cơ sở dữ liệu: {ex.Message}";
            _btnLogin.Enabled = true;
            _btnLogin.Text = "ĐĂNG NHẬP";
        }
    }
}

