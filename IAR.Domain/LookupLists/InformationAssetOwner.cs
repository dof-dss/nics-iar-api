using System.Collections.Generic;
using IAR.Domain.Admin;

namespace IAR.Domain.LookupLists
{
    public class InformationAssetOwner
    {
        public int InformationAssetOwnerId { get; set; }

        public string DisplayName { get; set; }

        public string EmailAddress { get; set; }

        public BusinessArea BusinessArea { get; set; }
    }
}
