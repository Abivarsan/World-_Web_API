using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using World.Api.DTO;
using World.Api.Models;
using World.Api.Repository.IRepository;

namespace World.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;
        public CountryController(ICountryRepository countryRepository,IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]

        public async Task<ActionResult<CreateCountryDto>> Create([FromBody] CreateCountryDto countryDto)
        {
            var result =  _countryRepository.IsCountryExists(countryDto.Name);

            if (result)
            {
                return Conflict("Country already exists");
            } 
            var country = _mapper.Map<Country>(countryDto);

            await _countryRepository.create(country);

            return CreatedAtAction("GetById", new {id = country.Id}, country);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<IEnumerable<GetAllCountryDto>>> GetAll()
        {
            var countries = await _countryRepository.GetAll();

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
        public async Task<ActionResult<GetByIdCountryDto>> GetById(int id)
        {
            var country = await _countryRepository.GetById(id);

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
        public async Task<ActionResult<Country>> Update(int id,[FromBody] UpdateCountryDto countryDto)
        {
            if (countryDto == null ||  id != countryDto.Id )
            {
                return BadRequest();
            }

            var country = _mapper.Map<Country>(countryDto);

            await _countryRepository.update(country);
            
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<Country>> DeleteById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var country = await _countryRepository.GetById(id);

            if (country == null)
            {
                return NotFound();
            }

            await _countryRepository.delete(country);
            return NoContent();
        }
    }
}
