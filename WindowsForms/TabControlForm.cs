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
    public partial class TabControlForm : Form
    {
        public TabControlForm()
        {
            InitializeComponent();
        }

        private void TabControlForm_Load(object sender, EventArgs e)
        {
            tabPage1.ImageIndex = 0;
            tabPage1.Text = "选项卡1";
            tabPage1.ToolTipText = "1";
            tabPage2.ImageIndex = 0;
            tabPage2.Text = "选项卡2";
            tabPage2.ToolTipText = "2";
        }
    }
}
