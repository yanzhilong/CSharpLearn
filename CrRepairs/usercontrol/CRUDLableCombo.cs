using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace CrRepairs.usercontrol
{
    public partial class CRUDLableCombo : UserControl, CRUDItemVIewI
    {
        public CRUDLableCombo(string lablestr,string[] values)
        {
            InitializeComponent();
            this.label1.Text = lablestr;
            foreach(string str in values)
            {
                this.comboBox1.Items.Add(str);
            }
        }

        public string getLable()
        {
            return this.label1.Text;
        }

        public string getValue()
        {
            return this.comboBox1.Text;
        }

    }
}
