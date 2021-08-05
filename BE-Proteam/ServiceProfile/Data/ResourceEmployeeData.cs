using Microsoft.EntityFrameworkCore;
using ServiceProfile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ServiceProfile.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
//using MasterRole_GetById.Tools;

namespace ServiceProfile.Data
{
    public class ResourceEmployeeData : IResourceEmployee
    {
        private ProteamContext _db;

        public ResourceEmployeeData(ProteamContext db)
        {
            _db = db;
        }
        public async Task Delete(string id)
        {
            var result = await GetById(id);
            //cek apakah data ada?
            if (result != null)
            {
                try
                {
                    _db.ResourceEmployees.Remove(result);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateException dbEx)
                {
                    throw new Exception($"DbError: {dbEx.Message}");
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error: {ex.Message}");
                }
            }
        }
        //#region LoadDataInboxRM
       // [Authorize]
       // [HttpPost]
        //public async Task<List<Vm>> GetDataInboxRM()
        //{

        //    List<Vm> res = new List<Vm>();
        //    try
        //    {
        //        List<Vm> list = new List<Vm>();
              

        //        list = StoredProcedureExecutor.ExecuteSPList<Vm>(_db, "sp_data", new SqlParameter[]{
        //               });

              

               
        //        return list;
        //    }
        //    catch (Exception ex)
        //    {
               
        //        return res;
        //    }
        //}
       // #endregion
        public async Task<IEnumerable<ResourceEmployee>> GetAll()
        {

             var results = await (from re in _db.ResourceEmployees.Include(e => e.Jenjab).Include(e => e.Kelompok)
                                 select re).ToListAsync();
            // var employeeskills = await (from e in _db.EmployeeSkills.Include(e => e.Skillset)
            //                            select e).AsNoTracking().ToListAsync();
            // for(int i=0; i < results.Count(); i++)
            // {
            //     results[i].EmployeeSkills = employeeskills;
            //var countsql = "exec SP_Select_Count_DynamicKendoGrid "
            //                     + "@KendoGrid='" + filter + "'";
            //int totalRow = _db.Database.SqlQuery<int>(countsql).First();

            //var xxxa = await _db.ResourceEmployees.FromSqlRaw("SELECT * FROM ResourceEmployee").ToListAsync();

            //   var xxxa = await _db.ResourceEmployees.FromSqlRaw("SELECT * FROM ResourceEmployee").ToListAsync();
            //  //var result = await context.SomeModels.FromSql("SQL_SCRIPT").ToListAsync();

            //  List<Vm> Data34 = xxxa.ToList();

            //}234

            return results;
        }

        public async Task<ResourceEmployee> GetById(string id)
        {
            var result = await(from re in _db.ResourceEmployees.Include(e => e.Jenjab).Include(e => e.Kelompok)
                               where re.EmployeeId == Convert.ToInt32(id)
                               select re).FirstOrDefaultAsync();

            var employeeskills = await (from e in _db.EmployeeSkills.Include(e => e.Skillset)
                                     where e.EmployeeId == Convert.ToInt32(id)
                                     select e).AsNoTracking().ToListAsync();
            result.EmployeeSkills = employeeskills;

            return result;
        }

        public async Task Insert(ResourceEmployee obj)
        {
               try
            {
                _db.ResourceEmployees.Add(obj);
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception($"Db Error: {dbEx.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

        public async Task Update(string id, ResourceEmployee obj)
        {
            try
            {
                var result = await GetById(id);
                //cek apakah data sudah ada
                if (result != null)
                {
                    //_db.Update(obj);
                    result.EmployeeName = obj.EmployeeName;
                    result.Email = obj.Email;
                    result.Phone = obj.Phone;
                    result.ActiveDate = obj.ActiveDate;
                    result.LastWorkDate = obj.LastWorkDate;
                    result.TotalManhour = obj.TotalManhour;
                    result.ResourceType = obj.ResourceType;
                    result.JenjabId = obj.JenjabId;
                    result.KelompokId = obj.KelompokId;
                    result.Role = obj.Role;
                    result.Status = obj.Status;
                    result.UpdatedBy = obj.UpdatedBy;
                    result.UpdateTime = obj.UpdateTime;
                    await _db.SaveChangesAsync();
                }
                else
                {
                    throw new Exception($"Data id:{id} tidak ditemukan");
                }
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception($"DbError: {dbEx.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }
    }
}
