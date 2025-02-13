using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Linq.Expressions;
using World.Api.Data;
using World.Api.Models;
using World.Api.Repository.IRepository;

namespace World.Api.Repository
{


    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        private readonly ApplicationDbContext _dbContext;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task create(T entity)
        {
            await _dbContext.AddAsync(entity);
            await save();
        }

        public async Task delete(T entity)
        {
            _dbContext.Remove(entity);
            await save();
        }

        public async Task<T> Get(int id)
        {
           return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public bool IsRecordExists(Expression<Func<T, bool>> condtion)
        {
            var result = _dbContext.Set<T>().AsQueryable().Where(condtion).Any();
            return result;
        }

        public async Task save()
        {
           await _dbContext.SaveChangesAsync();

        }

       
    }
}
