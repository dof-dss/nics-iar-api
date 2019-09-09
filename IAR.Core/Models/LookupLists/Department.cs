using System.Collections.Generic;

namespace IAR.Core.Models.LookupLists
{
    public class Department
    {
        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }

        public string DepartmentAbbreviation { get; set; }

        public string DPOName { get; set; }

        public string DataControllerName { get; set; }

        public virtual ICollection<Division> Divisions { get; set; }
    }
}
