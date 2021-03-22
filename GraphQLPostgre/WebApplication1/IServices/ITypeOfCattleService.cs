using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Entities;

namespace WebApplication1.IServices
{
    public interface ITypeOfCattleService
    {
        Task<List<TypeOfCattle>> GetAllTypeOfCattleAsync();
        Task<TypeOfCattle> GetTypeOfCattleById(int id);
        Task<bool> DeleteTypeOfCattleAsync(int id);
        Task<TypeOfCattle> CreateTypeOfCattleAsync(TypeOfCattle typeOfCattle);
        Task<TypeOfCattle> UpdateTypeOfCattleAsync(TypeOfCattle typeOfCattle);
    }
}
