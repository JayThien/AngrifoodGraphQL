using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Entities;

namespace WebApplication1.IServices
{
    public interface ICattleService
    {
        Task<List<Cattle>> GetAllCattleAsync();
        Task<Cattle> GetCattleById(int id);
        Task<bool> DeleteCattleAsync(int id);
        Task<Cattle> CreateCattleAsync(Cattle cattle);
        Task<Cattle> UpdateCattleAsync(Cattle cattle);
    }
}
