using System;
using System.Collections.Generic;

namespace Test.Models
{
    public partial class SysOrganization
    {
        public SysOrganization()
        {
            this.SysUsers = new List<SysUser>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<int> ParentID { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        public string OrganizationTypeCode { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public virtual SysOrganizationType SysOrganizationType { get; set; }
        public virtual ICollection<SysUser> SysUsers { get; set; }
    }
}
