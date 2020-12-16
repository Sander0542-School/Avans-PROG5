using System.ComponentModel.DataAnnotations;

namespace NinjaManager.Data.Models
{
    public class NinjaGear
    {
        public int NinjaId { get; set; }

        public int GearId { get; set; }

        public Gear Gear { get; set; }
        public Ninja Ninja { get; set; }
    }
}