using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Sockets;
using System.Text;
using System.Data.SqlClient;
using System.Reflection;
using System.Linq.Expressions;

namespace Test.Controllers
{
    public class TestController : Controller
    {
        //
        // GET: /Test/
        Test.Models.WYTraceCodeSystemContext db = new Models.WYTraceCodeSystemContext();
        public ActionResult Index()
        {
            return View();
        }
        public void test()
        {
            TcpClient client = new TcpClient();
            try
            {
                client.Connect("localhost", 8501);      // 与服务器连接
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
            Response.Write("Server Connected！"+
            client.Client.LocalEndPoint+"---->"+client.Client.RemoteEndPoint);

            string msg = "\"Welcome To TraceFact.Net\"";
            NetworkStream streamToServer = client.GetStream();

            byte[] buffer = Encoding.Unicode.GetBytes(msg);     // 获得缓存
            streamToServer.Write(buffer, 0, buffer.Length);     // 发往服务器
            Response.Write("send:"+msg);

            const int BufferSize = 8192;  
            int bytesRead;
            buffer = new byte[BufferSize];
            lock (streamToServer)
            {
                bytesRead = streamToServer.Read(buffer, 0, BufferSize);
            }
            msg = Encoding.Unicode.GetString(buffer, 0, bytesRead);
            Response.Write("Received: "+ msg);
            streamToServer.Dispose();
            client.Close();

        }
        public void BubbleSort<T>(T[] array)
            {
                int length = array.Length;

                for (int i = 0; i <= length - 2; i++)
                {
                    for (int j = length - 1; j >= 1; j--)
                    {

                        // 对两个元素进行交换
                        //if (array[j].CompareTo( array[j - 1])<0)
                        //{
                        //    T temp = array[j];
                        //    array[j] = array[j - 1];
                        //    array[j - 1] = temp;
                        //}
                    }
                }
            }

        public class ModelPParameterHelper
        {
            public static SqlParameter[] PrepareParametersFromModel<T>(T t)
            {
                string tempName = "";
                int i = 0;
                //属性数组
                PropertyInfo[] propertys = t.GetType().GetProperties();
                SqlParameter[] sqlParas=new SqlParameter[propertys.Length];
                foreach (PropertyInfo pi in propertys)
                {
                    tempName = pi.Name;
                    sqlParas[i++] = new SqlParameter("@" + tempName, pi.GetValue(t, null));
                }
                return sqlParas;
            }

            //public static SqlParameter[] PrerparameterFromModelAndParaStr<T>(string[] parastr, T t)
            //{
            //    string tempName = "";
            //    int i = 0;
            //    //属性数组
            //    PropertyInfo[] propertys = t.GetType().GetProperties();
            //    SqlParameter[]sqlParas=new SqlParameter[];
            //}
        }

        class Demo<T>
        {
            private T obj;
            public Demo(T obj)
            {
                this.obj = obj;
            }
            public T getObj()
            {
                return obj;
            }
            public T setObj(T obj)
            {
                this.obj = obj;
                return obj;
            }
          
        }
        Demo<int> model = new Demo<int>(10) ;
        public class mylist<T>
        {
            private Node head;
            public class Node
            {
                private Node next;
                private T data;
                public Node(T t)
                {
                    next = null;
                    data = t;
                }
            }
        }


        public class Employee
        {
            public class Employees
            {
                private string name;
                private int id;
                public Employees(string s, int i)
                {
                    name = s;
                    id = i;
                }

                public string Name
                {
                    get { return name; }
                    set { name = value; }
                }
                public int ID
                {
                    get { return id; }
                    set { id = value; }
                }

            }
        }
        class MyList<T> where T : Employee
        {
            //Rest of class as before.
            public T FindFirstOccurrence(string s)
            {
                T t = null;
                   
                return t;
            }
        }

       


  
    }
}
