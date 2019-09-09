using System.Collections.Generic;
using IAR.Domain.InformationAssets;

namespace IAR.Domain.LookupLists
{
    public class OrganisationalSecurityMeasure
    {
        /// <summary>
        /// Gets or sets an <see cref="int"/> which represents the unique automatically generated Id of the organisational security measure.
        /// </summary>
        public int OrganisationalSecurityMeasureId { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="string"/> which contains a description of the organisational security measure.
        /// </summary>
        public string Description { get; set; }

        public virtual ICollection<AssetOrganisationalSecurityMeasure> AssetOrganisationalSecurityMeasure { get; set; }
    }
}
