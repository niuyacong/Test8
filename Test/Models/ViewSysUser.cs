using System;
using System.Collections.Generic;

namespace Test.Models
{
    public partial class ViewSysUser
    {
        public int ID { get; set; }
        public string UserNo { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public Nullable<int> SysOrganizationID { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public string Image { get; set; }
        public string PasswordFormat { get; set; }
        public string PasswordSalt { get; set; }
        public string MobilePhone { get; set; }
        public string Telephone { get; set; }
        public string EmailAddress { get; set; }
        public string DisplayOrder { get; set; }
        public Nullable<int> Sex { get; set; }
        public Nullable<bool> Enabled { get; set; }
        public string SysOrganizationName { get; set; }
        public string SysJobLevelCode { get; set; }
        public string LevelName { get; set; }
    }
}
