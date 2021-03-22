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
    public class CattleService : ICattleService
    {
        private readonly DataDbContext _dataDbContext;
        public CattleService(DataDbContext dataDbContext)
        {
            _dataDbContext = dataDbContext;
        }
        public async Task<Cattle> CreateCattleAsync(Cattle cattle)
        {
            await _dataDbContext.Cattles.AddAsync(cattle);
            await _dataDbContext.SaveChangesAsync();
            return cattle;
        }

        public async Task<bool> DeleteCattleAsync(int id)
        {
            var cattle = await _dataDbContext.Cattles.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (cattle == null)
            {
                return false;
            }
            _dataDbContext.Cattles.Remove(cattle);
            await _dataDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Cattle>> GetAllCattleAsync()
        {
            return await _dataDbContext.Cattles.ToListAsync();
        }

        public async Task<Cattle> GetCattleById(int id)
        {
            return await _dataDbContext.Cattles.Where(a => a.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Cattle> UpdateCattleAsync(Cattle cattle)
        {
            _dataDbContext.Cattles.Attach(cattle);
            _dataDbContext.Entry(cattle).State = EntityState.Modified;
            await _dataDbContext.SaveChangesAsync();
            return cattle;
        }
    }
}
