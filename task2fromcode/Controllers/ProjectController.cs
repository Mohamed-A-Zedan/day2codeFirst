using AspNetCore;
using Microsoft.AspNetCore.Mvc;
using task2fromcode.Models;

namespace task2fromcode.Controllers
{
    
    public class ProjectController : Controller
    {
        companyDBcontext DB = new companyDBcontext();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult allProjects(int id)
        {
            var a = DB.Projects.ToList();
            return View(a);
        }
        [HttpGet]
        public IActionResult addform()
        {
            ViewBag.department = DB.Departments.ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult add(VMproject p)
        {
            if (ModelState.IsValid)
            {
                project proj = new project()
                {
                    Name = p.Name,
                    Pnumber = p.Pnumber,
                    location = p.location
                };
                DB.Projects.Add(proj);
                DB.SaveChanges();
                return RedirectToAction(nameof(allProjects));
            }
            else
            {
                return View();
            }
        }
        
    }
}
