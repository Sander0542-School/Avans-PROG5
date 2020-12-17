using System.ComponentModel.DataAnnotations;

namespace NinjaManager.Web.Models.Gears
{
    public class EditModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Gold { get; set; }

        [Required]
        public int Strength { get; set; }

        [Required]
        public int Intelligence { get; set; }

        [Required]
        public int Agility { get; set; }

        [Required]
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