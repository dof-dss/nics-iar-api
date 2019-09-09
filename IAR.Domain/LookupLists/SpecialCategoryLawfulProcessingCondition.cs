using System.Collections.Generic;
using IAR.Domain.InformationAssets;

namespace IAR.Domain.LookupLists
{
    public class SpecialCategoryLawfulProcessingCondition
    {
        /// <summary>
        /// Gets or sets an <see cref="int"/> which represents the unique automatically generated Id of the lawful
        /// condition for processing special categories of personal data.
        /// </summary>
        public int SpecialCategoryLawfulProcessingConditionId { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="string"/> which contains a description of the lawful
        /// condition for processing special categories of personal data.
        /// </summary>
        public string Description { get; set; }

        public virtual ICollection<AssetSpecialCategoryLawfulProcessingCondition> AssetSpecialCategoryLawfulProcessingCondition { get; set; }
    }
}
