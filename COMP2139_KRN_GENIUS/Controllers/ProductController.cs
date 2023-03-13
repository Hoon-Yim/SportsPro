using Microsoft.AspNetCore.Mvc;
using COMP2139_KRN_GENIUS.Models;

namespace COMP2139_KRN_GENIUS.Controllers
{
    public class ProductController : Controller
    {
        private MainContext context { get; set; }
        public ProductController(MainContext ctx)
        {
            context = ctx;
        }

        [HttpGet]
        [Route("Products")]
        public IActionResult List()
        {
            var products = context.Products.OrderBy(m => m.ProductId).ToList();
            return View(products);
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new Product());
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var product = context.Products.Find(id);
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                string message = "";
                if (product.ProductId == 0)
                {
                    context.Products.Add(product);
                    message = $"{product.Name} was added successfully.";
                }
                else
                {
                    context.Products.Update(product);
                    message = $"{product.Name} was updated successfully.";
                }
                context.SaveChanges();
                TempData["message"] = message.ToString();
                return RedirectToAction("List", "Product");
            }
            else
            {
                ViewBag.Action = (product.ProductId == 0) ? "Add" : "Edit";
                return View(product);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = context.Products.Find(id);
            return View(product);
        }
        [HttpPost]
        public IActionResult Delete(Product product)
        {
            context.Products.Remove(product);
            context.SaveChanges();
            TempData["message"] = $"{product.Name} was deleted successfully.";
            return RedirectToAction("List", "Product");
        }
    }
}