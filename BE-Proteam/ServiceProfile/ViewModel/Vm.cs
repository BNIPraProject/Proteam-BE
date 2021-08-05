using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceProfile.ViewModel
{
    public class Vm
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Npp { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime? ActiveDate { get; set; }
        public DateTime? LastWorkDate { get; set; }
        public decimal? TotalManhour { get; set; }
        public int? ResourceType { get; set; }
        public string tipe_resource { get; set; }
        public int? JenjabId { get; set; }
        public string JenjangJabatan { get; set; }
        public int? KelompokId { get; set; }
        public string Kelompok { get; set; }
        public int? Role { get; set; }
        public string nama_role { get; set; }
        public string ProjectExp { get; set; }
        public int? Status { get; set; }
        public string nama_status { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? UpdateTime { get; set; }


        public string Skill { get; set; }

    }
    public class SkillName
    {
        public string Skillset { get; set; }
    }

    public class ContohData
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class VendorMandays
    {
        public int Mandays_id { get; set; }
        public string VendorName { get; set; }

        public int TotalMandays { get; set; }
    }

    public class DashboardVendor
    {
        public int TotalVendor { get; set; }

        public int TotalMandays { get; set; }
        public List<VendorMandays> ListVendors { get; set; }
    }

    public class ResourceKelompok
    {
        public int Kelompok_id { get; set; }
        public string Kelompok { get; set; }

        public int TotalResourceKelompok { get; set; }
    }

    public class ResourceRole
    {
        public int Role { get; set; }
        public string Name { get; set; }

        public int TotalResourceRole { get; set; }
    }

    public class ResourceType
    {
        public int ResourceTypeVal { get; set; }
        public string Name { get; set; }

        public int TotalResourceType { get; set; }
    }


    public class DashboardResources
    {
        public int TotalResource { get; set; }

        public List<ResourceKelompok> ListResourceKelompok { get; set; }

        public List<ResourceRole> ListResourceRole { get; set; }

        public List<ResourceType> ListResourceType { get; set; }
    }
}