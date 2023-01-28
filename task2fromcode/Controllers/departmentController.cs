using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using task2fromcode.Models;
namespace task2fromcode.Controllers
{
    public class departmentController : Controller
    {
        companyDBcontext DB = new companyDBcontext();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetDeptByMgrId(int id)
        {
            var a = DB.Departments.Include(d => d.DLocations).Include(d => d.Projects).SingleOrDefault(d => d.MangerId == id);
            //List<DepartmentLocation> departmentLocations = (List<DepartmentLocation>)DB.Departments.Include(d => d.DepartmentLocations).Where(d => d.mngrSSN == 1).Select(d => d.DepartmentLocations);
            if (a == null)
                return View("Error");
            else
                return View(a);

        }
    }
}
