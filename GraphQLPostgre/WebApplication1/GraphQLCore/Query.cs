using HotChocolate;
using HotChocolate.AspNetCore.Authorization;
using HotChocolate.Types;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Entities;
using WebApplication1.IServices;

namespace WebApplication1.GraphQLCore
{
    public class Query
    {
        public async Task<List<User>> GetAllUserAsync([Service] IUserService userService)
        {
            return await userService.GetAllUserAsync();
        }

        public async Task<User> GetUserByIdAsync([Service] IUserService userService ,int id)
        {
            return await userService.GetUserByIdAsync(id);
        }
        public async Task<List<Role>> GetAllRoleAsync([Service] IRoleService roleService)
        {
            return await roleService.GetAllRoleAsync();
        }
        public async Task<List<Farmer>> GetAllFarmerAsync([Service] IFarmerService farmerService)
        {
            return await farmerService.GetAllFarmerAsync();
        }
        public async Task<Farmer> GetFarmerByIdAsync([Service] IFarmerService farmerService, int id)
        {
            return await farmerService.GetFarmerByIdAsync(id);
        }
        public async Task<List<Byre>> GetAllByreAsync([Service] IByreService byreService)
        {
            return await byreService.GetAllByreAsync();
        }
    }
}
