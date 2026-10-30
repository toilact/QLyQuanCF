using Microsoft.EntityFrameworkCore;
using CoffeeShopManagement.Data;
using CoffeeShopManagement.Models;
using CoffeeShopManagement.Services.Interfaces;
using CoffeeShopManagement.Utils;

namespace CoffeeShopManagement.Services.Implementations;

public class AuthService : IAuthService
{
    private readonly AppDbContext _context;

    public AuthService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<User?> LoginAsync(string username, string password)
    {
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            return null;

        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Username.ToLower() == username.Trim().ToLower());

        if (user == null || !user.IsActive)
            return null;

        if (PasswordHelper.VerifyPassword(password, user.PasswordHash))
            return user;

        return null;
    }

    public async Task<bool> ChangePasswordAsync(int userId, string oldPassword, string newPassword)
    {
        var user = await _context.Users.FindAsync(userId);
        if (user == null) return false;

        if (!PasswordHelper.VerifyPassword(oldPassword, user.PasswordHash))
            return false;

        user.PasswordHash = PasswordHelper.HashPassword(newPassword);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<List<User>> GetAllUsersAsync()
    {
        return await _context.Users.OrderBy(u => u.Id).ToListAsync();
    }

    public async Task<User> CreateUserAsync(User user, string plainPassword)
    {
        user.Username = user.Username.Trim();
        user.PasswordHash = PasswordHelper.HashPassword(plainPassword);
        user.CreatedAt = DateTime.Now;

        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<bool> UpdateUserAsync(User user, string? newPlainPassword = null)
    {
        var existing = await _context.Users.FindAsync(user.Id);
        if (existing == null) return false;

        existing.FullName = user.FullName;
        existing.Role = user.Role;
        existing.IsActive = user.IsActive;

        if (!string.IsNullOrWhiteSpace(newPlainPassword))
        {
            existing.PasswordHash = PasswordHelper.HashPassword(newPlainPassword);
        }

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> ToggleUserStatusAsync(int userId)
    {
        var user = await _context.Users.FindAsync(userId);
        if (user == null) return false;

        user.IsActive = !user.IsActive;
        await _context.SaveChangesAsync();
        return true;
    }
}

