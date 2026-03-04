using App.DTOs.Countries;
using App.DTOs.States;
using App.Services.Interfaces;
using Domain.Entities;
using Infra.Repos.Interfaces;

namespace App.Services.Classes;

public class StateService : IStateService
{
    private readonly IStateRepo _stateRepo;
    private readonly ICountryRepo _countryRepo;
    public StateService(IStateRepo stateRepo, ICountryRepo countryRepo)
    {
        _stateRepo = stateRepo;
        _countryRepo = countryRepo;
    }

    public async Task Add(StateCreateUpdateDto input)
    {
        var country = await _countryRepo.GetById(input.CountryId);
        if (country == null) return;

        State state = new State
        {
            Name = input.Name.ToLower(),
            CountryId = input.CountryId,
        };
        await _stateRepo.Add(state);
    }

    public async Task Update(StateCreateUpdateDto input, int id)
    {
        var state = await _stateRepo.GetById(id);
        var country = await _countryRepo.GetById(input.CountryId);
        if (state == null || country == null) return;

        state.Name = input.Name;
        state.CountryId = input.CountryId;

        await _stateRepo.Update(state);
    }

    public async Task Delete(int id)
    {
        var state = await _stateRepo.GetById(id);
        if (state == null) return;

        await _stateRepo.Delete(state);
    }

    public async Task<StateResponseDto?> GetByName(string name)
    {
        var state = await _stateRepo.GetByName(name.ToLower());
        if (state == null || state.Country == null) return null;

        return new StateResponseDto
        {
            Id = state.Id,
            Name = name,
            Country = new CountryResponseDto { Id = state.Country.Id, Name = state.Country.Name }
        };
    }

    public async Task<StateResponseDto?> GetById(int id)
    {
        var state = await _stateRepo.GetById(id);
        if (state == null || state.Country == null) return null;

        return new StateResponseDto
        {
            Id = state.Id,
            Name = state.Name,
            Country = new CountryResponseDto { Id = state.Country.Id, Name = state.Country.Name }
        };
    }

    public async Task<List<StateResponseDto>> GetAll()
    {
        var states = await _stateRepo.GetAll();

        return states.Select(s => new StateResponseDto
        {
            Id = s.Id,
            Name = s.Name,
            Country = s.Country == null ? null : new CountryResponseDto
            {
                Id = s.Country.Id,
                Name = s.Country.Name,
            }
        }).ToList();
    }
}
