namespace WindowsForm
{
    partial class ConnectionDatabaseForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.databasttype = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.database = new System.Windows.Forms.TextBox();
            this.connection = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.user = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.server = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.port = new System.Windows.Forms.TextBox();
            this.connectionresult = new System.Windows.Forms.RichTextBox();
            this.close = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tablename = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.selectCount = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.nonsql = new System.Windows.Forms.TextBox();
            this.nonquery = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.readersql = new System.Windows.Forms.TextBox();
            this.readerquery = new System.Windows.Forms.Button();
            this.havevalue = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.loadsql = new System.Windows.Forms.TextBox();
            this.loaddata = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label11 = new System.Windows.Forms.Label();
            this.idtb = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.nametb = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.agetb = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.loadsqlnew = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.tabletb = new System.Windows.Forms.TextBox();
            this.button11 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // databasttype
            // 
            this.databasttype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.databasttype.FormattingEnabled = true;
            this.databasttype.Location = new System.Drawing.Point(75, 13);
            this.databasttype.Name = "databasttype";
            this.databasttype.Size = new System.Drawing.Size(121, 20);
            this.databasttype.TabIndex = 0;
            this.databasttype.SelectedIndexChanged += new System.EventHandler(this.databasttype_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "数据库:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "数据库名:";
            // 
            // database
            // 
            this.database.Location = new System.Drawing.Point(75, 69);
            this.database.Name = "database";
            this.database.Size = new System.Drawing.Size(121, 21);
            this.database.TabIndex = 3;
            // 
            // connection
            // 
            this.connection.Location = new System.Drawing.Point(219, 160);
            this.connection.Name = "connection";
            this.connection.Size = new System.Drawing.Size(75, 23);
            this.connection.TabIndex = 4;
            this.connection.Text = "连接";
            this.connection.UseVisualStyleBackColor = true;
            this.connection.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "用户名:";
            // 
            // user
            // 
            this.user.Location = new System.Drawing.Point(75, 100);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(121, 21);
            this.user.TabIndex = 7;
            this.user.Text = "root";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "密码:";
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(75, 129);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(121, 21);
            this.password.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "服务器:";
            // 
            // server
            // 
            this.server.Location = new System.Drawing.Point(75, 39);
            this.server.Name = "server";
            this.server.Size = new System.Drawing.Size(121, 21);
            this.server.TabIndex = 11;
            this.server.Text = "localhost";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "端口:";
            // 
            // port
            // 
            this.port.Location = new System.Drawing.Point(75, 159);
            this.port.Name = "port";
            this.port.Size = new System.Drawing.Size(121, 21);
            this.port.TabIndex = 14;
            // 
            // connectionresult
            // 
            this.connectionresult.Location = new System.Drawing.Point(14, 340);
            this.connectionresult.Name = "connectionresult";
            this.connectionresult.Size = new System.Drawing.Size(278, 131);
            this.connectionresult.TabIndex = 15;
            this.connectionresult.Text = "";
            // 
            // close
            // 
            this.close.Location = new System.Drawing.Point(14, 196);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(75, 23);
            this.close.TabIndex = 16;
            this.close.Text = "关闭连接";
            this.close.UseVisualStyleBackColor = true;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(177, 195);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "释放连接";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(96, 195);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 18;
            this.button2.Text = "重新打开";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tablename
            // 
            this.tablename.Location = new System.Drawing.Point(75, 230);
            this.tablename.Name = "tablename";
            this.tablename.Size = new System.Drawing.Size(121, 21);
            this.tablename.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 233);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 20;
            this.label7.Text = "表名";
            // 
            // selectCount
            // 
            this.selectCount.Location = new System.Drawing.Point(202, 228);
            this.selectCount.Name = "selectCount";
            this.selectCount.Size = new System.Drawing.Size(75, 23);
            this.selectCount.TabIndex = 21;
            this.selectCount.Text = "查询数据";
            this.selectCount.UseVisualStyleBackColor = true;
            this.selectCount.Click += new System.EventHandler(this.selectCount_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 267);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 22;
            this.label8.Text = "增删改";
            // 
            // nonsql
            // 
            this.nonsql.Location = new System.Drawing.Point(75, 264);
            this.nonsql.Name = "nonsql";
            this.nonsql.Size = new System.Drawing.Size(121, 21);
            this.nonsql.TabIndex = 23;
            this.nonsql.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // nonquery
            // 
            this.nonquery.Location = new System.Drawing.Point(202, 262);
            this.nonquery.Name = "nonquery";
            this.nonquery.Size = new System.Drawing.Size(75, 23);
            this.nonquery.TabIndex = 24;
            this.nonquery.Text = "NonQuery";
            this.nonquery.UseVisualStyleBackColor = true;
            this.nonquery.Click += new System.EventHandler(this.nonquery_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 307);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 25;
            this.label9.Text = "查询";
            // 
            // readersql
            // 
            this.readersql.Location = new System.Drawing.Point(75, 304);
            this.readersql.Name = "readersql";
            this.readersql.Size = new System.Drawing.Size(121, 21);
            this.readersql.TabIndex = 26;
            // 
            // readerquery
            // 
            this.readerquery.Location = new System.Drawing.Point(202, 302);
            this.readerquery.Name = "readerquery";
            this.readerquery.Size = new System.Drawing.Size(75, 23);
            this.readerquery.TabIndex = 28;
            this.readerquery.Text = "query";
            this.readerquery.UseVisualStyleBackColor = true;
            this.readerquery.Click += new System.EventHandler(this.readerquery_Click);
            // 
            // havevalue
            // 
            this.havevalue.Location = new System.Drawing.Point(283, 302);
            this.havevalue.Name = "havevalue";
            this.havevalue.Size = new System.Drawing.Size(75, 23);
            this.havevalue.TabIndex = 29;
            this.havevalue.Text = "判断有值";
            this.havevalue.UseVisualStyleBackColor = true;
            this.havevalue.Click += new System.EventHandler(this.havevalue_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 483);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 30;
            this.label10.Text = "查询";
            // 
            // loadsql
            // 
            this.loadsql.Location = new System.Drawing.Point(57, 478);
            this.loadsql.Name = "loadsql";
            this.loadsql.Size = new System.Drawing.Size(139, 21);
            this.loadsql.TabIndex = 31;
            // 
            // loaddata
            // 
            this.loaddata.Location = new System.Drawing.Point(202, 477);
            this.loaddata.Name = "loaddata";
            this.loaddata.Size = new System.Drawing.Size(75, 23);
            this.loaddata.TabIndex = 32;
            this.loaddata.Text = "加载数据";
            this.loaddata.UseVisualStyleBackColor = true;
            this.loaddata.Click += new System.EventHandler(this.loaddata_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(14, 580);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.ShowEditingIcon = false;
            this.dataGridView1.Size = new System.Drawing.Size(278, 150);
            this.dataGridView1.TabIndex = 33;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 744);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 34;
            this.label11.Text = "编号";
            // 
            // idtb
            // 
            this.idtb.Location = new System.Drawing.Point(47, 741);
            this.idtb.Name = "idtb";
            this.idtb.Size = new System.Drawing.Size(54, 21);
            this.idtb.TabIndex = 35;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(107, 744);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 12);
            this.label12.TabIndex = 36;
            this.label12.Text = "姓名";
            // 
            // nametb
            // 
            this.nametb.Location = new System.Drawing.Point(142, 741);
            this.nametb.Name = "nametb";
            this.nametb.Size = new System.Drawing.Size(80, 21);
            this.nametb.TabIndex = 37;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(228, 744);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 12);
            this.label13.TabIndex = 38;
            this.label13.Text = "年龄:";
            // 
            // agetb
            // 
            this.agetb.Location = new System.Drawing.Point(269, 741);
            this.agetb.Name = "agetb";
            this.agetb.Size = new System.Drawing.Size(48, 21);
            this.agetb.TabIndex = 39;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(14, 774);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 40;
            this.button3.Text = "修改";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(202, 507);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 43;
            this.button6.Text = "加载数据";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 512);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 12);
            this.label14.TabIndex = 44;
            this.label14.Text = "新数据";
            // 
            // loadsqlnew
            // 
            this.loadsqlnew.Location = new System.Drawing.Point(57, 509);
            this.loadsqlnew.Name = "loadsqlnew";
            this.loadsqlnew.Size = new System.Drawing.Size(139, 21);
            this.loadsqlnew.TabIndex = 45;
            this.loadsqlnew.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(16, 536);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 46;
            this.button4.Text = "合并数据";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(96, 536);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 47;
            this.button5.Text = "复制并显示";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(39, 950);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 48;
            this.button7.Text = "第一条";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(120, 950);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 49;
            this.button8.Text = "上一条";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(202, 950);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 50;
            this.button9.Text = "下一条";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(283, 950);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 23);
            this.button10.TabIndex = 51;
            this.button10.Text = "最后一条";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(14, 819);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(29, 12);
            this.label15.TabIndex = 52;
            this.label15.Text = "表名";
            // 
            // tabletb
            // 
            this.tabletb.Location = new System.Drawing.Point(49, 816);
            this.tabletb.Name = "tabletb";
            this.tabletb.Size = new System.Drawing.Size(214, 21);
            this.tabletb.TabIndex = 53;
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(283, 816);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(75, 23);
            this.button11.TabIndex = 54;
            this.button11.Text = "查询";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(12, 845);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(363, 99);
            this.dataGridView2.TabIndex = 55;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(14, 979);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(75, 23);
            this.button12.TabIndex = 56;
            this.button12.Text = "获取单元格";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(96, 979);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(75, 23);
            this.button13.TabIndex = 57;
            this.button13.Text = "修改多行";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(0, 0);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(75, 23);
            this.button14.TabIndex = 58;
            this.button14.Text = "button14";
            this.button14.UseVisualStyleBackColor = true;
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(177, 979);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(75, 23);
            this.button15.TabIndex = 59;
            this.button15.Text = "手动添加数据";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(258, 979);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(75, 23);
            this.button16.TabIndex = 60;
            this.button16.Text = "下拉列表";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // ConnectionDatabaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 1040);
            this.Controls.Add(this.button16);
            this.Controls.Add(this.button15);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.tabletb);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.loadsqlnew);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.agetb);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.nametb);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.idtb);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.loaddata);
            this.Controls.Add(this.loadsql);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.havevalue);
            this.Controls.Add(this.readerquery);
            this.Controls.Add(this.readersql);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.nonquery);
            this.Controls.Add(this.nonsql);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.selectCount);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tablename);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.close);
            this.Controls.Add(this.connectionresult);
            this.Controls.Add(this.port);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.server);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.password);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.user);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.connection);
            this.Controls.Add(this.database);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.databasttype);
            this.Name = "ConnectionDatabaseForm";
            this.Text = "ConnectionDatabaseForm";
            this.Load += new System.EventHandler(this.ConnectionDatabaseForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox databasttype;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox database;
        private System.Windows.Forms.Button connection;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox user;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox server;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox port;
        private System.Windows.Forms.RichTextBox connectionresult;
        private System.Windows.Forms.Button close;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tablename;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button selectCount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox nonsql;
        private System.Windows.Forms.Button nonquery;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox readersql;
        private System.Windows.Forms.Button readerquery;
        private System.Windows.Forms.Button havevalue;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox loadsql;
        private System.Windows.Forms.Button loaddata;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox idtb;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox nametb;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox agetb;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox loadsqlnew;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tabletb;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button16;
    }
}