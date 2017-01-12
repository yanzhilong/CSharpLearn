using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleLearn1;
using System.Collections;

namespace ConsoleLearn
{
    /// <summary>
    /// 基本使用
    /// </summary>
    class Program
    {
        /// <summary>
        /// Man方法默认访问级别为private
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //helloWorld();
            //nameSpace();
            //variate();
            //expression();
            //StringLearn();
            ////flowControl();
            //arrayAndCollections();
            //attributeMethod();
            //structure();


            //高级应用
            //ProgramAdvanced.ProgramAdvanceMan();

            //异常处理
            //ExceptionLearn.ExceptionLeanMain();


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
            program1.Age = 10;
            Console.WriteLine("program1.value:{0},program2.value:{1}",program1.Age, program2.Age);

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

		
		/// <summary>
        /// 字符串与字符串
        /// </summary>
		static void StringLearn(){

			//字符及常用方法
			char ch1 = 'L';
			char ch2 = '1';

			char a = 'a';
			char b = '8';
			char c = 'L';
			char d = '.';
			char e = '|';
			char f = ' ';

			Console.WriteLine("{0}{1}字母",a,Char.IsLetter(a) ? "是" : "不是");
			Console.WriteLine("{0}{1}数字",b,Char.IsDigit(b) ? "是" : "不是");
			Console.WriteLine("{0}{1}字母或数字",c,Char.IsLetterOrDigit(c) ? "是" : "不是");
			Console.WriteLine("{0}{1}小写字母",a,Char.IsLower(a) ? "是" : "不是");
			Console.WriteLine("{0}{1}大写字母",c,Char.IsUpper(c) ? "是" : "不是");
			Console.WriteLine("{0}{1}标点符号",d,Char.IsPunctuation(d) ? "是" : "不是");
			Console.WriteLine("{0}{1}分隔符",e,Char.IsSeparator(e) ? "是" : "不是");
			Console.WriteLine("{0}{1}字母",f,Char.IsWhiteSpace(f) ? "是" : "不是");

			//转义字符
			char M = '\'';  //值为单引号
			char M1 = '\n';	//回车换行
			char M2 = '\t';	//下一个字表位置
			char M3 = '\b';	//退格
			char M4 = '\r';	//回车
			
			Console.WriteLine("hello world");
			Console.Write("hello world\n");

			//String 类，string类型
			string Str1 = "hello world";
			char Str1_1 = Str1[1];
			char Str1_2 = Str1[2];
			Console.WriteLine("{0}的第二个字符是{1}",Str1, Str1_1);
			Console.WriteLine("{0}的第三个字符是{1}",Str1, Str1_2);

			//字符串的比较
			//Compare
			Str1 = "abcde";
			String Str2 = "abcdf";
			Console.WriteLine("{0}和{1}比较的结果是:",Str1,Str2,String.Compare(Str1,Str2));
			Console.WriteLine("{0}和{1}比较的结果是:",Str1,Str1,String.Compare(Str1,Str1));
			Console.WriteLine("{0}和{1}比较的结果是:",Str2,Str1,String.Compare(Str2,Str1));
			//-1,0,1

			Console.WriteLine("{0}和{1}比较的结果是:",Str1,Str2,Str1.CompareTo(Str2));
			Console.WriteLine("{0}和{1}比较的结果是:",Str1,Str1,Str1.CompareTo(Str1));
			Console.WriteLine("{0}和{1}比较的结果是:",Str2,Str1,Str2.CompareTo(Str1));

			//Equals
			Str1 = "hello world";
			Str2 = "hello world!";
			Console.WriteLine("{0}和{1}{2}",Str1,Str2,Str1.Equals(Str2) ? "相等" : "不等");
			Console.WriteLine("{0}和{1}{2}",Str1,Str2,String.Equals(Str1,Str2) ? "相等" : "不等");

			//格式化字符串
			string StrA = "hello ";
			string StrB = "world";
			string StrAB = String.Format("{0},{1}!!!",StrA,StrB);
			Console.WriteLine(StrAB);

			//格式化日期
			//d YYYY-MM-dd
			//D YYYY年MM月dd日
			//t hh:mm
			//T hh:mm:ss
			//f YYYY年MM月dd日 hh:mm
			//F YYYY年MM月dd日 hh:mm:ss
			//g YYYY-MM-dd hh:mm
			//G YYYY-MM-dd hh:mm:ss
			//M或m MM月dd日
			//Y或y YYYY年MM月
			
			DateTime dt = DateTime.Now;
			string strB = String.Format("{0:D}",dt);
			Console.WriteLine(strB);

			//字符串的截取
			//public string Substring(int startIndex,int length);
			StrA = "hello world";
			StrB = StrA.Substring(1,4); //从索引1开始，截取4位
			Console.WriteLine(StrB);
			//注：当 length大于字符串的长度的时候，将截取之后的所有字符

			//分割字符串
			//public string[] Split(params char[] separator); separator包含分割符
			StrA = "用^一生#下载,你";
            char[] separator = {'^','#',',' };
			String[] splitstrings = new String[100];
			splitstrings = StrA.Split(separator);
			for(int i = 0; i < splitstrings.Length;i++){
				Console.WriteLine("item{0}:{1}",i,splitstrings[i]);
			}
			//item0:用
			//item1:一生
			//item2:下载
			//item3:你

			//插入和填充字符串
			//public string Insert(int startIndex,string value);
			// startIndex,要插入的位置,value，要插入的字符
			string str1 = "下载";
			string str2;
			str2 = str1.Insert(0,"用一生");
			string str3 = str2.Insert(5,"你");
			Console.WriteLine(str3);
			
			//result:用一生下载你
			string str4 = str2.Insert(str2.Length,"你");
			
			//填充字符串
			//public string PadLeft(int totalWidth,char paddingChar);
			//toalWidth:填充后的字符长度
			//paddingChar:指定要填充的字符，如果省略，则填充空格
			str1 = "*^_^*";
			str2 = str1.PadLeft(7,'(');
			str3 = str2.PadRight(8,')');
			Console.WriteLine("补充字符串之前:" + str1);
			Console.WriteLine("补充字符串之后:" + str3);

			//删除字符串
			//public String Remove(int startIndex);//从指定位置开始删除后面的全部
			//public String Remove(int startIndex,int count);
			//startIndex:用于指定开始删除的位置
			//count:要删除的字符数量
			str1 = "用一生下载你";
			str2 = str1.Remove(3);
			Console.WriteLine(str2);//输出:用一生

			str1 = "芸烨湘枫";
			str2 = str1.Remove(1,2);
			Console.WriteLine(str2);
			//输出:芸枫

			//复制字符串
			//public static string Copy(string str);
			//str:要复制的字符串
			string stra = "芸烨湘枫";
			string strb = String.Copy(stra);
			Console.WriteLine(strb);

			//public void CopyTo(int sourceIndex,char[]destination,int destinationIndex,int coune);
			//sourceIndex:需要复制字符的起始位置
			//destination:目标字符数组
			//destinationIndex:目标数组开始存放的位置
			//count:要复制的字符个数
			str1 = "用一生下载你";
			char[] str = new char[100];
			//将str1从1开始的4个字符串复制到字符数组str中
			str1.CopyTo(1,str,0,4);
			Console.WriteLine(str);
			//输出:一生下载

			//替换字符串
			//public string Replace(char Ochar,char NChar);
			//public string Replace(string OValue,string NValue)
			//Ochar 等替换的字符
			//NChat 替换后的字符
			//OValue 待替换的字符串
			//NValue 替换后的字符串
			string astr = "one world,one dream";
			string bstr = astr.Replace(',','*');
			Console.WriteLine(b);
			
			string cstr = astr.Replace("on world","One World");
			Console.WriteLine(cstr);

            //StringBuilder类的使用
            //public StringBuilder(string value,int cap);
            //value:初始的引用的字符串
            //cap:初始大小
            StringBuilder stringBuilder = new StringBuilder("Hello world!");
            int Num = 1000;
            StringBuilder LS = new StringBuilder("用一生下载你",100);
            LS.Append("VS 芸烨湘枫");
            Console.WriteLine(LS);
            LS.AppendFormat("{0:C}",Num);
            Console.WriteLine(LS);
            LS.Insert(0,"名称: ");
            Console.WriteLine(LS);
            LS.Remove(15, LS.Length - 15);
            Console.WriteLine(LS);
            LS.Replace("名称","一生所爱");
            Console.WriteLine(LS);

        }


        /// <summary>
        /// 流程控制学习
        /// </summary>
        static void flowControl()
        {
            //if else语句
            int ifi = 928;
            if (ifi > 927)
            {
                Console.WriteLine(String.Format("{0}大于927", ifi));
            }
            else
            {
                Console.WriteLine(String.Format("{0}小于927", ifi));
            }

            int agei = 8;
            int agej = 30;
            int agek = 50;
            int YouAge = 0;
            Console.WriteLine("请输入您的年龄:");
            YouAge = int.Parse(Console.ReadLine());
            if (YouAge <= agei)
            {
                Console.WriteLine("您的年龄还小，要努力奋斗噢!");
            }
            else
            {
                if (agei <= YouAge && YouAge < agej)
                {
                    Console.WriteLine("努力奋斗的黄金时段");
                }
                else
                {
                    if (agej <= YouAge && YouAge < agek)
                    {
                        Console.WriteLine("人生黄金阶段");
                    }
                    else
                    {
                        Console.WriteLine("最美不过夕阳红!");
                    }

                }
            }

            //switch语句
            //表达式类型:sbyte,byte,short,ushort,int,uint,long,ulong,chat,string,enum
            string MyStr = "用一生下载你";
            switch (MyStr)
            {
                case "用一生下载你":
                    Console.WriteLine("用一生下载你");
                    break;
                case "一生所爱":
                    Console.WriteLine("一生所爱");
                    break;
                default:
                    Console.WriteLine("未知字符");
                    break;
            }

            Console.WriteLine("请您输入一个月份:");
            int MyMouth = int.Parse(Console.ReadLine());
            switch (MyMouth)
            {
                case 12:
                case 1:
                case 2:
                    Console.WriteLine("冬季");
                    break;
                default:
                    Console.WriteLine("其它季");
                    break;
            }

            //迭代语句
            int[] MyNum = { 125, 258, 124, 358, 256, 589 };
            int s = 0;
            while (s < 6)
            {
                Console.WriteLine("myNum[{0}]的值为{1}", s, MyNum[s]);
                s++;
            }

            //循环输出奇数
            Console.WriteLine("循环输出0-40的奇数");
            s = 0;
            while (s < 80)
            {

                if (s > 40)
                {
                    break;
                }
                if ((s | 1) == s + 1)
                {
                    s++;
                    continue;
                }
                Console.WriteLine(s);
                s++;
            }

            //循环输出偶数,continue
            Console.WriteLine("循环输出0-40的偶数");
            s = 0;
            while (s < 80)
            {

                if (s > 40)
                {
                    break;
                }
                if ((s | 1) == s)
                {
                    s++;
                    continue;
                }
                Console.WriteLine(s);
                s++;
            }

            //do while语句,for语句
            bool term = false;
            int[] myArray = { 0, 1, 2, 3, 4 };
            do
            {
                for (int i = 0; i < myArray.Length; i++)
                {
                    Console.WriteLine(myArray[i]);
                }
            } while (term);

            //for死循环
            //for (;;) ;

            //foreach语句
            ArrayList alt = new ArrayList();
            alt.Add("a");
            alt.Add("b");
            alt.Add("c");
            alt.Add("d");
            alt.Add("e");
            foreach (String str in alt)
            {
                Console.WriteLine(str);
            }

            int[] intarray = { 0, 1, 2, 3, 4, 5, 6 };
            foreach (int i in intarray)
            {
                Console.WriteLine(i.ToString());
            }

            //break的使用
            int week = Convert.ToInt32(DateTime.Now.DayOfWeek);
            switch (week)
            {
                case 1:
                    Console.WriteLine("今天是星期一");
                    break;
                case 2:
                    Console.WriteLine("今天是星期二");
                    break;

                case 3:
                    Console.WriteLine("今天是星期三");
                    break;

                case 4:
                    Console.WriteLine("今天是星期四");
                    break;
                case 5:
                    Console.WriteLine("今天是星期五");
                    break;
                case 6:
                    Console.WriteLine("今天是星期六");
                    break;
                case 7:
                    Console.WriteLine("今天是星期天");
                    break;

            }

            //goto语句
            for (int i = 0; i < 1000; i++)
            {
                if (i == 100)
                {
                    goto Found;
                }
            }
            Console.WriteLine("没找到");
            goto Finish;
        Found:
            Console.WriteLine("找到");
        Finish:
            Console.WriteLine("查找结束");

            int switchi = 10;
            switch (switchi)
            {

                case 0:
                    break;
                case 10:
                    goto default;
                    break;

                case 11:
                    break;
                default:
                    Console.WriteLine("defaule");
                    break;

            }

            //return语句
            while (true)
            {
                return;
            }
        }


        /// <summary>
        /// 数组与集合的使用
        /// </summary>
        static void arrayAndCollections()
        {
            //数组初始化
            int[] intarray;
            intarray = new int[5];
            intarray = new int[] {1,2,3,4,5};
            intarray = new int[5] {1,2,3,4,5};//个数和值需要匹配
            int[] intarray1 = {1,2,3,4,5};

            //一维数组的使用
            int[] arr = {1,2,3,4,5};
            foreach(int i in arr){
                Console.WriteLine("{0}",i + "");
            }

            //二维数组
            int[,] arrs = new int[2,2];
            int[,] arrs1 = new int[2, 2] { {1,2}, {1,2} };
            int[,] arrs2 = new int[,] { { 1, 2, 4, 5 }, { 1, 2, 4, 5 } };

            Console.WriteLine("数组的行数为:" + arrs2.Rank);
            Console.WriteLine("数组的列数为:" + (arrs2.GetUpperBound(arrs2.Rank - 1) + 1));

            for(int i = 0; i < arrs2.Rank; i++)
            {
                String str = "";
                for (int j = 0; j < arrs2.GetUpperBound(arrs2.Rank - 1) + 1; j++)
                {
                    str = str + Convert.ToString(arrs2[i,j]);
                }
                Console.WriteLine(str);
            }


            //二维数组动态创建
            Console.WriteLine("请输入行数");
            int row = int.Parse(Console.ReadLine());
            Console.WriteLine("请输入列数");
            int col = int.Parse(Console.ReadLine());
            int[,] arry = new int[row, col];
            Console.WriteLine("结果:");
            for(int i = 0; i < row; i++)
            {
                for(int j = 0; j < col; j++)
                {
                    Console.Write("{0}{1} ",i,j);
                }
                Console.WriteLine();
            }

            //遍历数组
            foreach(int n in intarray)
            {
                Console.WriteLine(n);
            }

            //添加删除数组元素,一般通过ArrayList完成
            //数组的排序
            intarray = new int[] {3,9,27,6,18,12,21,15};
            foreach(int n in intarray)
            {
                Console.Write(n.ToString() + " ");
            }
            Console.WriteLine();

            //Array类的Sort 排序和Reverse反转
            Array.Sort(intarray);
            foreach (int n in intarray)
            {
                Console.Write(n.ToString() + " ");
            }
            Console.WriteLine();
            Array.Reverse(intarray);
            foreach (int n in intarray)
            {
                Console.Write(n.ToString() + " ");
            }
            Console.WriteLine();

            //ArrayList类
            ArrayList list1 = new ArrayList();//默认构造方法长度是4
            list1.Add(1);
            list1.Add(2);
            list1.Add(3);
            list1.Add(4);
            list1.Add(5);

            ArrayList list2 = new ArrayList(intarray);//用数组构造
            
            Console.WriteLine("数组元素个数:" + list1.Capacity);
            Console.WriteLine("数组元素数:" + list1.Count);
            Console.WriteLine("数组有固定大小:" + list1.IsFixedSize);
            Console.WriteLine("数组只读:" + list1.IsReadOnly);
            Console.WriteLine("数组可用于同步访问数组的对象:" + list1.IsSynchronized);
            Console.WriteLine("数组获得同步访问对象:" + list1.SyncRoot);

            //Insert方法
            int[] arra = {1,2,3,4,5,6};
            ArrayList list3 = new ArrayList(arra);//用数组构造
            foreach (int n in list3)
            {
                Console.Write(n.ToString() + " ");
            }
            Console.WriteLine();

            //指定位置插入元素
            list3.Insert(3,3);
            foreach (int n in list3)
            {
                Console.Write(n.ToString() + " ");
            }
            Console.WriteLine();

            //指定位置插入数组
            arra = new int[]{ 1, 2, 3, 4, 5, 6 };
            list3.InsertRange(3, arra);
            foreach (int n in list3)
            {
                Console.Write(n.ToString() + " ");
            }
            Console.WriteLine();

            //删除
            list3.RemoveAt(0);//删除索引项
            list3.Remove(2);//删除项
            list3.RemoveRange(0,2);//从0开始删除2项
            list3.Clear();

            foreach (int n in list3)
            {
                Console.Write(n.ToString() + " ");
            }
            Console.WriteLine();

            //遍历
            //foreach

            //判断元素是否在集合中
            Console.WriteLine("数组是否包含{0}" + list3.Contains(1), 1);


            //Hashtable哈希表
            Hashtable hashtable = new Hashtable();
            hashtable.Add("name","掌上电脑");
            hashtable.Add("age", "18");
            hashtable.Add("sex", "男");
            hashtable.Add("add", "中国");

            Hashtable hashtable1 = new Hashtable(5);

            Console.WriteLine("哈希表数据项:{0}" + hashtable.Count);
            Console.WriteLine("哈希表是否有固定大小:{0}" + hashtable.IsFixedSize);
            Console.WriteLine("哈希表是否只读:{0}" + hashtable.IsReadOnly);
            Console.WriteLine("哈希表是否线程安全:{0}" + hashtable.IsSynchronized);
            Console.WriteLine("哈希表keys列表:{0}" + hashtable.Keys);
            Console.WriteLine("哈希表values列表:{0}" + hashtable.Values);
            Console.WriteLine("哈希表线程同步对像:{0}" + hashtable.SyncRoot);

            //删除
            hashtable.Clear();
            hashtable.Remove("name");

            hashtable.Add("name", "掌上电脑");
            hashtable.Add("age", "18");
            hashtable.Add("sex", "男");
            hashtable.Add("add", "中国");

            //遍历
            foreach (DictionaryEntry dict in hashtable)
            {
                Console.WriteLine("\t" + dict.Key + "\t" + dict.Value);

            }

            //元素查找
            Console.WriteLine("哈希表是否包含key:{0}" + hashtable.Contains("name"), "name");
            Console.WriteLine("哈希表是否包含key:{0}" + hashtable.Contains("掌上电脑"), "掌上电脑");
            Console.WriteLine("哈希表是否包含key:{0}" + hashtable.ContainsKey("name"), "name");
            Console.WriteLine("哈希表是否包含value:{0}" + hashtable.ContainsValue("掌上电脑"), "掌上电脑");
            
        }


        /// <summary>
        /// 属性和方法
        /// </summary>
        static void attributeMethod()
        {
            Program1 program1 = new Program1();
            program1.Name = "123";
            program1.Age = 123;
            program1.Sex = "123";
            Console.WriteLine(program1.Name + " " + program1.Age + " " + program1.Sex);

            program1.Name = "321";
            program1.Age = 321;
            program1.Sex = "321";
            Console.WriteLine(program1.Name + " " + program1.Age + " " + program1.Sex);

            program1.method();//调用非静态方法
            program1.method(12);//调用非静态方法
            Program1.staticmethod();//调用静态方法

        }

        /// <summary>
        /// 结构和类
        /// </summary>
        static void structure()
        {
			//结构的使用
            Structure structure;
            structure.width = 10;
            structure.height = 20;
            Console.WriteLine("矩形的面积为{0}" , structure.Area());
            structure = new Structure(20,30);
            Console.WriteLine("矩形的面积为{0}", structure.Area());

            //类的构造方法
            ProgramBase programBase = new ProgramBase();

            Console.WriteLine("结果:" + programBase.z);

			//类的声明和实例化
			FatherClass fatherClass = new FatherClass();
            fatherClass.X = 3;
            fatherClass.Y = 5;
            fatherClass.Z = fatherClass.X + fatherClass.Y;
			Console.WriteLine(fatherClass.Z);
            Console.WriteLine(fatherClass.Add());
            
            //继承类的使用
            Console.WriteLine("继承类的使用");
            FatherClass fatherClass1 = new FatherClass();
			ChildClass childClass = new ChildClass();
            fatherClass1.X = 3;
            fatherClass1.Y = 5;
            childClass.X = 3;
            childClass.Y = 5;
            childClass.J = 7;
			Console.WriteLine(fatherClass1.Add());//父类调用父类的方法
			Console.WriteLine(childClass.Add());//子类调用父类的方法
			Console.WriteLine(childClass.ChildAdd());//子类调用子类的方法

            //虚拟类的继承
            Console.WriteLine("虚拟继承类的使用");
            VirtualChild virtualChild = new VirtualChild();
            VirtualClass virtualClass = virtualChild;
            virtualClass.X = 3;
            virtualClass.Y = 5;
            Console.WriteLine(virtualClass.Add());//父类的加法
			Console.WriteLine(virtualChild.Add());

        }


    }
}


namespace ConsoleLearn1
{
    
    /// <summary>
    /// 类
    /// new
    /// public 不限制访问
    /// protected 只能在所在类及子类中访问
    /// internal 只有所在类才能访问
    /// private 只有.NET中的应用程序和库才能访问
    /// abstract 抽象类，不能实例化
    /// sealed 密封类，不允许被继承
    /// </summary>
    public class Car
    {
        public int number; //编号
        public String color; // 颜色 
        private string brand; //厂家

    }

	/// <summary>
    /// 类
    /// 有构造函数和析构函数
    /// </summary>
	public class ProgramBase
	{
		public int x = 3;
		public int y = 5;
		public int z = 0;
		
		/// <summary>
		///	构造函数
		/// </summary>
		public ProgramBase(){

			z = x + y;
		}

		~ProgramBase(){

			Console.WriteLine("析构函数自动调用");
		}
	}


	/// <summary>
	///	虚拟基类
	/// </summary>
	class VirtualClass
    {
		private int x = 0;
		private int y = 0;

		public int X{
			get{
				return x;
			}
			set{
				x = value;
			}
		}

		
		public int Y{
			get{
				return y;
			}
			set{
				y = value;
			}
		}
		
		/// <summary>
		///	由子类实现
		/// </summary>
		public virtual int Add(){

            return X + Y;
		}

	}

	/// <summary>
	///	子类
	/// </summary>
	class VirtualChild: VirtualClass
    {

        /// <summary>
        /// 转换成父类的时候调用的方法也是子类方法
        /// </summary>
        /// <returns></returns>
        //public override int Add()
        //{

        //    return 5 + 7;
        //}

        /// <summary>
        /// 转换成父类的时候调用的方法是父类方法，相当于是子类自己创建的一个同名方法
        /// </summary>
        public new int Add()
        {
            return 5 + 7;
        }

    }

	/// <summary>
	///	父类
	/// </summary>
	class FatherClass
	{
		private int x = 0;
		private int y = 0;
		private int z = 0;

		public int X{
			get{
				return x;
			}
			set{
				x = value;
			}
		}

		public int Y{
			get{
				return y;
			}
			set{
				y = value;
			}
		}

		public int Z{
			get{
				return z;
			}
			set{
				z = value;
			}
		}

		/// <summary>
		///	加法方法
		/// </summary>
		public int Add(){

			return X + Y;
		}
	}

	/// <summary>
	///	子类继承父类
	/// </summary>
	class ChildClass: FatherClass
    {
		int j = 0;
		public int J{

			get{
				return j;
			}

			set{
				j = value;
			}
		}
		
		/// <summary>
		///	加法
		/// </summary>
		public int ChildAdd(){
			
			return X + Y + J;
		}
	}

    /// <summary>
    /// 结构
    /// </summary>
    public struct Structure
    {
        public double width; //矩形的宽
        public double height;//矩形的高

        public Structure(double width,double height)
        {
            this.width = width;
            this.height = height;
        }

        public double Area()
        {
            return width * height;
        }
    }

    /// <summary>
    /// 类
    /// </summary>
    class Program1
    {
        private String name;
        private int age;
        private String sex;

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

        public int Age
        {
            get
            {
                return age;
            }

            set
            {
                age = value;
            }
        }

        public string Sex
        {
            get
            {
                return sex;
            }

            set
            {
                sex = value;
            }
        }

        public void helloWorld()
        {
            Console.WriteLine("Program1 hello world!");
        }

        /// <summary>
        /// 方法
        /// </summary>
        public void method()
        {
            Console.WriteLine("void方法");
        }

        /// <summary>
        /// 方法重载
        /// </summary>
        public void method(int i)
        {
            Console.WriteLine("void重载方法");
        }

        /// <summary>
        /// 静态方法
        /// </summary>
        public static void staticmethod()
        {
            Console.WriteLine("静态方法");
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
