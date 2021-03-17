using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Entities;

namespace WebApplication1.IServices
{
    public interface IRoleService
    {
        Task<List<Role>> GetAllRoleAsync();
        Task<Role> CreateRoleAsync(Role role);
        Task<bool> DeleteRoleAsync(int id);
    }
}
