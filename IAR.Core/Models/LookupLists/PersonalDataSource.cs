using System.Collections.Generic;
using IAR.Core.Models.InformationAssets;

namespace IAR.Core.Models.LookupLists
{
    public class PersonalDataSource
    {
        /// <summary>
        /// Gets or sets an <see cref="int"/> which represents the unique automatically generated Id of the source of personal data.
        /// </summary>
        public int PersonalDataSourceId { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="string"/> which contains a description of the source of personal data.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="AssetDetail"/> which contains details of the current asset.
        /// </summary>
        public virtual ICollection<AssetDetail> Asset { get; set; }
    }
}
