using CattleManagerment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CattleManagerment.Iservice
{
    public interface IUserService
    {
        Task<User> CreateUserAsync(string email, string password);
    }
}
