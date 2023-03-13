using Microsoft.AspNetCore.Mvc;
using COMP2139_KRN_GENIUS.Models;
using COMP2139_KRN_GENIUS.Models.ViewModels;

namespace COMP2139_KRN_GENIUS.Controllers
{
    public class RegistrationController : Controller
    {
        private MainContext context { get; set; }
        public RegistrationController(MainContext ctx)
        {
            context = ctx;
        }

        [HttpGet]
        [Route("registration/getcustomer")]
        public ViewResult Get()
        {
            var reg = new RegistrationViewModel
            {
                CustomerId = 0,
                Customers = context.Customers.OrderBy(m => m.CustomerId).ToList()
            };

            return View(reg);
        }
        [HttpPost]
        [Route("registration/getcustomer")]
        public IActionResult Get(RegistrationViewModel regVM) 
        {
            if (regVM.CustomerId == 0)
            {
                TempData["message"] = "Please select a Customer.";
                regVM.Customers = context.Customers.OrderBy(m => m.CustomerId).ToList();
                return View(regVM);
            }
            
            return RedirectToAction("List", new { id = regVM.CustomerId });
        }

        public ViewResult List(int id)
        {
            HttpContext.Session.SetInt32("customerId", id);
            Customer? c = context.Customers.Where(c => c.CustomerId == id).FirstOrDefault();

            var reg = new RegistrationViewModel
            {
                Registration = new Registration { CustomerId = id, ProductId = 0 },
                CustomerName = c.FirstName + " " + c.LastName,
                Registrations = context.Registrations.Where(r => r.CustomerId == id).OrderBy(r => r.ProductId).ToList(),
                Products = context.Products.OrderBy(m => m.ProductId).ToList()
            };

            return View(reg);
        }

        [HttpPost]
        public RedirectToActionResult Register(RegistrationViewModel regVM)
        {
            if (regVM.Registration.ProductId == 0)
            {
                TempData["message"] = $"Please select a product.";
            }
            else
            {
                List<Registration> reg = context.Registrations.Where(
                    r =>
                    r.CustomerId == HttpContext.Session.GetInt32("customerId") &&
                    r.ProductId == regVM.Registration.ProductId).ToList();

                if (reg.Count == 0)
                {
                    Product product = context.Products.Where(p => p.ProductId == regVM.Registration.ProductId).FirstOrDefault();
                    TempData["productMessage"] = $"{product.Name} was added successfully.";
                    context.Registrations.Add(regVM.Registration);
                    context.SaveChanges();
                }
                else
                {
                    TempData["message"] = $"Cannot register the same pair of customer and product.";
                }
            }
            return RedirectToAction("List", new { id = HttpContext.Session.GetInt32("customerId") });
        }

        [HttpGet]
        public ViewResult Delete(int id)
        {
            var reg = new RegistrationViewModel
            {
                Registration = new Registration { ProductId = id, CustomerId = (int)HttpContext.Session.GetInt32("customerId") },
                Customers = context.Customers.Where(r => r.CustomerId == HttpContext.Session.GetInt32("customerId")).ToList(),
                Products = context.Products.Where(r => r.ProductId == id).ToList()
            };

            return View(reg);
        }
        [HttpPost]
        public RedirectToActionResult Delete(RegistrationViewModel regVM)
        {
            context.Registrations.Remove(regVM.Registration);
            context.SaveChanges();
            TempData["productMessage"] = $"{regVM.ProductName} was deleted successfully.";
            return RedirectToAction("List", new { id = HttpContext.Session.GetInt32("customerId") });
        }
    }
}
