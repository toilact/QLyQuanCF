using CoffeeShopManagement.Models;

namespace CoffeeShopManagement.Services.Interfaces;

public interface IAuthService
{
    Task<User?> LoginAsync(string username, string password);
    Task<bool> ChangePasswordAsync(int userId, string oldPassword, string newPassword);
    Task<List<User>> GetAllUsersAsync();
    Task<User> CreateUserAsync(User user, string plainPassword);
    Task<bool> UpdateUserAsync(User user, string? newPlainPassword = null);
    Task<bool> ToggleUserStatusAsync(int userId);
}

