using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NinjaManager.Data.Models
{
    public class Gear
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }

        public int Gold { get; set; }

        public int Strength { get; set; }

        public int Intelligence { get; set; }

        public int Agility { get; set; }

        public GearCategory Category { get; set; }

        public List<NinjaGear> NinjaGears { get; set; }

        public enum GearCategory
        {
            Head,
            Chest,
            Hand,
            Feet,
            Ring,
            Necklace
        }
    }
}