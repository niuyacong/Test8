using System;
using System.Collections.Generic;

namespace Test.Models
{
    public partial class SysMenuFunction
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Resource { get; set; }
        public string Description { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
    }
}
