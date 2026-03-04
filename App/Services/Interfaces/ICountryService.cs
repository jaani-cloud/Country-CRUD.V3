using App.DTOs.Countries;

namespace App.Services.Interfaces;

public interface ICountryService
{
    public Task Add(CountryCreateUpdateDto input);
    public Task Update(CountryCreateUpdateDto input, int id);
    public Task Delete(int id);
    public Task<CountryResponseDto?> GetByName(string name);
    public Task<CountryResponseDto?> GetById(int id);
    public Task<List<CountryResponseDto>> GetAll();
}
