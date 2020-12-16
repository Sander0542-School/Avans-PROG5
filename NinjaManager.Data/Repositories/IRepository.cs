using System.Collections.Generic;
using System.Threading.Tasks;
using NinjaManager.Data.Models;

namespace NinjaManager.Data.Repositories
{
    public interface IRepository
    {
        Task<List<Ninja>> GetAll();
        Task<Ninja> Get(int id);
        Task<bool> Create(Ninja ninja);
        Task<bool> Update(Ninja ninja);
        Task<bool> Delete(Ninja ninja);
    }
}