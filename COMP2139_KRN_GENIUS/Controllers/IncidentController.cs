using Microsoft.AspNetCore.Mvc;
using COMP2139_KRN_GENIUS.Models;
using COMP2139_KRN_GENIUS.Models.ViewModels;

namespace COMP2139_KRN_GENIUS.Controllers
{
    public class IncidentController : Controller
    {
        private MainContext context { get; set; }
        public IncidentController(MainContext ctx)
        {
            context = ctx;
        }

        [HttpGet]
        [Route("Incidents")]
        public ViewResult List(string activeFilter = "all")
        {
            IQueryable<IncidentViewModel> incidents;
            ViewBag.Active = activeFilter;
            if (activeFilter == "unassigned")
            {
                incidents = from incident in context.Incidents
                            join customer in context.Customers on incident.CustomerId equals customer.CustomerId
                            join product in context.Products on incident.ProductId equals product.ProductId
                            where incident.TechnicianId == null
                            select new IncidentViewModel
                            {
                                Incident = incident,
                                CustomerName = customer.FirstName + " " + customer.LastName,
                                ProductName = product.Name,
                                DateOpened = incident.DateOpened
                            };
            }
            else if (activeFilter == "open")
            {
                incidents = from incident in context.Incidents
                            join customer in context.Customers on incident.CustomerId equals customer.CustomerId
                            join product in context.Products on incident.ProductId equals product.ProductId
                            where incident.DateClosed == null
                            select new IncidentViewModel
                            {
                                Incident = incident,
                                CustomerName = customer.FirstName + " " + customer.LastName,
                                ProductName = product.Name,
                                DateOpened = incident.DateOpened
                            };
            }
            else
            {
                incidents = from incident in context.Incidents
                            join customer in context.Customers on incident.CustomerId equals customer.CustomerId
                            join product in context.Products on incident.ProductId equals product.ProductId
                            select new IncidentViewModel
                            {
                                Incident = incident,
                                CustomerName = customer.FirstName + " " + customer.LastName,
                                ProductName = product.Name,
                                DateOpened = incident.DateOpened
                            };
            }

            return View(incidents);
        }

        [HttpGet]
        public ViewResult Add()
        {
            var incident = new IncidentViewModel
            {
                Incident = new Incident { DateOpened = DateTime.Now },
                Action = "Add",
                Customers = context.Customers.OrderBy(m => m.CustomerId).ToList(),
                Products = context.Products.OrderBy(m => m.ProductId).ToList(),
                Technicians = context.Technicians.OrderBy(m => m.TechnicianId).ToList()
            };
            return View("Edit", incident);
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            HttpContext.Session.SetInt32("incidentId", id);
            var incident = new IncidentViewModel
            {
                Incident = context.Incidents.Find(id),
                Action = "Edit",
                Customers = context.Customers.OrderBy(m => m.CustomerId).ToList(),
                Products = context.Products.OrderBy(m => m.ProductId).ToList(),
                Technicians = context.Technicians.OrderBy(m => m.TechnicianId).ToList()
            };
            return View("Edit", incident);
        }
        [HttpPost]
        public IActionResult Edit(IncidentViewModel incidentVM)
        {
            if (ModelState.IsValid)
            {
                string message = "";
                if (incidentVM.Incident.IncidentId == 0)
                {
                    context.Incidents.Add(incidentVM.Incident);
                    message = $"\"{incidentVM.Incident.Title}\" incident was successfully added.";
                }
                else
                {
                    context.Incidents.Update(incidentVM.Incident);
                    message = $"\"{incidentVM.Incident.Title}\" incident was successfully updated.";
                }
                context.SaveChanges();
                TempData["message"] = message.ToString();
                return RedirectToAction("List", "Incident");
            }
            else
            {
                var incident = new IncidentViewModel
                {
                    Action = (incidentVM.Incident.IncidentId == 0) ? "Add" : "Edit",
                    Incident = incidentVM.Incident,
                    Customers = context.Customers.OrderBy(m => m.CustomerId).ToList(),
                    Products = context.Products.OrderBy(m => m.ProductId).ToList(),
                    Technicians = context.Technicians.OrderBy(m => m.TechnicianId).ToList()
                };
                return View(incident);
            }
        }

        [HttpGet]
        public ViewResult Delete(int id)
        {
            var incident = new IncidentViewModel
            {
                Incident = context.Incidents.Find(id),
                Action = "Edit",
                Customers = context.Customers.OrderBy(m => m.CustomerId).ToList(),
                Products = context.Products.OrderBy(m => m.ProductId).ToList(),
                Technicians = context.Technicians.OrderBy(m => m.TechnicianId).ToList()
            };
            return View(incident);
        }
        [HttpPost]
        public RedirectToActionResult Delete(IncidentViewModel incidentVM)
        {
            context.Incidents.Remove(incidentVM.Incident);
            context.SaveChanges();
            TempData["message"] = $"\"{incidentVM.Incident.Title}\" incident was deleted successfully.";
            return RedirectToAction("List", "Incident");
        }
    }
}
