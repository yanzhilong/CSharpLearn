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
    public partial class MDIBaseForm : Form
    {
        public MDIBaseForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void 加载子窗体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MDIBaseChild1 mdiBasechild1 = new MDIBaseChild1();
            mdiBasechild1.MdiParent = this;
            mdiBasechild1.Show();

            MDIBaseChild2 mdiBasechild2 = new MDIBaseChild2();
            mdiBasechild2.MdiParent = this;
            mdiBasechild2.Show();

            MDIBaseChild3 mdiBasechild3 = new MDIBaseChild3();
            mdiBasechild3.MdiParent = this;
            mdiBasechild3.Show();

        }

        private void 水平平铺ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void 垂直平铺ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void 层叠ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }
    }
}
