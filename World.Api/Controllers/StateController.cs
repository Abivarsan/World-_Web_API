using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using World.Api.DTO.Country;
using World.Api.DTO.State;
using World.Api.Models;
using World.Api.Repository;
using World.Api.Repository.IRepository;

namespace World.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IStateRepository _stateRepository;
        private readonly IMapper _mapper;
        public StateController(IStateRepository stateRepository, IMapper mapper) {
            _stateRepository = stateRepository;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]

        public async Task<ActionResult<CreateStateDto>> Create([FromBody] CreateStateDto stateDto)
        {
            var result = _stateRepository.IsRecordExists(x=>x.Name == stateDto.Name);

            if (result)
            {
                return Conflict("State already exists");
            }
            var state = _mapper.Map<State>(stateDto);

            await _stateRepository.create(state);

            return CreatedAtAction("GetById", new { id = state.Id }, state);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<IEnumerable<GetAllStateDto>>> GetAll()
        {
            var states = await _stateRepository.GetAll();

            var statesDto = _mapper.Map<List<GetAllStateDto>>(states);

            if (states == null)
            {
                return NoContent();
            }

            return Ok(statesDto);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<GetByIdStateDto>> GetById(int id)
        {
            var state = await _stateRepository.Get(id);

            var stateDto = _mapper.Map<GetByIdStateDto>(state);

            if (state == null)
            {
                return NoContent();
            }
            return Ok(stateDto);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<State>> Update(int id, [FromBody] UpdateStateDto stateDto)
        {
            if (stateDto == null || id != stateDto.Id)
            {
                return BadRequest();
            }

            var state = _mapper.Map<State>(stateDto);

            await _stateRepository.update(state);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<State>> DeleteById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var country = await _stateRepository.Get(id);

            if (country == null)
            {
                return NotFound();
            }

            await _stateRepository.delete(country);
            return NoContent();
        }

    }
}
