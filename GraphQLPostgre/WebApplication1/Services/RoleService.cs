using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Entities;
using WebApplication1.IServices;
using WebApplication1.Models.ModelContext;

namespace WebApplication1.Services
{
    public class RoleService : IRoleService
    {
        private readonly DataDbContext _dataDbContext;
        public RoleService(DataDbContext dataDbContext)
        {
            _dataDbContext = dataDbContext;
        }
        public async Task<Role> CreateRoleAsync(Role role)
        {
            await _dataDbContext.Roles.AddAsync(role);
            await _dataDbContext.SaveChangesAsync();
            return role;
        }

        public async Task<bool> DeleteRoleAsync(int id)
        {
            var role = await _dataDbContext.Roles.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (role == null)
            {
                return false;
            }
            _dataDbContext.Roles.Remove(role);
            await _dataDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Role>> GetAllRoleAsync()
        {
            return await _dataDbContext.Roles.ToListAsync();
        }
    }
}
