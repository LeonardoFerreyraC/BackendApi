using System.ComponentModel.DataAnnotations;

namespace BackendApi.Security.Services.Communication;

public class RegisterRequest
{
    [Required]
    public string FullName { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Birthday { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string ConfirmPassword { get; set; }
}