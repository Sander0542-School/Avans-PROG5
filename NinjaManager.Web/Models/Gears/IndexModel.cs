using System.Collections.Generic;

namespace NinjaManager.Web.Models.Gears
{
    public class IndexModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Gold { get; set; }
        public int Strength { get; set; }
        public int Intelligence { get; set; }
        public int Agility { get; set; }
        public GearCategory Category { get; set; }

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