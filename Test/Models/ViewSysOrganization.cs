using System;
using System.Collections.Generic;

namespace Test.Models
{
    public partial class ViewSysOrganization
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<int> ParentID { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public string ParentSysOrganizationName { get; set; }
        public string OrganizationTypeCode { get; set; }
        public string SysOrganizationTypeName { get; set; }
    }
}
