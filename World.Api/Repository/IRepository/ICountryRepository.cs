using World.Api.Models;

namespace World.Api.Repository.IRepository
{
    public interface ICountryRepository : IGenericRepository<Country>
    {
        Task update(Country country);
    }
}
