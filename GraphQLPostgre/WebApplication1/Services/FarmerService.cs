using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Entities;
using WebApplication1.IServices;
using WebApplication1.Models.ModelContext;

namespace WebApplication1.Services
{
    public class FarmerService : IFarmerService
    {
        private readonly DataDbContext _dataDbContext;
        public FarmerService(DataDbContext dataDbContext)
        {
            _dataDbContext = dataDbContext;
        }
        public async Task<Farmer> CreateFarmerAsync(Farmer farmer)
        {
            await _dataDbContext.Farmers.AddAsync(farmer);
            await _dataDbContext.SaveChangesAsync();
            return farmer;
        }

        public async Task<bool> DeleteFarmerAsync(int id)
        {
            var farmer = await _dataDbContext.Farmers.Where(a => a.Id == id).FirstOrDefaultAsync();
            if(farmer == null)
            {
                return false;
            }
            _dataDbContext.Farmers.Remove(farmer);
            await _dataDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Farmer>> GetAllFarmerAsync()
        {
            return await _dataDbContext.Farmers.ToListAsync();
        }

        public async Task<Farmer> GetFarmerByIdAsync(int id)
        {
            return await _dataDbContext.Farmers.Where(a => a.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Farmer> UpdateFarmerAsync(Farmer farmer)
        {
            _dataDbContext.Farmers.Attach(farmer);
            _dataDbContext.Entry(farmer).State = EntityState.Modified;
            await _dataDbContext.SaveChangesAsync();
            return farmer;
        }
    }
}
