# Kịch Bản Kiểm Thử & Hướng Dẫn Nghiệm Thu Đồ Án
## Hệ Thống Quản Lý Quán Cà Phê (.NET 8 WinForms - Code-First)

---

### I. Hướng dẫn Chạy & Cấu hình CSDL (Database Setup)

1. **Yêu cầu môi trường trên Windows:**
   - Hệ điều hành: Windows 10/11.
   - IDE: Visual Studio 2022 (bản Community / Professional) đã cài workload **.NET Desktop Development**.
   - CSDL: SQL Server (LocalDB hoặc SQL Server Express / Developer) và SQL Server Management Studio (SSMS).

2. **Cấu hình chuỗi kết nối (`appsettings.json`):**
   - Mặc định sử dụng LocalDB:
     ```json
     "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=CoffeeShopDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
     ```
   - Nếu bạn dùng SQL Server Express (ví dụ instance `SQLEXPRESS`):
     ```json
     "DefaultConnection": "Server=.\\SQLEXPRESS;Database=CoffeeShopDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
     ```

3. **Khởi tạo dữ liệu tự động (Zero-Config):**
   - Khi chạy ứng dụng (`F5` trong Visual Studio), `DbInitializer.cs` sẽ tự động:
     - Tạo CSDL `CoffeeShopDb` và 6 bảng (`Users`, `Categories`, `Products`, `Tables`, `Bills`, `BillDetails`).
     - Tự động nạp tài khoản: `admin` (pass: `admin123`) và `staff` (pass: `staff123`).
     - Tự động nạp 4 danh mục và 13 món mẫu kèm đơn giá thực tế.
     - Tự động nạp 12 bàn mẫu phân chia theo 2 khu vực "Tầng 1" và "Sân vườn".

---

### II. Kịch Bản Kiểm Thử Chức Năng (End-to-End Test Matrix)

| STT | Phân hệ / Kịch bản | Thao tác thực hiện | Kết quả mong đợi |
|:---:|:---|:---|:---|
| **1** | **Đăng nhập hợp lệ** | Nhập `admin` / `admin123` -> Bấm Đăng nhập | Đăng nhập thành công, mở Form Chính POS, hiển thị đầy đủ menu Quản trị. |
| **2** | **Đăng nhập sai** | Nhập `admin` / `sai_mat_khau` | Báo lỗi tinh tế màu đỏ "Sai tài khoản, mật khẩu...", không crash app. |
| **3** | **Phân quyền Nhân viên** | Đăng nhập `staff` / `staff123` | Chỉ dùng được tính năng Bán hàng POS. Các nút Quản lý Thực đơn, Bàn, Nhân viên, Báo cáo bị vô hiệu hóa kèm dấu `(*)`. |
| **4** | **Sơ đồ bàn & Gọi món** | 1. Chọn Bàn 01 (đang màu xanh trống).<br>2. Bấm "+ THÊM MÓN" -> Chọn "Cà phê sữa đá" (SL: 2) -> Thêm vào đơn. | Bàn 01 tự động chuyển sang màu đỏ gạch ("Có khách"). Bảng chi tiết bên phải hiện 2 ly Cà phê sữa, thành tiền 58.000 đ. |
| **5** | **Thêm món vào bàn đang ngồi** | Bấm tiếp Bàn 01 -> Thêm "Bánh Tiramisu" (SL: 1) | Hóa đơn Bàn 01 cập nhật thêm bánh, tổng tạm tính tăng lên 97.000 đ. |
| **6** | **Đổi bàn (Chuyển bàn)** | 1. Đang chọn Bàn 01.<br>2. Bấm "ĐỔI BÀN" -> Chọn Bàn 04 (trống) -> Xác nhận. | Bàn 01 trả về màu xanh (Trống). Bàn 04 đổi sang màu đỏ gạch (Có khách), giữ nguyên toàn bộ món đã gọi. |
| **7** | **Gộp bàn** | 1. Mở Bàn 02 gọi 1 Trà đào.<br>2. Bấm "GỘP BÀN" -> Chọn Bàn 04 -> Xác nhận. | Bàn 02 giải phóng về màu xanh. Bàn 04 gộp cả cà phê, bánh và trà đào. |
| **8** | **Thanh toán & In hóa đơn** | 1. Chọn bàn cần thanh toán.<br>2. Bấm "THANH TOÁN & IN HÓA ĐƠN".<br>3. Nhập giảm giá 10%.<br>4. Bấm "HOÀN TẤT THANH TOÁN". | - Tổng tiền tự động trừ 10% chiết khấu.<br>- Hiện cửa sổ `PrintPreviewDialog` mô phỏng hóa đơn nhiệt K80 sắc nét (có tên quán, logo text, danh sách món, tổng tiền, lời cảm ơn).<br>- Bàn thanh toán xong tự động reset về màu xanh trống. |
| **9** | **Quản lý Thực đơn & Món** | Vào menu "Thực đơn & Món" -> Thêm mới "Trà Ô long nhãn nhục" (45.000 đ) | Món mới xuất hiện ngay lập tức trong danh sách chọn món của POS. |
| **10**| **Quản lý Bàn & Khu vực** | Vào menu "Quản lý Bàn" -> Thêm "Bàn 13" ở khu vực "Tầng 2" | Sơ đồ bàn trên POS xuất hiện thêm Bàn 13 và bộ lọc khu vực có thêm "Tầng 2". |
| **11**| **Quản lý Tài khoản** | Đăng nhập Admin -> Menu "Quản lý Nhân viên" -> Thêm nhân viên `thu_ngan_1` | Tạo tài khoản thành công với mật khẩu mã hóa BCrypt. |
| **12**| **Báo cáo & Xuất Excel** | Vào menu "Báo cáo Doanh thu" -> Lọc theo "Hôm nay" -> Bấm "XUẤT BÁO CÁO EXCEL" | Xuất file `.xlsx` định dạng màu nâu cà phê sang trọng, gồm 2 Sheet: Doanh thu hóa đơn và Top sản phẩm bán chạy nhất. |

---

### III. Điểm Nhấn Kiến Trúc Để Báo Cáo & Chấm Điểm Cao

1. **Dependency Injection & Hosting:**
   - Ứng dụng không dùng biến tĩnh bừa bãi. Mọi Service và DbContext được inject qua `Microsoft.Extensions.DependencyInjection`.
2. **EF Core Code-First:**
   - Database được xây dựng từ C# Classes. Ràng buộc quan hệ và cascade delete được định nghĩa rõ ràng qua Fluent API trong `AppDbContext.cs`.
3. **Bảo mật mật khẩu:**
   - Không lưu plain text. Sử dụng chuẩn công nghiệp `BCrypt.Net-Next` chống tấn công vét cạn.
4. **UI Craft Chống AI Slop:**
   - Bộ màu cà phê ấm áp Espresso (`#3D2817`, `#C68B59`, `#F7F5F2`), font chữ đồng nhất `Segoe UI`.
   - Các bảng DataGridView và nút bấm đều được thiết kế phẳng bo tròn góc hiện đại, không dùng giao diện mặc định thô cứng.

