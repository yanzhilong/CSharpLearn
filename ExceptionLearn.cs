using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLearn
{
    public class ExceptionLearn
    {
        public static void ExceptionLeanMain()
        {
            Console.WriteLine("ExceptionLeanMain");

            //异常基本使用
            try
            {
                object obj = null;
                int N = (int)obj;
            }catch(Exception e)
            {
                Console.WriteLine("捕获异常" + e);
            }

            //throw的使用
            try
            {
                Console.WriteLine("请输入分子:");
                string str1 = Console.ReadLine();
                Console.WriteLine("请输入分母:");
                string str2 = Console.ReadLine();
                Console.WriteLine("值：" + divide(str1,str2));

            }catch(FormatException e)
            {
                Console.WriteLine("请输入数值格式数据");
            }
            finally
            {
                Console.WriteLine("清理现场");
            }



        }

        static int divide(String i,String j)
        {
            int inti = int.Parse(i);
            int intj = int.Parse(j);
            try
            {
                if (intj == 0)
                {
                    throw new DivideByZeroException();
                }
            }catch(DivideByZeroException e)
            {
                Console.WriteLine("用零整数引发异常");
                Console.WriteLine(e.Message);
                return 0;
            }
            return inti / intj;
        }
    }
}
