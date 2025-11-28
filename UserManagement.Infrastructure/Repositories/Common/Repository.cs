using Microsoft.EntityFrameworkCore;
using UserManagement.Domain.Common.Model;
using UserManagement.Domain.Persistence.Common;

namespace UserManagement.Infrastructure.Repositories.Common
{
    public class Repository<TEntity, TId> : IRepository<TEntity, TId> where TEntity : class
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;


        public async Task InsertAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);

        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }
        public Task<GetAllResponse<TEntity>> Get()
        {
            return _dbSet.ToListAsync().ContinueWith(task => new GetAllResponse<TEntity>
            {
                Values = task.Result
            });
        }
        public void Delete(TEntity? entity)
        {
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }

        public async Task DeleteAsync(TId id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }
    }
}
