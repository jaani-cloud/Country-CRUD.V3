using App.DTOs.Cities;
using App.DTOs.States;
using App.Services.Interfaces;
using Domain.Entities;
using Infra.Repos.Interfaces;

namespace App.Services.Classes;

public class CityService : ICityService
{
    private readonly ICityRepo _cityRepo;
    private readonly IStateRepo _stateRepo;
    public CityService(ICityRepo cityRepo, IStateRepo stateRepo)
    {
        _cityRepo = cityRepo;
        _stateRepo = stateRepo;
    }

    public async Task Add(CityCreateUpdateDto input)
    {
        var state = await _stateRepo.GetById(input.StateId);
        if (state == null) return;

        City city = new City
        {
            Name = input.Name.ToLower(),
            StateId = input.StateId,
        };
        await _cityRepo.Add(city);
    }

    public async Task Update(CityCreateUpdateDto input, int id)
    {
        var city = await _cityRepo.GetBYId(id);
        var state = await _stateRepo.GetById(input.StateId);

        if (city == null || state == null) return;

        city.Name = input.Name;
        city.StateId = input.StateId;
        await _cityRepo.Update(city);
    }

    public async Task Delete(int id)
    {
        var city = await _cityRepo.GetBYId(id);
        if(city == null) return;

        await _cityRepo.Delete(city);
    }

    public async Task<CityResponseDto?> GetByName(string name)
    {
        var city = await _cityRepo.GetByName(name.ToLower());

        if (city == null) return null;

        return new CityResponseDto
        {
            Id = city.Id,
            Name = city.Name,
            State = city.State == null ? null : new StateResponseDto
            {
                Id = city.State.Id,
                Name = city.State.Name
            }
        };
    }

    public async Task<CityResponseDto?> GetById(int id)
    {
        var city = await _cityRepo.GetBYId(id);
        if (city == null) return null;

        return new CityResponseDto
        {
            Id = city.Id,
            Name = city.Name,
            State = city.State == null ? null : new StateResponseDto
            {
                Id = city.State.Id,
                Name = city.State.Name
            }
        };
    }

    public async Task<List<CityResponseDto>> GetAll()
    {
        var cities = await _cityRepo.GetAll();

        return cities.Select(c => new CityResponseDto
        {
            Id = c.Id,
            Name = c.Name,
            State = c.State == null ? null : new StateResponseDto
            {
                Id = c.State.Id,
                Name = c.State.Name
            }
        }).ToList();
    }
}
