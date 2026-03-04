using Domain.Entities;

namespace Infra.Repos.Interfaces;

public interface IStateRepo
{
    public Task Add(State state);
    public Task Update(State state);
    public Task Delete(State state);
    public Task<State?> GetByName(string name);
    public Task<State?> GetById(int id);
    public Task<List<State>> GetAll();
}
