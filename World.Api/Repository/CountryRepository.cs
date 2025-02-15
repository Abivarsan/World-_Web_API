using Microsoft.EntityFrameworkCore;
using World.Api.Data;
using World.Api.Models;
using World.Api.Repository.IRepository;

namespace World.Api.Repository
{
    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CountryRepository(ApplicationDbContext dbContext) : base(dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task update(Country entity)
        {
            _dbContext.Countries.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
