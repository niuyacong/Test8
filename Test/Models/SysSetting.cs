using System;
using System.Collections.Generic;

namespace Test.Models
{
    public partial class SysSetting
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Remark { get; set; }
        public string SysSettingTypeCode { get; set; }
    }
}