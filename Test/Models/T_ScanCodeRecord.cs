using System;
using System.Collections.Generic;

namespace Test.Models
{
    public partial class T_ScanCodeRecord
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<int> CreateID { get; set; }
        public Nullable<int> Status { get; set; }
        public string Remark { get; set; }
    }
}
