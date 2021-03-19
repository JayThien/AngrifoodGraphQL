using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Entities;

namespace WebApplication1.IServices
{
    public interface IFarmerService
    {
        Task<List<Farmer>> GetAllFarmerAsync();
        Task<Farmer> GetFarmerByIdAsync(int id);
        Task<bool> DeleteFarmerAsync(int id);
        Task<Farmer> CreateFarmerAsync(Farmer farmer);
        Task<Farmer> UpdateFarmerAsync(Farmer farmer);
    }
}
