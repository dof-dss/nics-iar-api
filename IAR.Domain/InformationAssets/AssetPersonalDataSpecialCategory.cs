using IAR.Domain.LookupLists;

namespace IAR.Domain.InformationAssets
{
    public class AssetPersonalDataSpecialCategory
    {
        public int AssetPersonalDataSpecialCategoryId { get; set; }

        public virtual Asset Asset { get; set; }

        public virtual PersonalDataSpecialCategory PersonalDataSpecialCategory { get; set; }
    }
}
