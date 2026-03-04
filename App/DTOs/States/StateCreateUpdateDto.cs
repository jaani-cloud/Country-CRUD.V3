using System.ComponentModel.DataAnnotations;

namespace App.DTOs.States;

public class StateCreateUpdateDto
{
    [Required]
    [StringLength(2, MinimumLength = 2)]
    public string Name { get; set; } = string.Empty;    
    public int CountryId { get; set; }
}
