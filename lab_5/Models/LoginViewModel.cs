using System.ComponentModel.DataAnnotations;

namespace MyWebApp.Models
{
    public class LoginViewModel {
    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }
}
}