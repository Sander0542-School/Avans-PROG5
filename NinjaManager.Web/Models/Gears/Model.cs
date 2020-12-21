using NinjaManager.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NinjaManager.Web.Models.Gears
{
    public class Model
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Gold { get; set; }

        public int Strength { get; set; }

        public int Intelligence { get; set; }

        public int Agility { get; set; }

        public Gear.GearCategory Category { get; set; }
    }
}
