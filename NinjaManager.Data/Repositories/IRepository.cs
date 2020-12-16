using System.Collections.Generic;
using System.Threading.Tasks;
using NinjaManager.Data.Models;

namespace NinjaManager.Data.Repositories
{
    public interface IRepository<TEntity>
    {
        Task<List<TEntity>> GetAll();
        Task<TEntity> Get(int id);
        Task<bool> Create(TEntity entity);
        Task<bool> Update(TEntity entity);
        Task<bool> Delete(TEntity entity);
    }
}