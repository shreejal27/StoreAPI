using StoreAPI.Models;

namespace StoreAPI
{
    public class ShoesDataStore
    {
          public static List<ShoesDto> Current { get; set; } = new List<ShoesDto>();

        static ShoesDataStore()
        {
            Current = new List<ShoesDto>()
            {
                new ShoesDto()
                {
                    Id = 1,
                    Name = "Jordan 4 Retro Midnight Navy",
                    ReleasedDate = "2022-10-29",
                    Brand = "Jordan",
                     ShoesChild = new List<ShoesChildDto>()
                    {
                        new ShoesChildDto()
                        {
                            Id=1,
                            Size = 9,
                            Price = 200,
                        },

                        new ShoesChildDto()
                        {
                            Id=2,
                            Size = 10,
                           Price = 210,
                        },
                    }
                   
                },
                new ShoesDto()
                {
                    Id = 2,
                    Name = "Jordan 11 Royalty Taxi",
                    ReleasedDate = "2023-01-25",
                    Brand = "Jordan",
                      ShoesChild = new List<ShoesChildDto>()
                    {
                        new ShoesChildDto()
                        {
                            Id=1,
                            Size = 7,
                            Price = 100,
                        },

                        new ShoesChildDto()
                        {
                            Id=2,
                            Size = 8,
                           Price = 150,
                        },
                    }

                },
            };
        }
    }
}
