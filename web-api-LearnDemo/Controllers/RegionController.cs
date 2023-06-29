using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using web_api_LearnDemo.Data;
using web_api_LearnDemo.Models.Domain;
using web_api_LearnDemo.Models.DTO;

namespace web_api_LearnDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly StudentWebApiDbContext dbContext;

        public RegionController(StudentWebApiDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        #region Get All Region

        //GET All Regions
        [HttpGet]
        public IActionResult GetAll()
        {

            //Get data from database - domain models
            var regionsDomain = dbContext.Regions.ToList();

            // map/convert region domain models to region DTOs
            var regioDTO = new List<RegionDTO>();   
            foreach (var regionDomain in regionsDomain)
            {
                regioDTO.Add(new RegionDTO
                {
                    Id = regionDomain.Id,
                    Name = regionDomain.Name,
                    Code = regionDomain.Code,
                    RegionImageUrl = regionDomain.RegionImageUrl

                });
            }

            //Return DTOs
            return Ok(regioDTO) ;




            //Static pass 

            /*var regions = new List<Region>
            {
                new Region
                {
                    Id = Guid.NewGuid (),
                    Name = "Auckland region",
                    Code = "AKL",
                    RegionImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSLrw9X_m3d16i953DcdijOoX-wWGLSiGLMcdqggOvtqQ&s"
                },
                 new Region
                 {
                    Id = Guid.NewGuid (),
                    Name = "Welington region",
                    Code = "WLG",
                    RegionImageUrl = "https://www.google.com/search?q=wellington+imge&tbm=isch&ved=2ahUKEwiB0PzdkOj_AhUZumMGHRjoAUYQ2-cCegQIABAA&oq=wellington+imge&gs_lcp=CgNpbWcQAzoECCMQJzoHCAAQigUQQzoFCAAQgAQ6CggAEIoFELEDEEM6BggAEAUQHjoGCAAQCBAeUN4BWPghYN8iaABwAHgAgAG3AYgBxwaSAQMwLjWYAQCgAQGqAQtnd3Mtd2l6LWltZ8ABAQ&sclient=img&ei=FkqdZIHtI5n0juMPmNCHsAQ&bih=793&biw=1707&rlz=1C1UEAD_enIN980IN980"

                 }
            };
            */


        }

        #endregion

        #region GET SelectByPK

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById([FromRoute] Guid id) 
        {
          /*  var regions = dbContext.Regions.Find(id);
*/
            var regionDomain = dbContext.Regions.FirstOrDefault(x => x.Id == id);  
            if (regionDomain == null)
            {
                return NotFound();  
            }

            //map/convert region model to Region DTO
            var regionDto = new RegionDTO
            {
                Id = regionDomain.Id,
                Name = regionDomain.Name,
                Code = regionDomain.Code,
                RegionImageUrl = regionDomain.RegionImageUrl
            };
            return Ok(regionDto); 
        }


        #endregion

        // Post Region Creater new region
        //POST
        [HttpPost]
        public IActionResult Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            //map/convert dto ot Domain model
            var regionDomainModel = new Region
            {
                Code = addRegionRequestDto.Code,
                Name = addRegionRequestDto.Name,
                RegionImageUrl = addRegionRequestDto.RegionImageUrl

            };

            // use domain model to create region
            dbContext.Regions.Add(regionDomainModel);
            dbContext.SaveChanges();

            // map domain model back to dto
            var regionDto = new RegionDTO
            {
                Id = regionDomainModel.Id,
                Name = regionDomainModel.Name,
                Code = regionDomainModel.Code,
                RegionImageUrl = regionDomainModel.RegionImageUrl

            };

            return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);


        }
    }
}
