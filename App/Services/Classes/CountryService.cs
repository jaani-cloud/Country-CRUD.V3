using App.DTOs.Countries;
using App.Services.Interfaces;
using Domain.Entities;
using Infra.Repos.Interfaces;

namespace App.Services.Classes;

public class CountryService : ICountryService
{
    private readonly ICountryRepo _countryRepo;

    public CountryService(ICountryRepo countryRepo)
    {
        _countryRepo = countryRepo;
    }

    public async Task Add(CountryCreateUpdateDto input)
    {
        Country country = new Country
        {
            Name = input.Name.ToLower(),
        };
        await _countryRepo.Add(country);
    }

    public async Task Update(CountryCreateUpdateDto input, int id)
    {
        var country = await _countryRepo.GetById(id);

        if (country == null) return;

        country.Name = input.Name.ToLower();

        await _countryRepo.Update(country);
    }

    public async Task Delete(int id)
    {
        var country = await _countryRepo.GetById(id);
        if (country == null) return;

        await _countryRepo.Delete(country);
    }

    public async Task<CountryResponseDto?> GetByName(string name)
    {
        var country = await _countryRepo.GetByName(name);

        if (country == null) return null;

        return new CountryResponseDto
        {
            Id = country.Id,
            Name = country.Name,
        };
    }

    public async Task<CountryResponseDto?> GetById(int id)
    {
        var country = await _countryRepo.GetById(id);

        if (country == null) return null;

        return new CountryResponseDto
        {
            Id = country.Id,
            Name = country.Name,
        };
    }

    public async Task<List<CountryResponseDto>> GetAll()
    {
        var countries = await _countryRepo.GetAll();

        return countries.Select(c => new CountryResponseDto
        {
            Id = c.Id,
            Name = c.Name,
        }).ToList();
    }
}
