using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Proxies.Internal;
using task2fromcode.Models;

namespace task2fromcode.Controllers
{
    public class workOnProjectController : Controller
    {
        private companyDBcontext DB = new companyDBcontext();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddEmployees(int id)
        {
            List<project> projects = DB.Projects.Where(p => p.DepartmentDnum == id).ToList();
            List<employee> employees = DB.employees.Where(p => p.SSN == id).ToList();

            ViewBag.emps = employees;

            return View(projects);
        }

        workOn worksOnProject1;
        public IActionResult afterAdd(List<int> Projects, List<int> Employees)
        {

            foreach (var Project in Projects)
            {
                foreach (var employee in Employees)
                {
                    workOn worksOnProject = new workOn()
                    {
                        ESSN = employee,
                        Pnum = Project
                    };
                    worksOnProject1 = DB.WorkOns.Include(w => w.Project).SingleOrDefault(w => w.ESSN == worksOnProject.ESSN);
                    DB.WorkOns.Add(worksOnProject);
                    DB.SaveChanges();
                }

            }

            ViewBag.emps = Employees;
            ViewBag.mgrSSN = (int)HttpContext.Session.GetInt32("SSN");

            return View(worksOnProject1);
        }
    }
}
