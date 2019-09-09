using IAR.Domain.LookupLists;

namespace IAR.Domain.InformationAssets
{
    public class AssetLawfulProcessingCondition
    {
        public int AssetLawfulProcessingConditionId { get; set; }

        public virtual Asset Asset { get; set; }

        public virtual LawfulProcessingCondition LawfulProcessingCondition { get; set; }
    }
}
