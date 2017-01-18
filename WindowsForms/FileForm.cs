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

        private void button3_Click(object sender, EventArgs e)
        {
            File.Copy(filetb1.Text,filetb2.Text);
            File.Copy(filetb1.Text, filetb2.Text,true);

            FileInfo fileinfo = new FileInfo(filetb1.Text);
            fileinfo.CopyTo(filetb2.Text);
            fileinfo.CopyTo(filetb2.Text,true);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            File.Move(filetb1.Text, filetb2.Text);
            FileInfo fileinfo = new FileInfo(filetb1.Text);
            fileinfo.MoveTo(filetb2.Text);

            Directory.Move(filetb1.Text,filetb2.Text);
            DirectoryInfo directoryinfo = new DirectoryInfo(filetb1.Text);
            directoryinfo.MoveTo(filetb2.Text);
            //c:\\Test 到 d:\\新建文件夹\\Test
        }

        private void button5_Click(object sender, EventArgs e)
        {
            File.Delete(filetb1.Text);
            FileInfo fileinfo = new FileInfo(filetb1.Text);
            fileinfo.Delete();

            //删除文件夹，只能删除空的文件夹
            Directory.Delete(filetb1.Text);
            Directory.Delete(filetb1.Text,true);//连子文件夹一起删除
            DirectoryInfo directoryinfo = new DirectoryInfo(filetb1.Text);
            directoryinfo.Delete();
            directoryinfo.Delete(true);//连子文件夹一起删除

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filetb.Text = openFileDialog1.FileName;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FileInfo finfo = new FileInfo(filetb.Text);         //实例化FileInfo对象
            string strCTime, strLATime, strLWTime, strName, strFName, strDName, strISRead;
            long lgLength;
            strCTime = finfo.CreationTime.ToShortDateString();    //获取文件创建时间
            strLATime = finfo.LastAccessTime.ToShortDateString(); //获取上次访问该文件的时间
            strLWTime = finfo.LastWriteTime.ToShortDateString();  //获取上次写入文件的时间
            strName = finfo.Name;                                 //获取文件名称
            strFName = finfo.FullName;                            //获取文件的完整目录
            strDName = finfo.DirectoryName;                       //获取文件的完整路径
            strISRead = finfo.IsReadOnly.ToString();              //获取文件是否只读
            lgLength = finfo.Length;                              //获取文件长度
            MessageBox.Show("文件信息：\n创建时间：" + strCTime + " 上次访问时间：" + strLATime + "\n上次写入时间：" + strLWTime + " 文件名称：" + strName + "\n完整目录：" + strFName + "\n完整路径：" + strDName + "\n是否只读：" + strISRead + " 文件长度：" + lgLength);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DirectoryInfo directoryinfo = new DirectoryInfo(filetb1.Text);
            DirectoryInfo[] dtiarray = directoryinfo.GetDirectories();//
            DirectoryInfo[] dtiarray1 = directoryinfo.GetDirectories("搜索的名字");//
            DirectoryInfo[] dtiarray2 = directoryinfo.GetDirectories("搜索的名字",SearchOption.TopDirectoryOnly);//当前目录
            DirectoryInfo[] dtiarray3 = directoryinfo.GetDirectories("搜索的名字", SearchOption.AllDirectories);//所有子目录

            FileInfo[] filearray = directoryinfo.GetFiles();//
            FileInfo[] filearray1 = directoryinfo.GetFiles("搜索的名字");//
            FileInfo[] filearray2 = directoryinfo.GetFiles("搜索的名字", SearchOption.TopDirectoryOnly);//当前目录的文件
            FileInfo[] filearray3 = directoryinfo.GetFiles("搜索的名字", SearchOption.AllDirectories);//所有子目录的文件

            FileSystemInfo[] filesysarray = directoryinfo.GetFileSystemInfos();//
            FileSystemInfo[] filesysarray1 = directoryinfo.GetFileSystemInfos("搜索的名字");//


        }

        private void button9_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                foldertb.Text = folderBrowserDialog1.SelectedPath;
                //实例化DirectoryInfo对象
                DirectoryInfo dinfo = new DirectoryInfo(foldertb.Text);
                //获取指定目录下的所有子目录及文件类型
                FileSystemInfo[] fsinfos = dinfo.GetFileSystemInfos();
                foreach (FileSystemInfo fsinfo in fsinfos)
                {
                    if (fsinfo is DirectoryInfo)    //判断是否文件夹
                    {
                        //使用获取的文件夹名称实例化DirectoryInfo对象
                        DirectoryInfo dirinfo = new DirectoryInfo(fsinfo.FullName);
                        //为ListView控件添加文件夹信息
                        listView1.Items.Add(dirinfo.Name);
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(dirinfo.FullName);
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add("");
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(dirinfo.CreationTime.ToShortDateString());
                    }
                    else
                    {
                        //使用获取的文件名称实例化FileInfo对象
                        FileInfo finfo = new FileInfo(fsinfo.FullName);
                        //为ListView控件添加文件信息
                        listView1.Items.Add(finfo.Name);
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(finfo.FullName);
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(finfo.Length.ToString());
                        listView1.Items[listView1.Items.Count - 1].SubItems.Add(finfo.CreationTime.ToShortDateString());
                    }
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
