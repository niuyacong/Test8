using System;
using System.Collections.Generic;

namespace Test.Models
{
    public partial class SysJobLevel
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string LevelName { get; set; }
        public Nullable<int> ParentID { get; set; }
        public Nullable<int> SysOrganizationID { get; set; }
        public Nullable<int> CreateID { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
    }
}
