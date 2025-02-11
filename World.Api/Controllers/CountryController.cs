using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using World.Api.Data;
using World.Api.DTO;
using World.Api.Models;

namespace World.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public CountryController(ApplicationDbContext dbcontext,IMapper mapper)
        {
            _dbContext = dbcontext;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]

        public ActionResult<CreateCountryDto> Create([FromBody] CreateCountryDto countryDto)
        {
            var result = _dbContext.Countries.AsQueryable().Where(c => c.Name.ToLower().Trim() == countryDto.Name.ToLower().Trim()).Any();

            if (result)
            {
                return Conflict("Country already exists");
            }

            //Without using Auto Mapper
            //Country country = new Country
            //{
            //    Name = countryDto.Name,
            //    ShortName = countryDto.ShortName,
            //    CountryCode = countryDto.CountryCode
            //};

            //using AutoMApper  
            var country = _mapper.Map<Country>(countryDto);

            _dbContext.Countries.Add(country);
            _dbContext.SaveChanges();
            return CreatedAtAction("GetById", new {id = country.Id}, country);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<IEnumerable<GetAllCountryDto>> GetAll()
        {
            var countries = _dbContext.Countries.ToList();

            //var GetAllCountryDto = countries.Select(c => new GetAllCountryDto
            //{
            //    Name = c.Name,
            //    ShortName = c.ShortName,
            //    CountryCode = c.CountryCode
            //});

            var countriesDto = _mapper.Map<List<GetAllCountryDto>>(countries);

            if (countries == null)
            {
                return NoContent();
            }

            return Ok(countriesDto);


        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<GetByIdCountryDto> GetById(int id)
        {
            var country = _dbContext.Countries.Find(id);

            var countryDto = _mapper.Map<GetByIdCountryDto>(country);

            if (country == null)
            {
                return NoContent();
            }
            return Ok(countryDto);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Country> Update(int id,[FromBody] UpdateCountryDto countryDto)
        {
            if (countryDto == null ||  id != countryDto.Id )
            {
                return BadRequest();
            }

            //var countryFromDb = _dbContext.Countries.Find(id);

            //if(countryFromDb == null)
            //{
            //    return NotFound();
            //}

            //countryFromDb.Name = country.Name;
            //countryFromDb.ShortName = country.ShortName;
            //countryFromDb.CountryCode = country.CountryCode;



            var country = _mapper.Map<Country>(countryDto);



            _dbContext.Countries.Update(country);
            _dbContext.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<Country> DeleteById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var country = _dbContext.Countries.Find(id);

            if (country == null)
            {
                return NotFound();
            }
            _dbContext.Countries.Remove(country);
            _dbContext.SaveChanges();
            return NoContent();
        }
    }
}
