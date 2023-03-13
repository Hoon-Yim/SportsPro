using Microsoft.AspNetCore.Mvc;
using COMP2139_KRN_GENIUS.Models;

namespace COMP2139_KRN_GENIUS.Controllers
{
    public class CustomerController : Controller
    {
        private MainContext context { get; set; }
        public CustomerController(MainContext ctx)
        {
            context = ctx;
        }

        [HttpGet]
        [Route("Customers")]
        public IActionResult List()
        {
            var customers = context.Customers.OrderBy(m => m.CustomerId).ToList();
            return View(customers);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Countries = context.Countries.OrderBy(m => m.Name).ToList();
            ViewBag.Action = "Add";
            ViewBag.emailDuplicated = false;
            return View("Edit", new Customer());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Countries = context.Countries.OrderBy(m => m.Name).ToList();
            ViewBag.emailDuplicated = false;
            var customer = context.Customers.Find(id);
            return View(customer);
        }
        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            Customer? cust = null;
            if (customer.Email != null)
            {
                cust = context.Customers.Where(
                        c => 
                        c.Email == customer.Email &&
                        c.CustomerId != customer.CustomerId).FirstOrDefault();
            }

            if (ModelState.IsValid && cust == null)
            {
                string message = "";
                if (customer.CustomerId == 0)
                {
                    context.Customers.Add(customer);
                    message = $"{customer.FirstName} {customer.LastName} was successfully added";
                }
                else
                {
                    context.Customers.Update(customer);
                    message = $"{customer.FirstName} {customer.LastName} was successfully updated";
                }
                context.SaveChanges();
                TempData["message"] = message.ToString();

                return RedirectToAction("List", "Customer");
            }

            ViewBag.Countries = context.Countries.OrderBy(m => m.Name).ToList();
            ViewBag.Action = (customer.CustomerId == 0) ? "Add" : "Edit";
            ViewBag.emailDuplicated = (cust != null) ? true : false;
            return View(customer);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var customer = context.Customers.Find(id);
            ViewBag.Country = context.Countries.Find(customer.CountryId);
            return View(customer);
        }
        [HttpPost]
        public IActionResult Delete(Customer customer)
        {
            context.Customers.Remove(customer);
            context.SaveChanges();
            TempData["message"] = $"{customer.FirstName} {customer.LastName} was deleted successfully.";
            return RedirectToAction("List", "Customer");
        }
    }
}