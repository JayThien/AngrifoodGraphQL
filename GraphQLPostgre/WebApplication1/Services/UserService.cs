using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Entities;
using WebApplication1.IServices;
using WebApplication1.Models;
using WebApplication1.Models.ModelContext;

namespace WebApplication1.Services
{
    public class UserService : IUserService
    {
        private readonly DataDbContext _dataDbContext;

        public UserService(DataDbContext dataDbContext)
        {
            _dataDbContext = dataDbContext;
        }

        public async Task<bool> AddRoleToUserAsync(int userId, string roleName)
        {
            var user = await _dataDbContext.Users.Where(a => a.Id == userId).FirstOrDefaultAsync();
            if (user == null)
            {
                return false;
            }
            var roleId = await _dataDbContext.Roles.Where(a => a.Name.ToUpper() == roleName.ToUpper()).FirstOrDefaultAsync();
            if(roleId == null)
            {
                return false;
            }
            var userRole = new IdentityUserRole<int>();
            userRole.UserId = user.Id;
            userRole.RoleId = roleId.Id;
            await _dataDbContext.UserRoles.AddAsync(userRole);
            await _dataDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            await _dataDbContext.Users.AddAsync(user);
            await _dataDbContext.SaveChangesAsync();
            return user;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _dataDbContext.Users.Where(a => a.Id == id).FirstOrDefaultAsync();
            if(user == null)
            {
                return false;
            }
             _dataDbContext.Users.Remove(user);
            await _dataDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<User>> GetAllUserAsync()
        {
            return await _dataDbContext.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _dataDbContext.Users.Where(a => a.Id == id).FirstOrDefaultAsync();
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            _dataDbContext.Users.Attach(user);
            _dataDbContext.Entry(user).State = EntityState.Modified;
            await _dataDbContext.SaveChangesAsync();
            return user;
        }

        public string UserLogin(IOptions<TokenSettings> tokenSettings, LoginInput login)
        {
            var currentUser = _dataDbContext.Users.Where(_ => _.Email.ToLower() == login.Email.ToLower() &&
            _.Password == login.Password).FirstOrDefault();

            if (currentUser != null)
            {
                var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSettings.Value.Key));
                var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);

                var jwtToken = new JwtSecurityToken(
                    issuer: tokenSettings.Value.Issuer,
                    audience: tokenSettings.Value.Audience,
                    expires: DateTime.Now.AddMinutes(20),
                    signingCredentials: credentials
                );

                return new JwtSecurityTokenHandler().WriteToken(jwtToken);

            }
            return "";
        }
    }
}
