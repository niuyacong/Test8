using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NunitTest
{
    public class Class1
    {

        /// <summary>
        /// 用于演示的一个简单计算功能
        /// </summary>
        public class Calculate
        {
            /// <summary>
            /// 加法
            /// </summary>
            public int Add(int a, int b)
            {
                return a + b;
            }
            /// <summary>
            /// 减法
            /// </summary>
            public int Subtract(int a, int b)
            {
                return a - b;
            }
            /// <summary>
            /// 乘法
            /// </summary>
            public int Multiply(short a, short b)
            {
                return a * b;
            }
            /// <summary>
            /// 除法
            /// </summary>
            public int Quotient(int a, int b)
            {
                return a / b;
            }
            /// <summary>
            /// 开平方根
            /// </summary>
            public double SquareRoot(int num)
            {
                return Math.Sqrt(num);
            }
            /// <summary>
            /// 四舍五入，取整
            /// </summary>
            public int Round_Off(double num)
            {
                return (int)Math.Round(num);
            }
            /// <summary>
            /// 向上取整
            /// </summary>
            public int UpwardTrunc(double num)
            {
                return (int)Math.Ceiling(num);
            }
            /// <summary>
            /// 平方
            /// </summary>
            public int Square(short num)
            {
                throw new NotImplementedException();
            }
        }
    
    }
}
