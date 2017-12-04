using System;
using System.Collections.Generic;

namespace Test.Models
{
    public partial class ViewTraceCode
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public string Batch { get; set; }
        public string ProductSapCode { get; set; }
        public Nullable<int> ProductCategoryID { get; set; }
        public Nullable<int> ProductSpecificationID { get; set; }
        public Nullable<int> Num { get; set; }
        public string Rate { get; set; }
        public string Type { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<int> CreateID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryCode { get; set; }
        public string SpecificationName { get; set; }
        public string SpecificationCode { get; set; }
        public string SapCode { get; set; }
        public Nullable<int> CodeType { get; set; }
    }
}
