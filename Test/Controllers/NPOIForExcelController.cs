using Jeno.App.Common;
using Jeno.App.Common.Tool;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Test.Controllers
{
    public class NPOIForExcelController : Controller
    {
        //
        // GET: /NPOIForExcel/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetWorkHoursListForExcel()
        {
            DateTime StartTime = DateTime.MinValue;
            DateTime EndTime = DateTime.MaxValue;
            int projectID = 0;
            string WorkName = "";
            int SysOrganizationID = 0;
            string sql = @"SELECT 
                           Workhours as 工时
                           ,SysOrganization.Name  as 部门
                           ,sysUser.Name  as 姓名
                           ,T_Project.ProjectNO as 项目编号
                           ,T_Project.ProjectName as 项目名称
                           from (select sum(WorkHour)as Workhours,WorkID,T_ProjectID from 
                          (select * from ViewT_WorkHours where WorkStatus=1";

            //时间
            if (!string.IsNullOrEmpty(Request["StartTime"]) && !string.IsNullOrEmpty(Request["EndTime"]))
            {
                StartTime = Convert.ToDateTime(Request["StartTime"]);
                EndTime = Convert.ToDateTime(Request["EndTime"]);
                sql += "and WorkDate between '" + StartTime + "' and '" + EndTime + "'";
            }
            //项目
            if (Request["ProjectID"] != null)
            {
                projectID = int.Parse(Request["ProjectID"]);
                sql += "and T_ProjectID='" + projectID + "'";
            }
            //员工ID
            if (Request["WorkName"] != null)
            {
                WorkName = Request["WorkName"];
                sql += "and UserName='" + WorkName + "'";
            }
            //部门ID
            if (Request["SysOrganizationID"] != null)
            {
                SysOrganizationID = int.Parse(Request["SysOrganizationID"]);
                sql += "and SysOrganizationID='" + SysOrganizationID + "'";
            }
            sql += @") as a  group by WorkID,T_ProjectID) b
                   left join [sysUser] on sysUser.ID=b.WorkID
                   left join SysOrganization on [sysUser].DepartmentID=SysOrganization.ID
                   left join T_Project on T_Project.ID=b.T_ProjectID";
            DataTable thedt = DBHelper.ExecuteDataTable(sql);
            NPOIHelper.ExportDT(thedt, "0");
            return File(NPOIHelper.ExportManagerDecompose(thedt), "application/vnd.ms-excel", "工时统计" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls");
        }
    }
}
