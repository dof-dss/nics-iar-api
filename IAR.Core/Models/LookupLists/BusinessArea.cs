using System.Collections.Generic;

namespace IAR.Core.Models.LookupLists
{
    public class BusinessArea
    {
        public int BusinessAreaId { get; set; }

        public string BusinessAreaName { get; set; }

        public Division ParentDivision { get; set; }

        public virtual ICollection<InformationAssetOwner> InformationAssetOwners { get; set; }
    }
}
