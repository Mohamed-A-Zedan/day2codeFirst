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
        public IActionResult addform()
        {
            ViewBag.department = DB.Departments.ToList();
            return View();
        }
        public IActionResult add(project p)
        {
            DB.Projects.Add(p);
            DB.SaveChanges();
            return RedirectToAction(nameof(allProjects));
        }
        
    }
}
