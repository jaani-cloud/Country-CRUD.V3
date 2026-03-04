using Domain.Entities;

namespace Infra.Repos.Interfaces;

public interface ICountryRepo
{
    public Task Add(Country country);
    public Task Update(Country country);
    public Task Delete(Country country);
    public Task<Country?> GetByName(string name);
    public Task<Country?> GetById(int id);
    public Task<List<Country>> GetAll();
}
