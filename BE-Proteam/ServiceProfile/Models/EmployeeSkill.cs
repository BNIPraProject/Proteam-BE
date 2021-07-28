using System;
using System.Collections.Generic;

#nullable disable

namespace ServiceProfile.Models
{
    public partial class EmployeeSkill
    {
        public EmployeeSkill()
        {
            UnitProfilings = new HashSet<UnitProfiling>();
        }

        public int EmpSkillId { get; set; }
        public int? EmployeeId { get; set; }
        public int? SkillsetId { get; set; }

        public virtual ResourceEmployee Employee { get; set; }
        public virtual Skillset Skillset { get; set; }
        public virtual ICollection<UnitProfiling> UnitProfilings { get; set; }
    }
}
