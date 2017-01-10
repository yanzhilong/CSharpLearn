using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleLearn1;
namespace ConsoleLearn
{
    class Program
    {
        static void Main(string[] args)
        {
            helloWorld();
            nameSpace();
            variate();
            expression();
        }




        /// <summary>
        /// 第一个输出程序 
        /// </summary>
        static void helloWorld()
        {
            Console.WriteLine("hello world!");
        }

        /// <summary>
        /// 命名空间的使用
        /// </summary>
        static void nameSpace()
        {
            Program1 program1 = new Program1();
            program1.helloWorld();
        }


        /// <summary>
        /// 变量
        /// </summary>
        static void variate()
        {
            //有符号整数
            sbyte _sbyte = 127;   //8位
            short _short = 0;   //16位
            short _short1 = new short();   //16位,每个值类型都有一个隐式的构造函数
            Int16 _short2;  //16位
            int _int;       //32位
            Int32 _int1;    //32位
            long _long;     //64位
            Int64 _long1;   //64位

            //无符号整数
            byte _byte;     //8位
            ushort _ushort; //16位
            uint _uint;     //32位
            ulong _ulong;   //64位

            //浮点型,精确到7位数
            float _float = 1.88f;
            float _float1 = 1.88F;
            //双精度浮点型,精确到15-16位
            double _double = 1.88d;
            double _double1 = 1.88D;

            double result = 1.88 / 1.0; //如果后面不指定则默认是按double计算
            //布尔类型
            bool _bool = false;

            //引用类型
            Program1 program1 = new Program1();
            Program1 program2 = program1;
            program1.Value = 10;
            Console.WriteLine("program1.value:{0},program2.value:{1}",program1.Value,program2.Value);

            //枚举类型
            Sex sex = Sex.FEMALE;
            switch (sex)
            {
                case Sex.FEMALE:
                    Console.WriteLine("sex:{0}","女");
                    break;
                case Sex.MALE:
                    Console.WriteLine("sex:{0}", "男");
                    break;
                default:
                    break;
            }

            String[] datearray = {"天","一", "二", "三", "四", "五", "六" };
            int date = (int)DateTime.Now.DayOfWeek;
            switch (date)
            {

                case (int)Date.Sun:
                    Console.WriteLine("今天星期{0}",datearray[date]);
                    break;
                case (int)Date.Mon:
                    Console.WriteLine("今天星期{0}", datearray[date]);
                    break;
                case (int)Date.Tue:
                    Console.WriteLine("今天星期{0}", datearray[date]);
                    break;
                case (int)Date.Wed:
                    Console.WriteLine("今天星期{0}", datearray[date]);
                    break;
                case (int)Date.Thi:
                    Console.WriteLine("今天星期{0}", datearray[date]);
                    break;
                case (int)Date.Fri:
                    Console.WriteLine("今天星期{0}", datearray[date]);
                    break;
                case (int)Date.Sat:
                    Console.WriteLine("今天星期{0}", datearray[date]);
                    break;
                default:
                    break;
            }

            //类型转换
            int i = 917;
            double idouble = i;
            int iint = Convert.ToInt32(idouble);

            //拆箱和装箱
            int ii = 2008;
            object obj = ii;
            Console.WriteLine("i的值为{0},装箱后的对象为{1}",ii,obj);
            ii = 2009;
            Console.WriteLine("i的值为{0},装箱后的对象为{1}",ii,obj);

            //变量的声明
            int LS;
            string str1, str2, str3;
            string ss1 = "a", ss2 = "a";

            //常量
            const int AGEMAX = 150; //年龄的最大值为150
        }

        /// <summary>
        /// 表达式和运算符
        /// </summary>
        static void expression()
        {
            //算术运算符
            int M1 = 5;
            int M2 = M1 + 40;
            int M3 = M2 / 5; //除法
            int M4 = 8 % M1; //求余
            Console.WriteLine(M2.ToString());
            Console.WriteLine(M3.ToString());
            Console.WriteLine(M4.ToString());
            int M5;
            Math.DivRem(8, M1, out M5);
            Console.WriteLine(M5.ToString());

            //关系运算符
            int i1 = 10;
            int i2 = 10;
            Boolean result = i1 == i2;
            Console.WriteLine("{0}和{1}{2}",i1,i2,result ? "相等" : "不等");
            i2 = 11;
            result = i1 == i2;
            Console.WriteLine("{0}和{1}{2}", i1, i2, result ? "相等" : "不等");
            result = !(i1 == i2);
            Console.WriteLine("{0}和{1}{2}", i1, i2, result ? "不等" : "相等");

            //逻辑运算符
            int num1 = 1;
            int num2 = 85;
            bool iseven = (num1 & num2) == 0;//逻辑与，都是1的时候是1，否则0
            Console.WriteLine("{0}是{1}",num2,iseven ? "偶数" : "奇数");

            num2 = 102;
            iseven = (num1 | num2) != num2;//逻辑或，只要有一个是1就是1，否则0
            Console.WriteLine("{0}是{1}", num2, iseven ? "偶数" : "奇数");

            num1 = 1;
            num2 = 86;
            iseven = (num1 ^ num2) == num2 + 1;//按位异或,两个相同的时候返回0，不同返回1;
            Console.WriteLine("{0} ^ {1} 的值是{2}", num1, num2, num1 ^ num2);
            Console.WriteLine("{0}是{1}", num2, iseven ? "偶数" : "奇数");

            bool _bool1 = true;
            bool _bool2 = true;//布尔与运算,如果都是真，返回真，否则返回假
            Console.WriteLine("{0} & {1} 的值是{2}", _bool1, _bool2, _bool1 & _bool2);

            //注：当使用&&的时候当左边的值为假的时候就不会执行右边的表达式了

            _bool1 = true;
            _bool2 = false;//布尔或运算，只要有一个是真则为真，否则返回假
            Console.WriteLine("{0} | {1} 的值是{2}", _bool1, _bool2, _bool1 | _bool2);

            _bool1 = true;
            _bool2 = false;//布尔异或，当两个不一样的是返回真，否则返回假
            Console.WriteLine("{0} ^ {1} 的值是{2}", _bool1, _bool2, _bool1 ^ _bool2);

            //移们运算，左移右边补0,右移左边补0,X<<N,X>>N,X(int,uint,long,ulone),N(int)
            uint intmax = 4294967295;
            uint bytemask;
            bytemask = intmax << 8;
            Console.WriteLine("{0} << {1} 的值是{2}", intmax, 8, bytemask);
            //如果左边是int uint，则操作数由N的低五位给出，就是最多移31位;
            //如果左边是long ulong，则操作数由N的低六位给出，就是最多移63位;
            //左移n位就是乘以2的n次方
            //右移n位就是除以2的n次方

            intmax = 4294967295;
            bytemask = intmax >> 16;
            Console.WriteLine("{0} >> {1} 的值是{2}", intmax, 16, bytemask);

            //is运算符
            int i = 0;
            result = i is int;
            Console.WriteLine("{0} {1}整型", i, result ? "是" : "否");

            //条件运算符
            num1 = 10;
            num2 = 20;
            Console.WriteLine("{0} {1} {2}", num1, num1 > num2 ? "大于" : "小于",num2);
            num2 = 10;
            Console.WriteLine("{0} {1} {2}", num1, num1 > num2 ? "大于" : num1 == num2 ? "等于" : "小于", num2);

            //new运算符
            string[] st = new String[1];
            st[0] = "12";
            Console.WriteLine(st[0]);

            //typeof运算符
            Type mytype = typeof(int);
            Console.WriteLine("类型{0}",mytype);
        }

    }
}


namespace ConsoleLearn1
{
    class Program1
    {
        private int value = 0;
        private String name;

        public int Value
        {
            get
            {
                return value;
            }

            set
            {
                this.value = value;
            }
        }


        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public void helloWorld()
        {
            Console.WriteLine("Program1 hello world!");
        }
    }

    /// <summary>
    /// 性别枚举类
    /// </summary>
    enum Sex
    {
        MALE,
        FEMALE
    }

    /// <summary>
    /// 星期栈举类
    /// </summary>
    enum Date
    {
        Sun = 0,
        Mon = 1,
        Tue = 2,
        Wed = 3,
        Thi = 4,
        Fri = 5,
        Sat = 6,
    }

    /// <summary>
    /// 定义一个接口
    /// </summary>
    public interface Iconvertible
    {
        /// <summary>
        /// 输出字符串
        /// </summary>
        /// <param name="source">要输出的字符串</param>
        void println(String source);
    }
}
