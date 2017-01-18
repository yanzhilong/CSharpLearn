using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForm
{
    public partial class FanXingForm : Form
    {
        public FanXingForm()
        {
            InitializeComponent();
        }

        public class Finder                                     //建立一个公共类Finder
        {
            public static int Find<T>(T[] items, T item)                    //创建泛型方法
            {
                for (int i = 0; i < items.Length; i++)                      //调用for循环
                {
                    if (items[i].Equals(item))                          //调用Equals方法比较两个数
                    {
                        return i;                                   //返回相等数在数组中的位置
                    }
                }
                return -1;                                      //如果不存在指定的数，则返回-1
            }
        }

        public interface IGenericInterface<T>
        {
            T CreateInstance();
        }

        //实现上面泛型接口的泛型类
        //派生约束where T : TI（T要继承自TI）
        //构造函数约束where T : new()（T可以实例化）
        public class Factory<T, TI> : IGenericInterface<TI> where T : TI, new()
        {
            public TI CreateInstance()                          //创建一个公共方法CreateInstance
            {
                return new T();
            }
        }

        class myclass1<T>
        {
            public myclass1()
            {
                Console.WriteLine("这是第一个泛型类");
            }
        }
        class myclass2<T> : myclass1<T>
        {
            public myclass2()
            {
                Console.WriteLine("这是第二个泛型类");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //实例化接口
            IGenericInterface<System.ComponentModel.IListSource> factory = new Factory<System.Data.DataTable, System.ComponentModel.IListSource>();
            //输出指定泛型的类型
            Console.WriteLine(factory.CreateInstance().GetType().ToString());
            Console.ReadLine();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i = Finder.Find<int>(new int[] { 1, 2, 3, 4, 5, 6, 8, 9 }, 6);	//调用泛型方法，并定义数组指定数字
            Console.WriteLine("6在数组中的位置：" + i.ToString());		//输出中数字在数组中的位置
            Console.ReadLine();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<int> myList = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                myList.Add(i);
            }
            foreach (int i in myList)
            {
                Console.WriteLine(i);
            }
            Console.ReadLine();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            myclass1<int> mclass1 = new myclass1<int>();
            myclass2<int> mclass2 = new myclass2<int>();
        }
    }
}
