using Microsoft.AspNetCore.Mvc;
using MyWebApp.Models;
using MyWebApp.Library.Services;

namespace MyWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserService _userService;

        public AccountController(UserService userService)
        {
            _userService = userService;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    Username = model.Username,
                    FullName = model.FullName,
                    Phone = model.Phone,
                    Email = model.Email,
                    PasswordHash = _userService.HashPassword(model.Password)
                };
                _userService.CreateUser (user);
                return RedirectToAction("Login");
            }
            return View(model);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _userService.ValidateUser (model.Username, model.Password);
                if (user != null)
                {
                    // Логіка для авторизації
                    return RedirectToAction("Profile");
                }
                ModelState.AddModelError("", "Неправильний логін або пароль.");
            }
            return View(model);
        }

        public IActionResult Profile()
        {
            // Отримання даних користувача
            var user = _userService.GetCurrentUser ();
            return View(user);
        }
    }
}