using System;
using System.Collections.Generic;

namespace Test.Models
{
    public partial class ViewTraceCodeDetailQR
    {
        public int ID { get; set; }
        public Nullable<int> TraceCodesID { get; set; }
        public string Code { get; set; }
        public Nullable<int> CodeType { get; set; }
        public string Status { get; set; }
        public string Batch { get; set; }
        public string ProductName { get; set; }
    }
}
