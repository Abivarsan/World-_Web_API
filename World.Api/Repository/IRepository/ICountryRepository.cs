using World.Api.Models;

namespace World.Api.Repository.IRepository
{
    public interface ICountryRepository
    {
        Task<List<Country>> GetAll();
        Task<Country> GetById(int id);
        Task create(Country country);
        Task update(Country country);
        Task delete(Country country);
        Task save();
    
        bool IsCountryExists(string name);
    }
}
