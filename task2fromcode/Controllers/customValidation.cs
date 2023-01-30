using Microsoft.AspNetCore.Mvc;

namespace task2fromcode.Controllers
{
    public class customValidation : Controller
    {
            public IActionResult locationName(string location)
            {
                if (location.Contains("cairo") || location.Contains("giza") || location.Contains("alex"))
                {
                    return Json(true);
                }
                else
                {
                    return Json(false);
                }
            }

       

    }
}








