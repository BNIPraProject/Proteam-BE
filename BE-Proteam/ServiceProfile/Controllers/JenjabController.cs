using Microsoft.AspNetCore.Mvc;
using ServiceProfile.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServiceProfile.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JenjabController : ControllerBase
    {
        private IJenjab _jenjab;

        public JenjabController (IJenjab jenjab)
        {
            _jenjab = jenjab;
        }
        // GET: api/<JenjabController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<JenjabController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<JenjabController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<JenjabController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<JenjabController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
