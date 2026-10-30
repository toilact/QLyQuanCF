# QLyQuanCF - Hệ Thống Quản Lý Quán Cà Phê

Đồ án môn học: **Lập trình trên hệ điều hành Windows**

## Giới thiệu
Ứng dụng desktop Windows Forms quản lý bán hàng và hoạt động quán cà phê hiện đại:
- **Nền tảng:** C# .NET 10.0 Windows Forms
- **ORM:** Entity Framework Core (Code-First)
- **Hệ quản trị CSDL:** Microsoft SQL Server (LocalDB / SQL Express)
- **Bảo mật:** Mã hóa mật khẩu với `BCrypt.Net-Next`
- **Xuất hóa đơn & Báo cáo:** In hóa đơn nhiệt K80 qua `PrintDocument`, xuất báo cáo doanh thu Excel qua `ClosedXML`
- **Thiết kế UI:** Chuẩn Espresso Palette, giao diện phẳng chống AI Slop, font Segoe UI đồng nhất

## Các tính năng chính
1. **Đăng nhập & Phân quyền:** Phân quyền chặt chẽ giữa Quản trị viên (`Admin`) và Thu ngân (`Staff`).
2. **Sơ đồ bàn & POS:** Trực quan hóa bàn theo khu vực, đổi màu xanh/đỏ theo trạng thái (Trống / Có khách), gọi món nhanh.
3. **Đổi bàn & Gộp bàn:** Chuyển bàn sang bàn trống hoặc gộp món giữa các bàn có khách.
4. **Thanh toán & In Bill:** Tính tiền, áp dụng % giảm giá, xem trước và in hóa đơn K80.
5. **Quản lý Thực đơn & Bàn:** Thêm, sửa, xóa danh mục, món ăn, phân chia khu vực bàn.
6. **Quản lý Nhân viên:** Quản lý tài khoản thu ngân, phân quyền, khóa tài khoản.
7. **Báo cáo Doanh thu:** Thống kê doanh thu theo thời gian, biểu đồ top món bán chạy, xuất file Excel `.xlsx`.

## Cài đặt & Chạy ứng dụng
1. Mở solution `CoffeeShopManagement.sln` bằng **Visual Studio 2022** trên Windows.
2. Kiểm tra chuỗi kết nối trong `appsettings.json` (mặc định trỏ về `(localdb)\mssqllocaldb`).
3. Nhấn `F5` để chạy. Ứng dụng sẽ tự động khởi tạo CSDL và nạp sẵn dữ liệu mẫu.

### Tài khoản mặc định:
- **Admin:** `admin` / `admin123`
- **Staff:** `staff` / `staff123`
