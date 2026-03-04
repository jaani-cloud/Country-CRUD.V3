using App.DTOs.Cities;
using App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/city")]
[ApiController]
public class CityController : ControllerBase
{
    private readonly ICityService _cityService;

    public CityController(ICityService cityService)
    {
        _cityService = cityService;
    }

    [HttpPost("add")]
    public async Task Add(CityCreateUpdateDto input) => await _cityService.Add(input);

    [HttpPut("update/{id}")]
    public async Task Update(CityCreateUpdateDto input, int id) => await _cityService.Update(input, id);

    [HttpDelete("delete/{id}")]
    public async Task Delete(int id) => await _cityService.Delete(id);

    [HttpGet("get-by-name/{name}")]
    public async Task<CityResponseDto?> GetByName(string name) => await _cityService.GetByName(name);

    [HttpGet("get-by-id/{id}")]
    public async Task<CityResponseDto?> GetById(int id) => await _cityService.GetById(id);

    [HttpGet("get-all")]
    public async Task<List<CityResponseDto>> GetAll() => await _cityService.GetAll();
}
