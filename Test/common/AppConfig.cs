using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.IO;
using System.Windows.Forms;

namespace Jeno.App.Common
{
    /// <summary>
    /// 应用程序配置
    /// </summary>
    public partial class AppConfig
    {
        private static string _connectionString = null;
        private static string _MainConnectionString = null;
        private static string _NewsConnectioonString = null;
        private static string _EncyclopediasConnectioonString = null;

        #region 数据库连接配置 Jeno_Activity
        /// <summary>
        /// 数据库连接串
        /// </summary>
        public static string ConnectionString
        {
            get
            {
                if (_connectionString == null)
                {
                    //取得数据库连接串配置
                    _connectionString = ConfigurationHelper.GetSetting("ConnectionString");
                    //如果数据库连接串配置不存在，则使用组合配置
                    if (string.IsNullOrEmpty(_connectionString))
                    {
                        _connectionString = SqlServerHelper.GetConnectionString(SSPIEnabled, DatabaseServer, DatabaseName, DatabaseUser, DatabasePassword);
                    }
                }
                return _connectionString;
            }
            set
            {
                _connectionString = value;
            }
        }

        /// <summary>
        /// 数据库名
        /// </summary>
        public static string DatabaseName
        {
            get
            {
                return ConfigurationHelper.GetSetting("databaseName", "StroApp");
            }
        }
        /// <summary>
        /// 数据库服务器
        /// </summary>
        public static string DatabaseServer
        {
            get
            {
                return ConfigurationHelper.GetSetting("databaseServer", ".");
            }
        }
        /// <summary>
        /// 数据库用户
        /// </summary>
        public static string DatabaseUser
        {
            get
            {
                return ConfigurationHelper.GetSetting("databaseUser", "sa");
            }
        }
        /// <summary>
        /// 数据库密码
        /// </summary>
        public static string DatabasePassword
        {
            get
            {
                string databasePassword = Base64Encoder.Decode(ConfigurationHelper.GetSetting("databasePassword", "123456"));
                return databasePassword;
            }
        }
        #endregion

        #region 数据库连接配置 
        /// <summary>
        /// 主数据库
        /// </summary>
        public static string MainConnectionString
        {
            get
            {
                if (_MainConnectionString == null)
                {
                    //取得数据库连接串配置
                    _MainConnectionString = ConfigurationHelper.GetSetting("mainConnectionString");
                    //如果数据库连接串配置不存在，则使用组合配置
                    if (string.IsNullOrEmpty(_MainConnectionString))
                    {
                        _MainConnectionString = SqlServerHelper.GetConnectionString(SSPIEnabled, MainDatabaseServer, MainDatabaseName, MainDatabaseUser, MainDatabasePassword);
                    }
                }
                return _MainConnectionString;
            }
            set
            {
                _MainConnectionString = value;
            }
        }

        /// <summary>
        /// 数据库名
        /// </summary>
        public static string MainDatabaseName
        {
            get
            {
                return ConfigurationHelper.GetSetting("maindatabaseName", "StroApp");
            }
        }
        /// <summary>
        /// 数据库服务器
        /// </summary>
        public static string MainDatabaseServer
        {
            get
            {
                return ConfigurationHelper.GetSetting("maindatabaseServer", ".");
            }
        }
        /// <summary>
        /// 数据库用户
        /// </summary>
        public static string MainDatabaseUser
        {
            get
            {
                return ConfigurationHelper.GetSetting("maindatabaseUser", "sa");
            }
        }
        /// <summary>
        /// 数据库密码
        /// </summary>
        public static string MainDatabasePassword
        {
            get
            {
                string databasePassword = Base64Encoder.Decode(ConfigurationHelper.GetSetting("maindatabasePassword", "123456"));
                return databasePassword;
            }
        }
        #endregion

        #region 数据库连接配置 Jeno_News
        /// <summary>
        /// 数据库连接串
        /// </summary>
        public static string NewsConnectionString
        {
            get
            {
                if (_NewsConnectioonString == null)
                {
                    //取得数据库连接串配置
                    _NewsConnectioonString = ConfigurationHelper.GetSetting("NewsConnectionString");
                    //如果数据库连接串配置不存在，则使用组合配置
                    if (string.IsNullOrEmpty(_NewsConnectioonString))
                    {
                        _NewsConnectioonString = SqlServerHelper.GetConnectionString(SSPIEnabled, NewsDatabaseServer, NewsDatabaseName, NewsDatabaseUser, NewsDatabasePassword);
                    }
                }
                return _NewsConnectioonString;
            }
            set
            {
                _NewsConnectioonString = value;
            }
        }

        /// <summary>
        /// 数据库名
        /// </summary>
        public static string NewsDatabaseName
        {
            get
            {
                return ConfigurationHelper.GetSetting("databaseNameNews", "StroApp");
            }
        }
        /// <summary>
        /// 数据库服务器
        /// </summary>
        public static string NewsDatabaseServer
        {
            get
            {
                return ConfigurationHelper.GetSetting("databaseServerNews", ".");
            }
        }
        /// <summary>
        /// 数据库用户
        /// </summary>
        public static string NewsDatabaseUser
        {
            get
            {
                return ConfigurationHelper.GetSetting("databaseUserNews", "sa");
            }
        }
        /// <summary>
        /// 数据库密码
        /// </summary>
        public static string NewsDatabasePassword
        {
            get
            {
                string databasePassword = Base64Encoder.Decode(ConfigurationHelper.GetSetting("databasePasswordNews", "123456"));
                return databasePassword;
            }
        }

        #endregion

        #region 数据库连接配置 HM_Encyclopedias
        /// <summary>
        /// 数据库连接串
        /// </summary>
        public static string EncyclopediasConnectioonString
        {
            get
            {
                if (_EncyclopediasConnectioonString == null)
                {
                    //取得数据库连接串配置
                    _EncyclopediasConnectioonString = ConfigurationHelper.GetSetting("EncyclopediasConnectioonString");
                    //如果数据库连接串配置不存在，则使用组合配置
                    if (string.IsNullOrEmpty(_EncyclopediasConnectioonString))
                    {
                        _EncyclopediasConnectioonString = SqlServerHelper.GetConnectionString(SSPIEnabled, EncyclopediasDatabaseServer, EncyclopediasDatabaseName, EncyclopediasDatabaseUser, EncyclopediasDatabasePassword);
                    }
                }
                return _EncyclopediasConnectioonString;
            }
            set
            {
                _EncyclopediasConnectioonString = value;
            }
        }

        /// <summary>
        /// 数据库名
        /// </summary>
        public static string EncyclopediasDatabaseName
        {
            get
            {
                return ConfigurationHelper.GetSetting("databaseNameEncyclopedias", "StroApp");
            }
        }
        /// <summary>
        /// 数据库服务器
        /// </summary>
        public static string EncyclopediasDatabaseServer
        {
            get
            {
                return ConfigurationHelper.GetSetting("databaseServerEncyclopedias", ".");
            }
        }
        /// <summary>
        /// 数据库用户
        /// </summary>
        public static string EncyclopediasDatabaseUser
        {
            get
            {
                return ConfigurationHelper.GetSetting("databaseUserEncyclopedias", "sa");
            }
        }
        /// <summary>
        /// 数据库密码
        /// </summary>
        public static string EncyclopediasDatabasePassword
        {
            get
            {
                string databasePassword = Base64Encoder.Decode(ConfigurationHelper.GetSetting("databasePasswordEncyclopedias", "123456"));
                return databasePassword;
            }
        }
        #endregion

        /// <summary>
        /// 代理商初始密码
        /// </summary>
        public static string AgentPassword
        {
            get
            {
                string agentPassword = ConfigurationHelper.GetSetting("AgentPassword", "123456");
                return agentPassword;
            }
        }
        /// <summary>
        /// 是否使用SSPI
        /// </summary>
        public static bool SSPIEnabled
        {
            get
            {
                return ConfigurationHelper.GetBoolSetting("SSPIEnabled", true);
            }
        }
        /// <summary>
        /// 取得master库数据库连接串
        /// </summary>
        public static string MasterConnectionString
        {
            get
            {
                string connectionString = SqlServerHelper.GetConnectionString(SSPIEnabled, DatabaseServer, "master", DatabaseUser, DatabasePassword);
                return connectionString;
            }
        }
        /// <summary>
        /// 数据库连接串
        /// </summary>
        public static string OLEConnectionString
        {
            get
            {
                return ConfigurationHelper.GetSetting("OLEConnectionString");
            }
        }
        /// <summary>
        /// 上传文件路径
        /// </summary>
        public static string UploadDirectoryPath
        {
            get
            {
                return RootPath + "\\" + UploadDirectory;
            }
        }
        /// <summary>
        /// 站点根目录
        /// </summary>
        public static string RootPath
        {
            get
            {
                if (HttpContext.Current == null)
                {
                    return Application.StartupPath;
                }
                return HttpContext.Current.Server.MapPath("~");
            }
        }
        /// <summary>
        /// 上传文件目录名
        /// </summary>
        public static string UploadDirectory
        {
            get
            {
                string uploadfile = ConfigurationHelper.GetSetting("UploadDirectory", "UploadFile");
                return uploadfile;
            }
        }
        /// <summary>
        /// 下载文件目录名
        /// </summary>
        public static string DownloadDirecotry
        {
            get
            {
                string downloadDirecotry = ConfigurationHelper.GetSetting("DownloadDirecotry", "DownloadFile");
                return downloadDirecotry;
            }
        }
        /// <summary>
        /// 重置表配置文件路径
        /// </summary>
        public static string DataResetTablesConfigFilePath
        {
            get
            {
                string relativeFilePath = ConfigurationHelper.GetSetting("DataResetTablesConfigFilePath", "Config/DataResetTables.xml");
                string resetTablesFilePath = Path.Combine(RootPath, relativeFilePath);
                string fullName = new FileInfo(resetTablesFilePath).FullName;
                return fullName;
            }
        }
        /// <summary>
        /// 备份信息文件路径
        /// </summary>
        public static string BackupInfoFilePath
        {
            get
            {
                string relativeFilePath = ConfigurationHelper.GetSetting("BackupInfoFilePath", "Config/BackupInfo.xml");
                string absoluteFilePath = Path.Combine(RootPath, relativeFilePath);
                string fullName = new FileInfo(absoluteFilePath).FullName;
                return fullName;
            }
        }
        /// <summary>
        /// 自动备份保留天数
        /// </summary>
        public static int AutoBackupRemainDays
        {
            get
            {
                return ConfigurationHelper.GetIntSetting("AutoBackupRemainDays", 7);
            }
        }
        /// <summary>
        /// 数据库备份路径
        /// </summary>
        public static string DatabaseBackupDirectory
        {
            get
            {
                string relativeFilePath = ConfigurationHelper.GetSetting("DatabaseBackupDirectory", "Backup");
                string absoluteFilePath = Path.Combine(RootPath, relativeFilePath);
                string fullName = new DirectoryInfo(absoluteFilePath).FullName;
                return fullName;
            }
        }
        /// <summary>
        /// 导出配置文件路径
        /// </summary>
        public static string ExportConfigFilePath
        {
            get
            {
                string relativeFilePath = ConfigurationHelper.GetSetting("ExportConfigFilePath", "Config/ExportConfig.xml");
                string absoluteFilePath = Path.Combine(RootPath, relativeFilePath);
                string fullName = new FileInfo(absoluteFilePath).FullName;
                return fullName;
            }
        }
        /// <summary>
        /// 导入配置文件路径
        /// </summary>
        public static string ImportConfigFilePath
        {
            get
            {
                string relativeFilePath = ConfigurationHelper.GetSetting("ImportConfigFilePath", "Config/ImportConfig.xml");
                string absoluteFilePath = Path.Combine(RootPath, relativeFilePath);
                string fullName = new FileInfo(absoluteFilePath).FullName;
                return fullName;
            }
        }
        /// <summary>
        /// 导出配置文件路径
        /// </summary>
        public static string LoginHandlerConfigFilePath
        {
            get
            {
                string relativeFilePath = ConfigurationHelper.GetSetting("LoginHandlerConfigFilePath", "Config/LoginHandlers.xml");
                string absoluteFilePath = Path.Combine(RootPath, relativeFilePath);
                string fullName = new FileInfo(absoluteFilePath).FullName;
                return fullName;
            }
        }
        /// <summary>
        /// 导入配置文件路径
        /// </summary>
        public static string ImageRootPath
        {
            get
            {
                string imageRootPath = RootPath + "\\" + AppConstants.ImageDirectoryName;
                return imageRootPath;
            }
        }
        /// <summary>
        /// 下载处理类配置文件路径
        /// </summary>
        public static string DownloadHandlerConfigFilePath
        {
            get
            {
                string relativeFilePath = ConfigurationHelper.GetSetting("DownloadHandlerConfigFilePath", "Config/DownloadHandlers.xml");
                string downloadHandlerFilePath = Path.Combine(RootPath, relativeFilePath);
                string fullName = new FileInfo(downloadHandlerFilePath).FullName;
                return fullName;
            }
        }
        /// <summary>
        /// 下载处理类配置文件路径
        /// </summary>
        public static string ApproveHandlerConfigFilePath
        {
            get
            {
                string relativeFilePath = ConfigurationHelper.GetSetting("ApproveHandlerConfigFilePath", "Config/ApproveHandlers.xml");
                string approveHandlerFilePath = Path.Combine(RootPath, relativeFilePath);
                string fullName = new FileInfo(approveHandlerFilePath).FullName;
                return fullName;
            }
        }
        /// <summary>
        /// 服务处理类配置文件路径
        /// </summary>
        public static string ServiceHandlerConfigFilePath
        {
            get
            {
                string relativeFilePath = ConfigurationHelper.GetSetting("ServiceHandlerConfigFilePath", "Config/ServiceHandlers.xml");
                string serviceHandlerFilePath = Path.Combine(RootPath, relativeFilePath);
                string fullName = new FileInfo(serviceHandlerFilePath).FullName;
                return fullName;
            }
        }
        /// <summary>
        /// 服务地址配置文件路径
        /// </summary>
        public static string ServiceUrlConfigFilePath
        {
            get
            {
                string relativeFilePath = ConfigurationHelper.GetSetting("ServiceUrlConfigFilePath", "Config/ServiceUrls.xml");
                string serviceUrlFilePath = Path.Combine(RootPath, relativeFilePath);
                string fullName = new FileInfo(serviceUrlFilePath).FullName;
                return fullName;
            }
        }
        /// <summary>
        /// 服务处理类配置文件路径
        /// </summary>
        public static string APICallHandlerConfigFilePath
        {
            get
            {
                string relativeFilePath = ConfigurationHelper.GetSetting("APICallHandlerConfigFilePath", "Config/APICallHandlers.xml");
                string serviceHandlerFilePath = Path.Combine(RootPath, relativeFilePath);
                string fullName = new FileInfo(serviceHandlerFilePath).FullName;
                return fullName;
            }
        }
        /// <summary>
        /// 小器件配置文件路径
        /// </summary>
        public static string WidgetConfigFilePath
        {
            get
            {
                string relativeFilePath = ConfigurationHelper.GetSetting("WidgetConfigFilePath", "Config/Widgets.xml");
                string absoluteFilePath = Path.Combine(RootPath, relativeFilePath);
                string fullName = new FileInfo(absoluteFilePath).FullName;
                return fullName;
            }
        }
        /// <summary>
        /// 基础工资项配置文件路径
        /// </summary>
        public static string BasicSalaryAccountItemConfigFilePath
        {
            get
            {
                string relativeFilePath = ConfigurationHelper.GetSetting("BasicSalaryAccountItemConfigFilePath", "Config/BasicSalaryAccountItems.xml");
                string approveHandlerFilePath = Path.Combine(RootPath, relativeFilePath);
                string fullName = new FileInfo(approveHandlerFilePath).FullName;
                return fullName;
            }
        }
        /// <summary>
        /// 参照根目录
        /// </summary>
        public static string SelectionRootDirectory
        {
            get
            {
                string relativeDirectoryPath = ConfigurationHelper.GetSetting("SelectionRootDirectory", "Config/Selection");
                string absoluteDirectoryPath = Path.Combine(RootPath, relativeDirectoryPath);
                string fullName = new FileInfo(absoluteDirectoryPath).FullName;
                return fullName;
            }
        }
        /// <summary>
        /// 页面配置根目录
        /// </summary>
        public static string PageRootDirectory
        {
            get
            {
                string relativeDirectoryPath = ConfigurationHelper.GetSetting("PageRootDirectory", "Config/Page");
                string absoluteDirectoryPath = Path.Combine(RootPath, relativeDirectoryPath);
                string fullName = new FileInfo(absoluteDirectoryPath).FullName;
                return fullName;
            }
        }
        /// <summary>
        /// 证书文件路径
        /// </summary>
        public static string LicenseFilePath
        {
            get
            {
                string relativeFilePath = ConfigurationHelper.GetSetting("LicenseFilePath", "Config/License.xml");
                string absoluteFilePath = Path.Combine(RootPath, relativeFilePath);
                string fullName = new FileInfo(absoluteFilePath).FullName;
                return fullName;
            }
        }
        /// <summary>
        /// 产品编码
        /// </summary>
        public static string ProductCode
        {
            get
            {
                return "JenoApp";
            }
        }
        /// <summary>
        /// 产品名称
        /// </summary>
        public static string ProductName
        {
            get
            {
                return "江鸟网络应用系统";
            }
        }
        /// <summary>
        /// 产品版本
        /// </summary>
        public static string ProductVersion
        {
            get
            {
                return "1.0";
            }
        }
        /// <summary>
        /// 注册地址
        /// </summary>
        public static string RegisterAddress
        {
            get
            {
                return ConfigurationHelper.GetSetting("RegisterAddress", "http://service.strosoft.com/Common/GetLicense.ashx");
            }
        }
        /// <summary>
        /// 检查试用地址
        /// </summary>
        public static string CheckTryingAddress
        {
            get
            {
                return ConfigurationHelper.GetSetting("CheckTryingAddress", "http://service.strosoft.com/Common/CheckTrying.ashx");
            }
        }
        /// <summary>
        /// 系统版本
        /// </summary>
        public static string SystemVersion
        {
            get
            {
                return "1.0.0.0";
            }
        }
        /// <summary>
        /// 取得配置值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static string GetSetting(string key, string defaultValue)
        {
            return ConfigurationHelper.GetSetting(key, defaultValue);
        }
        /// <summary>
        /// 取得配置值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetSetting(string key)
        {
            return GetSetting(key, null);
        }
        /// <summary>
        /// 管理端根地址
        /// </summary>
        public static string AdminRootUrl
        {
            get
            {
                return ConfigurationHelper.GetSetting("AdminRootUrl", "http://app.strosoft.com");
            }
        }
        /// <summary>
        /// 前端根地址
        /// </summary>
        public static string FrontRootUrl
        {
            get
            {
                return ConfigurationHelper.GetSetting("FrontRootUrl", "http://app.strosoft.com");
            }
        }
        /// <summary>
        /// 登录页面
        /// </summary>
        public static string LoginPage
        {
            get
            {
                return ConfigurationHelper.GetSetting("LoginPage", "~/Login.aspx");
            }

        }
    }
}
