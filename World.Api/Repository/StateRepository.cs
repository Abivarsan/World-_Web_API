using Microsoft.EntityFrameworkCore;
using World.Api.Data;
using World.Api.Models;
using World.Api.Repository.IRepository;

namespace World.Api.Repository
{
    public class StateRepository : IStateRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public StateRepository(ApplicationDbContext dbContext) { 
            _dbContext = dbContext;
        }
        public async Task create(State state)
        {
            await _dbContext.States.AddAsync(state);
            await save();
        }
        public async Task delete(State state)
        {
            _dbContext.States.Remove(state); 
            await save();
        }
        public async Task<List<State>> GetAll()
        {
            List<State> states = await _dbContext.States.ToListAsync();
            return states;
        }
        public async Task<State> GetById(int id)
        {
            State state = await _dbContext.States.FindAsync(id);
            return state;
        }

        public bool  IsStateExists(string name)
        {
            var result = _dbContext.States.AsQueryable().Where(s => s.Name.ToLower().Trim() == name.ToLower().Trim()).Any();
            return result;
        }

        public async Task save()
        {
            await _dbContext.SaveChangesAsync();
        }
        public async Task update(State state)
        {
            _dbContext.States.Update(state);
            await save();
        }
    }
}
