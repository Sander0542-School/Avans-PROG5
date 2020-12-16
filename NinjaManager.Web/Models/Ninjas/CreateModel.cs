using System.ComponentModel.DataAnnotations;

namespace NinjaManager.Web.Models.Ninjas
{
    public class CreateModel
    {
        [Required]
        public string Name { get; set; }
    }
}