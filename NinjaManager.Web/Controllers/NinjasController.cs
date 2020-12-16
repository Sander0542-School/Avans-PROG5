using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NinjaManager.Data.Models;
using NinjaManager.Data.Repositories;
using NinjaManager.Web.Models.Ninjas;

namespace NinjaManager.Web.Controllers
{
    public class NinjasController : Controller
    {
        private readonly NinjaRepository _ninjaRepository;

        public NinjasController(NinjaRepository ninjaRepository)
        {
            _ninjaRepository = ninjaRepository;
        }

        public async Task<IActionResult> Index()
        {
            var ninjas = await _ninjaRepository.GetAll();

            var model = new IndexModel
            {
                Ninjas = ninjas.Select(ninja => new IndexModel.Ninja
                {
                    Id = ninja.Id,
                    Name = ninja.Name,
                    Gold = ninja.Gold,
                    Gears = ninja.NinjaGears.Select(gear => gear.Gear.Name),
                })
            };

            return View(model);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var ninja = await _ninjaRepository.Get(id.Value);

            if (ninja == null)
            {
                return NotFound();
            }

            var model = new DetailsModel
            {
                Name = ninja.Name,
                Gold = ninja.Gold,
                Gears = ninja.NinjaGears.ToDictionary(ninjaGear => ninjaGear.Gear.Category, ninjaGear =>
                {
                    var gear = ninjaGear.Gear;

                    return new DetailsModel.Gear
                    {
                        Name = gear.Name,
                        Gold = gear.Gold,
                        Agility = gear.Agility,
                        Intelligence = gear.Intelligence,
                        Strength = gear.Strength,
                    };
                })
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
                var ninja = new Ninja
                {
                    Name = createModel.Name,
                    Gold = 400
                };

                if (await _ninjaRepository.Create(ninja))
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError("", "The ninja could not be created.");
            }

            return View(createModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ninja = await _ninjaRepository.Get(id.Value);

            if (ninja == null)
            {
                return NotFound();
            }

            var model = new EditModel
            {
                Id = ninja.Id,
                Name = ninja.Name,
            };

            return View(model);
        }

        [HttpPost, ActionName("Edit")]
        public async Task<IActionResult> EditPost(EditModel editModel)
        {
            if (ModelState.IsValid)
            {
                var ninja = await _ninjaRepository.Get(editModel.Id);

                if (ninja == null)
                {
                    ModelState.AddModelError("", "The ninja does not exists");
                    return View(editModel);
                }

                ninja.Name = editModel.Name;

                if (await _ninjaRepository.Update(ninja))
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError("", "The ninja could not be edited.");
            }

            return View(editModel);
        }

        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ninja = await _ninjaRepository.Get(id.Value);

            if (ninja == null)
            {
                return NotFound();
            }

            var model = new DeleteModel
            {
                Id = ninja.Id,
                Name = ninja.Name,
                Gold = ninja.Gold,
                Gears = ninja.NinjaGears.Select(ninjaGear => ninjaGear.Gear.Name)
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
            var ninja = await _ninjaRepository.Get(id);

            if (ninja == null)
            {
                return RedirectToAction(nameof(Index));
            }

            ninja.NinjaGears.Clear();
            if (await _ninjaRepository.Delete(ninja))
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Delete), new {id, saveChangesError = true});
        }

        public async Task<IActionResult> Clear(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ninja = await _ninjaRepository.Get(id.Value);

            if (ninja == null)
            {
                return NotFound();
            }

            var model = new ClearModel
            {
                Id = ninja.Id,
                Name = ninja.Name,
                Gold = ninja.Gold,
                Gears = ninja.NinjaGears.Select(ninjaGear => new ClearModel.Gear
                {
                    Name = ninjaGear.Gear.Name,
                    Gold = ninjaGear.Gear.Gold
                })
            };

            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] = "Could not clear inventory. Try again, and if the problem persists see your system administrator.";
            }

            return View(model);
        }

        [HttpPost, ActionName("Clear")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ClearConfirmed(int id)
        {
            var ninja = await _ninjaRepository.Get(id);

            if (ninja == null)
            {
                return RedirectToAction(nameof(Index));
            }

            var addedGold = ninja.NinjaGears.Sum(ninjaGear => ninjaGear.Gear.Gold);

            ninja.Gold += addedGold;
            ninja.NinjaGears.Clear();

            if (await _ninjaRepository.Update(ninja))
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Clear), new {id, saveChangesError = true});
        }
    }
}