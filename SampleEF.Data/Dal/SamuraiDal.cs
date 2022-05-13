using Microsoft.EntityFrameworkCore;
using SampleEF.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleEF.Data.Dal
{
    public class SamuraiDal : ISamurai
    {
        private readonly SamuraiContext _context;
        public SamuraiDal(SamuraiContext context)
        {
            _context = context;
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Samurai> Get(int id)
        {
            var result = await _context.Samurais.FirstOrDefaultAsync(s => s.Id == id);
            if (result == null) throw new Exception($"Data {id} tidak ditemukan");
            return result;
        }

        public async Task<IEnumerable<Samurai>> GetAll()
        {
            var results = await _context.Samurais.OrderBy(s => s.Name).ToListAsync();
            return results;
        }

        public Task<IEnumerable<Samurai>> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<Samurai> Insert(Samurai obj)
        {
            try
            {
                _context.Samurais.Add(obj);
                var result = await _context.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public Task<Samurai> Update(Samurai obj)
        {
            throw new NotImplementedException();
        }
    }
}
