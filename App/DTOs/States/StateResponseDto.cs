using App.DTOs.Countries;
using Infra.Repos.Classes;

namespace App.DTOs.States;

public class StateResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public CountryResponseDto? Country { get; set; }
}
