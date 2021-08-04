using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using ServiceProfile.Component;
using ServiceProfile.Data;
using ServiceProfile.Models;
using ServiceProfile.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServiceProfile.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceEmployeesController : ControllerBase
    {
        private IResourceEmployee _resourceemployee;
        public ProteamContext _context;

        public ResourceEmployeesController(IResourceEmployee resourceemployee, ProteamContext context)
        {
            _context = context;
            _resourceemployee = resourceemployee;
        }
      
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            try
            {
                List<Vm> data = new List<Vm>();
                List<Vm> employee = new List<Vm>();
                List <SkillName> skillname = new List<SkillName>();


                data = StoredProcedureExecutor.ExecuteSPList<Vm>(_context, "join_skillset", new SqlParameter[]{
                        new SqlParameter("@Flag", 1),
                        new SqlParameter("@Parameter1", "Test"),
                        new SqlParameter("@Parameter2", "Test")
                });


                foreach (Vm Data2 in data)
                {
                    Vm NewData = new Vm();
                    NewData.EmployeeId = Data2.EmployeeId;
                    NewData.EmployeeName = Data2.EmployeeName;
                    NewData.Npp = Data2.Npp;
                    NewData.Email = Data2.Email;
                    NewData.Phone = Data2.Phone;
                    NewData.ActiveDate = Data2.ActiveDate;
                    NewData.LastWorkDate = Data2.LastWorkDate;
                    NewData.TotalManhour = Data2.TotalManhour;
                    NewData.tipe_resource = Data2.tipe_resource;
                    NewData.nama_role = Data2.nama_role;
                    NewData.Kelompok = Data2.Kelompok;
                    NewData.JenjangJabatan = Data2.JenjangJabatan;
                    NewData.ProjectExp = Data2.ProjectExp;
                    NewData.Status = Data2.Status;
                    NewData.CreatedBy = Data2.CreatedBy;
                    NewData.UpdatedBy = Data2.UpdatedBy;
                    NewData.CreatedTime = Data2.CreatedTime;
                    NewData.UpdateTime = Data2.UpdateTime;
                    NewData.ResourceType = Data2.ResourceType;
                    NewData.Role = Data2.Role;
                    NewData.JenjabId = Data2.JenjabId;
                    NewData.KelompokId = Data2.KelompokId;
                    NewData.nama_status = Data2.nama_status;

                    skillname = StoredProcedureExecutor.ExecuteSPList<SkillName>(_context, "join_skillset", new SqlParameter[]{
                        new SqlParameter("@Flag", 2),
                        new SqlParameter("@Parameter1", NewData.EmployeeId),
                        new SqlParameter("@Parameter2", "Test")
                    });
                    if (skillname.Count() > 0)
                    {
                        string DataSemuaRole = "";
                        foreach (SkillName role in skillname)
                        {
                            DataSemuaRole = DataSemuaRole + " " + role.Skillset + "</b> <br/>";
                        }
                        NewData.Skill = DataSemuaRole;
                    }
                    employee.Add(NewData);
                    
                }


                return Ok(new { employee });
            }
            catch (Exception ex)
            {
                return BadRequest("Error : " + ex.Message);
            }
            var results = await _resourceemployee.GetAll();

        }


        // GET api/<ResourceEmployeesController>/5
        //    [HttpGet("{id}")]
        //public async Task<ResourceEmployee> Get(int id)
        //{
        //    var result = await _resourceemployee.GetById(id.ToString());
        //    return result;
        //}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            try
            {
                List<Vm> data = new List<Vm>();
                List<Vm> employee = new List<Vm>();
                List<SkillName> skillname = new List<SkillName>();


                data = StoredProcedureExecutor.ExecuteSPList<Vm>(_context, "join_skillset_byid", new SqlParameter[]{
                        new SqlParameter("@Flag", 1),
                        new SqlParameter("@Parameter1", id),
                        new SqlParameter("@Parameter2", "Test")
                });


                foreach (Vm Data2 in data)
                {
                    Vm NewData = new Vm();
                    NewData.EmployeeId = Data2.EmployeeId;
                    NewData.EmployeeName = Data2.EmployeeName;
                    NewData.Npp = Data2.Npp;
                    NewData.Email = Data2.Email;
                    NewData.Phone = Data2.Phone;
                    NewData.ActiveDate = Data2.ActiveDate;
                    NewData.LastWorkDate = Data2.LastWorkDate;
                    NewData.TotalManhour = Data2.TotalManhour;
                    NewData.tipe_resource = Data2.tipe_resource;
                    NewData.nama_role = Data2.nama_role;
                    NewData.Kelompok = Data2.Kelompok;
                    NewData.JenjangJabatan = Data2.JenjangJabatan;
                    NewData.ProjectExp = Data2.ProjectExp;
                    NewData.Status = Data2.Status;
                    NewData.CreatedBy = Data2.CreatedBy;
                    NewData.UpdatedBy = Data2.UpdatedBy;
                    NewData.CreatedTime = Data2.CreatedTime;
                    NewData.UpdateTime = Data2.UpdateTime;
                    NewData.ResourceType = Data2.ResourceType;
                    NewData.Role = Data2.Role;
                    NewData.JenjabId = Data2.JenjabId;
                    NewData.KelompokId = Data2.KelompokId;
                    NewData.nama_status = Data2.nama_status;

                    skillname = StoredProcedureExecutor.ExecuteSPList<SkillName>(_context, "join_skillset", new SqlParameter[]{
                        new SqlParameter("@Flag", 2),
                        new SqlParameter("@Parameter1", id),
                        new SqlParameter("@Parameter2", "Test")
                    });
                    if (skillname.Count() > 0)
                    {
                        string DataSemuaRole = "";
                        foreach (SkillName role in skillname)
                        {
                            DataSemuaRole = DataSemuaRole + " " + role.Skillset + "</b> <br/>";
                        }
                        NewData.Skill = DataSemuaRole;
                    }
                    employee.Add(NewData);

                }


                return Ok(new { employee });
            }
            catch (Exception ex)
            {
                return BadRequest("Error : " + ex.Message);
            }
            var results = await _resourceemployee.GetAll();

        }


        // POST api/<ResourceEmployeesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ResourceEmployee resourceemployee)
        {
            try
            {
                await _resourceemployee.Insert(resourceemployee);
                return Ok($"Data Employee {resourceemployee.EmployeeName} berhasil ditambahkan");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ResourceEmployeesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ResourceEmployee resourceemployee)
        {
            try
            {
                await _resourceemployee.Update(id.ToString(), resourceemployee);
                return Ok($"Data Employee ID {id} berhasil diupdate");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ResourceEmployeesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _resourceemployee.Delete(id.ToString());
                return Ok($"Data Employee {id} berhasil dihapus");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
