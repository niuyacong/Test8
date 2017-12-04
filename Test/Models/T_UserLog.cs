using System;
using System.Collections.Generic;

namespace Test.Models
{
    public partial class T_UserLog
    {
        public string ID { get; set; }
        public Nullable<int> USID { get; set; }
        public Nullable<System.DateTime> OperatingTime { get; set; }
        public string Contents { get; set; }
    }
}
