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
    public class LookupsController : ControllerBase
    {
        private ILookup _lookup;

        public LookupsController(ILookup lookup)
        {
            _lookup = lookup;
        }
        // GET: api/<LookupsController>
        [HttpGet]
        public async Task<IEnumerable<Lookup>> Get()
        {
            var results = await _lookup.GetAll();
            return results;
        }

        // GET api/<LookupsController>/5
        [HttpGet("{id}")]
        public async Task<Lookup> Get(int id)
        {
            var result = await _lookup.GetById(id.ToString());
            return result;
        }
        [HttpGet("GetType/{type}")]
        public async Task<IEnumerable<Lookup>> GetType(string type)
        {
            var result = await _lookup.GetByType(type);
            return result;
        }

        [HttpGet("{type}/{status}")]
        public async Task<IEnumerable<Lookup>> GetTypeStatus(string type, string status)
        {
            var result = await _lookup.GetByTypeStatus(type, status);
            return result;
        }

        [HttpGet("GetTypeValue/{type}/{value}")]
        public async Task<Lookup> GetTypeValue(string type, string value)
        {
            var result = await _lookup.GetByTypeValue(type, value);
            return result;
        }

        // POST api/<LookupsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Lookup lookup)
        {
            try
            {
                await _lookup.Insert(lookup);
                return Ok($"Data  lookup tipe {lookup.Type} nama {lookup.Name} berhasil ditambahkan");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<LookupsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Lookup lookup)
        {
            try
            {
                await _lookup.Update(id.ToString(), lookup);
                return Ok($"Data Lookup ID {id} berhasil diupdate");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<LookupsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _lookup.Delete(id.ToString());
                return Ok($"Data lookup {id} berhasil dihapus");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
