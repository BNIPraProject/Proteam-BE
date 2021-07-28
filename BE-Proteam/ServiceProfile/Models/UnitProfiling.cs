using System;
using System.Collections.Generic;

#nullable disable

namespace ServiceProfile.Models
{
    public partial class UnitProfiling
    {
        public int UnitId { get; set; }
        public int? KelompokId { get; set; }
        public decimal? TotalEmployee { get; set; }
        public decimal? TotalManhour { get; set; }
        public int? EmpSkillId { get; set; }

        public virtual EmployeeSkill EmpSkill { get; set; }
        public virtual Kelompok Kelompok { get; set; }
    }
}
