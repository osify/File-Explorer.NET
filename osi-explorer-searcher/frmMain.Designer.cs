namespace osi_explorer_searcher
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tvSubDir = new System.Windows.Forms.TreeView();
            this.m_imageListTreeView = new System.Windows.Forms.ImageList(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lstSavedPath = new System.Windows.Forms.ListBox();
            this.txtFilePattern = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCopyAllTo = new System.Windows.Forms.Button();
            this.lstSourceFiles = new System.Windows.Forms.ListView();
            this.btnCopySelectedTo = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tvFolders = new System.Windows.Forms.TreeView();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtHidenSavedPath = new System.Windows.Forms.TextBox();
            this.txtHidenSubPath = new System.Windows.Forms.TextBox();
            this.txtHidenDestPath = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtHidenSubPath);
            this.groupBox1.Controls.Add(this.txtHidenSavedPath);
            this.groupBox1.Controls.Add(this.tvSubDir);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lstSavedPath);
            this.groupBox1.Controls.Add(this.txtFilePattern);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(21, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(957, 224);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Criteria and Path";
            // 
            // tvSubDir
            // 
            this.tvSubDir.ImageIndex = 0;
            this.tvSubDir.ImageList = this.m_imageListTreeView;
            this.tvSubDir.Location = new System.Drawing.Point(459, 53);
            this.tvSubDir.Name = "tvSubDir";
            this.tvSubDir.SelectedImageIndex = 0;
            this.tvSubDir.Size = new System.Drawing.Size(486, 164);
            this.tvSubDir.TabIndex = 5;
            this.tvSubDir.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvSubDir_AfterSelect);
            // 
            // m_imageListTreeView
            // 
            this.m_imageListTreeView.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_imageListTreeView.ImageStream")));
            this.m_imageListTreeView.TransparentColor = System.Drawing.Color.Transparent;
            this.m_imageListTreeView.Images.SetKeyName(0, "");
            this.m_imageListTreeView.Images.SetKeyName(1, "");
            this.m_imageListTreeView.Images.SetKeyName(2, "");
            this.m_imageListTreeView.Images.SetKeyName(3, "");
            this.m_imageListTreeView.Images.SetKeyName(4, "");
            this.m_imageListTreeView.Images.SetKeyName(5, "");
            this.m_imageListTreeView.Images.SetKeyName(6, "");
            this.m_imageListTreeView.Images.SetKeyName(7, "");
            this.m_imageListTreeView.Images.SetKeyName(8, "");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(454, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(200, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Sub folder of Current Selected path:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Saved Paths";
            // 
            // lstSavedPath
            // 
            this.lstSavedPath.FormattingEnabled = true;
            this.lstSavedPath.ItemHeight = 15;
            this.lstSavedPath.Location = new System.Drawing.Point(15, 81);
            this.lstSavedPath.Name = "lstSavedPath";
            this.lstSavedPath.Size = new System.Drawing.Size(411, 139);
            this.lstSavedPath.TabIndex = 2;
            this.lstSavedPath.SelectedIndexChanged += new System.EventHandler(this.lstSavedPath_SelectedIndexChanged);
            // 
            // txtFilePattern
            // 
            this.txtFilePattern.Location = new System.Drawing.Point(83, 29);
            this.txtFilePattern.Name = "txtFilePattern";
            this.txtFilePattern.Size = new System.Drawing.Size(343, 23);
            this.txtFilePattern.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "File Pattern:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtHidenDestPath);
            this.groupBox2.Controls.Add(this.btnCopyAllTo);
            this.groupBox2.Controls.Add(this.lstSourceFiles);
            this.groupBox2.Controls.Add(this.btnCopySelectedTo);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.tvFolders);
            this.groupBox2.Location = new System.Drawing.Point(23, 270);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(949, 332);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Files Transfer";
            // 
            // btnCopyAllTo
            // 
            this.btnCopyAllTo.Location = new System.Drawing.Point(521, 120);
            this.btnCopyAllTo.Name = "btnCopyAllTo";
            this.btnCopyAllTo.Size = new System.Drawing.Size(75, 61);
            this.btnCopyAllTo.TabIndex = 10;
            this.btnCopyAllTo.Text = "Copy ALL To";
            this.btnCopyAllTo.UseVisualStyleBackColor = true;
            this.btnCopyAllTo.Click += new System.EventHandler(this.btnCopyAllTo_Click);
            // 
            // lstSourceFiles
            // 
            this.lstSourceFiles.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lstSourceFiles.FullRowSelect = true;
            this.lstSourceFiles.Location = new System.Drawing.Point(14, 39);
            this.lstSourceFiles.Name = "lstSourceFiles";
            this.lstSourceFiles.Size = new System.Drawing.Size(493, 274);
            this.lstSourceFiles.TabIndex = 9;
            this.lstSourceFiles.UseCompatibleStateImageBehavior = false;
            this.lstSourceFiles.View = System.Windows.Forms.View.Details;
            // 
            // btnCopySelectedTo
            // 
            this.btnCopySelectedTo.Location = new System.Drawing.Point(521, 39);
            this.btnCopySelectedTo.Name = "btnCopySelectedTo";
            this.btnCopySelectedTo.Size = new System.Drawing.Size(75, 56);
            this.btnCopySelectedTo.TabIndex = 7;
            this.btnCopySelectedTo.Text = "Copy Selected To";
            this.btnCopySelectedTo.UseVisualStyleBackColor = true;
            this.btnCopySelectedTo.Click += new System.EventHandler(this.btnCopySelectedTo_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(603, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "Destination";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Source Files";
            // 
            // tvFolders
            // 
            this.tvFolders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tvFolders.ImageIndex = 0;
            this.tvFolders.ImageList = this.m_imageListTreeView;
            this.tvFolders.Location = new System.Drawing.Point(606, 39);
            this.tvFolders.Name = "tvFolders";
            this.tvFolders.SelectedImageIndex = 0;
            this.tvFolders.Size = new System.Drawing.Size(337, 274);
            this.tvFolders.TabIndex = 4;
            this.tvFolders.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvFolders_AfterSelect);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cambria", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(21, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(173, 32);
            this.label6.TabIndex = 2;
            this.label6.Text = "Transfer Files";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Desktop;
            this.panel1.Location = new System.Drawing.Point(22, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(955, 10);
            this.panel1.TabIndex = 3;
            // 
            // txtHidenSavedPath
            // 
            this.txtHidenSavedPath.Location = new System.Drawing.Point(305, 55);
            this.txtHidenSavedPath.Name = "txtHidenSavedPath";
            this.txtHidenSavedPath.Size = new System.Drawing.Size(100, 23);
            this.txtHidenSavedPath.TabIndex = 6;
            this.txtHidenSavedPath.Visible = false;
            // 
            // txtHidenSubPath
            // 
            this.txtHidenSubPath.Location = new System.Drawing.Point(733, 19);
            this.txtHidenSubPath.Name = "txtHidenSubPath";
            this.txtHidenSubPath.Size = new System.Drawing.Size(100, 23);
            this.txtHidenSubPath.TabIndex = 7;
            this.txtHidenSubPath.Visible = false;
            // 
            // txtHidenDestPath
            // 
            this.txtHidenDestPath.Location = new System.Drawing.Point(500, 290);
            this.txtHidenDestPath.Name = "txtHidenDestPath";
            this.txtHidenDestPath.Size = new System.Drawing.Size(100, 23);
            this.txtHidenDestPath.TabIndex = 11;
            this.txtHidenDestPath.Visible = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsProgressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 654);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(990, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsProgressBar
            // 
            this.tsProgressBar.Name = "tsProgressBar";
            this.tsProgressBar.Size = new System.Drawing.Size(200, 16);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 676);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstSavedPath;
        private System.Windows.Forms.TextBox txtFilePattern;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ImageList m_imageListTreeView;
        private System.Windows.Forms.TreeView tvFolders;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCopySelectedTo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TreeView tvSubDir;
        private System.Windows.Forms.ListView lstSourceFiles;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCopyAllTo;
        private System.Windows.Forms.TextBox txtHidenSubPath;
        private System.Windows.Forms.TextBox txtHidenSavedPath;
        private System.Windows.Forms.TextBox txtHidenDestPath;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar tsProgressBar;
    }
}