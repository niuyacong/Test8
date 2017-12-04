using System;
using System.Collections.Generic;

namespace Test.Models
{
    public partial class T_ProductSpecification
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public Nullable<int> ProductCategoryID { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<int> CreateID { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
        public Nullable<int> UpdateID { get; set; }
        public string SapCode { get; set; }
    }
}
