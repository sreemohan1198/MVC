using DemoMVC.Data;
using DemoMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoMVC.Controllers
{
    public class EmployeeController : Controller
    {
        //GET:EMPLOYEE DATA
        public IActionResult EmpDetails()
        {
            DataAccess dataAccess = new DataAccess();
            List<Employee>lstemp=dataAccess.GetEmployeeData();
            return View(lstemp);
        }
    }
}
