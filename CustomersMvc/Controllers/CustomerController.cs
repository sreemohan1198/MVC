using CustomersMvc.Data;
using CustomersMvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;

namespace CustomersMvc.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            DataAccess dataAccess = new DataAccess();
            List<CustomerModel> listCutsomerModel = dataAccess.GetData_SqlDataReader();
            return View(listCutsomerModel);
            //return View();
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            DataAccess dataAccess = new DataAccess();
            var customermodel = dataAccess.GetCustomerById(Convert.ToInt32(id));
            if (customermodel == null)
            {
                return NotFound();
            }
            return View(customermodel);

        }

        public IActionResult Create()
        {
            return View();            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("CustomerID,CustomerName,ContactName,Address,City,PostalCode,Country")] CustomerModel customermodel)
        {
            if (ModelState.IsValid)
            {
                DataAccess dataAccess = new DataAccess();
                dataAccess.Insert(customermodel);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            DataAccess dataAccess = new DataAccess();
            var customermodel= dataAccess.GetCustomerById(Convert.ToInt32(id));
            if (customermodel == null)
            {
                return NotFound();
            }
            return View(customermodel);
            //return null;
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,[Bind("CustomerID,CustomerName,ContactName,Address,City,PostalCode,Country")] CustomerModel customermodel)
        {
            if (id != customermodel.CustomerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
              
                    DataAccess dataAccess = new DataAccess();
                    dataAccess.Update(customermodel);
                    return RedirectToAction(nameof(Index));
                
            }
            return RedirectToAction(nameof(Index));

        }
    }
}
