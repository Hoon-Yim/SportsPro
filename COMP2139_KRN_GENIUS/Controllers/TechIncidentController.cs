using Microsoft.AspNetCore.Mvc;
using COMP2139_KRN_GENIUS.Models;
using COMP2139_KRN_GENIUS.Models.ViewModels;

namespace COMP2139_KRN_GENIUS.Controllers
{
    public class TechIncidentController : Controller
    {
        private MainContext context { get; set; }
        public TechIncidentController(MainContext ctx)
        {
            context = ctx;
        }

        [HttpGet]
        public ViewResult Get()
        {
            var techVM = new TechIncidentViewModel
            {
                id = 0,
                Technicians = context.Technicians.OrderBy(m => m.TechnicianId).ToList()
            };
            return View(techVM);
        }
        [HttpPost]
        public IActionResult Get(TechIncidentViewModel techVM)
        {
            if (techVM.id == 0)
            {
                TempData["message"] = "Please select a Technician.";
                techVM.Technicians = context.Technicians.OrderBy(m => m.TechnicianId).ToList();
                return View(techVM);
            }
            return RedirectToAction("List", new { id = techVM.id });
        }

        [HttpGet]
        public ViewResult List(int id)
        {
            var incidents = from incident in context.Incidents
                            join customer in context.Customers on incident.CustomerId equals customer.CustomerId
                            join product in context.Products on incident.ProductId equals product.ProductId
                            where incident.TechnicianId == id && incident.DateClosed == null
                            select new IncidentViewModel
                            {
                                Incident = incident,
                                CustomerName = customer.FirstName + " " + customer.LastName,
                                ProductName = product.Name,
                                DateOpened = incident.DateOpened
                            };

            HttpContext.Session.SetInt32("techId", id);
            var tech = from technician in context.Technicians where technician.TechnicianId == id select new { Name = technician.Name };
            ViewBag.Technician = tech.ToList()[0].Name;
            return View(incidents);
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            HttpContext.Session.SetInt32("techIncidentId", id);
            Incident incident = context.Incidents.Find(id);

            var incidentVM = new IncidentViewModel
            {
                Incident = incident,
                Technician = context.Technicians.Find(incident.TechnicianId),
                Customer = context.Customers.Find(incident.CustomerId),
                Product = context.Products.Find(incident.ProductId),
            };

            return View("Edit", incidentVM);
        }
        [HttpPost]
        public IActionResult Edit(IncidentViewModel incidentVM)
        {
            if (ModelState.IsValid)
            {
                TempData["message"] = $"\"{incidentVM.Incident.Title}\" incident was updated successfully.";
                context.Incidents.Update(incidentVM.Incident);
                context.SaveChanges();
                return RedirectToAction("List", new { id = HttpContext.Session.GetInt32("techId") });
            }
            else
            {
                Incident incident = context.Incidents.Find(HttpContext.Session.GetInt32("techIncidentId"));

                var inciVM = new IncidentViewModel
                {
                    Incident = incident,
                    Technician = context.Technicians.Find(incident.TechnicianId),
                    Customer = context.Customers.Find(incident.CustomerId),
                    Product = context.Products.Find(incident.ProductId),
                };
                return View(inciVM);
            }
        }
    }
}
