using HotChocolate;
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
        public async Task<User> CreateUserAsync([Service] IUserService userService, User user)
        {
            try
            {
                return await userService.CreateUserAsync(user);
            } catch(Exception e)
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

        public async Task<User> UpdateUserAsync([Service] IUserService userService, User user, int id)
        {
            try
            {
                var userId = await userService.GetUserByIdAsync(id);
                if(userId == null)
                {
                    throw new Exception();
                }
                userId.Email = user.Email;
                return await userService.UpdateUserAsync(userId);
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
    }
}
