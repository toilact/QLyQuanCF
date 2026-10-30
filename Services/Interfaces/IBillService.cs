using CoffeeShopManagement.Models;

namespace CoffeeShopManagement.Services.Interfaces;

public interface IBillService
{
    Task<Bill?> GetActiveBillByTableIdAsync(int tableId);
    Task<Bill?> GetBillByIdAsync(int billId);
    Task<Bill> AddOrUpdateProductAsync(int tableId, int productId, int quantity, int userId);
    Task<bool> RemoveDetailAsync(int billDetailId);
    Task<Bill> PayBillAsync(int billId, int discountPercent);
}

