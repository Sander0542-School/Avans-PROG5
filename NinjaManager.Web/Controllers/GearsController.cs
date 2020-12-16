using Microsoft.AspNetCore.Mvc;
using NinjaManager.Data.Repositories;

namespace NinjaManager.Web.Controllers
{
    public class GearsController : Controller
    {
        private readonly GearsRepository _gearsRepository;

        public GearsController(GearsRepository gearsRepository)
        {
            _gearsRepository = gearsRepository;
        }

        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}