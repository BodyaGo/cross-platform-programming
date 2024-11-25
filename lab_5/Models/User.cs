using System.ComponentModel.DataAnnotations;

namespace MyWebApp.Models
{
    public class User
    {
        public int Id { get; set; }
        
        [Required, MaxLength(50)]
        public string Username { get; set; } // Унікальне, до 50 символів
        
        [Required, MaxLength(500)]
        public string FullName { get; set; } // До 500 символів
        
        [Required]
        public string PasswordHash { get; set; } // Хешований пароль
        
        [Required, RegularExpression(@"^\+380[0-9]{9}$", ErrorMessage = "Невірний формат телефону.")]
        public string Phone { get; set; } // Формат Україна
        
        [Required, EmailAddress(ErrorMessage = "Невірний формат електронної адреси.")]
        public string Email { get; set; } // RFC 822
    }
}