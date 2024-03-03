using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using StoreAPI.Models;
using System.Drawing;

namespace StoreAPI.Controllers
{
    [ApiController]
    public class ShoesController : ControllerBase
    {
        [HttpGet]
        [Route("api/shoes/get")]
        public ActionResult<ShoesDto> GetAllShoes()
        {
            var shoesToReturn = ShoesDataStore.Current;

            if (shoesToReturn == null)
            {
                return NotFound();
            }

            return Ok(shoesToReturn);
        }

        [HttpGet]
        [Route("api/shoes/getById")]
        public ActionResult<ShoesDto> GetShoesIndex(int shoesId)
        {
            var shoesToReturn = ShoesDataStore.Current.FirstOrDefault(s => s.Id == shoesId);

            if (shoesToReturn == null)
            {
                return NotFound();
            }

            return Ok(shoesToReturn);
        }

        [HttpGet]
        [Route("api/shoes/getByName")]
        public ActionResult<ShoesDto> GetShoesName(string name)
        {
            var shoesToReturn = ShoesDataStore.Current.FirstOrDefault(s => s.Name == name);

            if (shoesToReturn == null)
            {
                return NotFound();
            }

            return Ok(shoesToReturn);
        }

        [HttpPost]
        [Route("api/shoes/post")]
        public ActionResult<ShoesDto> CreateShoes(ShoesForCreationDto shoesDto)
        {

            if (shoesDto == null)
            {
                return BadRequest();
            }

            var shoesId = ShoesDataStore.Current.Max(s => s.Id);

            var shoesToAdd = new ShoesDto()
            {
                Id = ++shoesId,
                Name = shoesDto.Name,
                ReleasedDate = shoesDto.ReleasedDate,
                Brand = shoesDto.Brand,
                //Price = shoesDto.Price,
                //Size = shoesDto.Size,
            };

            ShoesDataStore.Current.Add(shoesToAdd);

            return Ok(shoesToAdd);

        }

        [HttpPut]
        [Route("api/shoes/put")]
        public ActionResult<ShoesDto> UpdateShoes(int shoesId, ShoesForUpdateDto shoesDto)
        {
            var shoes = ShoesDataStore.Current.FirstOrDefault(s => s.Id == shoesId);
            if (shoes == null)
            {
                return NotFound();
            }

            shoes.Name = shoesDto.Name;
            shoes.ReleasedDate = shoesDto.ReleasedDate;
            shoes.Brand = shoesDto.Brand;
            //shoes.Price = shoesDto.Price;
            //shoes.Size = shoesDto.Size;

            return NoContent();
        }

        [HttpPatch]
        [Route("api/shoes/patch")]
        public ActionResult<ShoesDto> PartiallyUpdateShoes(int shoesId, JsonPatchDocument<ShoesForUpdateDto> patchDocument)
        {
            var shoes = ShoesDataStore.Current.FirstOrDefault(c => c.Id == shoesId);
            if (shoes == null)
            {
                return NotFound();
            }

            var shoesToPatch = new ShoesForUpdateDto()
            {

                Name = shoes.Name,
                ReleasedDate = shoes.ReleasedDate,
                Brand = shoes.Brand,
              //  Price = shoes.Price,
                //Size = shoes.Size,
            };

            patchDocument.ApplyTo(shoesToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            shoes.Name = shoesToPatch.Name;
            shoes.ReleasedDate = shoesToPatch.ReleasedDate;
            shoes.Brand = shoesToPatch.Brand;
            //shoes.Price = shoesToPatch.Price;
            //shoes.Size = shoesToPatch.Size;

            return NoContent();
        }

        [HttpDelete]
        [Route("api/shoes/delete")]
        public ActionResult DeleteCosmetics(int shoesId)
        {
            var shoes = ShoesDataStore.Current.FirstOrDefault(c => c.Id == shoesId);
            if (shoes == null)
            {
                return NotFound();
            }

            ShoesDataStore.Current.Remove(shoes);

            return NoContent();
        }
    }
}
