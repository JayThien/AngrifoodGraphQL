using CattleManagerment.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CattleManagerment.IReponsitory
{
    public interface IUserReponsitory
    {
        Task<User> CreateUserAsync(User user);
    }
}
