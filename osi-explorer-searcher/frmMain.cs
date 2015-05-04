using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;
using osi_explorer_searcher.core.util;
using System.IO;
using System.Collections;

namespace osi_explorer_searcher
{
    public partial class frmMain : Form
    {
        OsifyUtilities osifyUtil;
        public frmMain()
        {
            InitializeComponent();
            osifyUtil = new OsifyUtilities();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Load(object sender, EventArgs e)
        {
            osifyUtil.PopulateDriveList(this.tvFolders, this.Cursor);
            this.loadSavedFiles();
            osifyUtil.InitListViewFilePanel(this.lstSourceFiles);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvFolders_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //Populate folders and files when a folder is selected
            this.Cursor = Cursors.WaitCursor;

            //get current selected drive or folder
            TreeNode nodeCurrent = e.Node;

            //clear all sub-folders
            nodeCurrent.Nodes.Clear();

            if (nodeCurrent.SelectedImageIndex == 0)
            {
                //Selected My Computer - repopulate drive list
                osifyUtil.PopulateDriveList(this.tvFolders, this.Cursor);
            }
            else
            {
                //populate sub-folders and folder files
                osifyUtil.PopulateDirectory(nodeCurrent, nodeCurrent.Nodes, null, this.txtFilePattern.Text);
            }
            this.txtHidenDestPath.Text = osifyUtil.getFullPath(nodeCurrent.FullPath);
            this.Cursor = Cursors.Default;
        }
        /// <summary>
        /// Read saved files into form control
        /// </summary>
        protected void loadSavedFiles()
        {
            StreamReader reader1 = new StreamReader(Application.StartupPath + "/options.ini");
            String line = null;
            line = reader1.ReadLine();
            while (line != null && line != "")
            {
                this.txtFilePattern.Text = line;
                line = reader1.ReadLine();
            }
            reader1.Close();

            StreamReader reader2 = new StreamReader(Application.StartupPath + "/share_path.ini");
            line = reader2.ReadLine();
            lstSavedPath.Items.Clear();
            while (line != null && line != "")
            {
                lstSavedPath.Items.Add(line);
                line = reader2.ReadLine();
            }
            reader2.Close();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstSavedPath_SelectedIndexChanged(object sender, EventArgs e)
        {
            TreeNode nodeTreeNode;
            this.Cursor = Cursors.WaitCursor;

            if (this.lstSavedPath.SelectedItem == null) {
                return;
            }
            //clear TreeView
            this.tvSubDir.Nodes.Clear();
            nodeTreeNode = new TreeNode("My Computer", 0, 0);
            tvSubDir.Nodes.Add(nodeTreeNode);
            //set node collection
            TreeNodeCollection nodeCollection = nodeTreeNode.Nodes;
            //create new drive node
            nodeTreeNode = new TreeNode(this.lstSavedPath.SelectedItem.ToString() + "\\", 2, 3);

            //add new node
            nodeCollection.Add(nodeTreeNode);
            
            //Fetch files of current selected folder
            osifyUtil.PopulateFiles(nodeTreeNode, this.lstSourceFiles, this.txtFilePattern.Text);
            //store path in hiden field
            this.txtHidenSavedPath.Text = this.lstSavedPath.SelectedItem.ToString();

            this.Cursor = Cursors.Default;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvSubDir_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //Populate folders and files when a folder is selected
            this.Cursor = Cursors.WaitCursor;

            //get current selected drive or folder
            TreeNode nodeCurrent = e.Node;

            //clear all sub-folders
            nodeCurrent.Nodes.Clear();

            //populate sub-folders and folder files
            osifyUtil.PopulateDirectory(nodeCurrent, nodeCurrent.Nodes, this.lstSourceFiles, this.txtFilePattern.Text);

            //save sub path
            this.txtHidenSubPath.Text = osifyUtil.getFullPath(nodeCurrent.FullPath);            

            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCopySelectedTo_Click(object sender, EventArgs e)
        {
            processCopy(false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="allFiles"></param>
        private void processCopy(Boolean allFiles)
        {
            String sourcePath = this.txtHidenSavedPath.Text;
            if (this.txtHidenSubPath.Text != null && this.txtHidenSubPath.Text != "")
            {
                sourcePath = this.txtHidenSubPath.Text;
            }
            if (this.txtHidenDestPath.Text == "")
            {
                MessageBox.Show("No yet select any destination");
                return;
            }
            osifyUtil.copyFiles(false, allFiles, sourcePath, this.txtHidenDestPath.Text, this.lstSourceFiles, this.tsProgressBar.ProgressBar);
        }

        private void btnCopyAllTo_Click(object sender, EventArgs e)
        {
            processCopy(true);
        }
    }
}
