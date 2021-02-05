using Microsoft.EntityFrameworkCore;
using WeNotify.HttpService.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeNotify.HttpService.Data;

namespace PremiumTesh.TwitterNotifier.Support
{
    /// <summary>
    /// The repository <see cref="IRepository{TEntity}"/> implementation for all type entities
    /// </summary>
    /// <typeparam name="TargetEntity"></typeparam>
    public class RepositoryFactory<TargetEntity> : IRepository<TargetEntity> where TargetEntity : class
    {
        /// <summary>
        /// required a system context for <see cref="DbContext"/>
        /// </summary>
        /// <param name="context"></param>
        public RepositoryFactory(ServiceContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            TypeEntity = typeof(TargetEntity);
        }

        ServiceContext Context { get; }

        Type TypeEntity { get; }

        /// <summary>
        /// The basic implemntation for delete a element by id value
        /// </summary>
        /// <typeparam name="TId"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> DeleteAsync<TId>(TId id)
        {
            Context.Remove(await Context.FindAsync(TypeEntity, id).AsTask());
            return await Context.SaveChangesAsync(default);
        }

        /// <summary>
        /// The basic implemntation for delete a element by entity isntance
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<int> DeleteAsync(TargetEntity data)
        {
            Context.Remove(data);
            return Context.SaveChangesAsync(default);
        }

        /// <summary>
        /// The basic implemntation for delete a element by id value in for collection
        /// </summary>
        /// <typeparam name="TId"></typeparam>
        /// <param name="elements"></param>
        /// <returns></returns>
        public async Task<int> DeleteAsync<TId>(IEnumerable<TId> elements)
        {
            foreach (var id in elements)
            {
                Context.Remove(await Context.FindAsync(TypeEntity, id).AsTask());
            }
            return await Context.SaveChangesAsync(default);
        }

        /// <summary>
        /// The basic implemntation for delete a element by entity isntance for collection
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<int> DeleteAsync(IEnumerable<TargetEntity> data)
        {
            foreach (var item in data)
            {
                Context.Remove(item);
            }
            return Context.SaveChangesAsync(default);
        }

        /// <summary>
        /// Get the DbSet instance as IQueryable<TargetEntity>
        /// </summary>
        /// <returns></returns>
        public IQueryable<TargetEntity> Get()
        {
            return Context.Set<TargetEntity>();
        }

        /// <summary>
        /// Get paginated list
        /// </summary>
        /// <param name="page"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public Task<List<TargetEntity>> Get(int page, int length = 25)
        {
            return Context.Set<TargetEntity>().Skip((page - 1) * length).Take(length).ToListAsync();
        }

        /// <summary>
        /// Get filter and paginate list list 
        /// </summary>
        /// <param name="Predicate"></param>
        /// <param name="page"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public Task<List<TargetEntity>> Get(Func<IQueryable<TargetEntity>, IQueryable<TargetEntity>> Predicate, int page = 0, int length = 25)
        {
            var collection = Context.Set<TargetEntity>();
            if (page > 0)
            {
                collection.Skip((page - 1) * length).Take(length);
            }
            return Predicate(collection).ToListAsync();
        }

        /// <summary>
        /// Get all records
        /// </summary>
        /// <returns></returns>
        public Task<List<TargetEntity>> GetAll()
        {
            return Context.Set<TargetEntity>().ToListAsync();
        }

        /// <summary>
        /// Get a single record by id
        /// </summary>
        /// <typeparam name="TId"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TargetEntity> GetOne<TId>(TId id)
        {
            var result = await Context.FindAsync(TypeEntity, id).AsTask();
            if (result is TargetEntity data)
            {
                return data;
            }
            throw new InvalidCastException();
        }

        /// <summary>
        /// Add new record by instance
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Task<int> StoreAnsyc(TargetEntity entity)
        {
            Context.Add(entity);
            return Context.SaveChangesAsync(default);
        }

        /// <summary>
        ///  Update new record by instance
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<int> UpdateAsync(TargetEntity data)
        {
            Context.Update(data);
            return Context.SaveChangesAsync(default);
        }

        /// <summary>
        ///  Update new record by instance and check concurrency comprobation
        /// </summary>
        /// <param name="data"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Task<int> UpdateAsync(TargetEntity data, TargetEntity entity)
        {
            Context.Update(data);
            return Context.SaveChangesAsync(default);
        }

        /// <summary>
        /// Return true if the entity values is a correct
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Validate(TargetEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
