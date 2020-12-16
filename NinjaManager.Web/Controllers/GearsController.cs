using Microsoft.AspNetCore.Mvc;

namespace NinjaManager.Web.Controllers
{
    public class GearsController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}