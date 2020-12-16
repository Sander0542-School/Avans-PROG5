using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NinjaManager.Data.Models
{
    public class Ninja
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Gold { get; set; }

        public List<NinjaGear> NinjaGears { get; set; }
    }
}