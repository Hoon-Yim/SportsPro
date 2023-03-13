using Microsoft.AspNetCore.Mvc;
using COMP2139_KRN_GENIUS.Models;

namespace COMP2139_KRN_GENIUS.Controllers
{
    public class TechnicianController : Controller
    {
        private MainContext context { get; set; }
        public TechnicianController(MainContext ctx)
        {
            context = ctx;
        }

        [Route("Technicians")]
        public ViewResult List()
        {
            var tech = context.Technicians.OrderBy(m => m.TechnicianId).ToList();
            return View(tech);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new Technician());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var technician = context.Technicians.Find(id);
            return View(technician);
        }
        [HttpPost]
        public IActionResult Edit(Technician technician)
        {
            if (ModelState.IsValid)
            {
                string message = "";
                if (technician.TechnicianId == 0)
                {
                    context.Technicians.Add(technician);
                    message = $"{technician.Name} was added successfully.";
                }
                else
                {
                    context.Technicians.Update(technician);
                    message = $"{technician.Name} was updated successfully.";
                }
                context.SaveChanges();
                TempData["message"] = message.ToString();
                return RedirectToAction("List", "Technician");
            }
            else
            {
                ViewBag.Action = (technician.TechnicianId == 0) ? "Add" : "Edit";
                return View(technician);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var technician = context.Technicians.Find(id);
            return View(technician);
        }
        [HttpPost]
        public IActionResult Delete(Technician technician)
        {
            context.Technicians.Remove(technician);
            context.SaveChanges();
            TempData["message"] = $"{technician.Name} was deleted successfully.";
            return RedirectToAction("List", "Technician");
        }
    }
}
