using System;
using System.Collections.Generic;
using System.Text;

namespace IAR.Domain.Admin
{
    public class UserRole
    {
        public int UserRoleId { get; set; }

        /// <summary>
        /// Gets or sets the unique name of the application role
        /// </summary>
        public string RoleName { get; set; }
    }
}
