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
    public class KelompoksController : ControllerBase
    {
        private IKelompok _kelompok;

        public KelompoksController(IKelompok kelompok)
        {
            _kelompok = kelompok;
        }
        // GET: api/<KelompoksController>
        [HttpGet]
        public async Task<IEnumerable<Kelompok>> Get()
        {
            var results = await _kelompok.GetAll();
            return results;
        }

        // GET api/<KelompoksController>/5
        [HttpGet("{id}")]
        public async Task<Kelompok> Get(int id)
        {
            var result = await _kelompok.GetById(id.ToString());
            return result;
        }

        // POST api/<KelompoksController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Kelompok kelompok)
        {
            try
            {
                await _kelompok.Insert(kelompok);
                return Ok($"Data Kelompok {kelompok.Kelompok1} berhasil ditambahkan");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<KelompoksController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Kelompok kelompok)
        {
            try
            {
                await _kelompok.Update(id.ToString(), kelompok);
                return Ok($"Data Kelompok ID {id} berhasil diupdate");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<KelompoksController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _kelompok.Delete(id.ToString());
                return Ok($"Data kelompok {id} berhasil dihapus");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
