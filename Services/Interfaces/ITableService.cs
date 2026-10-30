using CoffeeShopManagement.Models;

namespace CoffeeShopManagement.Services.Interfaces;

public interface ITableService
{
    Task<List<Table>> GetAllTablesAsync();
    Task<List<Table>> GetTablesByAreaAsync(string area);
    Task<List<string>> GetAllAreasAsync();
    Task<Table?> GetTableByIdAsync(int id);
    Task<Table> CreateTableAsync(Table table);
    Task<bool> UpdateTableAsync(Table table);
    Task<bool> DeleteTableAsync(int id);
    Task<bool> SwitchTableAsync(int fromTableId, int toTableId);
    Task<bool> MergeTableAsync(int sourceTableId, int targetTableId);
}
