using Microsoft.AspNetCore.Mvc;

namespace WebApplication1_MVC.Controllers
{
    public class TeacherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
