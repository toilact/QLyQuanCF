# Kế hoạch Triển khai Hệ thống Quản lý Quán Cà phê (WinForms C# .NET 8 Code-First)

> **For agentic workers:** REQUIRED SUB-SKILL: Use superpowers:subagent-driven-development (recommended) or superpowers:executing-plans to implement this plan task-by-task. Steps use checkbox (`- [ ]`) syntax for tracking.

**Goal:** Xây dựng hoàn chỉnh ứng dụng desktop Quản lý Quán Cà phê bằng C# .NET 8 Windows Forms với Entity Framework Core Code-First, giao diện Espresso Craft hiện đại (chống AI Slop), phân quyền người dùng, sơ đồ bàn POS, in bill K80 và báo cáo Excel.

**Architecture:** Single-project WinForms với cấu trúc thư mục rõ ràng: `Models` (Entities), `Data` (EF Core DbContext + Migration + Seeder), `Services` (Nghiệp vụ), `Forms` & `Components` (Giao diện chuẩn UI Craft), `Utils` (BCrypt, ClosedXML, PrintDocument). Quản lý vòng đời qua Dependency Injection (`Microsoft.Extensions.DependencyInjection`).

**Tech Stack:** C# .NET 8.0, Windows Forms, Entity Framework Core 8, Microsoft SQL Server (LocalDB / SQL Express), BCrypt.Net-Next, ClosedXML, Microsoft.Extensions.Hosting.

---

## Danh sách Tệp triển khai

- `CoffeeShopManagement.csproj`: File cấu hình dự án WinForms .NET 8 và các gói NuGet.
- `appsettings.json`: Cấu hình chuỗi kết nối CSDL và thông tin quán.
- `Program.cs`: Cấu hình Dependency Injection container và chạy `FrmLogin`.
- `Models/*.cs`: `User.cs`, `Table.cs`, `Category.cs`, `Product.cs`, `Bill.cs`, `BillDetail.cs`.
- `Data/*.cs`: `AppDbContext.cs`, `AppDbContextFactory.cs`, `DbInitializer.cs`.
- `Utils/*.cs`: `PasswordHelper.cs`, `BillPrinter.cs`, `ExcelExporter.cs`.
- `Services/Interfaces/*.cs` & `Services/Implementations/*.cs`: `IAuthService`, `ITableService`, `IProductService`, `IBillService`, `IReportService`.
- `Components/*.cs`: `RjButton.cs` (nút bấm phẳng bo góc), `UcTableCard.cs` (thẻ hiển thị bàn trực quan).
- `Forms/*.cs`: `FrmLogin.cs`, `FrmMain.cs`, `FrmTableManager.cs`, `FrmCategoryProduct.cs`, `FrmPayment.cs`, `FrmUserManager.cs`, `FrmReport.cs`.

---

### Task 1: Khởi tạo Dự án & Khai báo Cấu hình NuGet

**Files:**
- Create: `CoffeeShopManagement.csproj`

- [ ] **Step 1: Tạo file `CoffeeShopManagement.csproj` với Target net8.0-windows và khai báo các packages cần thiết:**
  - `Microsoft.EntityFrameworkCore.SqlServer` (8.0.11)
  - `Microsoft.EntityFrameworkCore.Tools` (8.0.11)
  - `Microsoft.EntityFrameworkCore.Design` (8.0.11)
  - `Microsoft.Extensions.Hosting` (8.0.1)
  - `Microsoft.Extensions.Configuration.Json` (8.0.1)
  - `BCrypt.Net-Next` (4.0.3)
  - `ClosedXML` (0.102.3)

- [ ] **Step 2: Tạo solution file (`CoffeeShopManagement.sln`) và liên kết project.**

---

### Task 2: Cấu hình `appsettings.json`, DI Container và `Program.cs`

**Files:**
- Create: `appsettings.json`
- Create: `Program.cs`

- [ ] **Step 1: Tạo file `appsettings.json`:**
  - Thiết lập chuỗi kết nối `Server=(localdb)\\mssqllocaldb;Database=CoffeeShopDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True`.
  - Cấu hình thông tin quán (Tên quán, Địa chỉ, Số điện thoại, Lời chào chân hóa đơn).

- [ ] **Step 2: Viết `Program.cs`:**
  - Khởi tạo `Host.CreateDefaultBuilder()`.
  - Đăng ký `AppDbContext` với chuỗi kết nối lấy từ cấu hình.
  - Đăng ký các Services (Auth, Table, Product, Bill, Report).
  - Đăng ký các Forms (`FrmLogin`, `FrmMain`,...).
  - Thiết lập font toàn cục `Application.SetDefaultFont(new Font("Segoe UI", 9.5f, FontStyle.Regular))`.
  - Chạy `DbInitializer.Initialize(context)` tự động khi khởi động.

---

### Task 3: Xây dựng Entity Models (Code-First)

**Files:**
- Create: `Models/User.cs`
- Create: `Models/Table.cs`
- Create: `Models/Category.cs`
- Create: `Models/Product.cs`
- Create: `Models/Bill.cs`
- Create: `Models/BillDetail.cs`

- [ ] **Step 1: Tạo `User.cs`:**
  - Thuộc tính: `Id`, `Username` (Unique), `PasswordHash`, `FullName`, `Role` ("Admin" / "Staff"), `IsActive`, `CreatedAt`.
- [ ] **Step 2: Tạo `Category.cs` & `Product.cs`:**
  - `Category`: `Id`, `Name`, `Description`, `ICollection<Product> Products`.
  - `Product`: `Id`, `CategoryId`, `Category`, `Name`, `Price`, `Unit`, `ImagePath`, `IsActive`.
- [ ] **Step 3: Tạo `Table.cs`:**
  - `Id`, `Name`, `Area` ("Tầng 1", "Sân vườn"), `Status` (0: Trống, 1: Có khách).
- [ ] **Step 4: Tạo `Bill.cs` & `BillDetail.cs`:**
  - `Bill`: `Id`, `TableId`, `Table`, `UserId`, `User`, `CheckInDate`, `CheckOutDate`, `Status` (0: Chưa thanh toán, 1: Đã thanh toán), `DiscountPercent`, `TotalAmount`, `ICollection<BillDetail> Details`.
  - `BillDetail`: `Id`, `BillId`, `Bill`, `ProductId`, `Product`, `Quantity`, `UnitPrice`.

---

### Task 4: Xây dựng `AppDbContext`, `AppDbContextFactory` & Ràng buộc Quan hệ

**Files:**
- Create: `Data/AppDbContext.cs`
- Create: `Data/AppDbContextFactory.cs`

- [ ] **Step 1: Cài đặt `AppDbContext.cs`:**
  - Khai báo các `DbSet<>` tương ứng 6 thực thể.
  - Cấu hình `OnModelCreating`:
    - Đánh `HasIndex(u => u.Username).IsUnique()`.
    - Ràng buộc quan hệ: `Bill -> Table` (Restrict Delete), `BillDetail -> Product` (Restrict Delete), `Bill -> BillDetail` (Cascade Delete).
    - Cấu hình kiểu dữ liệu `decimal(18,2)` cho `Price`, `UnitPrice`, `TotalAmount`.
- [ ] **Step 2: Cài đặt `AppDbContextFactory.cs`:**
  - Triển khai `IDesignTimeDbContextFactory<AppDbContext>` để `dotnet-ef` CLI đọc connection string khi chạy Migration mà không cần chạy toàn bộ UI.

---

### Task 5: Xây dựng `DbInitializer` (Seed Dữ liệu mẫu)

**Files:**
- Create: `Data/DbInitializer.cs`

- [ ] **Step 1: Viết `DbInitializer.Initialize(AppDbContext context)`:**
  - Kiểm tra nếu database chưa có tài khoản admin:
    - Tạo `admin` / `admin123` (Role: Admin) được hash bằng BCrypt.
    - Tạo `staff` / `staff123` (Role: Staff).
  - Kiểm tra và tạo danh mục mẫu: "Cà phê truyền thống", "Trà trái cây", "Đá xay & Sinh tố", "Bánh & Ăn vặt".
  - Kiểm tra và tạo sản phẩm mẫu kèm giá tiền chuẩn (Cà phê đen: 25.000, Cà phê sữa: 29.000, Bạc xỉu: 35.000, Trà đào cam sả: 42.000,...).
  - Kiểm tra và tạo 12 bàn mẫu chia theo 2 khu vực: "Tầng 1" (Bàn 01 - Bàn 08), "Sân vườn" (Bàn 09 - Bàn 12).

---

### Task 6: Xây dựng Tầng Tiện ích & Bảo mật (`Utils/`)

**Files:**
- Create: `Utils/PasswordHelper.cs`
- Create: `Utils/BillPrinter.cs`
- Create: `Utils/ExcelExporter.cs`

- [ ] **Step 1: Tạo `PasswordHelper.cs`:**
  - Hàm `HashPassword(string plainPassword)` dùng `BCrypt.Net.BCrypt.HashPassword`.
  - Hàm `VerifyPassword(string plainPassword, string hash)` dùng `BCrypt.Net.BCrypt.Verify`.
- [ ] **Step 2: Tạo `BillPrinter.cs`:**
  - Sử dụng `System.Drawing.Printing.PrintDocument`.
  - Thiết kế mẫu hóa đơn nhiệt K80 chuẩn: Tiêu đề quán, địa chỉ, số bill, ngày giờ, danh sách món (cột Món, SL, Đơn giá, Thành tiền), Tổng tiền, Giảm giá %, Tiền thanh toán, Lời cảm ơn.
  - Hỗ trợ xem trước với `PrintPreviewDialog` hoặc in trực tiếp.
- [ ] **Step 3: Tạo `ExcelExporter.cs`:**
  - Sử dụng `ClosedXML.Excel.XLWorkbook`.
  - Tạo bảng tính xuất danh sách hóa đơn và doanh thu: Header tô màu `#3D2817`, chữ trắng, format tiền tệ `#,#0 VNĐ`, tự động căn chỉnh độ rộng cột (`AdjustToContents()`).

---

### Task 7: Xây dựng Tầng Nghiệp vụ (`Services/`)

**Files:**
- Create: `Services/Interfaces/IAuthService.cs` & `Services/Implementations/AuthService.cs`
- Create: `Services/Interfaces/ITableService.cs` & `Services/Implementations/TableService.cs`
- Create: `Services/Interfaces/IProductService.cs` & `Services/Implementations/ProductService.cs`
- Create: `Services/Interfaces/IBillService.cs` & `Services/Implementations/BillService.cs`
- Create: `Services/Interfaces/IReportService.cs` & `Services/Implementations/ReportService.cs`

- [ ] **Step 1: Cài đặt `AuthService`:**
  - `Login(string username, string password)`: Trả về đối tượng `User` nếu đúng mật khẩu và `IsActive = true`, ném Exception hoặc trả về null nếu sai.
  - `ChangePassword(int userId, string oldPass, string newPass)`.
- [ ] **Step 2: Cài đặt `TableService`:**
  - `GetAllTables()`, `GetTablesByArea(string area)`, `CreateTable(Table table)`, `UpdateTable(Table table)`, `DeleteTable(int id)`.
  - `SwitchTable(int fromTableId, int toTableId)`: Chuyển toàn bộ bill từ bàn này sang bàn trống kia.
  - `MergeTable(int sourceTableId, int targetTableId)`: Gộp món giữa hai bàn đang có khách.
- [ ] **Step 3: Cài đặt `ProductService`:**
  - `GetAllCategories()`, `CreateCategory()`, `UpdateCategory()`, `DeleteCategory()`.
  - `GetProductsByCategory(int categoryId)`, `CreateProduct()`, `UpdateProduct()`, `DeleteProduct()`.
- [ ] **Step 4: Cài đặt `BillService`:**
  - `GetActiveBillByTableId(int tableId)`: Lấy hóa đơn chưa thanh toán của bàn.
  - `AddOrUpdateProductToBill(int tableId, int productId, int quantity, int userId)`: Thêm món mới hoặc tăng/giảm số lượng món trong bàn.
  - `RemoveProductFromBill(int billDetailId)`.
  - `PayBill(int billId, int discountPercent)`: Tính tổng tiền, cập nhật trạng thái đã thanh toán, giải phóng bàn về trạng thái trống.
- [ ] **Step 5: Cài đặt `ReportService`:**
  - `GetRevenueReport(DateTime fromDate, DateTime toDate)`: Danh sách bill đã thanh toán, tổng doanh thu, số bill.
  - `GetTopSellingProducts(DateTime fromDate, DateTime toDate, int topCount)`: Top món bán chạy nhất.

---

### Task 8: Xây dựng Custom UI Controls phong cách Impeccable Craft

**Files:**
- Create: `Components/UITheme.cs` (Bảng mã màu & chuẩn thẩm mỹ)
- Create: `Components/RjButton.cs` (Nút bấm phẳng bo góc)
- Create: `Components/UcTableCard.cs` (Thẻ bàn trực quan)

- [ ] **Step 1: Tạo `UITheme.cs`:**
  - Khai báo các hằng số màu sắc chuẩn Espresso Craft:
    - `Primary = ColorTranslator.FromHtml("#3D2817")`
    - `Accent = ColorTranslator.FromHtml("#C68B59")`
    - `CanvasBg = ColorTranslator.FromHtml("#F7F5F2")`
    - `Surface = Color.White`
    - `Border = ColorTranslator.FromHtml("#E8E2D9")`
    - `TextDark = ColorTranslator.FromHtml("#2B2520")`
    - `TextMuted = ColorTranslator.FromHtml("#7D756D")`
    - `TableEmpty = ColorTranslator.FromHtml("#4E7C59")`
    - `TableOccupied = ColorTranslator.FromHtml("#C85A32")`
  - Khai báo font chữ mặc định: `MainFont = new Font("Segoe UI", 10f)`, `HeaderFont = new Font("Segoe UI", 14f, FontStyle.Bold)`.
- [ ] **Step 2: Tạo `RjButton.cs`:**
  - Kế thừa `Button`, vẽ bằng GDI+ với `GraphicsPath` bo tròn góc (BorderRadius = 8px), không viền thô, hiệu ứng rê chuột (Hover) mượt mà.
- [ ] **Step 3: Tạo `UcTableCard.cs`:**
  - Thẻ hiển thị từng bàn trên sơ đồ: Tên bàn to rõ, khu vực, trạng thái (Trống / Có khách) hiển thị bằng badge màu bo góc, tổng tiền tạm tính nếu bàn đang có khách.

---

### Task 9: Xây dựng Giao diện Đăng nhập (`FrmLogin`)

**Files:**
- Create: `Forms/FrmLogin.cs`
- Create: `Forms/FrmLogin.Designer.cs`

- [ ] **Step 1: Thiết kế giao diện `FrmLogin`:**
  - Phong cách hiện đại: Form không viền bo nhẹ hoặc FixedDialog, logo quán, ô nhập Username và Password (UseSystemPasswordChar = true).
  - Nút "ĐĂNG NHẬP" màu Espresso sang trọng.
  - Bắt sự kiện phím `Enter` tự động đăng nhập.
- [ ] **Step 2: Xử lý logic đăng nhập:**
  - Gọi `_authService.Login()`.
  - Hiển thị thông báo nếu sai tài khoản/mật khẩu bằng nhãn lỗi màu đỏ gạch tinh tế, không bật MessageBox giật cục.
  - Mở `FrmMain` và truyền thông tin `User` vừa đăng nhập thành công.

---

### Task 10: Xây dựng Giao diện Chính POS & Sơ đồ Bàn (`FrmMain`)

**Files:**
- Create: `Forms/FrmMain.cs`
- Create: `Forms/FrmMain.Designer.cs`

- [ ] **Step 1: Xây dựng Layout 3 vùng:**
  - **Trái:** Sidebar chứa Logo quán, thông tin nhân viên trực, các nút điều hướng (Bán hàng, Thực đơn, Bàn, Nhân viên, Báo cáo). Ẩn hoặc disable nút Quản lý nếu người dùng là `Staff`.
  - **Giữa:** Sơ đồ bàn: Tab hoặc combobox lọc theo Khu vực ("Tất cả", "Tầng 1", "Sân vườn"). Vùng `FlowLayoutPanel` chứa các `UcTableCard`.
  - **Phải:** Panel Hóa đơn bàn đang chọn:
    - Tiêu đề: Tên bàn đang chọn, giờ vào bàn.
    - DataGridView danh sách món trong bill (Món, SL, Đơn giá, Thành tiền) thiết kế phẳng, row height 38px.
    - Khu vực tính tiền: Tạm tính, ô nhập Giảm giá (%), Tổng thanh toán.
    - Hàng nút thao tác: "Thêm món", "Đổi bàn", "Gộp bàn", "THANH TOÁN & IN BILL".
- [ ] **Step 2: Logic tương tác POS:**
  - Bấm chọn bàn -> Tải thông tin bill hiện tại lên DataGridView.
  - Thêm món: Mở dialog chọn danh mục và món ăn -> Gọi `_billService.AddOrUpdateProductToBill` -> Tự động chuyển bàn sang màu đỏ.
  - Đổi bàn / Gộp bàn: Dialog chọn bàn đích -> Gọi service xử lý -> Refresh lại trạng thái các thẻ bàn.
  - Thanh toán: Xác nhận thanh toán -> In hóa đơn qua `BillPrinter` -> Đưa bàn về màu xanh trống.

---

### Task 11: Xây dựng Form Quản lý Thực đơn & Danh mục (`FrmCategoryProduct`)

**Files:**
- Create: `Forms/FrmCategoryProduct.cs`
- Create: `Forms/FrmCategoryProduct.Designer.cs`

- [ ] **Step 1: Thiết kế giao diện quản lý thực đơn:**
  - Tab 1: Quản lý Danh mục (Thêm, Sửa, Xóa, Danh sách DataGridView).
  - Tab 2: Quản lý Món ăn (Combobox chọn danh mục, ô nhập tên món, giá, đơn vị tính, chọn ảnh, checkbox trạng thái).
- [ ] **Step 2: Logic nghiệp vụ:**
  - Ràng buộc: Không cho xóa danh mục nếu đang có món ăn trực thuộc (hiển thị thông báo hướng dẫn).
  - Validate giá tiền phải là số dương hợp lệ.

---

### Task 12: Xây dựng Form Quản lý Bàn & Khu vực (`FrmTableManager`)

**Files:**
- Create: `Forms/FrmTableManager.cs`
- Create: `Forms/FrmTableManager.Designer.cs`

- [ ] **Step 1: Thiết kế giao diện quản lý bàn:**
  - DataGridView hiển thị danh sách bàn, tên bàn, khu vực, trạng thái.
  - Panel nhập liệu: Tên bàn, Khu vực (Tầng 1, Sân vườn, v.v.).
- [ ] **Step 2: Logic nghiệp vụ:**
  - Không cho phép xóa bàn đang có khách ngồi.
  - Thêm mới bàn tự động xuất hiện trên sơ đồ `FrmMain`.

---

### Task 13: Xây dựng Form Quản lý Tài khoản & Phân quyền (`FrmUserManager`)

**Files:**
- Create: `Forms/FrmUserManager.cs`
- Create: `Forms/FrmUserManager.Designer.cs`

- [ ] **Step 1: Thiết kế giao diện quản lý nhân viên:**
  - Bảng danh sách tài khoản: Username, Họ tên, Vai trò (Admin / Staff), Trạng thái (Hoạt động / Khóa), Ngày tạo.
  - Panel thêm / sửa nhân viên, đặt lại mật khẩu mới.
- [ ] **Step 2: Logic nghiệp vụ:**
  - Không cho phép xóa chính tài khoản Admin đang đăng nhập.
  - Mật khẩu tạo mới hoặc reset đều được tự động hash qua `PasswordHelper`.

---

### Task 14: Xây dựng Form Báo cáo Doanh thu & Xuất Excel (`FrmReport`)

**Files:**
- Create: `Forms/FrmReport.cs`
- Create: `Forms/FrmReport.Designer.cs`

- [ ] **Step 1: Thiết kế giao diện báo cáo:**
  - Bộ lọc: `DateTimePicker` Từ ngày -> Đến ngày, nút "Thống kê".
  - Các thẻ tổng quan (KPI Cards): Tổng doanh thu (VNĐ), Tổng số hóa đơn, Giá trị đơn trung bình.
  - Hai bảng chi tiết:
    - Bảng 1: Danh sách các hóa đơn đã thanh toán trong khoảng thời gian.
    - Bảng 2: Top các món bán chạy nhất (Tên món, Số lượng bán, Doanh thu từ món).
  - Nút "Xuất Báo Cáo Excel": Biểu tượng file trang nhã.
- [ ] **Step 2: Logic xử lý:**
  - Gọi `_reportService.GetRevenueReport` và nạp vào DataGridView.
  - Bấm Xuất Excel -> Mở `SaveFileDialog` -> Gọi `ExcelExporter.ExportRevenueReport()` xuất file `.xlsx` định dạng đẹp.

---

### Task 15: Kiểm thử Toàn diện & Nghiệm thu Kịch bản Đồ án

**Files:**
- Create: `Tests/ManualTestingChecklist.md`

- [ ] **Step 1: Kiểm thử Luồng Bán hàng (End-to-End POS):**
  - Mở bàn 01 -> Thêm 2 Cà phê đen, 1 Trà đào -> Bàn chuyển sang màu đỏ.
  - Đổi bàn 01 sang Bàn 05 (trống) -> Bàn 01 về xanh, Bàn 05 sang đỏ mang đúng món.
  - Gọi thanh toán Bàn 05 -> Nhập giảm giá 10% -> Kiểm tra tổng tiền chính xác -> Bấm in bill xem trước -> Bàn 05 về lại màu xanh.
- [ ] **Step 2: Kiểm thử Phân quyền (Security & Authorization):**
  - Đăng nhập tài khoản `staff` -> Kiểm tra các menu Quản lý, Nhân viên, Báo cáo bị khóa/ẩn.
  - Đăng nhập `admin` -> Truy cập được toàn bộ hệ thống.
- [ ] **Step 3: Kiểm thử Báo cáo Doanh thu:**
  - Lọc ngày hôm nay -> Kiểm tra xuất hiện đúng hóa đơn vừa thanh toán.
  - Xuất Excel -> Kiểm tra file `.xlsx` mở lên nguyên vẹn, định dạng tiền tệ chuẩn.

