using System;
using System.Collections.Generic;

namespace Test.Models
{
    public partial class T_TraceCodeDetail
    {
        public int ID { get; set; }
        public Nullable<int> TraceCodesID { get; set; }
        public string Code { get; set; }
        public Nullable<int> CodeType { get; set; }
        public Nullable<int> Status { get; set; }
    }
}
