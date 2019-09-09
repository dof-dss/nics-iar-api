using System.Collections.Generic;
using IAR.Domain.InformationAssets;

namespace IAR.Domain.LookupLists
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


        public virtual ICollection<AssetPersonalDataSource> AssetPersonalDataSource { get; set; }
    }
}
