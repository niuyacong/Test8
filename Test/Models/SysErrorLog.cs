using System;
using System.Collections.Generic;

namespace Test.Models
{
    public partial class SysErrorLog
    {
        public int ID { get; set; }
        public string Address { get; set; }
        public string Content { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
    }
}
