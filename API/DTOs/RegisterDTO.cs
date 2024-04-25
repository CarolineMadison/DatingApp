using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace API.DTOs;

public class RegisterDTO
{
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
}