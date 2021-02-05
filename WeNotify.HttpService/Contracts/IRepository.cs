using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeNotify.HttpService.Contracts
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> Get();
        Task<List<TEntity>> GetAll();
        Task<List<TEntity>> Get(int page, int length = 25);
        Task<List<TEntity>> Get(Func<IQueryable<TEntity>, IQueryable<TEntity>> Predicate, int page = 0, int length = 25);

        Task<TEntity> GetOne<TId>(TId id);
        
        bool Validate(TEntity entity);

        Task<int> StoreAnsyc(TEntity entity);

        Task<int> UpdateAsync(TEntity data);
        Task<int> UpdateAsync(TEntity data, TEntity entity);

        Task<int> DeleteAsync<TId>(TId id);
        Task<int> DeleteAsync<TId>(IEnumerable<TId> id);
        Task<int> DeleteAsync(TEntity data);
        Task<int> DeleteAsync(IEnumerable<TEntity> data);

    }
}
