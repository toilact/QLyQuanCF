using System.Drawing;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CoffeeShopManagement.Data;
using CoffeeShopManagement.Forms;
using CoffeeShopManagement.Models;
using CoffeeShopManagement.Services.Implementations;
using CoffeeShopManagement.Services.Interfaces;

namespace CoffeeShopManagement;

static class Program
{
    public static IHost AppHost { get; private set; } = null!;

    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        // Thiết lập font chữ Segoe UI toàn cục, loại bỏ triệt để font mặc định cũ
        try
        {
            Application.SetDefaultFont(new Font("Segoe UI", 9.5f, FontStyle.Regular));
        }
        catch
        {
            // Fallback nếu hệ thống không hỗ trợ SetDefaultFont
        }

        AppHost = Host.CreateDefaultBuilder()
            .ConfigureAppConfiguration((_, config) =>
            {
                config.SetBasePath(Directory.GetCurrentDirectory())
                      .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            })
            .ConfigureServices((context, services) =>
            {
                var connectionString = context.Configuration.GetConnectionString("DefaultConnection")
                    ?? "Server=(localdb)\\mssqllocaldb;Database=CoffeeShopDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True";

                services.AddDbContext<AppDbContext>(options =>
                {
                    options.UseSqlServer(connectionString);
                });

                // Business Services
                services.AddScoped<IAuthService, AuthService>();
                services.AddScoped<ITableService, TableService>();
                services.AddScoped<IProductService, ProductService>();
                services.AddScoped<IBillService, BillService>();
                services.AddScoped<IReportService, ReportService>();

                // Factory tạo Form chính theo User đăng nhập
                services.AddSingleton<Func<User, FrmMain>>(sp => user =>
                    new FrmMain(
                        user,
                        sp.GetRequiredService<ITableService>(),
                        sp.GetRequiredService<IProductService>(),
                        sp.GetRequiredService<IBillService>(),
                        sp.GetRequiredService<IReportService>(),
                        sp.GetRequiredService<IAuthService>()
                    ));

                // Forms
                services.AddTransient<FrmLogin>();
            })
            .Build();

        // Tự động kiểm tra và khởi tạo CSDL + Seed dữ liệu mẫu
        using (var scope = AppHost.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            try
            {
                DbInitializer.Initialize(dbContext);
            }
            catch (Exception ex)
            {
                // Khi chạy trên máy chưa có SQL Server instance, hiển thị hướng dẫn
                MessageBox.Show(
                    $"Không thể tự động kết nối CSDL SQL Server:\n{ex.Message}\n\n" +
                    "Vui lòng kiểm tra file appsettings.json đã trỏ đúng SQL Server / LocalDB và chạy Migration.",
                    "Lưu ý kết nối Cơ sở dữ liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        var loginForm = AppHost.Services.GetRequiredService<FrmLogin>();
        Application.Run(loginForm);
    }
}
