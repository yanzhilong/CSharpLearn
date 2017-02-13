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
    public partial class CRUDLableTextBox : UserControl
    {
        public CRUDLableTextBox(string lablestr,string value)
        {
            InitializeComponent();
            this.label1.Text = lablestr;
            this.textBox1.Text = value;
        }

        public Hashtable getValue()
        {
            Hashtable hashtable = new Hashtable();
            hashtable.Add(this.label1.Text,this.textBox1.Text);
            return hashtable;
        }
       
    }
}
