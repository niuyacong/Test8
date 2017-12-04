using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Configuration;
using System.Reflection;

namespace Jeno.App.Common
{
    /// <summary>
    /// SQLServer������
    /// </summary>
    public class SqlServerHelper
    {
        /// <summary>
        /// ����û�
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="databaseName"></param>
        /// <returns></returns>
        public static void AddUser(string connectionString, string userName, string password)
        {
            string commandText = "exec sp_addlogin '" + userName + "','" + password + "'";
            ExecuteNonQuery(connectionString, commandText);
        }
        /// <summary>
        /// �������ݿ�
        /// </summary>
        /// <param name="connectionString">���ݿ����Ӵ�</param>
        /// <param name="databaseName">Ҫ���ӵ������������ݿ�����ơ������Ʊ�����Ψһ�ġ�</param>
        /// <param name="fileNames">���ݿ��ļ����������ƣ�����·����������ָ�� 16 ���ļ�����</param>
        /// <returns></returns>
        public static void AttachDatabase(string connectionString, string databaseName, string[] fileNames)
        {
            string commandText = string.Format("EXEC sp_attach_db '{0}'", databaseName);
            foreach (string fileName in fileNames)
            {
                commandText += string.Format(", '{0}'", fileName);
            }
            ExecuteNonQuery(connectionString, commandText);
        }
        /// <summary>
        /// �������ݿ�
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="databaseName"></param>
        /// <param name="skipChecks"></param>
        /// <returns></returns>
        public static void DetachDatabase(string connectionString, string databaseName, bool skipChecks)
        {
            string commandText = string.Format("EXEC sp_detach_db '{0}', '{1}'", databaseName, skipChecks);
            ExecuteNonQuery(connectionString, commandText);
        }
        /// <summary>
        /// ������ݿ��Ƿ����
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="databaseName"></param>
        /// <returns></returns>
        public static bool ExistsDatabase(string connectionString, string databaseName)
        {
            string commandText = string.Format("use master \n select count(*) from sysdatabases where name = '{0}'", databaseName);
            int count = Convert.ToInt32(ExecuteScalar(connectionString, commandText));
            return count != 0;

        }
        /// <summary>
        /// ȡ�õ�ֵ
        /// </summary>
        /// <param name="commandText"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string connnectionString, string commandText)
        {
            using (SqlConnection con = new SqlConnection(connnectionString))
            {
                SqlCommand command = new SqlCommand(commandText, con);
                con.Open();
                object returnValue = command.ExecuteScalar();
                return returnValue;
            }
        }
        /// <summary>
        /// ִ����䷵�����ݼ�
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="commandText"></param>
        /// <returns></returns>
        public static DataSet ExecuteDataSet(string connectionString, string commandText)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter(commandText, connectionString);
            DataSet dsResult = new DataSet();
            dataAdapter.Fill(dsResult);
            return dsResult;
        }
        /// <summary>
        /// ִ����䷵�����ݱ�
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="commandText"></param>
        /// <returns></returns>
        public static DataTable ExecuteDataTable(string connectionString, string commandText)
        {
            SqlDataAdapter dataAdapter = new SqlDataAdapter(commandText, connectionString);
            DataTable dtResult = new DataTable();
            dataAdapter.Fill(dtResult);
            return dtResult;
        }
        /// <summary>
        /// ִ��SQL���
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="commandText"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string connectionString, string commandText)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(commandText, con);
                sqlCommand.CommandTimeout = GetConnectionTimeout();
                sqlCommand.CommandType = CommandType.Text;
                try
                {
                    con.Open();
                    int returnValue = sqlCommand.ExecuteNonQuery();
                    return returnValue;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        /// <summary>
        /// ɾ�����ݿ�
        /// </summary>
        /// <param name="connectionString">���ݿ����Ӵ�</param>
        /// <param name="databaseName">���ݿ���</param>
        /// <returns></returns>
        public static void DropDatabase(string connectionString, string databaseName)
        {
            string commandText = string.Format("drop database {0}", databaseName);
            ExecuteNonQuery(connectionString, commandText);
        }
        /// <summary>
        /// �ָ����ݿ�
        /// </summary>
        /// <param name="connectionString">���ݿ����Ӵ�</param>
        /// <param name="databaseName">���ݿ���</param>
        /// <param name="backupDatabaseFilePath">�����ļ�·��</param>
        /// <param name="databaseLogicalDataName">�����ļ��߼���</param>
        /// <param name="databaseDataFilePath">�����ļ�����·��</param>
        /// <param name="databaseLogicalLogName">��־�ļ��߼���</param>
        /// <param name="databaseLogFilePath">��־�ļ�����·��</param>
        /// <returns></returns>
        public static void RestoreDatabase(string connectionString, string databaseName, string backupDatabaseFilePath, string databaseLogicalDataName, string databaseDataFilePath, string databaseLogicalLogName, string databaseLogFilePath)
        {
            string restoreCommandText = string.Format(@"RESTORE DATABASE {0} FROM DISK='{1}' WITH MOVE '{2}' TO '{3}',MOVE '{4}' TO '{5}',replace", databaseName, backupDatabaseFilePath, databaseLogicalDataName, databaseDataFilePath, databaseLogicalLogName, databaseLogFilePath);
            ExecuteNonQuery(connectionString, restoreCommandText);
        }
        /// <summary>
        /// ���������ݿ��߼��ļ�����
        /// </summary>
        /// <param name="connectionString">���ݿ����Ӵ�</param>
        /// <param name="databaseName">���ݿ���</param>
        /// <param name="oldName">��ǰ�߼��ļ���</param>
        /// <param name="newName">���߼��ļ���</param>
        /// <returns></returns>
        public static void RenameLogicalFileName(string connectionString, string databaseName, string oldName, string newName)
        {
            string renameCommandText = string.Format("ALTER DATABASE {0} MODIFY FILE ( NAME = '{1}', NEWNAME = '{2}'", databaseName, oldName, newName);
            ExecuteNonQuery(connectionString, renameCommandText);
        }
        /// <summary>
        /// �������ݿ�
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="databaseName"></param>
        /// <param name="backupFilePath"></param>
        /// <returns></returns>
        public static void BackupDatabase(string connectionString, string databaseName, string backupFilePath)
        {
            string backupCommandText = string.Format("backup database {0} to disk='{1}' WITH INIT", databaseName, backupFilePath);
            ExecuteNonQuery(connectionString, backupCommandText);
        }
        /// <summary>
        /// ��ԭ���ݿ�
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="databaseName"></param>
        /// <param name="backupFilePath"></param>
        /// <returns></returns>
        public static void RestoreDatabase(string connectionString, string databaseName, string backupFilePath)
        {
            string restoreCommandText = string.Format("restore database {0} from disk='{1}'", databaseName, backupFilePath);
            ExecuteNonQuery(connectionString, restoreCommandText);
        }
        /// <summary>
        /// ������ݿ�����
        /// </summary>
        /// <param name="masterConnectionString"></param>
        /// <param name="databaseName"></param>
        /// <returns></returns>
        public static void ClearDatabaseConnection(string masterConnectionString, string databaseName)
        {
            DataTable dtWho = ExecuteDataTable(masterConnectionString, "sp_who");
            if (dtWho == null)
            {
                return;
            }
            //ȡ�����ӵ�ָ�����ݿ��ϵͳ�����б�
            List<string> spidList = new List<string>();
            foreach (DataRow dr in dtWho.Rows)
            {
                if (dr["dbname"] == DBNull.Value)
                {
                    continue;
                }
                string dbname = dr["dbname"].ToString();
                if (dbname == databaseName)
                {
                    string spid = dr["spid"].ToString();
                    spidList.Add(spid);
                }
            }
            //��ֹ����
            foreach (string spid in spidList)
            {
                string killCommandText = string.Format("kill {0}", spid);
                ExecuteNonQuery(masterConnectionString, killCommandText);
            }
        }
        /// <summary>
        /// ȡ�����ݿ������ַ���
        /// </summary>
        /// <param name="SSPIEnabled">�Ƿ񼯳���֤</param>
        /// <param name="server">������</param>
        /// <param name="databaseName">���ݿ�</param>
        /// <param name="userName">�û���</param>
        /// <param name="password">����</param>
        /// <returns></returns>
        public static string GetConnectionString(bool SSPIEnabled, string server, string databaseName, string userName, string password)
        {
            int connectionTimeout = GetConnectionTimeout();
            return GetConnectionString(SSPIEnabled, server, databaseName, userName, password, connectionTimeout);
        }
        /// <summary>
        /// ȡ�����ݿ������ַ���
        /// </summary>
        /// <param name="SSPIEnabled">�Ƿ񼯳���֤</param>
        /// <param name="server">������</param>
        /// <param name="databaseName">���ݿ�</param>
        /// <param name="userName">�û���</param>
        /// <param name="password">����</param>
        /// <returns></returns>
        public static string GetConnectionString(bool SSPIEnabled, string server, string databaseName, string userName, string password, int connectionTimeout)
        {
            string sRet = "";
            if (!SSPIEnabled)
            {
                if (null == server || server.Trim().Length <= 0 ||
                    null == userName || userName.Trim().Length <= 0 ||
                    null == databaseName || databaseName.Trim().Length <= 0)
                {
                    return null;
                }
                sRet = string.Format("DATA SOURCE={0};INITIAL CATALOG={1};user id={2};password={3};Connect Timeout={4}", server, databaseName, userName, password, connectionTimeout);
            }
            else
            {
                if (null == server || server.Trim().Length <= 0 ||
                    null == databaseName || databaseName.Trim().Length <= 0)
                {
                    return null;
                }
                sRet = string.Format("DATA SOURCE={0}; INITIAL CATALOG={1};Integrated Security=SSPI;Connect Timeout={2}", server, databaseName, connectionTimeout);
            }
            sRet += "; Max Pool Size=10000";
            return sRet;
        }
        private static int GetConnectionTimeout()
        {
            if (ConfigurationManager.AppSettings["connectionTimeout"] != null)
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["connectionTimeout"]);
            }
            return 60;
        }
        /// <summary>
        /// ִ�нű��ļ�
        /// </summary>
        /// <param name="trustedConnection"></param>
        /// <param name="server"></param>
        /// <param name="databaseName"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="scriptFile"></param>
        /// <param name="outputFile"></param>
        public static void ExecuteScript(bool trustedConnection, string server, string databaseName, string userName, string password, string scriptFile, string outputFile)
        {
            string arguments = string.Empty;
            if (trustedConnection)
            {
                arguments = string.Format("-S {0} -d {1} -E -b -i \"{2}\" -o \"{3}\"", server, databaseName, scriptFile, outputFile);
            }
            else
            {
                arguments = string.Format("-S {0} -d {1} -b -U {2} -P {3} -i \"{4}\" -o \"{5}\"", server, databaseName, userName, password, scriptFile, outputFile);
            }
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "osql";
            startInfo.Arguments = arguments;
            startInfo.CreateNoWindow = true;
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            Process process = Process.Start(startInfo);
            process.WaitForExit();
        }
        /// <summary>
        /// �������ݿ�����
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static bool TestConnection(string connectionString)
        {
            if (connectionString == null)
            {
                return false;
            }
            SqlConnection oCon = null;
            try
            {
                oCon = new SqlConnection(connectionString);
                oCon.Open();
                return true;
            }
            catch (SqlException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                if (null != oCon)
                {
                    oCon.Close();
                }
            }
        }
        /// <summary>
        /// ������־
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="databaseName"></param>
        public static void DumpLog(string connectionString, string databaseName)
        {
            string backupCommandText = string.Format("BACKUP LOG [{0}] WITH NO_LOG", databaseName);
            string dumpCommandText = string.Format("DUMP TRANSACTION [{0}] WITH NO_LOG ", databaseName);
            string shrinkCommandText = string.Format("DBCC SHRINKDATABASE({0})", databaseName);
            ExecuteNonQuery(connectionString, backupCommandText);
            ExecuteNonQuery(connectionString, dumpCommandText);
            ExecuteNonQuery(connectionString, shrinkCommandText);
        }
        /// <summary>
        /// �ؽ�����
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="databaseName"></param>
        public static void DBReIndex(string connectionString, string databaseName)
        {
            //ȡ�������û���
            List<string> tables = GetUserTables(connectionString);
            //�ؽ�����
            foreach (string tableName in tables)
            {
                ReIndexTable(connectionString, tableName);
            }
        }
        /// <summary>
        /// �ؽ�ָ��������
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="tableName"></param>
        private static void ReIndexTable(string connectionString, string tableName)
        {
            string commandText = string.Format("DBCC DBREINDEX('{0}','',90)", tableName);
            ExecuteNonQuery(connectionString, commandText);
        }
        /// <summary>
        /// ������ݿ�
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="databaseName"></param>
        public static void CheckDB(string masterConnectionString, string databaseName)
        {
            //�����������
            ClearDatabaseConnection(masterConnectionString, databaseName);
            string setSingleUserModeCommmandText = string.Format("EXEC sp_dboption '{0}', 'single user', 'true'", databaseName);
            string checkDBCommandText = string.Format("dbcc checkdb ('{0}',REPAIR_ALLOW_DATA_LOSS)", databaseName);
            string setMultiUserModeCommmandText = string.Format("EXEC sp_dboption '{0}', 'single user', 'false'", databaseName);
            ExecuteNonQuery(masterConnectionString, setSingleUserModeCommmandText);
            ExecuteNonQuery(masterConnectionString, checkDBCommandText);
            ExecuteNonQuery(masterConnectionString, setMultiUserModeCommmandText);
        }
        /// <summary>
        /// ȡ�������û���
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static List<string> GetUserTables(string connectionString)
        {
            string commandText = "select * from sysobjects where xtype='u' and name <> 'dtproperties'";
            DataTable dtTable = ExecuteDataTable(connectionString, commandText);
            List<string> tableList = new List<string>();
            foreach (DataRow drCurrent in dtTable.Rows)
            {
                tableList.Add(drCurrent["name"].ToString());
            }
            return tableList;
        }
        /// <summary>
        /// ȡ�����ݿ��б�
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static DataTable GetDatabases(string connectionString)
        {
            string commandText = "exec sp_helpdb";
            return ExecuteDataTable(connectionString, commandText);

        }
        /// <summary>
        /// ȡ�����б�
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static DataTable GetTables(string connectionString)
        {
            string commandText = "select * from sysobjects where xtype='u' and name <> 'dtproperties' order by name";
            return ExecuteDataTable(connectionString, commandText);
        }
        /// <summary>
        /// ȡ�����б�
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static DataTable GetViews(string connectionString)
        {
            string commandText = "select * from sysobjects where xtype='v' and substring([name], 1, 3) <> 'sys'";
            return ExecuteDataTable(connectionString, commandText);
        }
        /// <summary>
        /// ȡ�����б�
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public static DataTable GetProcedures(string connectionString)
        {
            string commandText = "select * from sysobjects where xtype='p' and substring([name], 1,3) <> 'dt_'";
            return ExecuteDataTable(connectionString, commandText);
        }
        /// <summary>
        /// ȡ��ָ���������ֶκ͹��������
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static DataTable GetForeignKeyTable(string connectionString, string tableName)
        {
            string commandText = string.Format(@"
                select distinct t1.fTableName,t1.name as fName,t2.rTableName,t2.name as rName
                from
                (select OBJECT_NAME(f.fkeyid) as ftableName, col.name, f.constid as temp
                 from syscolumns col,sysforeignkeys f
                 where f.fkeyid=col.id
                 and f.fkey=col.colid
                 and f.constid in
                 ( select distinct(id) 
                   from sysobjects
                   where OBJECT_NAME(parent_obj)='{0}'
                   and xtype='F'
                  )
                 ) as t1 ,
                (select OBJECT_NAME(f.rkeyid) as rtableName,col.name, f.constid as temp
                 from syscolumns col,sysforeignkeys f
                 where f.rkeyid=col.id
                 and f.rkey=col.colid
                 and f.constid in
                 ( select distinct(id)
                   from sysobjects
                   where OBJECT_NAME(parent_obj)='{0}'
                   and xtype='F'
                 )
                ) as t2
                where t1.temp=t2.temp
                ", tableName);
            return ExecuteDataTable(connectionString, commandText);
        }

        /// <summary>
        /// ȡ��Ψһ���ֶ��б�
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static List<string> GetUniqueColumnList(string connectionString, string tableName)
        {
            DataSet dsConstraint = ExecuteDataSet(connectionString, string.Format("exec sp_helpconstraint '{0}'", tableName));
            List<string> lstUniqueColumn = new List<string>();
            foreach (DataRow drCurrent in dsConstraint.Tables[1].Rows)
            {
                if (drCurrent["constraint_type"].ToString().IndexOf("UNIQUE", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    lstUniqueColumn.Add(drCurrent["constraint_keys"].ToString());
                }
            }
            return lstUniqueColumn;
        }
        /// <summary>
        /// ȡ���ֶα�
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static DataTable GetColumns(string connectionString, string tableName)
        {
            string commandText = string.Format("exec sp_columns '{0}'", tableName);
            return ExecuteDataTable(connectionString, commandText);
        }
        /// <summary>
        /// �����Ƿ����
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="databaseName"></param>
        /// <returns></returns>
        public static bool ExistsTable(string connectionString, string tableName)
        {
            string commandText = string.Format("select count(*) from sysobjects where xtype='u' and name='{0}'", tableName);
            int count = Convert.ToInt32(ExecuteScalar(connectionString, commandText));
            return count != 0;
        }
        /// <summary>
        /// ȡ��������
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static DataTable GetPrimaryKeyTable(string connectionString, string tableName)
        {
            string commandText = string.Format("exec sp_pkeys '{0}'", tableName);
            DataTable dtPrimaryKey = ExecuteDataTable(connectionString, commandText);
            return dtPrimaryKey;
        }
        /// <summary>
        /// ȡ�������б�
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static List<string> GetPrimaryKeyList(string connectionString, string tableName)
        {
            DataTable dtPrimaryKey = GetPrimaryKeyTable(connectionString, tableName);
            List<string> lstPrimaryKey = new List<string>();
            foreach (DataRow drCurrent in dtPrimaryKey.Rows)
            {
                lstPrimaryKey.Add(drCurrent["COLUMN_NAME"].ToString());
            }
            return lstPrimaryKey;
        }
        #region //----------------------------> sql�����ַ���ѯ ��ֹ Sql ע�빥��

        /// <summary>
        /// sql�����ַ���ѯ ��ֹ Sql ע�빥��
        /// </summary>
        /// <param name="source">���жϵ�ϵͳ��Ϣ</param>
        /// <returns> true ������ false ����</returns>
        public static bool ProcessSqlStr(string source)
        {
            bool ReturnValue = true;
            try
            {
                if (!string.IsNullOrEmpty(source))
                {
                    string SqlStr = @"'|,|(|;|)|select*|and'|or'|insertinto|deletefrom|altertable|update|createtable|createview|dropview|cr
                    //eateindex|dropindex|createprocedure|dropprocedure|createtrigger|droptrigger|createschema|dropschema|createdomain|alterdomain|dropdomain|);|select@|declare@|print@|char(|select|where|create|xp_|sp_|0x_|execute@|exec@|net|xp_cmdshell|truncate@|table";
                    string[] anySqlStr = SqlStr.Split('|');
                    foreach (string item in anySqlStr)
                    {
                        if ((source.Trim().ToLower().IndexOf(item.Trim()) > -1) || (source.Trim().ToLower().IndexOf(item.Trim()) > -1))
                        {
                            return false;
                        }
                    }
                }
            }
            catch
            {
                ReturnValue = false;
            }
            return ReturnValue;
        }


        /// <summary>
        /// sql�����ַ���ѯ ��ֹ Sql ע�빥����û�ж���
        /// </summary>
        /// <param name="source">���жϵ�ϵͳ��Ϣ</param>
        /// <returns> true ������ false ����</returns>
        public static bool ProcessSqlStrLt(string source)
        {
            bool ReturnValue = true;
            try
            {
                if (!string.IsNullOrEmpty(source))
                {
                    string SqlStr = @"(|;|)|select*|and'|or'|insertinto|deletefrom|altertable|update|createtable|createview|dropview|cr
                    //eateindex|dropindex|createprocedure|dropprocedure|createtrigger|droptrigger|createschema|dropschema|createdomain|alterdomain|dropdomain|);|select@|declare@|print@|char(|select|where|create|xp_|sp_|0x_|execute@|exec@|net|xp_cmdshell|truncate@|table";
                    string[] anySqlStr = SqlStr.Split('|');
                    foreach (string item in anySqlStr)
                    {
                        if ((source.Trim().ToLower().IndexOf(item.Trim()) > -1) || (source.Trim().ToLower().IndexOf(item.Trim()) > -1))
                        {
                            return false;
                        }
                    }
                }
            }
            catch
            {
                ReturnValue = false;
            }
            return ReturnValue;
        }
        #endregion //----------------------------> sql�����ַ���ѯ ��ֹ Sql ע�빥��
        #region //----------------------------> sql�����ַ���ѯ ��ֹ Sql ע�빥��

        /// <summary>
        /// sql�����ַ���ѯ ��ֹ Sql ע�빥��
        /// </summary>
        /// <param name="source">���жϵ�ϵͳ��Ϣ</param>
        /// <returns> true ������ false ����</returns>
        public static bool ProcessSqlStrByList(List<string> li)
        {
            bool result = true;

            if (li.Count > 0)
            {
                for (int i = 0; i < li.Count; i++)
                {
                    if (!ProcessSqlStr(li[i]))
                    {
                        result = false;
                        break;
                    };
                }
            }

            return result;
        }

        #endregion //----------------------------> sql�����ַ���ѯ ��ֹ Sql ע�빥��

        #region  //----------------------------> ���ض�������
        private static T ExecReader<T>(SqlDataReader dr)
        {
            T obj = default(T);
            try
            {
                Type type = typeof(T);
                obj = Activator.CreateInstance<T>();
                PropertyInfo[] propertyInfo = type.GetProperties();
                int fileCount = dr.FieldCount;
                for (int i = 0; i < fileCount; i++)
                {
                    string drName = dr.GetName(i);
                    foreach (PropertyInfo propertyInfos in propertyInfo)
                    {
                        string ProName = propertyInfos.Name;
                        if (string.Equals(drName, ProName, StringComparison.InvariantCultureIgnoreCase))
                        {

                            object dbValue = dr.GetValue(i);
                            if (dbValue != null && dbValue != DBNull.Value)
                            {

                                propertyInfos.SetValue(obj, dbValue, null);
                            }

                        }

                    }

                }

            }
            catch (Exception ex)
            {
                //LogHelper.WriteLine("------------------ ExecReader<T> Result-------------------->" + ex.Message);
                throw ex;
            }

            return obj;
        }
        #endregion

        #region  //----------------------------> ִ��ͨ����ɾ��
        public static int ExecuteNonQuery<T>(string cmdText, CommandType cmdType, params SqlParameter[] args)
        {
            int result = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(AppConfig.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                    {
                        cmd.CommandType = cmdType;
                        cmd.Parameters.AddRange(args);
                        conn.Open();
                        result = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLine("------------------ ExecuteNonQuery<T> Result-------------------->" + ex.Message);
                throw ex;
            }
            return result;
        }
        #endregion

        #region  //---------------------------->  ִ�з���һ��ʵ�����
        public static T ExecOject<T>(string cmdText, CommandType cmdType, params SqlParameter[] args)
        {
            T obj = default(T);
            try
            {
                using (SqlConnection conn = new SqlConnection(AppConfig.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                    {
                        cmd.CommandType = cmdType;
                        cmd.Parameters.AddRange(args);
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            while (reader.Read())
                            {
                                obj = ExecReader<T>(reader);
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLine("------------------  ExecOject<T> Result-------------------->" + ex.Message);
                throw ex;
            }
            return obj;
        }
        #endregion

        #region  //---------------------------->  ִ�ж�����ѯ��Ϣ
        public static List<T> ExecList<T>(string cmdText, CommandType cmdType, params SqlParameter[] args)
        {
            List<T> list = new List<T>();
            try
            {
                using (SqlConnection conn = new SqlConnection(AppConfig.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                    {
                        cmd.CommandType = cmdType;
                        cmd.Parameters.AddRange(args);
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {

                            while (reader.Read())
                            {
                                T obj = ExecReader<T>(reader);
                                list.Add(obj);

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLine("------------------  ExecList<T> Result-------------------->" + ex.Message);
                throw ex;
            }
            return list;
        }
        #endregion

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }

    public class SqlParam : IDisposable
    {
        public string FieldName
        {
            get;
            set;
        }

        public DbType DataType
        {
            get;
            set;
        }

        public object FiledValue
        {
            get;
            set;
        }

        public SqlParam()
        {
        }

        public SqlParam(string _FieldName, object _FiledValue)
            : this(_FieldName, DbType.AnsiString, _FiledValue)
        {
        }

        public SqlParam(string _FieldName, DbType _DbType, object _FiledValue)
        {
            this.FieldName = _FieldName;
            this.DataType = _DbType;
            this.FiledValue = _FiledValue;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}