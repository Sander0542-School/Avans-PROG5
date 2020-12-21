using System.ComponentModel.DataAnnotations;

namespace NinjaManager.Web.Models.Ninjas
{
    public class EditModel : CreateModel
    {
        [Required]
        public int Id { get; set; }
    }
}