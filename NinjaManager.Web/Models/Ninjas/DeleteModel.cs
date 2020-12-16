using System.Collections.Generic;

namespace NinjaManager.Web.Models.Ninjas
{
    public class DeleteModel
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public int Gold { get; set; }

        public IEnumerable<string> Gears { get; set; }
    }
}