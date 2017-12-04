using System;
using System.Collections.Generic;

namespace Test.Models
{
    public partial class T_TraceCodes
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public string Batch { get; set; }
        public string ProductSapCode { get; set; }
        public Nullable<int> ProductCategoryID { get; set; }
        public Nullable<int> ProductSpecificationID { get; set; }
        public Nullable<int> Num { get; set; }
        public string Rate { get; set; }
        public Nullable<int> Type { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<int> CreateID { get; set; }
        public Nullable<int> CodeType { get; set; }
    }
}
