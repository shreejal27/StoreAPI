namespace StoreAPI.Models
{
    public class ShoesDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string ReleasedDate { get; set; } = string.Empty;

        public int Price { get; set; }

        public string Brand { get; set; } = string.Empty;

        public float Size { get; set; }
    }
}
