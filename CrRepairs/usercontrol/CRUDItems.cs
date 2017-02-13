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
using CrRepairs.viewinterface;

namespace CrRepairs.usercontrol
{
    public partial class CRUDItems : UserControl
    {
        private ViewExitI ve;
        public CRUDItems()
        {
            InitializeComponent();
           
        }


        public void addItems(Hashtable hashtable, Object i)
        {
            this.ve = (ViewExitI)i;
            foreach (DictionaryEntry dict in hashtable)
            {
                string lable = (string)dict.Key;
                string value = (string)dict.Value;
                CRUDLableTextBox crudltb = new CRUDLableTextBox(lable, value);
                this.flowLayoutPanel1.Controls.Add(crudltb);
            }
        }


        private void cancel_Click(object sender, EventArgs e)
        {
            ve.exit();
        }
    }
}
