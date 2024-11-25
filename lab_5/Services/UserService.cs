using MyWebApp.Models;
using System.Collections.Generic;

namespace MyWebApp.Library.Services
{
    public class UserService
    {
        private readonly List<User> _users = new List<User>();

        public void CreateUser (User user)
        {
            _users.Add(user);
        }

        public string HashPassword(string password)
        {
            // Логіка для хешування пароля
            return password; // Заміна на реальне хешування
        }

        public User ValidateUser (string username, string password)
        {
            // Логіка для перевірки користувача
            return _users.Find(u => u.Username == username && u.PasswordHash == password);
        }

        public User GetCurrentUser ()
        {
            // Логіка для отримання поточного користувача
            return null; // Заміна на реальну логіку
        }
    }
}