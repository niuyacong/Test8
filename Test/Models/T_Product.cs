using System;
using System.Collections.Generic;

namespace Test.Models
{
    public partial class T_Product
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
    }
}
