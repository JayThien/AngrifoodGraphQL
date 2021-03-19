using HotChocolate;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Entities;
using WebApplication1.IServices;
using WebApplication1.Models;

namespace WebApplication1.GraphQLCore
{
    public class Mutation
    {
        public async Task<User> CreateUserAsync([Service] IUserService userService, UserInputK userInput)
        {
            try
            {
                var user = new User();
                user.Email = userInput.Email;
                user.Password = userInput.Password;
                user.UserName = userInput.UserName;
                await userService.CreateUserAsync(user);
                return user;
            } catch(Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> AddRoleToUserAsync(int userId, string nameRole, [Service] IUserService userService)
        {
            try
            {
                return await userService.AddRoleToUserAsync(userId, nameRole);
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }

        public async Task<bool> DeleteUserAsync([Service] IUserService userService, int id)
        {
            try
            {
                return await userService.DeleteUserAsync(id);
            }catch(Exception e)
            {
                throw e;
            }
        }

        public async Task<User> UpdateUserAsync([Service] IUserService userService, User user)
        {
            try
            {
                return await userService.UpdateUserAsync(user);
            } catch(Exception e)
            {
                throw e;
            }
        }

        public string UserLogin([Service] IOptions<TokenSettings> tokenSettings, LoginInput login, [Service] IUserService userService)
        {
            return userService.UserLogin(tokenSettings, login);
        }

        public async Task<Role> CreateRoleAsync([Service] IRoleService roleService, Role role)
        {
            try
            {
                return await roleService.CreateRoleAsync(role);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<bool> DeleteFarmerAsync([Service] IFarmerService farmerService, int id)
        {
            try
            {
                return await farmerService.DeleteFarmerAsync(id);
            }
            catch (Exception e) {
                throw e;
            }
        }
        public async Task<Farmer> CreateFarmerAsync([Service] IFarmerService farmerService, Farmer farmer)
        {
            try
            {
                return await farmerService.CreateFarmerAsync(farmer);
            } catch(Exception e)
            {
                throw e;
            }
        }
        public async Task<Farmer> UpdateFarmerAsync([Service] IFarmerService farmerService, Farmer farmer)
        {
            try
            {
                return await farmerService.UpdateFarmerAsync(farmer);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
