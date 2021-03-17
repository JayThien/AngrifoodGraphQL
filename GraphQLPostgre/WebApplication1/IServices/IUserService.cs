using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Entities;
using WebApplication1.Models;

namespace WebApplication1.IServices
{
    public interface IUserService
    {
        Task<List<User>> GetAllUserAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> CreateUserAsync(User user);
        Task<bool> DeleteUserAsync(int id);
        string UserLogin(IOptions<TokenSettings> tokenSettings, LoginInput login);
        Task<User> UpdateUserAsync(User user);
        Task<bool> AddRoleToUserAsync(int userId, string roleName);
    }
}
