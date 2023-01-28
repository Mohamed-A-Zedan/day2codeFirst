using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using task2fromcode.Models;

namespace task2fromcode.Controllers
{
    public class EmployeeController : Controller
    {
        companyDBcontext DB=new companyDBcontext(); 
        public IActionResult Index()
        {
       var a=  DB.employees.ToList();
            return View(a);
        }

        public IActionResult user_details()
        {
            var id = HttpContext.Session.GetInt32("SSN");
            var a = DB.employees.Where(x => x.SSN == id).SingleOrDefault();
            ViewBag.emp = DB.employees.ToList();
           
            return View(a);
        }
        public IActionResult getinfo(int id)
        {
            var a = DB.employees.Where(x => x.SSN == id).SingleOrDefault();
            ViewBag.emp = DB.employees.ToList();

            return View(a);
        }

        public IActionResult addform()
        {
           
            var a = DB.employees.ToList();
            return View(a);
        }

        public IActionResult addnew(employee emp)
        {
            var a = DB.employees.ToList();
            DB.employees.Add(emp);
            DB.SaveChanges();


            return RedirectToAction(nameof(Index));
        }

        public IActionResult delete(int id)
        {

            var a = DB.employees.Where(x=>x.SSN== id).SingleOrDefault();

            DB.employees.Remove(a);
                 DB.SaveChanges();
            return RedirectToAction(nameof(Index));

        }

        public IActionResult editform(int id)
        {

            var a = DB.employees.Where(x => x.SSN == id).SingleOrDefault();
             ViewBag.emp = DB.employees.ToList();
           
            return View(a);

        }

        public IActionResult afteredit(employee emp)
        {

            var a = DB.employees.Where(x=>x.SSN== emp.SSN).SingleOrDefault();
            a.Fname=emp.Fname;
            a.Lname=emp.Lname;
            a.salary=emp.salary;
            a.superid=emp.superid;
            a.sex=emp.sex;
            a.address=emp.address;
            DB.SaveChanges();
            return RedirectToAction(nameof(Index));



        }
        public IActionResult login()
        {
            //var a = DB.employees.Where(x=>x.SSN==id && x.Fname==name).SingleOrDefault();
            return View();
        }
        public IActionResult logging(employee empLogin)
        {

            employee emppp = DB.employees.Where(x => x.SSN == empLogin.SSN && x.Fname == empLogin.Fname).SingleOrDefault();
            if (emppp == null)
            {
                return View("error"); 
            }
            else
            {
                HttpContext.Session.SetInt32("SSN",empLogin.SSN);
                return RedirectToAction(nameof(user_details));
            }
        }
        public IActionResult manager()
        {

            var a = DB.Departments.Include(e => e.Employee).Where(e => e.MangerId != null).Select(e => e.Employee.Fname).ToList();

            return View(a);

        }



    }
}









