using System.ComponentModel.DataAnnotations;

namespace App.DTOs.States;

public class StateCreateUpdateDto
{
    [Required]
    [StringLength(20, MinimumLength = 3)]
    public string Name { get; set; } = string.Empty;    
    public int CountryId { get; set; }
}
