using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SampleEF.Data.Dal;
using SampleEF.Domain;
using SampleEF.Domain.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SampleEF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SamuraisController : ControllerBase
    {
        private readonly ISamurai _samurai;
        private readonly IMapper _mapper;
        public SamuraisController(ISamurai samurai,IMapper mapper)
        {
            _samurai = samurai;
            _mapper = mapper;
        }

        // GET: api/<SamuraisController>
        [HttpGet]
        public async Task<IEnumerable<SamuraiReadDto>> Get()
        {
            /*List<SamuraiReadDto> lstSamurai= new List<SamuraiReadDto>();
            var results = await _samurai.GetAll();
            foreach(var result in results)
            {
                lstSamurai.Add(new SamuraiReadDto
                {
                    Id = result.Id,
                    Name = result.Name,
                });
            }*/
            var results = await _samurai.GetAll();
            var output = _mapper.Map<IEnumerable<SamuraiReadDto>>(results);
            return output;
        }

        // GET api/<SamuraisController>/5
        [HttpGet("{id}")]
        public async Task<SamuraiReadDto> Get(int id)
        {
            var result = _samurai.Get(id);
            var output = _mapper.Map<SamuraiReadDto>(result);
            return output;
        }

        // POST api/<SamuraisController>
        [HttpPost]
        public async Task<ActionResult> Post(SamuraiCreateDto samuraiCreateDto)
        {
            try
            {
                var newSamurai = _mapper.Map<Samurai>(samuraiCreateDto);
                var result = await _samurai.Insert(newSamurai);
                var samuraiReadDto = _mapper.Map<SamuraiReadDto>(result);
                return CreatedAtAction("Get", new { id = result.Id }, samuraiReadDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<SamuraisController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SamuraisController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
