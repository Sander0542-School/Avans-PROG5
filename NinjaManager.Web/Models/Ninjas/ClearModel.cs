using System.Collections.Generic;

namespace NinjaManager.Web.Models.Ninjas
{
    public class ClearModel
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public int Gold { get; set; }

        public IEnumerable<Gear> Gears { get; set; }
        
        public class Gear
        {
            public string Name { get; set; }

            public int Gold { get; set; }
        }
    }
}