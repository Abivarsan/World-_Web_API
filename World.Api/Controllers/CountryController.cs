using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using World.Api.Data;

namespace World.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CountryController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]

    }
}
