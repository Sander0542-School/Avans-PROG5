using System.Collections.Generic;

namespace NinjaManager.Web.Models.Ninjas
{
    public class IndexModel
    {
        public IEnumerable<Ninja> Ninjas { get; set; }

        public class Ninja
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public int Gold { get; set; }

            public IEnumerable<string> Gears { get; set; }
        }
    }
}