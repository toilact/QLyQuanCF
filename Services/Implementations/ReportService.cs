using Microsoft.EntityFrameworkCore;
using CoffeeShopManagement.Data;
using CoffeeShopManagement.Models;
using CoffeeShopManagement.Services.Interfaces;

namespace CoffeeShopManagement.Services.Implementations;

public class ReportService : IReportService
{
    private readonly AppDbContext _context;

    public ReportService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Bill>> GetRevenueBillsAsync(DateTime fromDate, DateTime toDate)
    {
        var start = fromDate.Date;
        var end = toDate.Date.AddDays(1).AddTicks(-1);

        return await _context.Bills
            .Include(b => b.Table)
            .Include(b => b.User)
            .Include(b => b.Details)
                .ThenInclude(d => d.Product)
            .Where(b => b.Status == 1 && b.CheckOutDate >= start && b.CheckOutDate <= end)
            .OrderByDescending(b => b.CheckOutDate)
            .ToListAsync();
    }

    public async Task<(decimal TotalRevenue, int TotalBills, decimal AverageBill)> GetSummaryAsync(DateTime fromDate, DateTime toDate)
    {
        var bills = await GetRevenueBillsAsync(fromDate, toDate);
        int totalBills = bills.Count;
        decimal totalRevenue = bills.Sum(b => b.TotalAmount);
        decimal average = totalBills > 0 ? totalRevenue / totalBills : 0;

        return (totalRevenue, totalBills, average);
    }

    public async Task<List<(string ProductName, int QuantitySold, decimal Revenue)>> GetTopSellingProductsAsync(DateTime fromDate, DateTime toDate, int top = 10)
    {
        var start = fromDate.Date;
        var end = toDate.Date.AddDays(1).AddTicks(-1);

        var details = await _context.BillDetails
            .Include(d => d.Product)
            .Include(d => d.Bill)
            .Where(d => d.Bill.Status == 1 && d.Bill.CheckOutDate >= start && d.Bill.CheckOutDate <= end)
            .GroupBy(d => d.Product.Name)
            .Select(g => new
            {
                ProductName = g.Key,
                QuantitySold = g.Sum(x => x.Quantity),
                Revenue = g.Sum(x => x.Quantity * x.UnitPrice)
            })
            .OrderByDescending(x => x.QuantitySold)
            .Take(top)
            .ToListAsync();

        return details.Select(d => (d.ProductName, d.QuantitySold, d.Revenue)).ToList();
    }
}
