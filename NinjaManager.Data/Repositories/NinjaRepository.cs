using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NinjaManager.Data.Models;

namespace NinjaManager.Data.Repositories
{
    public class NinjaRepository : IRepository<Ninja>
    {
        private ApplicationDbContext _context;

        public NinjaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Ninja>> GetAll()
        {
            return await _context.Ninjas
                .Include(ninja => ninja.NinjaGears)
                .ThenInclude(ninjaGear => ninjaGear.Gear)
                .ToListAsync();
        }

        public async Task<Ninja> Get(int id)
        {
            return await _context.Ninjas
                .Include(ninja => ninja.NinjaGears)
                .ThenInclude(ninjaGear => ninjaGear.Gear)
                .FirstOrDefaultAsync(ninja => ninja.Id == id);
        }

        public async Task<bool> Create(Ninja ninja)
        {
            try
            {
                _context.Add(ninja);

                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Update(Ninja ninja)
        {
            try
            {
                _context.Entry(ninja).State = EntityState.Modified;

                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Delete(Ninja ninja)
        {
            try
            {
                _context.Remove(ninja);

                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}