using Microsoft.AspNetCore.Mvc;
using myTestWebApi.DTO;
using myTestWebApi.Models;

namespace myTestWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
   
    public class HomeController : ControllerBase
    {
        private readonly DBTFContext _dbContect;

        public HomeController(DBTFContext dbcontext)
        {
            _dbContect = dbcontext;
        }
        [HttpGet("getEmp")]
        public IActionResult getEmp()
        {
            return Ok(_dbContect.TEmployee);
        }
    }
}
