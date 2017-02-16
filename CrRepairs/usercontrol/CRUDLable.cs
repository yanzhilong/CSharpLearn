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
    public partial class CRUDLable : UserControl, CRUDItemVIewI
    {
        public CRUDLable(string lablestr)
        {
            InitializeComponent();
            this.label1.Text = lablestr;
           
        }

        public string getLable()
        {
            return this.label1.Text;
        }

        public string getValue()
        {
            return this.label1.Text;
        }

    }
}
