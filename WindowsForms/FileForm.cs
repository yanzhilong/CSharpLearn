using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForm
{
    public partial class FileForm : Form
    {
        public FileForm()
        {
            InitializeComponent();
        }

        StringBuilder result = new StringBuilder();

        private void button1_Click(object sender, EventArgs e)
        {
            String file = "d:\\test.txt";
            FileInfo fileinfo = new FileInfo(file);
            bool exist = fileinfo.Exists;
            if (File.Exists(file))       //使用File类的Exists方法判断要创建的文件是否存在
            {
                result.Append("d:\\test.txt" + "已经存在. \n");
            }
            else
            {
                File.Create(file);       //使用File类的Create方法创建文件
                //fileinfo.Create();      //这里也可以创建文件
                result.Append("d:\\test.txt" + "创建成功. \n");
            }
            refreshMessage();
        }

        private void refreshMessage()
        {
            richTextBox1.Text = result.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String file = "d:\\test";
            DirectoryInfo directoryInfo = new DirectoryInfo(file);
            bool existi = directoryInfo.Exists;
            if (Directory.Exists(file))       //使用File类的Exists方法判断要创建的文件是否存在
            {
                result.Append("d:\\test" + "已经存在. \n");
            }
            else
            {
                Directory.CreateDirectory(file);       //使用File类的Create方法创建文件
                result.Append("d:\\test" + "创建成功. \n");
            }
            refreshMessage();
        }
    }
}
