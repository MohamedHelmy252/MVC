using Microsoft.AspNetCore.Mvc;

namespace Project01Session02MVC.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
           
        }
        public IActionResult Register()
        {
            return View();
        }
    }
}
