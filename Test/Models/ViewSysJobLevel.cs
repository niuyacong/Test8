using System;
using System.Collections.Generic;

namespace Test.Models
{
    public partial class ViewSysJobLevel
    {
        public int LevelId { get; set; }
        public string LevelName { get; set; }
        public Nullable<int> OrgId { get; set; }
        public string OrgName { get; set; }
        public Nullable<int> ParentId { get; set; }
        public string ParentName { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public string Code { get; set; }
    }
}
