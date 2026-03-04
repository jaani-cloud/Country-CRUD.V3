using App.DTOs.States;
using Domain.Entities;

namespace App.Services.Interfaces;

public interface IStateService
{
    public Task Add(StateCreateUpdateDto input);
    public Task Update(StateCreateUpdateDto input, int id);
    public Task Delete(int id);
    public Task<StateResponseDto?> GetByName(string name);
    public Task<StateResponseDto?> GetById(int id);
    public Task<List<StateResponseDto>> GetAll();
}
