using System.ComponentModel.DataAnnotations;

namespace NinjaManager.Web.Models.Ninjas
{
    public class EditModel
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
    }
}