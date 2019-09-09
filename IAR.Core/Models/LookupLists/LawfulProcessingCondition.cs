using System.Collections.Generic;
using IAR.Core.Models.InformationAssets;

namespace IAR.Core.Models.LookupLists
{
    public class LawfulProcessingCondition
    {
        /// <summary>
        /// Gets or sets an <see cref="int"/> which represents the unique automatically generated Id of the lawful condition for processing.
        /// </summary>
        public int LawfulProcessingConditionId { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="string"/> which contains a description of the lawful condition for processing.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a collection of <see cref="AssetDetail"/> containing details of the applicable rights of the individual
        /// whose personal data is being processed.
        /// </summary>
        public virtual ICollection<AssetDetail> Asset { get; set; }
    }
}
