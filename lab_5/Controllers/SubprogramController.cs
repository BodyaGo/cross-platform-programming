using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyWebApp.Controllers
{
    [Authorize]
    public class SubprogramController : Controller
    {
        public IActionResult Subprogram1()
        {
            return View();
        }

        public IActionResult Subprogram2()
        {
            return View();
        }

        public IActionResult Subprogram3()
        {
            return View();
        }
    }
}