namespace osi_explorer_searcher
{
    partial class frmBrowser
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Windows (C:)", 8, 32, new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("STORAGE (D:)", 8, 32, new System.Windows.Forms.TreeNode[] {
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("WORK (E:)", 8, 32, new System.Windows.Forms.TreeNode[] {
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("DVD-RAM Drive (F:)", 35, 36, new System.Windows.Forms.TreeNode[] {
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Control Panel", 24, 25, new System.Windows.Forms.TreeNode[] {
            treeNode9});
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("mtr\'s Documents", 9, 23, new System.Windows.Forms.TreeNode[] {
            treeNode11});
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Shared Documents", 9, 23, new System.Windows.Forms.TreeNode[] {
            treeNode13});
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("USB Video Device", 26, 31);
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("My Computer", 7, 18, new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode4,
            treeNode6,
            treeNode8,
            treeNode10,
            treeNode12,
            treeNode14,
            treeNode15});
            this.osiBrowser = new FileBrowser.Browser();
            this.SuspendLayout();
            // 
            // osiBrowser
            // 
            this.osiBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.osiBrowser.ListViewMode = System.Windows.Forms.View.List;
            this.osiBrowser.Location = new System.Drawing.Point(12, 12);
            this.osiBrowser.Name = "osiBrowser";
            treeNode1.Name = "";
            treeNode1.Text = "";
            treeNode2.ImageIndex = 8;
            treeNode2.Name = "Windows (C:)";
            treeNode2.SelectedImageIndex = 32;
            treeNode2.Text = "Windows (C:)";
            treeNode3.Name = "";
            treeNode3.Text = "";
            treeNode4.ImageIndex = 8;
            treeNode4.Name = "STORAGE (D:)";
            treeNode4.SelectedImageIndex = 32;
            treeNode4.Text = "STORAGE (D:)";
            treeNode5.Name = "";
            treeNode5.Text = "";
            treeNode6.ImageIndex = 8;
            treeNode6.Name = "WORK (E:)";
            treeNode6.SelectedImageIndex = 32;
            treeNode6.Text = "WORK (E:)";
            treeNode7.Name = "";
            treeNode7.Text = "";
            treeNode8.ImageIndex = 35;
            treeNode8.Name = "DVD-RAM Drive (F:)";
            treeNode8.SelectedImageIndex = 36;
            treeNode8.Text = "DVD-RAM Drive (F:)";
            treeNode9.Name = "";
            treeNode9.Text = "";
            treeNode10.ImageIndex = 24;
            treeNode10.Name = "Control Panel";
            treeNode10.SelectedImageIndex = 25;
            treeNode10.Text = "Control Panel";
            treeNode11.Name = "";
            treeNode11.Text = "";
            treeNode12.ImageIndex = 9;
            treeNode12.Name = "mtr\'s Documents";
            treeNode12.SelectedImageIndex = 23;
            treeNode12.Text = "mtr\'s Documents";
            treeNode13.Name = "";
            treeNode13.Text = "";
            treeNode14.ImageIndex = 9;
            treeNode14.Name = "Shared Documents";
            treeNode14.SelectedImageIndex = 23;
            treeNode14.Text = "Shared Documents";
            treeNode15.ImageIndex = 26;
            treeNode15.Name = "USB Video Device";
            treeNode15.SelectedImageIndex = 31;
            treeNode15.Text = "USB Video Device";
            treeNode16.ImageIndex = 7;
            treeNode16.Name = "My Computer";
            treeNode16.SelectedImageIndex = 18;
            treeNode16.Text = "My Computer";
            this.osiBrowser.SelectedNode = treeNode16;
            this.osiBrowser.ShowFoldersButton = false;
            this.osiBrowser.ShowNavigationBar = false;
            this.osiBrowser.Size = new System.Drawing.Size(741, 439);
            this.osiBrowser.SplitterDistance = 162;
            this.osiBrowser.TabIndex = 0;
            // 
            // frmBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 456);
            this.Controls.Add(this.osiBrowser);
            this.Name = "frmBrowser";
            this.Text = "frmBrowser";
            this.Load += new System.EventHandler(this.frmBrowser_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private FileBrowser.Browser osiBrowser;
    }
}