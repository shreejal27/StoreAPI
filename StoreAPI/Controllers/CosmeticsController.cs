using Microsoft.AspNetCore.Mvc;
using StoreAPI.Models;

namespace StoreAPI.Controllers
{
    [ApiController]
    public class CosmeticsController : ControllerBase
    {
        [HttpGet]
        [Route("api/cosmetics")]
        public ActionResult <CosmeticsDto> GetCosmetics()
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
            var cosmeticsToReturn = CosmeticsDataStore.Current.FirstOrDefault(c=>c.Id == id);

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

       
    }
}
