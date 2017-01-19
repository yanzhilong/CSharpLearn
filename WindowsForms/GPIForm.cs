using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForm
{
    public partial class GPIForm : Form
    {
        public GPIForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics ghs = this.CreateGraphics();					//创建Graphics对象
            Brush mybs = new SolidBrush(Color.Red);				//使用SolidBrush类创建一个Brush对象
            Rectangle rt = new Rectangle(10, 10, 100, 100);				//绘制一个矩形
            ghs.FillRectangle(mybs, rt);								//用Brush填充Rectangle
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Graphics ghs = this.CreateGraphics();					//创建Graphics对象
            for (int i = 1; i < 6; i++)								//使用for循环
            {
                HatchStyle hs = (HatchStyle)(5 + i);					//设置HatchStyle值
                HatchBrush hb = new HatchBrush(hs, Color.White);		//实例化HatchBrush类
                Rectangle rtl = new Rectangle(10, 50 * i, 50 * i, 50);			//根据i值绘制矩形
                ghs.FillRectangle(hb, rtl);							//填充矩形
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //实例化两个Point类
            Point p1 = new Point(100, 100);
            Point p2 = new Point(150, 150);
            //实例化LinerGradientBrush类，设置其使用黑色和白色进行渐变
            LinearGradientBrush lgb = new LinearGradientBrush(p1, p2, Color.Black, Color.White);
            Graphics ghs = this.CreateGraphics();					//实例化Graphics类
            //设置WrapMode属性指示该LinearGradientBrush的环绕模式
            lgb.WrapMode = WrapMode.TileFlipX;
            ghs.FillRectangle(lgb, 15, 15, 150, 150);					//填充绘制矩形
        }
    }
}
