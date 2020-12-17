using Microsoft.AspNetCore.Mvc;
using NinjaManager.Data.Repositories;
using System.Threading.Tasks;
using NinjaManager.Web.Models.Gears;
using System.Linq;
using NinjaManager.Data.Models;

namespace NinjaManager.Web.Controllers
{
    public class GearsController : Controller
    {
        private readonly GearsRepository _gearsRepository;

        public GearsController(GearsRepository gearsRepository)
        {
            _gearsRepository = gearsRepository;
        }

        public async Task<IActionResult> Index()
        {
            var gears = await _gearsRepository.GetAll();

            var model = gears.Select(gear => new IndexModel
            {
                Id = gear.Id,
                Name = gear.Name,
                Gold = gear.Gold,
                Strength = gear.Strength,
                Intelligence = gear.Intelligence,
                Agility = gear.Agility,
                Category = (IndexModel.GearCategory)gear.Category
            });

            return View(model);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var gear = await _gearsRepository.Get(id.Value);

            if (gear == null)
            {
                return NotFound();
            }

            var model = new DetailsModel
            {
                Id = gear.Id,
                Name = gear.Name,
                Gold = gear.Gold,
                Strength = gear.Strength,
                Intelligence = gear.Intelligence,
                Agility = gear.Agility,
                Category = (DetailsModel.GearCategory)gear.Category
            };

            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, ActionName("Create")]
        public async Task<IActionResult> CreatePost(CreateModel createModel)
        {
            if (ModelState.IsValid)
            {
                var gear = new Gear
                {
                    Name = createModel.Name,
                    Gold = createModel.Gold,
                    Strength = createModel.Strength,
                    Intelligence = createModel.Intelligence,
                    Agility = createModel.Agility,
                    Category = (Gear.GearCategory)createModel.Category
                };

                if (await _gearsRepository.Create(gear))
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError("", "The gear could not be created.");
            }

            return View(createModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gear = await _gearsRepository.Get(id.Value);

            if (gear == null)
            {
                return NotFound();
            }

            var model = new EditModel
            {
                Id = gear.Id,
                Name = gear.Name,
                Gold = gear.Gold,
                Strength = gear.Strength,
                Intelligence = gear.Intelligence,
                Agility = gear.Agility,
                Category = (EditModel.GearCategory)gear.Category
            };

            return View(model);
        }

        [HttpPost, ActionName("Edit")]
        public async Task<IActionResult> EditPost(EditModel editModel)
        {
            if (ModelState.IsValid)
            {
                var gear = await _gearsRepository.Get(editModel.Id);

                if (gear == null)
                {
                    ModelState.AddModelError("", "The gear does not exists");
                    return View(editModel);
                }

                gear.Name = editModel.Name;
                gear.Gold = editModel.Gold;
                gear.Strength = editModel.Strength;
                gear.Intelligence = editModel.Intelligence;
                gear.Agility = editModel.Agility;
                gear.Category = (Gear.GearCategory)editModel.Category;

                if (await _gearsRepository.Update(gear))
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError("", "The gear could not be edited.");
            }

            return View(editModel);
        }

        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gear = await _gearsRepository.Get(id.Value);

            if (gear == null)
            {
                return NotFound();
            }

            var model = new DeleteModel
            {
                Id = gear.Id,
                Name = gear.Name,
                Gold = gear.Gold,
                Strength = gear.Strength,
                Intelligence = gear.Intelligence,
                Agility = gear.Agility,
                Category = (DeleteModel.GearCategory)gear.Category
            };

            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }

            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gear = await _gearsRepository.Get(id);

            if (gear == null)
            {
                return RedirectToAction(nameof(Index));
            }

            // TODO: Payback all the ninjas using this gear
            gear.NinjaGears.Clear();

            if (await _gearsRepository.Delete(gear))
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Delete), new { id, saveChangesError = true });
        }
    }
}