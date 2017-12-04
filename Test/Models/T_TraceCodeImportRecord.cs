using System;
using System.Collections.Generic;

namespace Test.Models
{
    public partial class T_TraceCodeImportRecord
    {
        public int ID { get; set; }
        public Nullable<int> TraceCodesID { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<int> CreateID { get; set; }
    }
}
