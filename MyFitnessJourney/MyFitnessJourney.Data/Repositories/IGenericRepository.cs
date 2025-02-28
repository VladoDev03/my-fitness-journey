using MyFitnessJourney.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFitnessJourney.Data.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetAllAsNoTracking();
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> EditAsync(TEntity entity);
        Task<TEntity> DeleteAsync(TEntity entity);
    }
}
