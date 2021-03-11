using CattleManagerment.Entities;
using CattleManagerment.IReponsitory;
using CattleManagerment.Iservice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CattleManagerment.Service
{
    public class UserService : IUserService
    {
        private readonly IUserReponsitory _userReponsitory;

        public UserService(IUserReponsitory userReponsitory)
        {
            _userReponsitory = userReponsitory;
        }

        public async Task<User> CreateUserAsync(string email, string password)
        {
            User user = new User
            {
                Id = 12,
                Email = email,
                Password = password,
                EmailConfirmed = false,
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = false,
                AccessFailedCount = 0
            };
            var test = await _userReponsitory.CreateUserAsync(user);
            return test;
            
        }
    }
}
