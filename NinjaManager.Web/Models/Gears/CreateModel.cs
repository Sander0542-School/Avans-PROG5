using NinjaManager.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace NinjaManager.Web.Models.Gears
{
    public class CreateModel
    {
        public string Name { get; set; }
        public int Gold { get; set; }
        public int Strength { get; set; }
        public int Intelligence { get; set; }
        public int Agility { get; set; }

        public Gear.GearCategory Category { get; set; }
    }
}