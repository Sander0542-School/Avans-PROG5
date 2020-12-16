using System.Collections.Generic;
using System.Threading.Tasks;
using NinjaManager.Data.Models;

namespace NinjaManager.Data.Repositories
{
    public class GearsRepository : IRepository
    {
        private ApplicationDbContext _context;

        public GearsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<List<Ninja>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<Ninja> Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Create(Ninja ninja)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Update(Ninja ninja)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Delete(Ninja ninja)
        {
            throw new System.NotImplementedException();
        }
    }
}