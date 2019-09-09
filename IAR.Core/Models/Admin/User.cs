using DSS.Architecture.Patterns.DotNet.Clean.Validation;
using IAR.Core.Models.LookupLists;
using System;
using System.Collections.Generic;
using System.Text;

namespace IAR.Core.Models.Admin
{
    /// <summary>
    /// An object which contains basic user details for users of the application
    /// </summary>
    public class User : IValidate
    {
        /// <summary>
        /// Gets or sets an int which represents the unique automatically generated Id of the User
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="string"/> which contains the Windows Login Name of the user.
        /// </summary>
        public string WindowsLoginName { get; set; }

        /// <summary>
        /// Gets or sets a <see cref="string"/> which contains the user friendly display name for the user
        /// </summary>
        public string DisplayName { get; set; }        

        /// <summary>
        /// Gets or sets the <see cref="ApplicationRole"/> the user belongs to
        /// </summary>
        public UserRole Role { get; set; }
        
        /// <summary>
        /// Gets or sets the <see cref="Department"/> the user belings to.
        /// </summary>
        public Department Department { get; set; }

        /// <summary>
        /// Gets or sets the BusinessArea the user belongs to
        /// </summary>
        public BusinessArea BusinessArea { get; set; }

        /// <summary>
        /// Gets or sets an <see cref="IEnumerable{T}"/> of type <see cref="InformationAssetOwner"/>
        /// which indicates which IAO's the user has access to.
        /// </summary>
        public virtual ICollection<InformationAssetOwner> AvailableIAOs { get; set; }

        public ValidationResult Validate()
        {
            ValidationResult validation = new ValidationResult();
            // perform basic domain model validation logic

            if (string.IsNullOrWhiteSpace(WindowsLoginName))
            {
                validation.AddError("WindowsLoginName", "You must provide a Windows Login Name value for this User");
            }

            if (string.IsNullOrWhiteSpace(WindowsLoginName))
            {
                validation.AddError("DisplayName", "You must provide a Display Name value for this User");
            }

            if(BusinessArea == null)
            {
                validation.AddError("BusinessArea", "You must specify a Business Area for this User");
            }

            return validation;
        }

    }
}
