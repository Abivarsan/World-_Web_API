using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using World.Api.Data;
using World.Api.Models;

namespace World.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ApplicationDbContext _dbcontext;
        public CountryController(ApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        [HttpPost]
        public ActionResult<Country> Create([FromBody] Country country)
        {
            _dbcontext.Countries.Add(country);
            _dbcontext.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Country>> GetAll()
        {
            return _dbcontext.Countries.ToList();
        }

    }
}
