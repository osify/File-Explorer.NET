namespace osi_explorer_searcher
{
    partial class frmManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManage));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lvPlaylistFiles = new System.Windows.Forms.ListView();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.cutMenuItem = new System.Windows.Forms.MenuItem();
            this.copyMenuItem = new System.Windows.Forms.MenuItem();
            this.pasteMenuItem = new System.Windows.Forms.MenuItem();
            this.refreshMenuItem = new System.Windows.Forms.MenuItem();
            this.tvPlaylist = new System.Windows.Forms.TreeView();
            this.contextMenuPlaylist = new System.Windows.Forms.ContextMenu();
            this.menuNewPlaylist = new System.Windows.Forms.MenuItem();
            this.menuEditPlaylist = new System.Windows.Forms.MenuItem();
            this.menuDelPlaylist = new System.Windows.Forms.MenuItem();
            this.menuRefreshPlaylist = new System.Windows.Forms.MenuItem();
            this.m_imageListTreeView = new System.Windows.Forms.ImageList(this.components);
            this.panelPlaylist = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnPlaylistSave = new System.Windows.Forms.Button();
            this.btnPlaylistCancel = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cboPlaylistParent = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPlaylistName = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboPlType = new System.Windows.Forms.ComboBox();
            this.txtSelectedPlaylist = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.chkEditable = new System.Windows.Forms.CheckBox();
            this.txtMainPlaylistFile = new System.Windows.Forms.TextBox();
            this.txtMainPlaylist = new System.Windows.Forms.TextBox();
            this.txtSelectedSubPlaylist = new System.Windows.Forms.TextBox();
            this.txtIsParent = new System.Windows.Forms.TextBox();
            this.txtPlaylistSize = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusSelected = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusListSize = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusNumFiles = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1.SuspendLayout();
            this.panelPlaylist.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.lvPlaylistFiles);
            this.groupBox1.Controls.Add(this.tvPlaylist);
            this.groupBox1.Location = new System.Drawing.Point(16, 79);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(961, 556);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lists";
            // 
            // lvPlaylistFiles
            // 
            this.lvPlaylistFiles.AllowDrop = true;
            this.lvPlaylistFiles.ContextMenu = this.contextMenu1;
            this.lvPlaylistFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvPlaylistFiles.Location = new System.Drawing.Point(280, 23);
            this.lvPlaylistFiles.Margin = new System.Windows.Forms.Padding(4);
            this.lvPlaylistFiles.Name = "lvPlaylistFiles";
            this.lvPlaylistFiles.Size = new System.Drawing.Size(677, 529);
            this.lvPlaylistFiles.TabIndex = 9;
            this.lvPlaylistFiles.UseCompatibleStateImageBehavior = false;
            this.lvPlaylistFiles.View = System.Windows.Forms.View.Details;
            this.lvPlaylistFiles.SelectedIndexChanged += new System.EventHandler(this.lvPlaylistFiles_SelectedIndexChanged);
            this.lvPlaylistFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvPlaylistFiles_DragDrop);
            this.lvPlaylistFiles.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lvPlaylistFiles_ItemDrag);
            this.lvPlaylistFiles.DragOver += new System.Windows.Forms.DragEventHandler(this.lvPlaylistFiles_DragOver);
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.cutMenuItem,
            this.copyMenuItem,
            this.pasteMenuItem,
            this.refreshMenuItem});
            // 
            // cutMenuItem
            // 
            this.cutMenuItem.Index = 0;
            this.cutMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlX;
            this.cutMenuItem.Text = "Cut";
            this.cutMenuItem.Click += new System.EventHandler(this.cutMenuItem_Click);
            // 
            // copyMenuItem
            // 
            this.copyMenuItem.Index = 1;
            this.copyMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlC;
            this.copyMenuItem.Text = "Copy";
            this.copyMenuItem.Click += new System.EventHandler(this.copyMenuItem_Click);
            // 
            // pasteMenuItem
            // 
            this.pasteMenuItem.Index = 2;
            this.pasteMenuItem.Shortcut = System.Windows.Forms.Shortcut.CtrlV;
            this.pasteMenuItem.Text = "Paste";
            this.pasteMenuItem.Click += new System.EventHandler(this.pasteMenuItem_Click);
            // 
            // refreshMenuItem
            // 
            this.refreshMenuItem.Index = 3;
            this.refreshMenuItem.Shortcut = System.Windows.Forms.Shortcut.F5;
            this.refreshMenuItem.Text = "Refresh";
            this.refreshMenuItem.Click += new System.EventHandler(this.refreshMenuItem_Click);
            // 
            // tvPlaylist
            // 
            this.tvPlaylist.ContextMenu = this.contextMenuPlaylist;
            this.tvPlaylist.Dock = System.Windows.Forms.DockStyle.Left;
            this.tvPlaylist.ImageIndex = 0;
            this.tvPlaylist.ImageList = this.m_imageListTreeView;
            this.tvPlaylist.Location = new System.Drawing.Point(4, 23);
            this.tvPlaylist.Margin = new System.Windows.Forms.Padding(4);
            this.tvPlaylist.Name = "tvPlaylist";
            this.tvPlaylist.SelectedImageIndex = 0;
            this.tvPlaylist.ShowNodeToolTips = true;
            this.tvPlaylist.Size = new System.Drawing.Size(276, 529);
            this.tvPlaylist.TabIndex = 8;
            this.tvPlaylist.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvPlaylist_AfterSelect);
            // 
            // contextMenuPlaylist
            // 
            this.contextMenuPlaylist.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuNewPlaylist,
            this.menuEditPlaylist,
            this.menuDelPlaylist,
            this.menuRefreshPlaylist});
            // 
            // menuNewPlaylist
            // 
            this.menuNewPlaylist.Index = 0;
            this.menuNewPlaylist.Shortcut = System.Windows.Forms.Shortcut.CtrlX;
            this.menuNewPlaylist.Text = "New Llist";
            this.menuNewPlaylist.Click += new System.EventHandler(this.menuNewPlaylist_Click);
            // 
            // menuEditPlaylist
            // 
            this.menuEditPlaylist.Index = 1;
            this.menuEditPlaylist.Shortcut = System.Windows.Forms.Shortcut.CtrlC;
            this.menuEditPlaylist.Text = "Edit List";
            this.menuEditPlaylist.Click += new System.EventHandler(this.menuEditPlaylist_Click);
            // 
            // menuDelPlaylist
            // 
            this.menuDelPlaylist.Index = 2;
            this.menuDelPlaylist.Shortcut = System.Windows.Forms.Shortcut.CtrlV;
            this.menuDelPlaylist.Text = "Delete List";
            this.menuDelPlaylist.Click += new System.EventHandler(this.menuDelPlaylist_Click);
            // 
            // menuRefreshPlaylist
            // 
            this.menuRefreshPlaylist.Index = 3;
            this.menuRefreshPlaylist.Shortcut = System.Windows.Forms.Shortcut.F5;
            this.menuRefreshPlaylist.Text = "Refresh";
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
            this.m_imageListTreeView.Images.SetKeyName(9, "sitemap_color.png");
            this.m_imageListTreeView.Images.SetKeyName(10, "film.png");
            this.m_imageListTreeView.Images.SetKeyName(11, "film_save.png");
            this.m_imageListTreeView.Images.SetKeyName(12, "images.png");
            this.m_imageListTreeView.Images.SetKeyName(13, "image_add.png");
            this.m_imageListTreeView.Images.SetKeyName(14, "music.png");
            this.m_imageListTreeView.Images.SetKeyName(15, "package.png");
            this.m_imageListTreeView.Images.SetKeyName(16, "package_add.png");
            this.m_imageListTreeView.Images.SetKeyName(17, "asterisk_orange.png");
            this.m_imageListTreeView.Images.SetKeyName(18, "asterisk_yellow.png");
            this.m_imageListTreeView.Images.SetKeyName(19, "book.png");
            this.m_imageListTreeView.Images.SetKeyName(20, "book_open.png");
            this.m_imageListTreeView.Images.SetKeyName(21, "report_disk.png");
            this.m_imageListTreeView.Images.SetKeyName(22, "report_magnify.png");
            this.m_imageListTreeView.Images.SetKeyName(23, "sport_golf.png");
            this.m_imageListTreeView.Images.SetKeyName(24, "script.png");
            this.m_imageListTreeView.Images.SetKeyName(25, "attach.png");
            // 
            // panelPlaylist
            // 
            this.panelPlaylist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panelPlaylist.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelPlaylist.Controls.Add(this.panel2);
            this.panelPlaylist.Controls.Add(this.btnPlaylistSave);
            this.panelPlaylist.Controls.Add(this.btnPlaylistCancel);
            this.panelPlaylist.Controls.Add(this.label5);
            this.panelPlaylist.Controls.Add(this.cboPlaylistParent);
            this.panelPlaylist.Controls.Add(this.label4);
            this.panelPlaylist.Controls.Add(this.txtPlaylistName);
            this.panelPlaylist.Controls.Add(this.panel1);
            this.panelPlaylist.Controls.Add(this.label3);
            this.panelPlaylist.Controls.Add(this.label2);
            this.panelPlaylist.Controls.Add(this.cboPlType);
            this.panelPlaylist.Location = new System.Drawing.Point(600, 16);
            this.panelPlaylist.Name = "panelPlaylist";
            this.panelPlaylist.Size = new System.Drawing.Size(370, 199);
            this.panelPlaylist.TabIndex = 4;
            this.panelPlaylist.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panel2.Location = new System.Drawing.Point(0, 185);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(366, 10);
            this.panel2.TabIndex = 10;
            // 
            // btnPlaylistSave
            // 
            this.btnPlaylistSave.Location = new System.Drawing.Point(168, 139);
            this.btnPlaylistSave.Name = "btnPlaylistSave";
            this.btnPlaylistSave.Size = new System.Drawing.Size(85, 31);
            this.btnPlaylistSave.TabIndex = 9;
            this.btnPlaylistSave.Text = "Save";
            this.btnPlaylistSave.UseVisualStyleBackColor = true;
            this.btnPlaylistSave.Click += new System.EventHandler(this.btnPlaylistSave_Click);
            // 
            // btnPlaylistCancel
            // 
            this.btnPlaylistCancel.Location = new System.Drawing.Point(66, 139);
            this.btnPlaylistCancel.Name = "btnPlaylistCancel";
            this.btnPlaylistCancel.Size = new System.Drawing.Size(96, 31);
            this.btnPlaylistCancel.TabIndex = 8;
            this.btnPlaylistCancel.Text = "Cancel";
            this.btnPlaylistCancel.UseVisualStyleBackColor = true;
            this.btnPlaylistCancel.Click += new System.EventHandler(this.btnPlaylistCancel_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 18);
            this.label5.TabIndex = 7;
            this.label5.Text = "Type *";
            // 
            // cboPlaylistParent
            // 
            this.cboPlaylistParent.FormattingEnabled = true;
            this.cboPlaylistParent.Location = new System.Drawing.Point(66, 95);
            this.cboPlaylistParent.Name = "cboPlaylistParent";
            this.cboPlaylistParent.Size = new System.Drawing.Size(296, 26);
            this.cboPlaylistParent.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 18);
            this.label4.TabIndex = 5;
            this.label4.Text = "Parent";
            // 
            // txtPlaylistName
            // 
            this.txtPlaylistName.Location = new System.Drawing.Point(66, 29);
            this.txtPlaylistName.Name = "txtPlaylistName";
            this.txtPlaylistName.Size = new System.Drawing.Size(297, 26);
            this.txtPlaylistName.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(366, 10);
            this.panel1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(2, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "CATEGORY";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name *";
            // 
            // cboPlType
            // 
            this.cboPlType.FormattingEnabled = true;
            this.cboPlType.Location = new System.Drawing.Point(66, 63);
            this.cboPlType.Name = "cboPlType";
            this.cboPlType.Size = new System.Drawing.Size(296, 26);
            this.cboPlType.TabIndex = 0;
            // 
            // txtSelectedPlaylist
            // 
            this.txtSelectedPlaylist.Location = new System.Drawing.Point(296, 59);
            this.txtSelectedPlaylist.Name = "txtSelectedPlaylist";
            this.txtSelectedPlaylist.ReadOnly = true;
            this.txtSelectedPlaylist.Size = new System.Drawing.Size(681, 26);
            this.txtSelectedPlaylist.TabIndex = 8;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.panel3.Location = new System.Drawing.Point(15, 23);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(962, 10);
            this.panel3.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cambria", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(14, -3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(309, 32);
            this.label6.TabIndex = 9;
            this.label6.Text = "Lists && Files Management";
            // 
            // chkEditable
            // 
            this.chkEditable.AutoSize = true;
            this.chkEditable.Checked = true;
            this.chkEditable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEditable.Location = new System.Drawing.Point(193, 59);
            this.chkEditable.Name = "chkEditable";
            this.chkEditable.Size = new System.Drawing.Size(97, 22);
            this.chkEditable.TabIndex = 11;
            this.chkEditable.Text = "Can Modify";
            this.chkEditable.UseVisualStyleBackColor = true;
            // 
            // txtMainPlaylistFile
            // 
            this.txtMainPlaylistFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMainPlaylistFile.Location = new System.Drawing.Point(984, 431);
            this.txtMainPlaylistFile.Name = "txtMainPlaylistFile";
            this.txtMainPlaylistFile.ReadOnly = true;
            this.txtMainPlaylistFile.Size = new System.Drawing.Size(129, 26);
            this.txtMainPlaylistFile.TabIndex = 12;
            this.txtMainPlaylistFile.Visible = false;
            // 
            // txtMainPlaylist
            // 
            this.txtMainPlaylist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMainPlaylist.Location = new System.Drawing.Point(984, 379);
            this.txtMainPlaylist.Name = "txtMainPlaylist";
            this.txtMainPlaylist.ReadOnly = true;
            this.txtMainPlaylist.Size = new System.Drawing.Size(129, 26);
            this.txtMainPlaylist.TabIndex = 13;
            this.txtMainPlaylist.Visible = false;
            // 
            // txtSelectedSubPlaylist
            // 
            this.txtSelectedSubPlaylist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSelectedSubPlaylist.Location = new System.Drawing.Point(984, 278);
            this.txtSelectedSubPlaylist.Name = "txtSelectedSubPlaylist";
            this.txtSelectedSubPlaylist.ReadOnly = true;
            this.txtSelectedSubPlaylist.Size = new System.Drawing.Size(129, 26);
            this.txtSelectedSubPlaylist.TabIndex = 13;
            this.txtSelectedSubPlaylist.Visible = false;
            this.txtSelectedSubPlaylist.TextChanged += new System.EventHandler(this.txtSelectedSubPlaylist_TextChanged);
            // 
            // txtIsParent
            // 
            this.txtIsParent.Location = new System.Drawing.Point(984, 463);
            this.txtIsParent.Name = "txtIsParent";
            this.txtIsParent.Size = new System.Drawing.Size(100, 26);
            this.txtIsParent.TabIndex = 14;
            this.txtIsParent.Text = "0";
            this.txtIsParent.Visible = false;
            // 
            // txtPlaylistSize
            // 
            this.txtPlaylistSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPlaylistSize.Location = new System.Drawing.Point(984, 328);
            this.txtPlaylistSize.Name = "txtPlaylistSize";
            this.txtPlaylistSize.ReadOnly = true;
            this.txtPlaylistSize.Size = new System.Drawing.Size(129, 26);
            this.txtPlaylistSize.TabIndex = 20;
            this.txtPlaylistSize.Visible = false;
            this.txtPlaylistSize.TextChanged += new System.EventHandler(this.txtPlaylistSize_TextChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.statusSelected,
            this.statusListSize,
            this.statusNumFiles});
            this.statusStrip1.Location = new System.Drawing.Point(0, 647);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1121, 22);
            this.statusStrip1.TabIndex = 21;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(83, 17);
            this.toolStripStatusLabel1.Text = "INFORMATION:";
            // 
            // statusSelected
            // 
            this.statusSelected.Name = "statusSelected";
            this.statusSelected.Size = new System.Drawing.Size(0, 17);
            // 
            // statusListSize
            // 
            this.statusListSize.Name = "statusListSize";
            this.statusListSize.Size = new System.Drawing.Size(0, 17);
            // 
            // statusNumFiles
            // 
            this.statusNumFiles.Name = "statusNumFiles";
            this.statusNumFiles.Size = new System.Drawing.Size(0, 17);
            // 
            // frmManage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1121, 669);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.txtPlaylistSize);
            this.Controls.Add(this.panelPlaylist);
            this.Controls.Add(this.txtIsParent);
            this.Controls.Add(this.txtMainPlaylist);
            this.Controls.Add(this.txtSelectedSubPlaylist);
            this.Controls.Add(this.txtMainPlaylistFile);
            this.Controls.Add(this.chkEditable);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtSelectedPlaylist);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmManage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Lists & Files";
            this.Load += new System.EventHandler(this.frmManage_Load);
            this.groupBox1.ResumeLayout(false);
            this.panelPlaylist.ResumeLayout(false);
            this.panelPlaylist.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ImageList m_imageListTreeView;
        private System.Windows.Forms.ListView lvPlaylistFiles;
        private System.Windows.Forms.TreeView tvPlaylist;
        private System.Windows.Forms.Panel panelPlaylist;
        private System.Windows.Forms.ComboBox cboPlType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPlaylistName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboPlaylistParent;
        private System.Windows.Forms.Button btnPlaylistSave;
        private System.Windows.Forms.Button btnPlaylistCancel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtSelectedPlaylist;
        private System.Windows.Forms.ContextMenu contextMenu1;
        private System.Windows.Forms.MenuItem cutMenuItem;
        private System.Windows.Forms.MenuItem copyMenuItem;
        private System.Windows.Forms.MenuItem pasteMenuItem;
        private System.Windows.Forms.MenuItem refreshMenuItem;
        private System.Windows.Forms.ContextMenu contextMenuPlaylist;
        private System.Windows.Forms.MenuItem menuNewPlaylist;
        private System.Windows.Forms.MenuItem menuEditPlaylist;
        private System.Windows.Forms.MenuItem menuDelPlaylist;
        private System.Windows.Forms.MenuItem menuRefreshPlaylist;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkEditable;
        private System.Windows.Forms.TextBox txtMainPlaylistFile;
        private System.Windows.Forms.TextBox txtMainPlaylist;
        private System.Windows.Forms.TextBox txtSelectedSubPlaylist;
        private System.Windows.Forms.TextBox txtIsParent;
        private System.Windows.Forms.TextBox txtPlaylistSize;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel statusSelected;
        private System.Windows.Forms.ToolStripStatusLabel statusListSize;
        private System.Windows.Forms.ToolStripStatusLabel statusNumFiles;
    }
}