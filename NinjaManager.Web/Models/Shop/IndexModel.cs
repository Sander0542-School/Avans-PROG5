using System.Collections.Generic;

namespace NinjaManager.Web.Models.Shop
{
    public class IndexModel
    {
        public Data.Models.Gear.GearCategory? Category { get; set; }

        public NinjaModel Ninja { get; set; }

        public IDictionary<Data.Models.Gear.GearCategory, IEnumerable<Gear>> Gears { get; set; }

        public class Gear
        {
            public int Id { get; set; }
            
            public string Name { get; set; }

            public int Gold { get; set; }
            
            public int Strength { get; set; }
            
            public int Agility { get; set; }
            
            public int Intelligence { get; set; }
            
            public GearState State { get; set; }

            public enum GearState
            {
                Bought,
                OwnsCategory,
                Expensive,
                Available
            }
        }
    }
}