using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using task2fromcode.Models;

namespace task2fromcode.Controllers
{
    public class dependentController : Controller
    {
        companyDBcontext DB = new companyDBcontext();
        public IActionResult Index()
        {

            var a = DB.Dependents.ToList();
            return View(a);
        }
        Int32 SSNFromSession;
        public IActionResult GetAllDependent()
        {
            SSNFromSession = (int)HttpContext.Session.GetInt32("SSN");
            var a = DB.Dependents.Where(g => g.EmployeeSSN == SSNFromSession).ToList();
            return View(a);
        }
        public IActionResult addform()
        {
            return View();
        }
        public IActionResult addNew(dependent dependentt)
        {
            SSNFromSession = (int)HttpContext.Session.GetInt32("SSN");
            dependentt.EmployeeSSN = SSNFromSession;
            DB.Dependents.Add(dependentt);
            DB.SaveChanges();
            TempData["AddMsg"] = "You Add New Dependent";
            return RedirectToAction("GetAllDependent");
        }
        public IActionResult updateForm()
        {
            SSNFromSession = (int)HttpContext.Session.GetInt32("SSN");
            var a = DB.Dependents.Where(k => k.EmployeeSSN == SSNFromSession).SingleOrDefault();
            return View(a);
        }
        public IActionResult Deleting(string id)
        {
            SSNFromSession = (int)HttpContext.Session.GetInt32("SSN");
            var a = DB.Dependents.Where(k => k.EmployeeSSN == SSNFromSession && k.name==id).SingleOrDefault();
            DB.Remove(a);
            DB.SaveChanges();
            return RedirectToAction(nameof(GetAllDependent));
        }
        public IActionResult AfterUpdate(dependent editDependent)
        {
            SSNFromSession = (int)HttpContext.Session.GetInt32("SSN");
            var a = DB.Dependents.Where(k => k.EmployeeSSN == SSNFromSession).SingleOrDefault();
            a.sex = editDependent.sex;
            a.relationship = editDependent.relationship;
            a.Bdate = editDependent.Bdate;
            DB.SaveChanges();
            return RedirectToAction(nameof(GetAllDependent));
        }
    }
}

























