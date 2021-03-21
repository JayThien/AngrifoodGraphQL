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
    public class ByreService : IByreService
    {
        private readonly DataDbContext _dataDbContext;
        public ByreService(DataDbContext dataDbContext)
        {
            _dataDbContext = dataDbContext;
        }
        public async Task<Byre> CreateByreAsync(Byre byre)
        {
            await _dataDbContext.Byres.AddAsync(byre);
            await _dataDbContext.SaveChangesAsync();
            return byre;
        }

        public async Task<bool> DeleteByreAsync(int id)
        {
            var byre = await _dataDbContext.Byres.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (byre == null)
            {
                return false;
            }
            _dataDbContext.Byres.Remove(byre);
            await _dataDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Byre>> GetAllByreAsync()
        {
            return await _dataDbContext.Byres.ToListAsync();
        }

        public async Task<Byre> GetByreById(int id)
        {
            return await _dataDbContext.Byres.Where(a => a.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Byre> UpdateByreAsync(Byre byre)
        {
            _dataDbContext.Byres.Attach(byre);
            _dataDbContext.Entry(byre).State = EntityState.Modified;
            await _dataDbContext.SaveChangesAsync();
            return byre;
        }
    }
}
