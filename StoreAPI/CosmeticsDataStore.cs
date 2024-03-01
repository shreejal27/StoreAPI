using System.Collections.Generic;
using StoreAPI.Models;

namespace StoreAPI
{
    public class CosmeticsDataStore
    {
        public static List<CosmeticsDto> Current { get; set; } = new List<CosmeticsDto>();

        static CosmeticsDataStore()
        {
            Current = new List<CosmeticsDto>()
            {
                new CosmeticsDto()
                {
                    Id = 1,
                    Name = "Foundation",
                    Description = "natural looking",
                },
                new CosmeticsDto()
                {
                    Id = 2,
                    Name = "Eye liner",
                    Description = "eyes",
                },
                 new CosmeticsDto()
                {
                    Id = 3,
                    Name = "Blush",
                    Description = "colors",
                }
            };
        }
    }
}