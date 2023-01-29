using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using task2fromcode.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        public IActionResult allDepartments()
        {
            var a = DB.Departments.ToList();
            return View(a);

        }
        public IActionResult details(int id)
        {
            var a = DB.Departments.Where(x => x.Dnum == id).SingleOrDefault();


            return View(a);
        }
        public IActionResult addform() 
        {
            return View();
        }
        public IActionResult add(department d)
        {
            DB.Departments.Add(d);
            DB.SaveChanges();

            return RedirectToAction(nameof(allDepartments));
        }
        public IActionResult editform(int id)
        {
            var a = DB.Departments.Where(x => x.Dnum == id).SingleOrDefault();


            return View(a);
        }
        public IActionResult edit(department d) 
        {
            var a = DB.Departments.Where(x => x.Dnum == d.Dnum).SingleOrDefault();

            a.DName = d.DName;
            DB.SaveChanges();

            return RedirectToAction(nameof(allDepartments));
        }
        public IActionResult delete(int id)
        {
            var a = DB.Departments.SingleOrDefault(d => d.Dnum == id);
            DB.Departments.Remove(a);
            DB.SaveChanges();
            return RedirectToAction(nameof(allDepartments));

        }
    }

    }
