using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Test.Areas.导出
{
    public class ExcelImportController : Controller
    {
        //
        // GET: /导出/ExcelImport/

        public ActionResult Index()
        {
            return View();
        }
        ///停用了，需要更新插件
        /// <summary>
        /// 把Excel中的数据导入到DataTable。(根据excel路径和sheet名称，返回excel的DataTable)
        /// </summary>
        public static DataTable GetExcelDataTable(string path, string tname)
        {
            /*Office 2007*/
            string ace = "Microsoft.ACE.OLEDB.12.0";
            /*Office 97 - 2003*/
            string jet = "Microsoft.Jet.OLEDB.4.0";
            string xl2007 = "Excel 12.0 Xml";
            string xl2003 = "Excel 8.0";
            string imex = "IMEX=1";
            /* csv */
            string text = "text";
            string fmt = "FMT=Delimited";
            string hdr = "Yes";
            string conn = "Provider={0};Data Source={1};Extended Properties=\"{2};HDR={3};{4}\";";
            string select = string.Format("SELECT * FROM [{0}$A:AC]", tname);
            //string select = sql;
            string ext = Path.GetExtension(path);
            bool IsNull = false;
            OleDbDataAdapter oda;
            DataTable dt = new DataTable("data");
            switch (ext.ToLower())
            {
                case ".xlsx":
                    conn = String.Format(conn, ace, Path.GetFullPath(path), xl2007, hdr, imex);
                    break;
                case ".xls":
                    conn = String.Format(conn, jet, Path.GetFullPath(path), xl2003, hdr, imex);
                    break;
                case ".csv":
                    conn = String.Format(conn, jet, Path.GetDirectoryName(path), text, hdr, fmt);
                    //sheet = Path.GetFileName(path);
                    break;
                default:
                    throw new Exception("File Not Supported!");
            }

            OleDbConnection con = new OleDbConnection(conn);
            con.Open();
            //select = string.Format(select, sql);
            oda = new OleDbDataAdapter(select, con);
            //将Excel里面有表内容装载到内存表中！
            oda.Fill(dt);
            //过滤空白行   
            DataTable newdt = dt.Clone();   //克隆一个结构一样的表

            con.Close();
            return dt;
        }
    }
}
