using Microsoft.EntityFrameworkCore;
using CoffeeShopManagement.Data;
using CoffeeShopManagement.Models;
using CoffeeShopManagement.Services.Interfaces;

namespace CoffeeShopManagement.Services.Implementations;

public class TableService : ITableService
{
    private readonly AppDbContext _context;

    public TableService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Table>> GetAllTablesAsync()
    {
        return await _context.Tables
            .Include(t => t.Bills.Where(b => b.Status == 0))
                .ThenInclude(b => b.Details)
                    .ThenInclude(d => d.Product)
            .OrderBy(t => t.Area)
            .ThenBy(t => t.Name)
            .ToListAsync();
    }

    public async Task<List<Table>> GetTablesByAreaAsync(string area)
    {
        return await _context.Tables
            .Where(t => t.Area == area)
            .Include(t => t.Bills.Where(b => b.Status == 0))
                .ThenInclude(b => b.Details)
            .OrderBy(t => t.Name)
            .ToListAsync();
    }

    public async Task<List<string>> GetAllAreasAsync()
    {
        return await _context.Tables
            .Select(t => t.Area)
            .Distinct()
            .OrderBy(a => a)
            .ToListAsync();
    }

    public async Task<Table?> GetTableByIdAsync(int id)
    {
        return await _context.Tables.FindAsync(id);
    }

    public async Task<Table> CreateTableAsync(Table table)
    {
        _context.Tables.Add(table);
        await _context.SaveChangesAsync();
        return table;
    }

    public async Task<bool> UpdateTableAsync(Table table)
    {
        var existing = await _context.Tables.FindAsync(table.Id);
        if (existing == null) return false;

        existing.Name = table.Name;
        existing.Area = table.Area;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteTableAsync(int id)
    {
        var table = await _context.Tables
            .Include(t => t.Bills)
            .FirstOrDefaultAsync(t => t.Id == id);

        if (table == null) return false;

        // Nếu bàn đang có khách hoặc có lịch sử hóa đơn, không được xóa để đảm bảo toàn vẹn dữ liệu
        if (table.Status == 1 || table.Bills.Any(b => b.Status == 0))
            throw new InvalidOperationException("Không thể xóa bàn đang có khách ngồi!");

        _context.Tables.Remove(table);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> SwitchTableAsync(int fromTableId, int toTableId)
    {
        if (fromTableId == toTableId) return false;

        var fromTable = await _context.Tables.FindAsync(fromTableId);
        var toTable = await _context.Tables.FindAsync(toTableId);

        if (fromTable == null || toTable == null) return false;
        if (toTable.Status == 1)
            throw new InvalidOperationException("Bàn đích đang có khách, vui lòng chọn chức năng Gộp bàn!");

        var activeBill = await _context.Bills
            .FirstOrDefaultAsync(b => b.TableId == fromTableId && b.Status == 0);

        if (activeBill == null) return false;

        activeBill.TableId = toTableId;
        fromTable.Status = 0; // Trống
        toTable.Status = 1;   // Có khách

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> MergeTableAsync(int sourceTableId, int targetTableId)
    {
        if (sourceTableId == targetTableId) return false;

        var sourceTable = await _context.Tables.FindAsync(sourceTableId);
        var targetTable = await _context.Tables.FindAsync(targetTableId);

        if (sourceTable == null || targetTable == null) return false;

        var sourceBill = await _context.Bills
            .Include(b => b.Details)
            .FirstOrDefaultAsync(b => b.TableId == sourceTableId && b.Status == 0);

        if (sourceBill == null) return false;

        var targetBill = await _context.Bills
            .Include(b => b.Details)
            .FirstOrDefaultAsync(b => b.TableId == targetTableId && b.Status == 0);

        if (targetBill == null)
        {
            // Bàn đích chưa có bill, chuyển thành switch table
            sourceBill.TableId = targetTableId;
            sourceTable.Status = 0;
            targetTable.Status = 1;
        }
        else
        {
            // Gộp từng món từ source sang target
            foreach (var sDetail in sourceBill.Details.ToList())
            {
                var existingInTarget = targetBill.Details
                    .FirstOrDefault(d => d.ProductId == sDetail.ProductId);

                if (existingInTarget != null)
                {
                    existingInTarget.Quantity += sDetail.Quantity;
                }
                else
                {
                    targetBill.Details.Add(new BillDetail
                    {
                        ProductId = sDetail.ProductId,
                        Quantity = sDetail.Quantity,
                        UnitPrice = sDetail.UnitPrice
                    });
                }
            }

            // Xóa bill cũ của bàn nguồn
            _context.Bills.Remove(sourceBill);
            sourceTable.Status = 0;
            targetTable.Status = 1;
        }

        await _context.SaveChangesAsync();
        return true;
    }
}

