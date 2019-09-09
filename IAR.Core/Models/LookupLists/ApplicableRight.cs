using IAR.Core.Models.InformationAssets;
using System.Collections.Generic;

namespace IAR.Core.Models.LookupLists
{
    public class ApplicableRight
    {
        /// <summary>
        /// Gets or sets an <see cref="int"/> which represents the unique automatically generated Id of the applicable right.
        /// </summary>
        public int ApplicableRightId { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="string"/> which contains a description of the applicable right.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a collection of <see cref="AssetDetail"/> containing details of the applicable rights of the individual
        /// whose personal data is being processed.
        /// </summary>
        public virtual ICollection<AssetDetail> Asset { get; set; }
    }
}
