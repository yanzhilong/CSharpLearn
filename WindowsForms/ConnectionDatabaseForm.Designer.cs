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
            this.button3 = new System.Windows.Forms.Button();
            this.readerquery = new System.Windows.Forms.Button();
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
            this.connectionresult.Location = new System.Drawing.Point(14, 362);
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
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(0, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 27;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
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
            // ConnectionDatabaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 539);
            this.Controls.Add(this.readerquery);
            this.Controls.Add(this.button3);
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
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button readerquery;
    }
}