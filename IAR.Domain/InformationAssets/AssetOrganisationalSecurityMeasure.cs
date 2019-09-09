using IAR.Domain.LookupLists;

namespace IAR.Domain.InformationAssets
{
    public class AssetOrganisationalSecurityMeasure
    {
        public int AssetOrganisationalSecurityMeasureId { get; set; }

        public virtual Asset Asset { get; set; }

        public virtual OrganisationalSecurityMeasure OrganisationalSecurityMeasure { get; set; }
    }
}
