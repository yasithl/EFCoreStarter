using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        TEntity Add(TEntity entity, bool autoSave = false);
        Task<TEntity> AddAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default);
        TEntity Delete(int id, bool autoSave = false);
        Task<TEntity> DeleteAsync(int id, bool autoSave = false, CancellationToken cancellationToken = default);
        TEntity Get(int id);
        List<TEntity> GetAll();
        Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<TEntity> GetAsync(int id, CancellationToken cancellationToken = default);
        IQueryable<TEntity> GetQueryable();
        TEntity Update(TEntity entity, bool autoSave = false);
        Task<TEntity> UpdateAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default);
    }
}