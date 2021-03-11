using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Entities;

namespace WebApplication1.IServices
{
    public interface IUserService
    {
        List<User> GetAllUser();
        User GetUserById(int id);
    }
}
