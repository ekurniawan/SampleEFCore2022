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
        public SamuraisController(ISamurai samurai)
        {
            _samurai = samurai;
        }

        // GET: api/<SamuraisController>
        [HttpGet]
        public async Task<IEnumerable<SamuraiReadDto>> Get()
        {
            List<SamuraiReadDto> lstSamurai= new List<SamuraiReadDto>();
            var results = await _samurai.GetAll();
            foreach(var result in results)
            {
                lstSamurai.Add(new SamuraiReadDto
                {
                    Id = result.Id,
                    Name = result.Name,
                });
            }
            return lstSamurai;
        }

        // GET api/<SamuraisController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SamuraisController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
