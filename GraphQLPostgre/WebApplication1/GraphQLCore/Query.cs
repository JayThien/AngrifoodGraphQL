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
        //public async Task<List<User>> GetAllUserAsync2([Service] IUserService userService)
        //{
        //    return await userService.GetAllUserAsync();
        //}
        //public async Task<List<User>> GetAllUserAsync1([Service] IUserService userService)
        //{
        //    return await userService.GetAllUserAsync();
        //}

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
        public async Task<Byre> GetByreById([Service] IByreService byreService, int id)
        {
            return await byreService.GetByreById(id);
        }

        public async Task<List<Cattle>> GetAllCattleAsync([Service] ICattleService cattleService)
        {
            return await cattleService.GetAllCattleAsync();
        }
        public async Task<Cattle> GetCattleById([Service] ICattleService cattleService, int id)
        {
            return await cattleService.GetCattleById(id);
        }

        public async Task<List<TypeOfCattle>> GetAllTypeOfCattleAsync([Service] ITypeOfCattleService typeOfCattleService)
        {
            return await typeOfCattleService.GetAllTypeOfCattleAsync();
        }
        public async Task<TypeOfCattle> GetTypeOfCattleById([Service] ITypeOfCattleService typeOfCattleService, int id)
        {
            return await typeOfCattleService.GetTypeOfCattleById(id);
        }
    }
}
