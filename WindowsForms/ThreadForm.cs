using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForm
{
    public partial class ThreadForm : Form
    {
        StringBuilder message = new StringBuilder();

        public ThreadForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string strInfo = string.Empty;                             //定义一个字符串，用来记录线程相关信息
            Thread myThread = new Thread(new ThreadStart(threadOut));  //实例化Thread线程类对象
            myThread.Start();                                          //启动新的线程
            //获取线程相关信息
            strInfo = "线程唯一标识符：" + myThread.ManagedThreadId;
            strInfo += "\n线程名称：" + myThread.Name;
            strInfo += "\n线程状态：" + myThread.ThreadState.ToString();
            strInfo += "\n线程优先级：" + myThread.Priority.ToString();
            strInfo += "\n是否为后台线程：" + myThread.IsBackground;
            Thread.Sleep(1000);                                        //使主线程休眠1秒钟
            myThread.Abort("退出");                                    //通过主线程阻止新开线程
            myThread.Join();                                           //等待新开的线程结束
            message.Append("线程运行结束\n");
            message.Append(strInfo + "\n");
            refreshMessage();
        }

        public void threadOut()
        {
            message.Append("新线程开始运行\n");
            refreshMessage();
        }

        public void refreshMessage()
        {
            richTextBox1.Text = message.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Thread myThread;									//声明线程
            //用线程起始点的ThreadStart委托创建该线程的实例
            myThread = new Thread(new ThreadStart(createThread));
            myThread.Start();

            myThread.Abort();//终止线程
            myThread.Join();//阻止调用该线程，直到线程终止    
        }

        private void createThread()
        {
            message.Append("创建线程\n");
            refreshMessage();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(threadSuspend));
            thread.Start();//启动线程
            thread.Suspend();//挂起线程
            thread.Resume();//恢复线程

            thread.Abort();//终止线程
            thread.Join();//阻止调用该线程，直到线程终止    
        }

        private void threadSuspend()
        {
            message.Append("创建线程\n");
            refreshMessage();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(threadSuspend));
            thread.Start();//启动线程
            thread.Suspend();//挂起线程
            thread.Abort();//终止线程
            thread.Join();//阻止调用该线程，直到线程终止       
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Thread thread1 = new Thread(new ThreadStart(Thread1));   //使用自定义方法Thread1声明线程
            thread1.Priority = ThreadPriority.Lowest;              //设置线程的调度优先级
            Thread thread2 = new Thread(new ThreadStart(Thread2)); //使用自定义方法Thread2声明线程
            thread1.Start();                                       //开启线程一
            thread2.Start();
        }
        private void Thread1()
        {
            message.Append("线程一\n");
            refreshMessage();
        }
        private void Thread2()
        {
            message.Append("线程二\n");
            refreshMessage();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(threadlock1));
            thread.Start();//启动线程
            thread.Abort();//终止线程
            thread.Join();//阻止调用该线程，直到线程终止    
        }

        public void threadlock1()
        {
            lock (this)									//锁定当前线程，以实现同步
            {
                Console.WriteLine("锁定线程以实现线程同步");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(threadlock2));
            thread.Start();//启动线程
            thread.Abort();//终止线程
            thread.Join();//阻止调用该线程，直到线程终止 
        }

        public void threadlock2()
        {
            Monitor.Enter(this);						//锁定当前线程
            Console.WriteLine("锁定线程以实现线程同步");
            Monitor.Exit(this);						//释放当前线程
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(threadlock3));
            thread.Start();//启动线程
            thread.Abort();//终止线程
            thread.Join();//阻止调用该线程，直到线程终止 
        }

        public void threadlock3()
        {
            Mutex myMutex = new Mutex(false);				//实例化Mutex类对象
            myMutex.WaitOne();							//阻止当前线程
            Console.WriteLine("锁定线程以实现线程同步");
            myMutex.ReleaseMutex();						//释放Mutex对象
        }
    }
}
