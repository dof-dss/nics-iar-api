using IAR.Domain.InformationAssets;
using System.Collections.Generic;

namespace IAR.Domain.LookupLists
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

        public virtual ICollection<AssetApplicableRight> AssetApplicableRights { get; set; }
    }
}
