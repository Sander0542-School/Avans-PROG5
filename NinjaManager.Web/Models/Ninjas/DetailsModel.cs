using System.Collections.Generic;
using System.Linq;

namespace NinjaManager.Web.Models.Ninjas
{
    public class DetailsModel
    {
        public string Name { get; set; }

        public int Gold { get; set; }

        public IDictionary<Data.Models.Gear.GearCategory, Gear> Gears { get; set; }

        public KeyValuePair<Data.Models.Gear.GearCategory, Gear> GetGear(Data.Models.Gear.GearCategory category)
        {
            return Gears.ContainsKey(category) ? Gears.First(valuePair => valuePair.Key == category) : new KeyValuePair<Data.Models.Gear.GearCategory, Gear>(category, null);
        }

        public class Gear
        {
            public string Name { get; set; }
            
            public int Gold { get; set; }
            
            public int Strength { get; set; }

            public int Intelligence { get; set; }

            public int Agility { get; set; }
        }
    }
}