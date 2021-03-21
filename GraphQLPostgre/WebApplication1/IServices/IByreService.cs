using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Entities;

namespace WebApplication1.IServices
{
    public interface IByreService
    {
        Task<List<Byre>> GetAllByreAsync();
        Task<Byre> GetByreById(int id);
        Task<bool> DeleteByreAsync(int id);
        Task<Byre> CreateByreAsync(Byre byre);
        Task<Byre> UpdateByreAsync(Byre byre);
    }
}
