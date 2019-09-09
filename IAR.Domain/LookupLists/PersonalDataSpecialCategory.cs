using System.Collections.Generic;
using IAR.Domain.InformationAssets;

namespace IAR.Domain.LookupLists
{
    public class PersonalDataSpecialCategory
    {
        /// <summary>
        /// Gets or sets an <see cref="int"/> which represents the unique automatically generated Id of the special category of personal data.
        /// </summary>
        public int PersonalDataSpecialCategoryId { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="string"/> which contains a description of the special category of personal data.
        /// </summary>
        public string Description { get; set; }

        public virtual ICollection<AssetPersonalDataSpecialCategory> AssetPersonalDataSpecialCategory { get; set; }
    }
}
