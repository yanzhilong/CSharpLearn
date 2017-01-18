using System;
using System.Collections;
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
    public partial class IEnumeratorForm : Form
    {
        public IEnumeratorForm()
        {
            InitializeComponent();
        }

        
        public class Family : IEnumerable
        {
            string[] MyFamily = { "父亲", "母亲", "弟弟", "妹妹" };
            public IEnumerator GetEnumerator()
            {
                for (int i = 0; i < MyFamily.Length; i++)
                {
                    yield return MyFamily[i];
                }
            }
        }

        private void IEnumeratorForm_Load(object sender, EventArgs e)
        {
            Family f = new Family();
            foreach(string str in f)
            {
                richTextBox1.Text += str + "\n";
            }
        }
    }
}
