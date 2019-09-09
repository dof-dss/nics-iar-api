using System.Collections.Generic;

namespace IAR.Domain.LookupLists
{
    public class BusinessArea
    {
        public int BusinessAreaId { get; set; }

        public string BusinessAreaName { get; set; }

        public Division ParentDivision { get; set; }
    }
}
