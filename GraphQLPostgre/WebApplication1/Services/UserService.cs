using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Entities;
using WebApplication1.IServices;
using WebApplication1.Models.ModelContext;

namespace WebApplication1.Services
{
    public class UserService : IUserService
    {
        private readonly DataDbContext _dataDbContext;

        public UserService(DataDbContext dataDbContext)
        {
            _dataDbContext = dataDbContext;
        }
        public  List<User> GetAllUser()
        {
            return _dataDbContext.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return _dataDbContext.Users.Where(a => a.Id == id).FirstOrDefault();
        }
    }
}
