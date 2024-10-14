using System;
using System.ComponentModel.DataAnnotations;

namespace mandrilAPI.Models;

public class InsertMandril
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string Apellido { get; internal set; } = string.Empty;
}
