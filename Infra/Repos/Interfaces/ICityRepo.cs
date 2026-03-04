using Domain.Entities;

namespace Infra.Repos.Interfaces;

public interface ICityRepo
{
    public Task Add(City city);
    public Task Update(City city);
    public Task Delete(City city);
    public Task<City?> GetByName(string name);
    public Task<City?> GetById(int id);
    public Task<List<City>> GetAll();
}
