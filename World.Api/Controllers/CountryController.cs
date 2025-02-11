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
        private readonly ApplicationDbContext _dbContext;
        public CountryController(ApplicationDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        [HttpPost]
        public ActionResult<Country> Create([FromBody] Country country)
        {
            _dbContext.Countries.Add(country);
            _dbContext.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Country>> GetAll()
        {
            return _dbContext.Countries.ToList();
        }

        [HttpGet("{id:int}")]
        public ActionResult<Country> GetById(int id)
        {
            return _dbContext.Countries.Find(id);
        }

        [HttpPut]
        public ActionResult<Country> Update([FromBody] Country country)
        {
            _dbContext.Countries.Update(country);
            _dbContext.SaveChanges();
            return Ok();
        }

        [HttpDelete]

        public ActionResult<Country> DeleteById(int id)
        {
            var country = _dbContext.Countries.Find(id);
            _dbContext.Countries.Remove(country);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
