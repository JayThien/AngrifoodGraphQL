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
    public class TypeOfCattleService : ITypeOfCattleService
    {
        private readonly DataDbContext _dataDbContext;
        public TypeOfCattleService(DataDbContext dataDbContext)
        {
            _dataDbContext = dataDbContext;
        }
        public async Task<TypeOfCattle> CreateTypeOfCattleAsync(TypeOfCattle typeOfCattle)
        {
            await _dataDbContext.TypeOfCattles.AddAsync(typeOfCattle);
            await _dataDbContext.SaveChangesAsync();
            return typeOfCattle;
        }

        public async Task<bool> DeleteTypeOfCattleAsync(int id)
        {
            var typeOfCattle = await _dataDbContext.TypeOfCattles.Where(a => a.Id == id).FirstOrDefaultAsync();
            if (typeOfCattle == null)
            {
                return false;
            }
            _dataDbContext.TypeOfCattles.Remove(typeOfCattle);
            await _dataDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<TypeOfCattle>> GetAllTypeOfCattleAsync()
        {
            return await _dataDbContext.TypeOfCattles.ToListAsync();
        }

        public async Task<TypeOfCattle> GetTypeOfCattleById(int id)
        {
            return await _dataDbContext.TypeOfCattles.Where(a => a.Id == id).FirstOrDefaultAsync();
        }

        public async Task<TypeOfCattle> UpdateTypeOfCattleAsync(TypeOfCattle typeOfCattle)
        {
            _dataDbContext.TypeOfCattles.Attach(typeOfCattle);
            _dataDbContext.Entry(typeOfCattle).State = EntityState.Modified;
            await _dataDbContext.SaveChangesAsync();
            return typeOfCattle;
        }
    }
}
