using System;
using System.Collections.Generic;
using System.Text;

namespace IAR.Core.Models.Admin
{
    public class UserRole
    {
        /// <summary>
        /// Gets or sets an int which represents the unique automatically generated Id of the Application Role
        /// </summary>
        public int ApplicationRoleId { get; set; }

        /// <summary>
        /// Gets or sets the unique name of the application role
        /// </summary>
        public string ApplicationRoleName { get; set; }
    }
}
