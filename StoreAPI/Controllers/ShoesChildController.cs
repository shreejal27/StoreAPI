using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using StoreAPI.Models;

namespace StoreAPI.Controllers
{
    [ApiController]
    public class ShoesChildController : ControllerBase
    {
        [HttpGet]
        [Route("api/shoes/getChild")]
        public ActionResult<IEnumerable<ShoesChildDto>> GetShoesChild(int shoesId)
        {
            var shoes = ShoesDataStore.Current.FirstOrDefault(s => s.Id == shoesId);

            if (shoes == null)
            {
                return NotFound();
            }


            return Ok(shoes.ShoesChild);
        }

        [HttpGet]
        [Route("api/shoes/getChildById", Name = "GetPointOfInterest")]
        [Produces("application/json")]
        public ActionResult<ShoesChildDto> GetShoesChildById(int shoesId, int shoesChildId)
        {
            var shoes = ShoesDataStore.Current.FirstOrDefault(s => s.Id == shoesId);
            if (shoes == null)
            {
                return NotFound();
            }
            //    //find point of interest

            var shoesChild = shoes.ShoesChild.FirstOrDefault(t => t.Id == shoesChildId);
            if (shoesChild == null)
            {
                return NotFound();
            }

            return Ok(shoesChild);
        }

        [HttpPost]
        [Route("api/shoes/postChild")]

        public ActionResult<ShoesChildDto> CreateShoesChild(int shoesId,
           ShoesChildForCreationDto shoesChild)
        {

            var shoes = ShoesDataStore.Current.FirstOrDefault(s => s.Id == shoesId);

            if (shoes == null)
            {
                return NotFound();
            }

            var maxShoesChildId = ShoesDataStore.Current.SelectMany(s => s.ShoesChild).Max(c => c.Id);

            var shoesChildToAdd = new ShoesChildDto()
            {
                Id = ++maxShoesChildId,
                Size = shoesChild.Size,
                Price = shoesChild.Price
            };
            shoes.ShoesChild.Add(shoesChildToAdd);

            return Ok(shoesChildToAdd);



        }

        [HttpPut]
        [Route("api/shoes/putChild")]
        public ActionResult UpdateShoesChild(int shoesId, int shoesChildId, ShoesChildForUpdateDto shoesChild)
        {
            var shoes = ShoesDataStore.Current.FirstOrDefault(s => s.Id == shoesId);
            if (shoes == null)
            {
                return NotFound();
            }
            //    //find point of interest

            var shoesChildFromDataStore = shoes.ShoesChild.FirstOrDefault(t => t.Id == shoesChildId);
            if (shoesChildFromDataStore == null)
            {
                return NotFound();
            }

            shoesChildFromDataStore.Size = shoesChild.Size;
            shoesChildFromDataStore.Price = shoesChild.Price;


            return NoContent();
        }

        [HttpPatch]
        [Route("api/shoes/patchChild")]
        public ActionResult PartiallyUpdateShoesChild(int shoesId, int shoesChildId, JsonPatchDocument<ShoesChildForUpdateDto> patchDocument)
        {
            var shoes = ShoesDataStore.Current.FirstOrDefault(s => s.Id == shoesId);
            if (shoes == null)
            {
                return NotFound();
            }

            var shoesChildFromStore = shoes.ShoesChild.FirstOrDefault(s => s.Id == shoesChildId);
            if (shoesChildFromStore == null)
            {
                return NotFound();
            }

            var shoesChildToPatch = new ShoesChildForUpdateDto()
            {
                Size = shoesChildFromStore.Size,
                Price = shoesChildFromStore.Price,
            };

            patchDocument.ApplyTo(shoesChildToPatch, ModelState);

            if (!ModelState.IsValid) //errors that happened when patching 
            {
                return BadRequest(ModelState);
            }
            if (!TryValidateModel(shoesChildToPatch)) //this will trigger validation from our model and will end up in model state
            {
                return BadRequest(ModelState);
            }

            shoesChildFromStore.Size = shoesChildToPatch.Size;
            shoesChildFromStore.Price = shoesChildToPatch.Price;

            return NoContent();
        }

        [HttpDelete]
        [Route("api/shoes/deleteChild")]
        public ActionResult DeletePointOfInterest(int shoesId, int shoesChildId)
        {
            var shoes = ShoesDataStore.Current.FirstOrDefault(s => s.Id == shoesId);
            if (shoes == null)
            {
                return NotFound();
            }

            var shoesChildFromStore = shoes.ShoesChild.FirstOrDefault(t => t.Id == shoesChildId);
            if (shoesChildFromStore == null)
            {
                return NotFound();
            }

            shoes.ShoesChild.Remove(shoesChildFromStore);
         
            return NoContent();
        }

    }
}


