using System.ComponentModel.DataAnnotations;

namespace StoreAPI.Models
{
    public class ShoesForUpdateDto
    {
        [Required(ErrorMessage = "You should provide a shoes name")]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(10)]
        public string? ReleasedDate { get; set; }

        public int Price { get; set; }
        public string? Brand { get; set; }
        public float Size { get; set; }
    }
}
