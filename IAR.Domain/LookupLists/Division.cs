using System.Collections.Generic;

namespace IAR.Domain.LookupLists
{
    public class Division
    {
        public int DivisionId { get; set; }

        public string DivisionName { get; set; }

        public Department Department { get; set; }

        public virtual ICollection<BusinessArea> BusinessAreas { get; set; }
    }
}
