using System.ComponentModel.DataAnnotations;

namespace StoreAPI.Models
{
    public class ShoesChildForCreationDto
    {
        [Required(ErrorMessage = "You should provide a size value")]
        public float Size { get; set; }

        // [MaxLength(200)]
        [Required(ErrorMessage = "You should provide a price")]
        public int Price { get; set; }
    }
}
