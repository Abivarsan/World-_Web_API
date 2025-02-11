using Microsoft.EntityFrameworkCore;
using World.Api.Data;
using World.Api.Models;
using World.Api.Repository.IRepository;

namespace World.Api.Repository
{
    public class CountryRepository : ICountryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CountryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task create(Country country)
        {
            await _dbContext.Countries.AddAsync(country);
            await save();
        }

        public async Task delete(Country country)
        {
            _dbContext.Countries.Remove(country);
            await save();
        }

        public async Task<List<Country>> GetAll()
        {
            List<Country> countries = await _dbContext.Countries.ToListAsync();
            return countries;

        }

        public async Task<Country> GetById(int id)
        {
           Country country = await _dbContext.Countries.FindAsync(id);
            return country;
        }

        public bool IsCountryExists(string name)
        {
            var result = _dbContext.Countries.AsQueryable().Where(c => c.Name.ToLower().Trim() == name.ToLower().Trim()).Any();
            return result;
        }

        public async Task save()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task update(Country country)
        {
            _dbContext.Countries.Update(country);
            await save();
        }
    }
}
