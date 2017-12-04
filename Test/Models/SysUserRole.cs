using System;
using System.Collections.Generic;

namespace Test.Models
{
    public partial class SysUserRole
    {
        public int UserID { get; set; }
        public int RoleID { get; set; }
        public virtual SysRole SysRole { get; set; }
    }
}
