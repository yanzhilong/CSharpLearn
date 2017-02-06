using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using xyz.ibean.data;
using CrRepairs.model;

namespace CrRepairs
{
    public partial class LocationList : UserControl
    {
        private Repository repository;
        public LocationList()
        {
            InitializeComponent();
        }

        private void LocationList_Load(object sender, EventArgs e)
        {
            repository = Repository.newInstance();
            //设置最大化
            this.Dock = DockStyle.Fill;
            //获取地址列表
            List<Location> locations = repository.getLocations();

            for (int i = 0; i < locations.Count; i++)
            {
                TreeNode tn1 = treeView1.Nodes.Add(locations[i].LocationName);
            }
            //TreeNode tn1 = treeView1.Nodes.Add("报修模块");
            //TreeNode Ntn1 = new TreeNode("位置管理");
            //TreeNode Ntn2 = new TreeNode("设备点管理");
            //TreeNode Ntn3 = new TreeNode("报修位置管理");
            //TreeNode Ntn4 = new TreeNode("故障描述管理");
            //TreeNode Ntn5 = new TreeNode("故障分类管理");
            //TreeNode Ntn6 = new TreeNode("报修申请");
            //TreeNode Ntn7 = new TreeNode("报修列表管理");

            //tn1.Nodes.Add(Ntn1);
            //tn1.Nodes.Add(Ntn2);
            //tn1.Nodes.Add(Ntn3);
            //tn1.Nodes.Add(Ntn4);
            //tn1.Nodes.Add(Ntn5);
            //tn1.Nodes.Add(Ntn6);
            //tn1.Nodes.Add(Ntn7);

        }
    }
}
