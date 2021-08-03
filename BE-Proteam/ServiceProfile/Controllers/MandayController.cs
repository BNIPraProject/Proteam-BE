using Microsoft.AspNetCore.Mvc;
using ServiceProfile.Data;
using ServiceProfile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServiceProfile.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MandayController : ControllerBase
    {
        private IManday _manday;

        public MandayController(IManday manday)
        {
            _manday = manday;
        }
        // GET: api/<MandayController>
        [HttpGet]
        [Route("GetAll")]
        public async Task<IEnumerable<Manday>> Get()
        {
            var result = await _manday.GetAll();
            return (IEnumerable<Manday>)result;
        }

        // GET api/<MandayController>/5
        [HttpGet("{id}")]
        public async Task<Manday> Get(int id)
        {
            var result = await _manday.GetById(id.ToString());
            return result;
        }

        // POST api/<MandayController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Manday manday)
        {
            try
            {
                await _manday.Insert(manday);
                return Ok($"Manday {manday.MandaysId} sukses ditambahkan");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<MandayController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Manday manday)
        {
            try
            {
                await _manday.Update(id.ToString(), manday);
                return Ok($"Manday {id} sukses diupdate");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<MandayController>/5
        [HttpDelete("{id}")]
        [NonAction]
        public void Delete(int id)
        {
        }
    }
}