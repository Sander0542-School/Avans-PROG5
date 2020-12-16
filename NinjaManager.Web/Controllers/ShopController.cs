using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NinjaManager.Data.Models;
using NinjaManager.Data.Repositories;
using NinjaManager.Web.Models.Shop;

namespace NinjaManager.Web.Controllers
{
    [Route("/Ninjas/Shop/{ninjaId:int}/{action=Index}/{id?}")]
    public class ShopController : Controller
    {
        private readonly NinjaRepository _ninjaRepository;
        private readonly GearsRepository _gearsRepository;

        public ShopController(NinjaRepository ninjaRepository, GearsRepository gearsRepository)
        {
            _ninjaRepository = ninjaRepository;
            _gearsRepository = gearsRepository;
        }

        // GET
        public async Task<IActionResult> Index(int ninjaId, Gear.GearCategory? category)
        {
            var ninja = await _ninjaRepository.Get(ninjaId);

            if (ninja == null)
            {
                return NotFound();
            }

            var gears = await _gearsRepository.GetAll();

            var model = new IndexModel
            {
                Category = category,
                Ninja = new IndexModel.NinjaModel
                {
                    Id = ninja.Id,
                    Name = ninja.Name,
                    Gold = ninja.Gold
                },
                Gears = gears.GroupBy(gear => gear.Category).ToDictionary(grouping => grouping.Key, grouping => grouping.Select(gear => new IndexModel.Gear
                {
                    Id = gear.Id,
                    Name = gear.Name,
                    Gold = gear.Gold,
                    Agility = gear.Agility,
                    Intelligence = gear.Intelligence,
                    Strength = gear.Strength,
                    State = GetGearState(ninja, gear, grouping)
                }))
            };

            return View(model);
        }

        public async Task<IActionResult> Buy(int ninjaId, int? id, bool? saveChangesError = false)
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            var ninja = await _ninjaRepository.Get(ninjaId);

            var gear = await _gearsRepository.Get(id.Value);

            if (ninja == null || gear == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] = "Purchase failed. Try again, and if the problem persists see your system administrator.";
            }
            else if (ninja.NinjaGears.Select(ninjaGear => ninjaGear.Gear.Category).Contains(gear.Category))
            {
                ViewData["ErrorMessage"] = $"You already own a {gear.Category}.";
            }
            else if (ninja.Gold < gear.Gold)
            {
                ViewData["ErrorMessage"] = "You dont have enough money to buy this.";
            }

            var model = new BuySellModel
            {
                Ninja = new BuySellModel.NinjaModel
                {
                    Id = ninja.Id,
                    Name = ninja.Name,
                    Gold = ninja.Gold
                },
                Gear = new BuySellModel.GearModel
                {
                    Id = gear.Id,
                    Name = gear.Name,
                    Gold = gear.Gold
                }
            };

            return View(model);
        }

        [HttpPost, ActionName("Buy")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BuyConfirmed(int ninjaId, int id)
        {
            var ninja = await _ninjaRepository.Get(ninjaId);

            var gear = await _gearsRepository.Get(id);

            if (ninja == null || gear == null)
            {
                return RedirectToAction(nameof(Index), new {ninjaId});
            }

            if (ninja.NinjaGears.Select(ninjaGear => ninjaGear.Gear.Category).Contains(gear.Category) || ninja.Gold < gear.Gold)
            {
                return RedirectToAction(nameof(Buy), new {ninjaId, id, saveChangesError = true});
            }

            ninja.Gold -= gear.Gold;
            ninja.NinjaGears.Add(new NinjaGear
            {
                GearId = gear.Id
            });

            if (await _ninjaRepository.Update(ninja))
            {
                return RedirectToAction(nameof(Index), new {ninjaId});
            }

            return RedirectToAction(nameof(Buy), new {ninjaId, id, saveChangesError = true});
        }

        public async Task<IActionResult> Sell(int ninjaId, int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ninja = await _ninjaRepository.Get(ninjaId);

            if (ninja == null)
            {
                return NotFound();
            }

            var ninjaGear = ninja.NinjaGears.FirstOrDefault(ninjaGear1 => ninjaGear1.GearId == id);

            if (ninjaGear == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] = "Sell failed. Try again, and if the problem persists see your system administrator.";
            }

            return View(new BuySellModel
            {
                Ninja = new BuySellModel.NinjaModel
                {
                    Id = ninja.Id,
                    Name = ninja.Name,
                    Gold = ninja.Gold
                },
                Gear = new BuySellModel.GearModel
                {
                    Id = ninjaGear.Gear.Id,
                    Name = ninjaGear.Gear.Name,
                    Gold = ninjaGear.Gear.Gold
                }
            });
        }

        [HttpPost, ActionName("Sell")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SellConfirmed(int ninjaId, int id)
        {
            var ninja = await _ninjaRepository.Get(ninjaId);

            if (ninja == null)
            {
                return RedirectToAction(nameof(Index), new {ninjaId});
            }

            var ninjaGear = ninja.NinjaGears.FirstOrDefault(ninjaGear1 => ninjaGear1.GearId == id);

            if (ninjaGear == null)
            {
                return RedirectToAction(nameof(Sell), new {ninjaId, id, saveChangesError = true});
            }

            ninja.Gold += ninjaGear.Gear.Gold;
            ninja.NinjaGears.Remove(ninjaGear);

            if (await _ninjaRepository.Update(ninja))
            {
                return RedirectToAction(nameof(Index), new {ninjaId});
            }

            return RedirectToAction(nameof(Sell), new {ninjaId, id, saveChangesError = true});
        }

        private IndexModel.Gear.GearState GetGearState(Ninja ninja, Gear gear, IEnumerable<Gear> otherGears)
        {
            if (ninja.NinjaGears.Exists(ninjaGear => ninjaGear.GearId == gear.Id))
            {
                return IndexModel.Gear.GearState.Bought;
            }

            if (ninja.NinjaGears.Select(ninjaGear => ninjaGear.GearId).Intersect(otherGears.Select(gear1 => gear1.Id)).Any())
            {
                return IndexModel.Gear.GearState.OwnsCategory;
            }

            if (ninja.Gold < gear.Gold)
            {
                return IndexModel.Gear.GearState.Expensive;
            }

            return IndexModel.Gear.GearState.Available;
        }
    }
}