using Microsoft.AspNetCore.Mvc;

namespace Project01Session02MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()//تم الانشاء ال view الخاص بال index
        {
            return View();
        }
        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult ContactUs()
        {
            return View();
        }
    }
}
