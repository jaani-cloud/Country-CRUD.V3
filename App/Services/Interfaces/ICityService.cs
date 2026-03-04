using App.DTOs.Cities;

namespace App.Services.Interfaces;

public interface ICityService
{
    public Task Add(CityCreateUpdateDto input);
    public Task Update(CityCreateUpdateDto input, int id);
    public Task Delete(int id);
    public Task<CityResponseDto?> GetByName(string name);
    public Task<CityResponseDto?> GetById(int id);
    public Task<List<CityResponseDto>> GetAll();
}
