using System;
using System.Collections.Generic;

namespace Test.Models
{
    public partial class SysOrganizationType
    {
        public SysOrganizationType()
        {
            this.SysOrganizations = new List<SysOrganization>();
        }

        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<SysOrganization> SysOrganizations { get; set; }
    }
}
