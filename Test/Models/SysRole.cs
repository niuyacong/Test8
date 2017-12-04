using System;
using System.Collections.Generic;

namespace Test.Models
{
    public partial class SysRole
    {
        public SysRole()
        {
            this.SysRolePermissions = new List<SysRolePermission>();
            this.SysUserRoles = new List<SysUserRole>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public virtual ICollection<SysRolePermission> SysRolePermissions { get; set; }
        public virtual ICollection<SysUserRole> SysUserRoles { get; set; }
    }
}
