using Microsoft.AspNetCore.Mvc;
using DemoMVC.Models;

namespace DemoMVC.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Details(int ID)
        {
            Logic s = new Logic();
            Student s1 = s.GetDetails(ID);
            //--view data ki manam type cast cheyali
            ViewData["Student"] = s1;
            //---viewbag dynamic ga chesthadhi kabatti typecasting avasram ledu direct declare chestham
            ViewBag.Student = s1;
            return View(s1);
        }
       
        public IActionResult Edit()
        {
            return View();
        }
        public IActionResult Delete()
        {
            return View();
        }
    }
}
