﻿using System;
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
    public partial class PanelForm : Form
    {
        public PanelForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PanelForm_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }
    }
}
