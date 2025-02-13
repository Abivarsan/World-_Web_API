using Microsoft.EntityFrameworkCore;
using World.Api.Data;
using World.Api.Models;
using World.Api.Repository.IRepository;

namespace World.Api.Repository
{
    public class StateRepository : GenericRepository<State>,IStateRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public StateRepository(ApplicationDbContext dbContext) :base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task update(State entity)
        {
            _dbContext.States.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
