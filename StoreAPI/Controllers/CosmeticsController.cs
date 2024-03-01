using Microsoft.AspNetCore.Mvc;
using StoreAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using System.Xml.XPath;
using Microsoft.VisualStudio.Services.WebApi.Patch;

namespace StoreAPI.Controllers
{
    [ApiController]
    public class CosmeticsController : ControllerBase
    {
        [HttpGet]
        [Route("api/cosmetics/get", Name = "GetCosmetics")]
        public ActionResult<CosmeticsDto> GetCosmetics()
        {
            var cosmeticsToReturn = CosmeticsDataStore.Current;

            if (cosmeticsToReturn == null)
            {
                return NotFound();
            }

            return Ok(cosmeticsToReturn);
        }

        [HttpGet]
        [Route("api/cosmetics/getById")]
        public ActionResult<CosmeticsDto> GetCosmeticsIndex(int id)
        {
            var cosmeticsToReturn = CosmeticsDataStore.Current.FirstOrDefault(c => c.Id == id);

            if (cosmeticsToReturn == null)
            {
                return NotFound();
            }

            return Ok(cosmeticsToReturn);
        }

        [HttpGet]
        [Route("api/cosmetics/getByName")]
        public ActionResult<CosmeticsDto> GetCosmeticsName(string name)
        {
            var cosmeticsToReturn = CosmeticsDataStore.Current.FirstOrDefault(c => c.Name == name);

            if (cosmeticsToReturn == null)
            {
                return NotFound();
            }

            return Ok(cosmeticsToReturn);
        }

        [HttpPost]
        [Route("api/cosmetics/post")]
        public ActionResult<CosmeticsDto> CreateCosmetics(CosmeticsDto cosmeticsDto)
        {
            var cosmeticsId = CosmeticsDataStore.Current.Max(c => c.Id);

            if (cosmeticsDto == null)
            {
                return BadRequest();
            }

            var cosmeticsToAdd = new CosmeticsDto()
            {
                Id = ++cosmeticsId,
                Name = cosmeticsDto.Name,
                Description = cosmeticsDto.Description,
            };

            CosmeticsDataStore.Current.Add(cosmeticsToAdd);

            return Ok(cosmeticsToAdd);


            //return CreatedAtRoute("GetCosmetics", cosmeticsDto);
        }

        [HttpPut]
        [Route("api/cosmetics/put")]
        public ActionResult<CosmeticsDto> UpdateCosmetics(int cosmeticsId, CosmeticsDto cosmeticsDto)
        {
            var cosmetics = CosmeticsDataStore.Current.FirstOrDefault(c => c.Id == cosmeticsId);
            if (cosmetics == null)
            {
                return NotFound();
            }

            cosmetics.Name = cosmeticsDto.Name;
            cosmetics.Description = cosmeticsDto.Description;

            return NoContent();
        }
        //[HttpPatch]
        //[Route("api/cosmetics/patch")]
        //public ActionResult<CosmeticsDto> PartiallyUpdateCosmetics(int cosmeticsId, [FromBody] JsonPatchDocument<CosmeticsDto> patchDocument)
        //{
        //    var cosmetics = CosmeticsDataStore.Current.FirstOrDefault(c => c.Id == cosmeticsId);
        //    if (cosmetics == null)
        //    {
        //        return NotFound();
        //    }

        //    var cosmeticsToPatch = new CosmeticsDto()
        //    {
        //        Name = cosmetics.Name,
        //        Description = cosmetics.Description
        //    };

        //    patchDocument.ApplyTo(cosmeticsToPatch, ModelState);

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    cosmetics.Name = cosmeticsToPatch.Name;
        //    cosmetics.Description = cosmeticsToPatch.Description;

        //    return NoContent();
        //}

        [HttpDelete]
        [Route("api/cosmetics/delete")]
        public ActionResult DeleteCosmetics(int cosmeticsId)
        {
            var cosmetics = CosmeticsDataStore.Current.FirstOrDefault(c => c.Id == cosmeticsId);
            if (cosmetics == null)
            {
                return NotFound();
            }

            CosmeticsDataStore.Current.Remove(cosmetics);

            return NoContent();
        }
    }
}
