using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Gear>> GetAll()
        {
            return await _context.Gears
                .Include(gear => gear.NinjaGears)
                .ToListAsync();
        }

        public async Task<Gear> Get(int id)
        {
            return await _context.Gears
                .Include(gear => gear.NinjaGears)
                .FirstOrDefaultAsync(gear => gear.Id == id);
        }

        public async Task<bool> Create(Gear gear)
        {
            try
            {
                _context.Add(gear);

                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Update(Gear gear)
        {
            try
            {
                _context.Entry(gear).State = EntityState.Modified;

                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Delete(Gear gear)
        {
            try
            {
                _context.Remove(gear);

                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}