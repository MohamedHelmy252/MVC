using Microsoft.AspNetCore.Mvc;

namespace Project01Session02MVC.Controllers
{
    public class MoviesController : Controller
    {
        public IActionResult GetMovies(int id)
        {
          //  return Content($"Hello from GetMovies with id: {id} ");

            if (id == 100)
            {
                return Content("You have 5 Star");
            }
            return Content($"Hello from GetMovies with id: {id} ");
        }
        public IActionResult Index(int id)
        {
            // return Content("Hello InAction Index Defualt Action ");
            //UnauthorizedResult unauthorizedResult = new UnauthorizedResult();
            if (id > 100)
            {
                //return new  UnauthorizedResult(); //اختصار
              //  return new NotFoundResult();
                return NotFound(); //Helper Method
            }
            return Content($"Hello In Idex Page {id}");
        }
    }
}
