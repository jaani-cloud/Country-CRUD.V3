using App.DTOs.Countries;
using App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/country")]
[ApiController]
public class CountryController : ControllerBase
{
    private readonly ICountryService _countryService;

    public CountryController(ICountryService countryService)
    {
        _countryService = countryService;
    }

    [HttpPost("add")]
    public async Task Add(CountryCreateUpdateDto input) => await _countryService.Add(input);


    [HttpPut("update/{id}")]
    public async Task Update(CountryCreateUpdateDto input, int id) => await _countryService.Update(input, id);

    [HttpDelete("delete/{id}")]
    public async Task Delete(int id) => await _countryService.Delete(id);

    [HttpGet("get-by-name/{name}")]
    public async Task<CountryResponseDto?> GetByName(string name) => await _countryService.GetByName(name.ToLower());

    [HttpGet("get-by-id/{id}")]
    public async Task<CountryResponseDto?> GetById(int id) => await _countryService.GetById(id);

    [HttpGet("get-all")]
    public async Task<List<CountryResponseDto>> GetAll() => await _countryService.GetAll();
}
