using NinjaManager.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace NinjaManager.Web.Models.Gears
{
    public class EditModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Gold { get; set; }

        [Required]
        public int Strength { get; set; }

        [Required]
        public int Intelligence { get; set; }

        [Required]
        public int Agility { get; set; }

        [Required]
        public Gear.GearCategory Category { get; set; }
    }
}