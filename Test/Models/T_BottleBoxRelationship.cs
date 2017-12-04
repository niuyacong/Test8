using System;
using System.Collections.Generic;

namespace Test.Models
{
    public partial class T_BottleBoxRelationship
    {
        public int ID { get; set; }
        public string BoxNumber { get; set; }
        public string BottleNumber { get; set; }
        public string FromNo { get; set; }
        public Nullable<System.DateTime> ScanTime { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<int> CreateID { get; set; }
    }
}
