namespace WindowsForm
{
    partial class PartialForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.value1 = new System.Windows.Forms.TextBox();
            this.op = new System.Windows.Forms.ComboBox();
            this.value2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.result = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.result);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.value2);
            this.groupBox1.Controls.Add(this.op);
            this.groupBox1.Controls.Add(this.value1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(358, 107);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "运算";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // value1
            // 
            this.value1.Location = new System.Drawing.Point(7, 21);
            this.value1.Name = "value1";
            this.value1.Size = new System.Drawing.Size(100, 21);
            this.value1.TabIndex = 0;
            // 
            // op
            // 
            this.op.FormattingEnabled = true;
            this.op.Items.AddRange(new object[] {
            "加",
            "减",
            "乘",
            "除"});
            this.op.Location = new System.Drawing.Point(114, 21);
            this.op.Name = "op";
            this.op.Size = new System.Drawing.Size(47, 20);
            this.op.TabIndex = 1;
            // 
            // value2
            // 
            this.value2.Location = new System.Drawing.Point(168, 21);
            this.value2.Name = "value2";
            this.value2.Size = new System.Drawing.Size(100, 21);
            this.value2.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(274, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "等于";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "结果:";
            // 
            // result
            // 
            this.result.Location = new System.Drawing.Point(48, 64);
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(220, 21);
            this.result.TabIndex = 5;
            // 
            // PartialForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 136);
            this.Controls.Add(this.groupBox1);
            this.Name = "PartialForm";
            this.Text = "PartialForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox result;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox value2;
        private System.Windows.Forms.ComboBox op;
        private System.Windows.Forms.TextBox value1;
    }
}