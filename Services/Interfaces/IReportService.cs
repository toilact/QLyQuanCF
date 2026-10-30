using CoffeeShopManagement.Models;

namespace CoffeeShopManagement.Services.Interfaces;

public interface IReportService
{
    Task<List<Bill>> GetRevenueBillsAsync(DateTime fromDate, DateTime toDate);
    Task<(decimal TotalRevenue, int TotalBills, decimal AverageBill)> GetSummaryAsync(DateTime fromDate, DateTime toDate);
    Task<List<(string ProductName, int QuantitySold, decimal Revenue)>> GetTopSellingProductsAsync(DateTime fromDate, DateTime toDate, int top = 10);
}
