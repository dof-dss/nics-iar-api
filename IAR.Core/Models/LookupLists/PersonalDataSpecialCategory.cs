using System.Collections.Generic;
using IAR.Core.Models.InformationAssets;

namespace IAR.Core.Models.LookupLists
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

        /// <summary>
        /// Gets or sets a collection of <see cref="AssetDetail"/> containing the special types of
        /// information that is processed.
        /// </summary>
        public virtual ICollection<AssetDetail> Asset { get; set; }
    }
}
