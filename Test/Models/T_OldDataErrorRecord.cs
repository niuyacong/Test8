using System;
using System.Collections.Generic;

namespace Test.Models
{
    public partial class T_OldDataErrorRecord
    {
        public int Id { get; set; }
        public string MATERCODE { get; set; }
        public string BOXCODE { get; set; }
        public string BOTTLE_NUMBER { get; set; }
        public string PRODUCT_NAME { get; set; }
        public string ErrorInfo { get; set; }
        public string CreateTime { get; set; }
    }
}
