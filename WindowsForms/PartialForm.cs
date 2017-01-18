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
    public partial class PartialForm : Form
    {
        public PartialForm()
        {
            InitializeComponent();
        }

        partial class Account
        {
            public int add(int value1,int value2)
            {
                return value1 + value2;
            }
        }

        partial class Account
        {
            public int multiplication(int value1, int value2)
            {
                return value1 * value2;
            }
        }

        partial class Account
        {
            public int subtration(int value1, int value2)
            {
                return value1 - value2;
            }
        }

        partial class Account
        {
            public int division(int value1, int value2)
            {
                return value1 / value2;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            op.SelectedIndex = 0;
            op.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Account at = new Account();
                int M = int.Parse(value1.Text.Trim());
                int N = int.Parse(value2.Text.Trim());
                string str = op.Text;
                switch (str)
                {
                    case "加": result.Text = at.add(M, N).ToString(); break;
                    case "减": result.Text = at.subtration(M, N).ToString(); break;
                    case "乘": result.Text = at.multiplication(M, N).ToString(); break;
                    case "除": result.Text = at.division(M, N).ToString(); break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
