using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IAR.Domain.Admin
{
    public class UserLinkedUser
    {
        public int UserLinkedUserId { get; set; }

        [ForeignKey("PrimaryUser_UserId")]
        public virtual User PrimaryUser { get; set; }

        [ForeignKey("LinkedUser_UserId")]
        public virtual User LinkedUser { get; set; }
    }
}
