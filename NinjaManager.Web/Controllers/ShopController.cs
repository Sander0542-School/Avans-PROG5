using Microsoft.AspNetCore.Mvc;

namespace NinjaManager.Web.Controllers
{
    public class ShopController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}