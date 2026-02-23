using System.ComponentModel.DataAnnotations;

namespace PowkeApp.Data;

public class TeamDto
{
    [Required(ErrorMessage = "Team Name is an obligation")]
    [MaxLength(50, ErrorMessage = "Max 50 char")]
    public required string Name { get; set; }

    public string? Description { get; set; }
}