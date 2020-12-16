namespace NinjaManager.Web.Models.Shop
{
    public class BuySellModel
    {
        public NinjaModel Ninja { get; set; }
        
        public GearModel Gear { get; set; }
        
        public class GearModel
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public int Gold { get; set; }
        }
    }
}