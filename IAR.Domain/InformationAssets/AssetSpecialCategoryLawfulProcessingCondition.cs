using IAR.Domain.LookupLists;

namespace IAR.Domain.InformationAssets
{
    public class AssetSpecialCategoryLawfulProcessingCondition
    {
        public int AssetSpecialCategoryLawfulProcessingConditionId { get; set; }

        public virtual Asset Asset { get; set; }

        public virtual SpecialCategoryLawfulProcessingCondition SpecialCategoryLawfulProcessingCondition { get; set; }
    }
}
