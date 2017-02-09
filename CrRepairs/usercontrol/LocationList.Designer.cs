namespace CrRepairs
{
    partial class LocationList
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.addWithLocation = new System.Windows.Forms.Button();
            this.addChildLocation = new System.Windows.Forms.Button();
            this.locationNameTB = new System.Windows.Forms.TextBox();
            this.deleteLocation = new System.Windows.Forms.Button();
            this.updateLocation = new System.Windows.Forms.Button();
            this.selectLocationNameTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.editLocationName = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.addLocation = new System.Windows.Forms.Button();
            this.querystring = new System.Windows.Forms.TextBox();
            this.query = new System.Windows.Forms.Button();
            this.queryresult = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(3, 3);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(407, 340);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // addWithLocation
            // 
            this.addWithLocation.Enabled = false;
            this.addWithLocation.Location = new System.Drawing.Point(511, 320);
            this.addWithLocation.Name = "addWithLocation";
            this.addWithLocation.Size = new System.Drawing.Size(75, 23);
            this.addWithLocation.TabIndex = 1;
            this.addWithLocation.Text = "添加同级";
            this.addWithLocation.UseVisualStyleBackColor = true;
            this.addWithLocation.Click += new System.EventHandler(this.addLocation_Click);
            // 
            // addChildLocation
            // 
            this.addChildLocation.Enabled = false;
            this.addChildLocation.Location = new System.Drawing.Point(592, 320);
            this.addChildLocation.Name = "addChildLocation";
            this.addChildLocation.Size = new System.Drawing.Size(75, 23);
            this.addChildLocation.TabIndex = 2;
            this.addChildLocation.Text = "添加子级";
            this.addChildLocation.UseVisualStyleBackColor = true;
            this.addChildLocation.Click += new System.EventHandler(this.addChildLocation_Click);
            // 
            // locationNameTB
            // 
            this.locationNameTB.Location = new System.Drawing.Point(486, 293);
            this.locationNameTB.Name = "locationNameTB";
            this.locationNameTB.Size = new System.Drawing.Size(181, 21);
            this.locationNameTB.TabIndex = 4;
            // 
            // deleteLocation
            // 
            this.deleteLocation.Enabled = false;
            this.deleteLocation.Location = new System.Drawing.Point(592, 264);
            this.deleteLocation.Name = "deleteLocation";
            this.deleteLocation.Size = new System.Drawing.Size(75, 23);
            this.deleteLocation.TabIndex = 5;
            this.deleteLocation.Text = "删除地址";
            this.deleteLocation.UseVisualStyleBackColor = true;
            this.deleteLocation.Click += new System.EventHandler(this.deleteLocation_Click);
            // 
            // updateLocation
            // 
            this.updateLocation.Enabled = false;
            this.updateLocation.Location = new System.Drawing.Point(511, 264);
            this.updateLocation.Name = "updateLocation";
            this.updateLocation.Size = new System.Drawing.Size(75, 23);
            this.updateLocation.TabIndex = 7;
            this.updateLocation.Text = "更新";
            this.updateLocation.UseVisualStyleBackColor = true;
            this.updateLocation.Click += new System.EventHandler(this.updateLocation_Click);
            // 
            // selectLocationNameTB
            // 
            this.selectLocationNameTB.Enabled = false;
            this.selectLocationNameTB.Location = new System.Drawing.Point(486, 237);
            this.selectLocationNameTB.Name = "selectLocationNameTB";
            this.selectLocationNameTB.Size = new System.Drawing.Size(181, 21);
            this.selectLocationNameTB.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(425, 240);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "当前地址:";
            // 
            // editLocationName
            // 
            this.editLocationName.Enabled = false;
            this.editLocationName.Location = new System.Drawing.Point(427, 264);
            this.editLocationName.Name = "editLocationName";
            this.editLocationName.Size = new System.Drawing.Size(75, 23);
            this.editLocationName.TabIndex = 10;
            this.editLocationName.Text = "编辑";
            this.editLocationName.UseVisualStyleBackColor = true;
            this.editLocationName.Click += new System.EventHandler(this.editLocationName_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(425, 296);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "新地址:";
            // 
            // addLocation
            // 
            this.addLocation.Location = new System.Drawing.Point(430, 320);
            this.addLocation.Name = "addLocation";
            this.addLocation.Size = new System.Drawing.Size(75, 23);
            this.addLocation.TabIndex = 12;
            this.addLocation.Text = "添加位置";
            this.addLocation.UseVisualStyleBackColor = true;
            this.addLocation.Click += new System.EventHandler(this.addLocation_Click_1);
            // 
            // querystring
            // 
            this.querystring.Location = new System.Drawing.Point(427, 13);
            this.querystring.Name = "querystring";
            this.querystring.Size = new System.Drawing.Size(240, 21);
            this.querystring.TabIndex = 13;
            this.querystring.TextChanged += new System.EventHandler(this.querystring_TextChanged);
            // 
            // query
            // 
            this.query.Location = new System.Drawing.Point(673, 11);
            this.query.Name = "query";
            this.query.Size = new System.Drawing.Size(75, 23);
            this.query.TabIndex = 14;
            this.query.Text = "查询";
            this.query.UseVisualStyleBackColor = true;
            // 
            // queryresult
            // 
            this.queryresult.FormattingEnabled = true;
            this.queryresult.ItemHeight = 12;
            this.queryresult.Location = new System.Drawing.Point(430, 41);
            this.queryresult.Name = "queryresult";
            this.queryresult.Size = new System.Drawing.Size(237, 184);
            this.queryresult.TabIndex = 15;
            // 
            // LocationList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.queryresult);
            this.Controls.Add(this.query);
            this.Controls.Add(this.querystring);
            this.Controls.Add(this.addLocation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.editLocationName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.selectLocationNameTB);
            this.Controls.Add(this.updateLocation);
            this.Controls.Add(this.deleteLocation);
            this.Controls.Add(this.locationNameTB);
            this.Controls.Add(this.addChildLocation);
            this.Controls.Add(this.addWithLocation);
            this.Controls.Add(this.treeView1);
            this.Name = "LocationList";
            this.Size = new System.Drawing.Size(760, 346);
            this.Load += new System.EventHandler(this.LocationList_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button addWithLocation;
        private System.Windows.Forms.Button addChildLocation;
        private System.Windows.Forms.TextBox locationNameTB;
        private System.Windows.Forms.Button deleteLocation;
        private System.Windows.Forms.Button updateLocation;
        private System.Windows.Forms.TextBox selectLocationNameTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button editLocationName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button addLocation;
        private System.Windows.Forms.TextBox querystring;
        private System.Windows.Forms.Button query;
        private System.Windows.Forms.ListBox queryresult;
    }
}
