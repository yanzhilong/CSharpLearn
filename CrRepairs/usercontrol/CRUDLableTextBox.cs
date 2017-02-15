﻿using System;
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
    public partial class CRUDLableTextBox : UserControl,CRUDItemVIewI
    {
        public CRUDLableTextBox(string lablestr,string value,bool enable)
        {
            InitializeComponent();
            this.label1.Text = lablestr;
            this.textBox1.Text = value;
            this.textBox1.Enabled = enable;
        }

        public string getLable()
        {
            return this.label1.Text;
        }

        public string getValue()
        {
            return this.textBox1.Text;
        }

    }
}
