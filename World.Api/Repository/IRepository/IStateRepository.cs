using World.Api.Models;

namespace World.Api.Repository.IRepository
{
    public interface IStateRepository
    {
        Task<List<State>> GetAll();
        Task<State> GetById(int id);
        Task create(State state);
        Task update(State state);
        Task delete(State state);
        Task save();
        bool IsStateExists(string name);
    }
}
