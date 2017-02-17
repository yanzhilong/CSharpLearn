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
    public partial class CRUDLableRadioButton : UserControl, CRUDItemVIewI
    {
        List<RadioButton> radios = new List<RadioButton>();
        public CRUDLableRadioButton(string lablestr,string[] values)
        {
            InitializeComponent();
            this.label1.Text = lablestr;
            radioButton1.Text = values[0];
            radioButton1.Checked = true;
            radioButton2.Text = values[1];
        }

        public string getLable()
        {
            return this.label1.Text;
        }

        public string getValue()
        {
            if (radioButton1.Checked)
            {
                return radioButton1.Text;
            }else
            {
                return radioButton2.Text;
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
