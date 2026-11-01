# Sơ đồ UML hệ thống quản lý quán cà phê

> Các sơ đồ dưới đây được xây dựng theo tài liệu thiết kế và luồng xử lý hiện tại của project `CoffeeShopManagement`.

## 1. Use Case Diagram



### Phân quyền chính

| Actor | Quyền sử dụng |
|---|---|
| `Staff` | Đăng nhập, xem bàn, chọn bàn, thêm món, đổi/gộp bàn, thanh toán và in hóa đơn |
| `Admin` | Toàn bộ quyền của Staff, đồng thời quản lý món, danh mục, bàn, tài khoản và báo cáo |

---

## 2. Sequence Diagram đăng nhập

```mermaid
sequenceDiagram
	autonumber
	actor User as Người dùng
	participant Login as FrmLogin
	participant Auth as AuthService
	participant DB as AppDbContext
	participant Users as SQL Server Users
	participant Main as FrmMain

	User->>Login: Nhập username và password
	User->>Login: Nhấn ĐĂNG NHẬP
	Login->>Login: Kiểm tra dữ liệu rỗng

	alt Thiếu username hoặc password
		Login-->>User: Hiển thị "Vui lòng nhập đầy đủ..."
	else Dữ liệu hợp lệ
		Login->>Auth: LoginAsync(username, password)
		Auth->>DB: Tìm User theo Username
		DB->>Users: SELECT User
		Users-->>DB: Trả về User hoặc null
		DB-->>Auth: User
		Auth->>Auth: Kiểm tra IsActive
		Auth->>Auth: BCrypt.Verify(password, PasswordHash)

		alt Sai tài khoản, sai mật khẩu hoặc tài khoản bị khóa
			Auth-->>Login: null
			Login-->>User: Hiển thị thông báo đăng nhập thất bại
		else Đăng nhập thành công
			Auth-->>Login: User
			Login->>Login: Hide()
			Login->>Main: Tạo FrmMain(User)
			Main-->>User: Hiển thị giao diện POS theo quyền
		end
	end
```

---

## 3. Sequence Diagram Staff

```mermaid
sequenceDiagram
	autonumber
	actor Staff as Nhân viên Staff
	participant Login as FrmLogin
	participant Auth as AuthService
	participant Main as FrmMain
	participant TableSvc as TableService
	participant BillSvc as BillService
	participant ProductForm as FrmSelectProduct
	participant Payment as FrmPayment
	participant DB as SQL Server

	Staff->>Login: Đăng nhập
	Login->>Auth: LoginAsync(username, password)
	Auth->>DB: Xác thực tài khoản Staff
	DB-->>Auth: User hợp lệ
	Auth-->>Login: User
	Login->>Main: Mở FrmMain(User)

	Main->>TableSvc: GetAllTablesAsync()
	TableSvc->>DB: Lấy bàn và bill chưa thanh toán
	DB-->>TableSvc: Danh sách bàn
	TableSvc-->>Main: Hiển thị sơ đồ bàn

	Staff->>Main: Chọn một bàn
	Main->>BillSvc: GetActiveBillByTableIdAsync(tableId)
	BillSvc->>DB: Lấy bill đang hoạt động và chi tiết món
	DB-->>BillSvc: Bill hiện tại
	BillSvc-->>Main: Hiển thị chi tiết hóa đơn

	opt Thêm món
		Staff->>Main: Nhấn + THÊM MÓN
		Main->>ProductForm: Mở cửa sổ chọn món
		Staff->>ProductForm: Chọn món và số lượng
		ProductForm-->>Main: ProductId, Quantity
		Main->>BillSvc: AddOrUpdateProductAsync(...)
		BillSvc->>DB: Tạo/cập nhật BillDetail
		BillSvc->>DB: Đổi trạng thái bàn thành Có khách
		DB-->>BillSvc: Lưu thành công
		BillSvc-->>Main: Refresh sơ đồ bàn và hóa đơn
	end

	opt Đổi bàn hoặc gộp bàn
		Staff->>Main: Chọn ĐỔI BÀN / GỘP BÀN
		Main->>TableSvc: SwitchTableAsync() hoặc MergeTableAsync()
		TableSvc->>DB: Cập nhật bill, bàn nguồn và bàn đích
		DB-->>TableSvc: Lưu thành công
		TableSvc-->>Main: Refresh sơ đồ bàn
	end

	opt Thanh toán
		Staff->>Main: Nhấn THANH TOÁN VÀ IN HÓA ĐƠN
		Main->>Payment: Mở FrmPayment
		Staff->>Payment: Nhập giảm giá và xác nhận
		Payment->>BillSvc: PayBillAsync(billId, discountPercent)
		BillSvc->>DB: Tính tổng tiền và cập nhật Bill
		BillSvc->>DB: Đổi trạng thái Bill = Đã thanh toán
		BillSvc->>DB: Đổi trạng thái bàn = Trống
		DB-->>BillSvc: Lưu thành công
		BillSvc-->>Payment: Bill đã thanh toán
		Payment-->>Main: Đóng cửa sổ thanh toán
		Main-->>Staff: Bàn trở về trạng thái Trống
	end
```

---

## 4. Sequence Diagram Admin

```mermaid
sequenceDiagram
	autonumber
	actor Admin as Quản trị viên Admin
	participant Login as FrmLogin
	participant Auth as AuthService
	participant Main as FrmMain
	participant ProductForm as FrmCategoryProduct
	participant TableForm as FrmTableManager
	participant UserForm as FrmUserManager
	participant ReportForm as FrmReport
	participant ProductSvc as ProductService
	participant TableSvc as TableService
	participant ReportSvc as ReportService
	participant DB as SQL Server
	participant Excel as ExcelExporter

	Admin->>Login: Nhập tài khoản admin và đăng nhập
	Login->>Auth: LoginAsync(username, password)
	Auth->>DB: Xác thực User và Role
	DB-->>Auth: User(Role = Admin)
	Auth-->>Login: User Admin
	Login->>Main: Mở FrmMain(User Admin)
	Main-->>Admin: Kích hoạt toàn bộ menu quản trị

	alt Quản lý món và danh mục
		Admin->>Main: Chọn Thực đơn món
		Main->>ProductForm: Mở FrmCategoryProduct
		ProductForm->>ProductSvc: GetAllCategoriesAsync / GetProductsByCategoryAsync
		ProductSvc->>DB: Đọc danh mục và sản phẩm
		DB-->>ProductSvc: Dữ liệu thực đơn
		ProductSvc-->>ProductForm: Hiển thị dữ liệu
		Admin->>ProductForm: Thêm, sửa hoặc xóa danh mục/món
		ProductForm->>ProductSvc: Create / Update / Delete
		ProductSvc->>DB: Lưu thay đổi thực đơn
		DB-->>ProductSvc: Kết quả thao tác
		ProductSvc-->>ProductForm: Refresh danh sách
	else Quản lý bàn và khu vực
		Admin->>Main: Chọn Quản lý bàn
		Main->>TableForm: Mở FrmTableManager
		TableForm->>TableSvc: GetAllTablesAsync()
		TableSvc->>DB: Đọc danh sách bàn
		DB-->>TableSvc: Danh sách bàn
		TableSvc-->>TableForm: Hiển thị dữ liệu
		Admin->>TableForm: Thêm, sửa hoặc xóa bàn
		TableForm->>TableSvc: CreateTable / UpdateTable / DeleteTable
		TableSvc->>DB: Lưu thay đổi bàn
		DB-->>TableSvc: Kết quả thao tác
		TableSvc-->>TableForm: Refresh danh sách
	else Quản lý tài khoản
		Admin->>Main: Chọn Quản lý nhân viên
		Main->>UserForm: Mở FrmUserManager
		UserForm->>Auth: GetAllUsersAsync()
		Auth->>DB: Đọc danh sách tài khoản
		DB-->>Auth: Danh sách User
		Auth-->>UserForm: Hiển thị tài khoản
		Admin->>UserForm: Tạo, sửa, khóa hoặc mở khóa tài khoản
		UserForm->>Auth: CreateUser / UpdateUser / ToggleUserStatus
		Auth->>Auth: Hash mật khẩu bằng BCrypt nếu cần
		Auth->>DB: Lưu thay đổi tài khoản
		DB-->>Auth: Kết quả thao tác
		Auth-->>UserForm: Refresh danh sách
	else Báo cáo doanh thu
		Admin->>Main: Chọn Báo cáo doanh thu
		Main->>ReportForm: Mở FrmReport
		Admin->>ReportForm: Chọn khoảng thời gian
		ReportForm->>ReportSvc: GetRevenueReport(fromDate, toDate)
		ReportSvc->>DB: Lấy bill đã thanh toán
		DB-->>ReportSvc: Danh sách hóa đơn và doanh thu
		ReportSvc-->>ReportForm: Hiển thị KPI và bảng báo cáo
		opt Xuất Excel
			Admin->>ReportForm: Nhấn Xuất Báo Cáo Excel
			ReportForm->>Excel: ExportRevenueReport(...)
			Excel-->>Admin: File báo cáo .xlsx
		end
	end
```

---

## Ghi chú triển khai

- `FrmLogin` gọi `AuthService.LoginAsync()` để xác thực tài khoản.
- `BCrypt.Net-Next` chỉ dùng để kiểm tra mật khẩu với `PasswordHash`, không lưu mật khẩu dạng rõ.
- `FrmMain` là màn hình POS dùng chung cho Admin và Staff.
- `Staff` bị vô hiệu hóa các menu quản trị trong `FrmMain`.
- `Admin` có thể truy cập `FrmCategoryProduct`, `FrmTableManager`, `FrmUserManager` và `FrmReport`.
- `DbInitializer` gọi `context.Database.Migrate()` khi ứng dụng khởi động để áp dụng migration trước khi seed dữ liệu mẫu.
