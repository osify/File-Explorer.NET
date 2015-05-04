using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using osi_explorer_searcher.core.util;
using System.Management;
using System.IO;
using System.Collections;

namespace osi_explorer_searcher
{
    public partial class frmOptions : Form
    {
        OsifyUtilities osifyUtil;

        public frmOptions()
        {
            InitializeComponent();
            osifyUtil = new OsifyUtilities();
        }

        private void frmOptions_Load(object sender, EventArgs e)
        {
            osifyUtil.PopulateDriveList(this.tvFolders, this.Cursor);
            this.prepareFileCriteria();
            this.loadSavedFiles();
        }

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
                osifyUtil.PopulateDirectory(nodeCurrent, nodeCurrent.Nodes, this.lvFiles, this.txtFileCriteria.Text);
            }
            this.txtHidenPath.Text = osifyUtil.getFullPath(nodeCurrent.FullPath);
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// 
        /// </summary>
        protected void prepareFileCriteria()
        {
            StreamReader reader1 = new StreamReader(Application.StartupPath + "/available_file_pattern.ini");
            String line = null;
            line = reader1.ReadLine();
            while (line != null && line != "")
            {
                if (!this.lstFileCriteria.Items.Contains(line))
                {
                    this.lstFileCriteria.Items.Add(line);
                }
                line = reader1.ReadLine();
            }
            if (this.lstFileCriteria.Items.Count == 0)
            {
                this.lstFileCriteria.Items.Add("*.mp3");
                this.lstFileCriteria.Items.Add("*.wma");
                this.lstFileCriteria.Items.Add("*.avi");
                this.lstFileCriteria.Items.Add("*.mp4");
                this.lstFileCriteria.Items.Add("*.mpg");
                this.lstFileCriteria.Items.Add("*.dat");
                this.lstFileCriteria.Items.Add("*.midi");
            }
            
        }

        private void lstFileCriteria_SelectedIndexChanged(object sender, EventArgs e)
        {
            String strCri = this.txtFileCriteria.Text;
            strCri += this.lstFileCriteria.SelectedItem + ";";
            this.txtFileCriteria.Text = strCri;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.txtHidenPath.Text != "")
            {
                if (!this.lstSearchPath.Items.Contains(this.txtHidenPath.Text))
                {
                    this.lstSearchPath.Items.Add(this.txtHidenPath.Text);
                }
            }
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
                this.txtFileCriteria.Text = line;
                line = reader1.ReadLine();
            }
            reader1.Close();
            
            StreamReader reader2 = new StreamReader(Application.StartupPath + "/share_path.ini");
            line = reader2.ReadLine();
            lstSearchPath.Items.Clear();
            while (line != null && line != "")
            {
                lstSearchPath.Items.Add(line);
                line = reader2.ReadLine();
            }
            reader2.Close();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            StreamWriter writer1 = new StreamWriter(Application.StartupPath + "/options.ini");
            writer1.WriteLine(this.txtFileCriteria.Text);
            writer1.Close();
            StreamWriter writer2 = new StreamWriter(Application.StartupPath + "/share_path.ini");
            foreach (String str in lstSearchPath.Items)
            {
                writer2.WriteLine(str);
            }
            writer2.Close();
            MessageBox.Show("All saved paths in the list and file criteria have been saved.");
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            this.lstSearchPath.Items.Remove(this.lstSearchPath.SelectedItem);
        }

        private void lvFiles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
    }
}
