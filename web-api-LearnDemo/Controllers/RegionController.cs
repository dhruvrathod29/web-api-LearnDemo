using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using web_api_LearnDemo.Models.Domain;

namespace web_api_LearnDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            var regions = new List<Region>
            {
                new Region
                {
                    Id = Guid.NewGuid (),
                    Name = "Auckland region",
                    Code = "AKL",
                    RegionImageUrl = ""
                }
            }
        }
    }
}
