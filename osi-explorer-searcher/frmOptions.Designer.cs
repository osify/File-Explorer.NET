namespace osi_explorer_searcher
{
    partial class frmOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOptions));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFileCriteria = new System.Windows.Forms.TextBox();
            this.lstFileCriteria = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lvFiles = new System.Windows.Forms.ListView();
            this.tvFolders = new System.Windows.Forms.TreeView();
            this.m_imageListTreeView = new System.Windows.Forms.ImageList(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.lstSearchPath = new System.Windows.Forms.ListBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtHidenPath = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtFileCriteria);
            this.groupBox2.Controls.Add(this.lstFileCriteria);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(48, 45);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(377, 223);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "(1) Search Criterias";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(77, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ex: *.mp3;*.wma;HM*.avi";
            // 
            // txtFileCriteria
            // 
            this.txtFileCriteria.Location = new System.Drawing.Point(81, 29);
            this.txtFileCriteria.Name = "txtFileCriteria";
            this.txtFileCriteria.Size = new System.Drawing.Size(290, 26);
            this.txtFileCriteria.TabIndex = 2;
            // 
            // lstFileCriteria
            // 
            this.lstFileCriteria.FormattingEnabled = true;
            this.lstFileCriteria.ItemHeight = 18;
            this.lstFileCriteria.Location = new System.Drawing.Point(14, 97);
            this.lstFileCriteria.MultiColumn = true;
            this.lstFileCriteria.Name = "lstFileCriteria";
            this.lstFileCriteria.Size = new System.Drawing.Size(357, 112);
            this.lstFileCriteria.TabIndex = 1;
            this.lstFileCriteria.SelectedIndexChanged += new System.EventHandler(this.lstFileCriteria_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "File type";
            // 
            // groupBox3
            // 
            this.groupBox3.AutoSize = true;
            this.groupBox3.Controls.Add(this.lvFiles);
            this.groupBox3.Controls.Add(this.tvFolders);
            this.groupBox3.Location = new System.Drawing.Point(443, 45);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(571, 340);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "(2) Drives/Directories Explorer";
            // 
            // lvFiles
            // 
            this.lvFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvFiles.Location = new System.Drawing.Point(211, 22);
            this.lvFiles.Name = "lvFiles";
            this.lvFiles.Size = new System.Drawing.Size(357, 315);
            this.lvFiles.TabIndex = 5;
            this.lvFiles.UseCompatibleStateImageBehavior = false;
            this.lvFiles.View = System.Windows.Forms.View.Details;
            this.lvFiles.SelectedIndexChanged += new System.EventHandler(this.lvFiles_SelectedIndexChanged);
            // 
            // tvFolders
            // 
            this.tvFolders.Dock = System.Windows.Forms.DockStyle.Left;
            this.tvFolders.ImageIndex = 0;
            this.tvFolders.ImageList = this.m_imageListTreeView;
            this.tvFolders.Location = new System.Drawing.Point(3, 22);
            this.tvFolders.Name = "tvFolders";
            this.tvFolders.SelectedImageIndex = 0;
            this.tvFolders.Size = new System.Drawing.Size(208, 315);
            this.tvFolders.TabIndex = 3;
            this.tvFolders.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvFolders_AfterSelect);
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
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(443, 391);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(277, 30);
            this.button1.TabIndex = 3;
            this.button1.Text = "(3) Add Current Path in File Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnRemove);
            this.groupBox4.Controls.Add(this.lstSearchPath);
            this.groupBox4.Controls.Add(this.btnSave);
            this.groupBox4.Location = new System.Drawing.Point(48, 274);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(377, 277);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "(4) Search Path Saved";
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(177, 238);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(185, 33);
            this.btnRemove.TabIndex = 7;
            this.btnRemove.Text = "Remove Selected Path";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // lstSearchPath
            // 
            this.lstSearchPath.FormattingEnabled = true;
            this.lstSearchPath.ItemHeight = 18;
            this.lstSearchPath.Location = new System.Drawing.Point(9, 30);
            this.lstSearchPath.Name = "lstSearchPath";
            this.lstSearchPath.Size = new System.Drawing.Size(361, 202);
            this.lstSearchPath.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(6, 238);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(165, 33);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save Current Paths";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtHidenPath
            // 
            this.txtHidenPath.Location = new System.Drawing.Point(726, 394);
            this.txtHidenPath.Name = "txtHidenPath";
            this.txtHidenPath.Size = new System.Drawing.Size(100, 26);
            this.txtHidenPath.TabIndex = 5;
            this.txtHidenPath.Visible = false;
            // 
            // frmOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 664);
            this.Controls.Add(this.txtHidenPath);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmOptions";
            this.Text = "OPTIONS";
            this.Load += new System.EventHandler(this.frmOptions_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtFileCriteria;
        private System.Windows.Forms.ListBox lstFileCriteria;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ImageList m_imageListTreeView;
        private System.Windows.Forms.TreeView tvFolders;
        private System.Windows.Forms.ListView lvFiles;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListBox lstSearchPath;
        private System.Windows.Forms.TextBox txtHidenPath;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnSave;
    }
}