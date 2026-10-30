using CoffeeShopManagement.Models;
using CoffeeShopManagement.Utils;

namespace CoffeeShopManagement.Data;

public static class DbInitializer
{
    public static void Initialize(AppDbContext context)
    {
        // Đảm bảo Database tồn tại
        context.Database.EnsureCreated();

        // 1. Seed Users
        if (!context.Users.Any())
        {
            var admin = new User
            {
                Username = "admin",
                PasswordHash = PasswordHelper.HashPassword("admin123"),
                FullName = "Quản Trị Viên",
                Role = "Admin",
                IsActive = true,
                CreatedAt = DateTime.Now
            };

            var staff = new User
            {
                Username = "staff",
                PasswordHash = PasswordHelper.HashPassword("staff123"),
                FullName = "Nhân Viên Thu Ngân",
                Role = "Staff",
                IsActive = true,
                CreatedAt = DateTime.Now
            };

            context.Users.AddRange(admin, staff);
            context.SaveChanges();
        }

        // 2. Seed Categories & Products
        if (!context.Categories.Any())
        {
            var catCoffee = new Category
            {
                Name = "Cà Phê Truyền Thống",
                Description = "Đậm đà hương vị cà phê Robusta & Arabica nguyên chất"
            };

            var catTea = new Category
            {
                Name = "Trà Trái Cây",
                Description = "Thanh mát, tươi mới với trái cây tự nhiên"
            };

            var catFreeze = new Category
            {
                Name = "Đá Xay & Sinh Tố",
                Description = "Thức uống đá xay béo mịn, ngọt ngào"
            };

            var catCake = new Category
            {
                Name = "Bánh & Tráng Miệng",
                Description = "Bánh ngọt thơm lừng dùng kèm đồ uống"
            };

            context.Categories.AddRange(catCoffee, catTea, catFreeze, catCake);
            context.SaveChanges();

            // Products
            var products = new List<Product>
            {
                new Product { CategoryId = catCoffee.Id, Name = "Cà phê đen đá", Price = 25000, Unit = "Ly", IsActive = true },
                new Product { CategoryId = catCoffee.Id, Name = "Cà phê sữa đá", Price = 29000, Unit = "Ly", IsActive = true },
                new Product { CategoryId = catCoffee.Id, Name = "Bạc xỉu Sài Gòn", Price = 35000, Unit = "Ly", IsActive = true },
                new Product { CategoryId = catCoffee.Id, Name = "Espresso đậm vị", Price = 30000, Unit = "Tách", IsActive = true },

                new Product { CategoryId = catTea.Id, Name = "Trà đào cam sả", Price = 42000, Unit = "Ly", IsActive = true },
                new Product { CategoryId = catTea.Id, Name = "Trà vải hoa hồng", Price = 45000, Unit = "Ly", IsActive = true },
                new Product { CategoryId = catTea.Id, Name = "Trà olong sen vàng", Price = 48000, Unit = "Ly", IsActive = true },

                new Product { CategoryId = catFreeze.Id, Name = "Matcha đá xay kem cheese", Price = 49000, Unit = "Ly", IsActive = true },
                new Product { CategoryId = catFreeze.Id, Name = "Chocolate đá xay", Price = 49000, Unit = "Ly", IsActive = true },
                new Product { CategoryId = catFreeze.Id, Name = "Sinh tố bơ sáp", Price = 45000, Unit = "Ly", IsActive = true },

                new Product { CategoryId = catCake.Id, Name = "Bánh Tiramisu Ý", Price = 39000, Unit = "Đĩa", IsActive = true },
                new Product { CategoryId = catCake.Id, Name = "Croissant bơ tỏi", Price = 32000, Unit = "Cái", IsActive = true },
                new Product { CategoryId = catCake.Id, Name = "Phô mai hoàng kim", Price = 35000, Unit = "Đĩa", IsActive = true }
            };

            context.Products.AddRange(products);
            context.SaveChanges();
        }

        // 3. Seed Tables
        if (!context.Tables.Any())
        {
            var tables = new List<Table>();

            // Tầng 1: 8 bàn
            for (int i = 1; i <= 8; i++)
            {
                tables.Add(new Table
                {
                    Name = $"Bàn {i:D2}",
                    Area = "Tầng 1",
                    Status = 0 // Trống
                });
            }

            // Sân vườn: 4 bàn
            for (int i = 9; i <= 12; i++)
            {
                tables.Add(new Table
                {
                    Name = $"Bàn {i:D2}",
                    Area = "Sân vườn",
                    Status = 0 // Trống
                });
            }

            context.Tables.AddRange(tables);
            context.SaveChanges();
        }
    }
}
