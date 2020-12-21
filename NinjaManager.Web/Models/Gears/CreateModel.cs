using NinjaManager.Data.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace NinjaManager.Web.Models.Gears
{
    public class CreateModel 
    {
        [Required]
        public string Name { get; set; }

        [Range(minimum: 0, maximum: Int32.MaxValue)]
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