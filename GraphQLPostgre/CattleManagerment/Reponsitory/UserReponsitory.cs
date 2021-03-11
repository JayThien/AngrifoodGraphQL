using CattleManagerment.Entities;
using CattleManagerment.IReponsitory;
using CattleManagerment.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CattleManagerment.Reponsitory
{
    public class UserReponsitory : IUserReponsitory
    {
        private readonly DataDbContext _dataDbContext;
        public UserReponsitory(DataDbContext dataDbContext)
        {
            _dataDbContext = dataDbContext;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            await _dataDbContext.Users.AddAsync(user);
            await _dataDbContext.SaveChangesAsync();
            return user;
        }

    }
}
