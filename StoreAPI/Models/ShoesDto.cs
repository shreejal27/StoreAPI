namespace StoreAPI.Models
{
    public class ShoesDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string ReleasedDate { get; set; } = string.Empty;

        public string Brand { get; set; } = string.Empty;

        public int NumberOfPointsOfInterest
        {
            get
            {
                return ShoesChild.Count;
            }
        }

        //to include collection of points of interest
        public ICollection<ShoesChildDto> ShoesChild { get; set; } = new List<ShoesChildDto>();
        //always assign empty list to avoid null issues
    }
}
