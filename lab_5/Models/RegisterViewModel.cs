using System.ComponentModel.DataAnnotations;

namespace MyWebApp.Models
{
    public class RegisterViewModel
    {
        [Required, MaxLength(50)]
        public string Username { get; set; }

        [Required, MaxLength(500)]
        public string FullName { get; set; }

        [Required, StringLength(16, MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).*$", ErrorMessage = "Пароль повинен містити принаймні 1 цифру, 1 спеціальний символ, 1 велику літеру.")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Паролі не співпадають.")]
        public string ConfirmPassword { get; set; }

        [RegularExpression(@"^\+380[0-9]{9}$", ErrorMessage = "Невірний формат телефону.")]
        public string Phone { get; set; }

        [EmailAddress(ErrorMessage = "Невірний формат електронної адреси.")]
        public string Email { get; set; }
    }
}