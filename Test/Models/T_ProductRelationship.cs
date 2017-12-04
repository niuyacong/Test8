using System;
using System.Collections.Generic;

namespace Test.Models
{
    public partial class T_ProductRelationship
    {
        public int ID { get; set; }
        public string PreCode { get; set; }
        public Nullable<long> StartCode { get; set; }
        public Nullable<long> EndCode { get; set; }
        public Nullable<int> TraceCodesID { get; set; }
        public Nullable<int> CodeType { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
    }
}
