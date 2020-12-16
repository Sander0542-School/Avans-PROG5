using System.Collections.Generic;
using System.Threading.Tasks;
using NinjaManager.Data.Models;

namespace NinjaManager.Data.Repositories
{
    public class GearsRepository : IRepository<Gear>
    {
        private ApplicationDbContext _context;

        public GearsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<List<Gear>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<Gear> Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Create(Gear gear)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Update(Gear gear)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Delete(Gear gear)
        {
            throw new System.NotImplementedException();
        }
    }
}