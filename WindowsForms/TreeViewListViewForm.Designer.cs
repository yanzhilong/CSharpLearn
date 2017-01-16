namespace WindowsForm
{
    partial class TreeViewListViewForm
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
            this.TreeViewFile = new System.Windows.Forms.TreeView();
            this.ListViewFile = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // TreeViewFile
            // 
            this.TreeViewFile.Location = new System.Drawing.Point(13, 13);
            this.TreeViewFile.Name = "TreeViewFile";
            this.TreeViewFile.Size = new System.Drawing.Size(121, 237);
            this.TreeViewFile.TabIndex = 0;
            this.TreeViewFile.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeViewFile_AfterSelect);
            // 
            // ListViewFile
            // 
            this.ListViewFile.Location = new System.Drawing.Point(145, 13);
            this.ListViewFile.MultiSelect = false;
            this.ListViewFile.Name = "ListViewFile";
            this.ListViewFile.Size = new System.Drawing.Size(213, 237);
            this.ListViewFile.TabIndex = 1;
            this.ListViewFile.UseCompatibleStateImageBehavior = false;
            this.ListViewFile.View = System.Windows.Forms.View.List;
            this.ListViewFile.SelectedIndexChanged += new System.EventHandler(this.ListViewFile_SelectedIndexChanged);
            this.ListViewFile.DoubleClick += new System.EventHandler(this.ListViewFile_DoubleClick);
            // 
            // TreeViewListViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 262);
            this.Controls.Add(this.ListViewFile);
            this.Controls.Add(this.TreeViewFile);
            this.Name = "TreeViewListViewForm";
            this.Text = "TreeViewListView";
            this.Load += new System.EventHandler(this.TreeViewListViewForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView TreeViewFile;
        private System.Windows.Forms.ListView ListViewFile;
    }
}