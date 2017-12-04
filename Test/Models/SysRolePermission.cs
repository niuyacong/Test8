using System;
using System.Collections.Generic;

namespace Test.Models
{
    public partial class SysRolePermission
    {
        public int RoleID { get; set; }
        public string Permission { get; set; }
        public virtual SysRole SysRole { get; set; }
    }
}
