using System;
using System.Collections.Generic;

namespace Test.Models
{
    public partial class ViewSysMenu
    {
        public int ID { get; set; }
        public Nullable<int> ParentID { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string NavigateUrl { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public string ParentName { get; set; }
        public Nullable<bool> isNotVisible { get; set; }
        public string BlackIcon { get; set; }
        public string WhiteIcon { get; set; }
    }
}
