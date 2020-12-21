using NinjaManager.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace NinjaManager.Web.Models.Gears
{
    public class EditModel : CreateModel
    {
        [Required]
        public int Id { get; set; }
    }
}