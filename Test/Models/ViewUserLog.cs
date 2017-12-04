using System;
using System.Collections.Generic;

namespace Test.Models
{
    public partial class ViewUserLog
    {
        public int ID { get; set; }
        public Nullable<int> USID { get; set; }
        public Nullable<System.DateTime> OperatingTime { get; set; }
        public string Contents { get; set; }
        public string UserNo { get; set; }
        public string LoginName { get; set; }
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
        public string SysJobLevelCode { get; set; }
        public Nullable<System.DateTime> LastLoginTime { get; set; }
        public string Token { get; set; }
    }
}
