using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net;

namespace Jeno.App.Common
{
    /// <summary>
    /// 数据库帮助类
    /// </summary>
    public class DBHelper
    {
       
        /// <summary>
        /// 执行语句
        /// </summary>
        /// <param name="commandText"></param>
        public static int ExecuteNonQuery(string commandText)
        {
            return ExecuteNonQuery(AppConfig.ConnectionString, commandText);
        }
        /// <summary>
        /// 执行语句
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="commandText"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string connectionString, string commandText)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(commandText, conn);
                command.CommandTimeout = conn.ConnectionTimeout;
                conn.Open();
                return command.ExecuteNonQuery();
            }
        }
        /// <summary>
        /// 执行语句
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="commandText"></param>
        public static int ExecuteNonQuery(IDbTransaction transaction, string commandText)
        {
            SqlTransaction sqlTransaction = transaction as SqlTransaction;
            if (sqlTransaction == null)
            {
                throw new ArgumentNullException("transaction");
            }
            SqlCommand command = new SqlCommand(commandText, sqlTransaction.Connection, sqlTransaction);
            command.CommandTimeout = sqlTransaction.Connection.ConnectionTimeout;
            return command.ExecuteNonQuery();
        }
        /// <summary>
        /// 取得单值
        /// </summary>
        /// <param name="commandText"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string commandText)
        {
            return ExecuteScalar(AppConfig.ConnectionString, commandText);
        }

        /// <summary>
        /// 取得单值
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="commandText"></param>
        /// <returns></returns>
        public static object ExecuteScalar(string connectionString, string commandText)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(commandText, conn);
                command.CommandTimeout = conn.ConnectionTimeout;
                conn.Open();
                object returnValue = command.ExecuteScalar();
                return returnValue;
            }
        }
        public static object ExecuteScalarSAP(string commandText)
        {
            return ExecuteScalarSAP(AppConfig.MainConnectionString, commandText);
        }

        public static object ExecuteScalarSAP(string connectionString, string commandText)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(commandText, conn);
                command.CommandTimeout = conn.ConnectionTimeout;
                conn.Open();
                object returnValue = command.ExecuteScalar();
                return returnValue;
            }
        }

        /// <summary>
        /// 取得单值（事务）
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="commandText"></param>
        /// <returns></returns>
        public static object ExecuteScalar(IDbTransaction transaction, string commandText)
        {
            SqlTransaction sqlTransaction = transaction as SqlTransaction;
            if (sqlTransaction == null)
            {
                return null;
            }
            SqlCommand command = new SqlCommand(commandText, sqlTransaction.Connection, sqlTransaction);
            command.CommandTimeout = sqlTransaction.Connection.ConnectionTimeout;
            return command.ExecuteScalar();
        }
        /// <summary>
        /// 取得数据表
        /// </summary>
        /// <param name="commandText"></param>
        /// <returns></returns>
        public static DataTable ExecuteDataTable(string commandText)
        {
            return ExecuteDataTable(AppConfig.ConnectionString, commandText);
        }
        /// <summary>
        /// 取得数据表
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="commandText"></param>
        /// <returns></returns>
        public static DataTable ExecuteDataTable(string connectionString, string commandText)
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(commandText, connectionString))
            {
                da.Fill(dt);
                return dt;
            }
        }
        /// <summary>
        /// 取得数据表
        /// </summary>
        /// <param name="commandText"></param>
        /// <returns></returns>
        public static DataTable ExecuteDataTable(IDbTransaction transaction, string commandText)
        {
            if (transaction == null)
            {
                return null;
            }
            SqlConnection con = (SqlConnection)transaction.Connection;
            SqlCommand command = new SqlCommand(commandText, con);
            command.CommandTimeout = con.ConnectionTimeout;
            command.Transaction = (SqlTransaction)transaction;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            return dt;
        }
        /// <summary>
        /// 取得数据表
        /// </summary>
        /// <param name="commandText"></param>
        /// <returns></returns>
        public static DataSet ExecuteDataSet(string commandText)
        {
            return ExecuteDataSet(AppConfig.ConnectionString, commandText);
        }
        /// <summary>
        /// 取得数据表
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="commandText"></param>
        /// <returns></returns>
        public static DataSet ExecuteDataSet(string connectionString, string commandText)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(commandText, connectionString);
            da.Fill(ds);
            return ds;
        }
        /// <summary>
        /// 取得数据表
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static DataTable GetDataTable(string tableName)
        {
            string commandText = string.Format("select * from [{0}]", tableName);
            return ExecuteDataTable(commandText);
        }
        /// <summary>
        /// 取得数据表
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static DataTable GetDataTable(string tableName, string condition)
        {
            return GetDataTable(tableName, condition, null);
        }
        /// <summary>
        /// 取得数据表
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="condition"></param>
        /// <param name="orderBy"></param>
        /// <returns></returns>
        public static DataTable GetDataTable(string tableName, string condition, string orderBy)
        {
            string commandText = string.Format("select * from [{0}] {1} {2}", tableName, string.IsNullOrEmpty(condition) ? "" : " where " + condition, string.IsNullOrEmpty(orderBy) ? "" : " order by " + orderBy);
            return ExecuteDataTable(commandText);
        }
        /// <summary>
        /// 开始事务
        /// </summary>
        /// <returns></returns>
        public static IDbTransaction BeginTransaction()
        {
            return BeginTransaction(AppConfig.ConnectionString);
        }
        /// <summary>
        /// 开始事务
        /// </summary>
        /// <returns></returns>
        public static IDbTransaction BeginTransaction(string connectionString)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlTransaction transaction = con.BeginTransaction();
            return transaction;
        }
        /// <summary>
        /// 提交事务
        /// </summary>
        /// <param name="transaction"></param>
        public static void CommitTransaction(IDbTransaction transaction)
        {
            SqlConnection con = (SqlConnection)transaction.Connection;
            transaction.Commit();
            con.Close();
        }
        /// <summary>
        /// 回滚事务
        /// </summary>
        /// <param name="transaction"></param>
        public static void RollbackTransaction(IDbTransaction transaction)
        {
            SqlConnection con = (SqlConnection)transaction.Connection;
            transaction.Rollback();
            con.Close();
        }
        /// <summary>
        /// 数据库是否在本地
        /// </summary>
        /// <param name="databaseServer"></param>
        /// <returns></returns>
        public static bool IsLocalDatabase(string databaseServer)
        {
            if (databaseServer.StartsWith("."))
            {
                return true;
            }
            if (databaseServer.ToLower().StartsWith("(local)"))
            {
                return true;
            }
            string serverAddress = databaseServer;
            if (databaseServer.Contains(@"\"))
            {
                serverAddress = serverAddress.Substring(0, serverAddress.IndexOf(@"\"));
            }
            if (serverAddress.ToLower() == Environment.MachineName.ToLower())
            {
                return true;
            }
            IPAddress[] ipAddressArray = Dns.GetHostAddresses(Environment.MachineName);
            foreach (IPAddress ipAddress in ipAddressArray)
            {
                if (ipAddress.ToString() == serverAddress)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 删除表
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="tableName"></param>
        public static void DropTable(IDbTransaction transaction, string tableName)
        {
            string commandText = string.Format(@"if exists (select * from sysobjects where id = object_id(N'[{0}]') and OBJECTPROPERTY(id, N'IsUserTable') = 1)
                drop table [{0}]",
                tableName);
            ExecuteNonQuery(transaction, commandText);
        }
        /// <summary>
        /// 执行查询语句，返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public static DataSet Query(string SQLString, string ConnectionString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        da.Fill(ds, "ds");
                        cmd.Parameters.Clear();
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    return ds;
                }
            }
        }
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, string cmdText, SqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;//cmdType;
          
            if (cmdParms != null)
            {
                foreach (SqlParameter parameter in cmdParms)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }
        }

        #region DataTable批量添加(有事务) By lijingzhou 2017/2/6
        /// <summary>
        /// DataTable批量添加(有事务)
        /// </summary>
        /// <param name="Table">数据源</param>
        /// <param name="DestinationTableName">目标表即需要插入数据的数据表名称如"User_1"</param>
        /// <param name="AppConnectionString">数据库连接地址</param>
        public static bool SaleMySqlBulkCopy(DataTable Table, string DestinationTableName,string AppConnectionString)
        {
            bool Bool = true;
            //数据库连接串
            string ConnectionString = AppConnectionString;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                using (SqlTransaction Tran = con.BeginTransaction())//应用事物
                {
                    using (SqlBulkCopy Copy = new SqlBulkCopy(con, SqlBulkCopyOptions.KeepIdentity, Tran))
                    {
                        Copy.DestinationTableName = DestinationTableName;//指定目标表
                        SqlBulkCopyColumnMapping[] Mapping = GetMapping(Table);//获取映射关系
                        if (Mapping != null)
                        {
                            //如果有数据
                            foreach (SqlBulkCopyColumnMapping Map in Mapping)
                            {
                                Copy.ColumnMappings.Add(Map);
                            }
                        }
                        try
                        {
                            Copy.WriteToServer(Table);//批量添加
                            Tran.Commit();//提交事务
                        }
                        catch
                        {
                            Tran.Rollback();//回滚事务
                            Bool = false;
                        }
                    }
                }
                con.Close();
            }
            return Bool;
        }

        public static SqlBulkCopyColumnMapping[] GetMapping(DataTable dt)
        {
            string[] strColumns = null;
            if (dt.Columns.Count > 0)
            {
                int columnNum = 0;
                columnNum = dt.Columns.Count;
                strColumns = new string[columnNum];
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    strColumns[i] = dt.Columns[i].ColumnName;
                }
            }
            SqlBulkCopyColumnMapping[] mapping = new SqlBulkCopyColumnMapping[strColumns.Length];
            for (int i = 0; i < strColumns.Length; i++)
            {
                mapping[i] = new SqlBulkCopyColumnMapping(strColumns[i], strColumns[i]);
            }
            return mapping;
        }
        #endregion

    }
}
