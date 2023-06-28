using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace web_api_LearnDemo.Controllers
{

    // https://localhost:portnumber/api/Students

    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        // GET:https://localhost:portnumber/api/Students
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            string[] StudentsName = new string[]
            {
                 "Dhruv",
                 "Jenil",
                 "Bhargav",
                 "Dhruvil",
            };
            return Ok(StudentsName);    
        }
    }
}
