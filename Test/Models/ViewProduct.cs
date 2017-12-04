using System;
using System.Collections.Generic;

namespace Test.Models
{
    public partial class ViewProduct
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Nullable<int> ProductCategoryID { get; set; }
        public Nullable<int> ProductSpecificationID { get; set; }
        public string Tankage { get; set; }
        public string Remark { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<int> CreateID { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
        public Nullable<int> UpdateID { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<int> Version { get; set; }
        public string SpecificationName { get; set; }
        public string SpecificationCode { get; set; }
        public string CategoryName { get; set; }
        public string CategoryCode { get; set; }
        public string SapCode { get; set; }
    }
}
