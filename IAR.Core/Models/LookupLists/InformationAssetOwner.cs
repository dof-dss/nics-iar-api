using System.Collections.Generic;
using IAR.Core.Models.Admin;

namespace IAR.Core.Models.LookupLists
{
    public class InformationAssetOwner
    {
        public int InformationAssetOwnerId { get; set; }

        public string DisplayName { get; set; }

        public string EmailAddress { get; set; }

        public BusinessArea BusinessArea { get; set; }

        /// <summary>
        /// Gets or sets an <see cref="IEnumerable{T}"/> of type <see cref="User"/>
        /// which indicates which users which have access to create/edit/view assets created for the 
        /// Information Asset Owner.
        /// </summary>
        public virtual ICollection<User> LinkedUsers { get; set; }
    }
}
