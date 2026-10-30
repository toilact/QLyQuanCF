using Microsoft.EntityFrameworkCore;
using CoffeeShopManagement.Data;
using CoffeeShopManagement.Models;
using CoffeeShopManagement.Services.Interfaces;

namespace CoffeeShopManagement.Services.Implementations;

public class BillService : IBillService
{
    private readonly AppDbContext _context;

    public BillService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Bill?> GetActiveBillByTableIdAsync(int tableId)
    {
        return await _context.Bills
            .Include(b => b.Table)
            .Include(b => b.User)
            .Include(b => b.Details)
                .ThenInclude(d => d.Product)
            .FirstOrDefaultAsync(b => b.TableId == tableId && b.Status == 0);
    }

    public async Task<Bill?> GetBillByIdAsync(int billId)
    {
        return await _context.Bills
            .Include(b => b.Table)
            .Include(b => b.User)
            .Include(b => b.Details)
                .ThenInclude(d => d.Product)
            .FirstOrDefaultAsync(b => b.Id == billId);
    }

    public async Task<Bill> AddOrUpdateProductAsync(int tableId, int productId, int quantity, int userId)
    {
        var table = await _context.Tables.FindAsync(tableId)
            ?? throw new InvalidOperationException("Bàn không tồn tại");

        var product = await _context.Products.FindAsync(productId)
            ?? throw new InvalidOperationException("Món không tồn tại");

        var bill = await _context.Bills
            .Include(b => b.Details)
            .FirstOrDefaultAsync(b => b.TableId == tableId && b.Status == 0);

        if (bill == null)
        {
            // Tạo mới hóa đơn nếu bàn chưa có bill hoạt động
            bill = new Bill
            {
                TableId = tableId,
                UserId = userId,
                CheckInDate = DateTime.Now,
                Status = 0, // Chưa thanh toán
                DiscountPercent = 0,
                TotalAmount = 0
            };
            _context.Bills.Add(bill);
            table.Status = 1; // Đổi trạng thái bàn thành Có khách
            await _context.SaveChangesAsync();
        }

        var detail = bill.Details.FirstOrDefault(d => d.ProductId == productId);
        if (detail != null)
        {
            detail.Quantity += quantity;
            if (detail.Quantity <= 0)
            {
                _context.BillDetails.Remove(detail);
            }
        }
        else if (quantity > 0)
        {
            detail = new BillDetail
            {
                BillId = bill.Id,
                ProductId = productId,
                Quantity = quantity,
                UnitPrice = product.Price
            };
            _context.BillDetails.Add(detail);
        }

        await _context.SaveChangesAsync();

        // Tự động giải phóng bàn nếu xóa hết toàn bộ món trong bill
        await _context.Entry(bill).Collection(b => b.Details).LoadAsync();
        if (!bill.Details.Any())
        {
            _context.Bills.Remove(bill);
            table.Status = 0;
            await _context.SaveChangesAsync();
        }

        return bill;
    }

    public async Task<bool> RemoveDetailAsync(int billDetailId)
    {
        var detail = await _context.BillDetails
            .Include(d => d.Bill)
                .ThenInclude(b => b.Details)
            .Include(d => d.Bill.Table)
            .FirstOrDefaultAsync(d => d.Id == billDetailId);

        if (detail == null) return false;

        var bill = detail.Bill;
        var table = bill.Table;

        _context.BillDetails.Remove(detail);
        await _context.SaveChangesAsync();

        // Nếu không còn món nào, hủy luôn bill và trả bàn về trạng thái trống
        if (bill.Details.Count <= 1)
        {
            _context.Bills.Remove(bill);
            table.Status = 0;
            await _context.SaveChangesAsync();
        }

        return true;
    }

    public async Task<Bill> PayBillAsync(int billId, int discountPercent)
    {
        var bill = await _context.Bills
            .Include(b => b.Table)
            .Include(b => b.Details)
                .ThenInclude(d => d.Product)
            .FirstOrDefaultAsync(b => b.Id == billId)
            ?? throw new InvalidOperationException("Hóa đơn không tồn tại");

        if (bill.Status == 1)
            throw new InvalidOperationException("Hóa đơn này đã được thanh toán trước đó!");

        decimal subTotal = bill.Details.Sum(d => d.Quantity * d.UnitPrice);
        bill.DiscountPercent = Math.Clamp(discountPercent, 0, 100);
        bill.TotalAmount = subTotal * (100 - bill.DiscountPercent) / 100m;
        bill.Status = 1; // Đã thanh toán
        bill.CheckOutDate = DateTime.Now;

        // Trả trạng thái bàn về Trống
        if (bill.Table != null)
        {
            bill.Table.Status = 0;
        }

        await _context.SaveChangesAsync();
        return bill;
    }
}
