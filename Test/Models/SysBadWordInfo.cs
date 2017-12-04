using System;
using System.Collections.Generic;

namespace Test.Models
{
    public partial class SysBadWordInfo
    {
        public int ID { get; set; }
        public string BadWord { get; set; }
        public string Type { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<System.DateTime> CreatTime { get; set; }
        public Nullable<int> CreatID { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
        public Nullable<int> UpdateID { get; set; }
    }
}
