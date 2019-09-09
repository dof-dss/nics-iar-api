using IAR.Domain.LookupLists;
using System.Collections.Generic;

namespace IAR.Domain.InformationAssets
{
    public class AssetApplicableRight
    {
        public int AssetApplicableRightId { get; set; }

        public virtual Asset Asset { get; set; }

        public virtual ApplicableRight ApplicableRight { get; set; }
    }
}
