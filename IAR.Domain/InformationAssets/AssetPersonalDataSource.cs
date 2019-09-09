using IAR.Domain.LookupLists;

namespace IAR.Domain.InformationAssets
{
    public class AssetPersonalDataSource
    {
        public int AssetPersonalDataSourceId { get; set; }

        public virtual Asset Asset { get; set; }

        public virtual PersonalDataSource PersonalDataSource { get; set; }
    }
}
