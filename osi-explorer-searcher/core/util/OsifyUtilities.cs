using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;
using System.Windows.Forms;
using System.Globalization;
using System.IO;
using System.Collections;
using osi_explorer_searcher.core.constant;

namespace osi_explorer_searcher.core.util
{
    class OsifyUtilities
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryName"></param>
        /// <returns></returns>
        public String generateFileName(String categoryName, String path)
        {
            String filename = path + "/" + categoryName + ".csv";
            if (File.Exists(filename))
            {
                this.generateFileName(categoryName + "_" + DateTime.Now.ToString("yyyyMMddHHmmssfffffzz"), path);
            }

            return categoryName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stringPath"></param>
        /// <returns></returns>
        public string GetPathName(string stringPath)
        {
            //Get Name of folder
            string[] stringSplit = stringPath.Split('\\');
            int _maxIndex = stringSplit.Length;
            return stringSplit[_maxIndex - 1];
        }


        /// <summary>
        /// Get full path
        /// </summary>
        /// <param name="stringPath"></param>
        /// <returns></returns>
        public string getFullPath(string stringPath)
        {
            //Get Full path
            string stringParse = "";
            //remove My Computer from path.
            stringParse = stringPath.Replace("My Computer\\", "");

            return stringParse;
        }

        public string getFullPath(string stringPath, String strToReplace)
        {
            //Get Full path
            string stringParse = "";
            //remove My Computer from path.
            stringParse = stringPath.Replace(strToReplace + "\\", "");

            return stringParse;
        }

        /// <summary>
        /// Get all drives
        /// </summary>
        /// <returns></returns>
        public ManagementObjectCollection getDrives()
        {
            //get drive collection
            ManagementObjectSearcher query = new ManagementObjectSearcher("SELECT * From Win32_LogicalDisk ");
            ManagementObjectCollection queryCollection = query.Get();

            return queryCollection;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dtDate"></param>
        /// <returns></returns>
        public string formatDate(DateTime dtDate)
        {
            //Get date and time in short format
            string stringDate = "";

            stringDate = dtDate.ToShortDateString().ToString() + " " + dtDate.ToShortTimeString().ToString();

            return stringDate;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lSize"></param>
        /// <returns></returns>
        public string formatSize(Int64 lSize)
        {
            //Format number to KB
            string stringSize = "";
            NumberFormatInfo myNfi = new NumberFormatInfo();

            Int64 lKBSize = 0;

            if (lSize < 1024)
            {
                if (lSize == 0)
                {
                    //zero byte
                    stringSize = "0";
                }
                else
                {
                    //less than 1K but not zero byte
                    stringSize = "1";
                }
            }
            else
            {
                //convert to KB
                lKBSize = lSize / 1024;
                //format number with default format
                stringSize = lKBSize.ToString("n", myNfi);
                //remove decimal
                stringSize = stringSize.Replace(".00", "");
            }

            return stringSize + " KB";

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lSize"></param>
        /// <returns></returns>
        public string formatSize(float lSize, String firstUnit)
        {   

            String strUnit = firstUnit;
            
            
            //Format number to KB
            string stringSize = "";
            NumberFormatInfo myNfi = new NumberFormatInfo();

            float lKBSize = lSize;

            if (lSize < 1024)
            {
                if (lSize == 0)
                {
                    //zero byte
                    stringSize = "0";
                }
                else if (OsifyConstants.KB.Equals(firstUnit) || OsifyConstants.BYT.Equals(firstUnit))
                {
                    //less than 1K but not zero byte
                    stringSize = "1";
                    strUnit = OsifyConstants.KB;
                }
                else
                {
                    //format number with default format
                    stringSize = lKBSize.ToString("n", myNfi);
                    //remove decimal
                    stringSize = stringSize.Replace(".00", "");
                }
            }
            else if (lSize >= 1024 && firstUnit != OsifyConstants.TB)
            {
                //convert to KB
                lKBSize = lSize / 1024;
                //format number with default format
                //stringSize = lKBSize.ToString("n", myNfi);
                //remove decimal
                //stringSize = stringSize.Replace(".00", "");

                switch (firstUnit)
                {
                    case OsifyConstants.BYT:
                        strUnit = OsifyConstants.KB; break;
                    case OsifyConstants.KB:
                        strUnit = OsifyConstants.MB; break;
                    case OsifyConstants.MB:
                        strUnit = OsifyConstants.GB; break;
                    case OsifyConstants.GB:
                        strUnit = OsifyConstants.TB; break;
                }
                stringSize = formatSize(lKBSize, strUnit);
                return stringSize;
            }
            else
            {
                //format number with default format
                stringSize = lKBSize.ToString("n", myNfi);
                //remove decimal
                stringSize = stringSize.Replace(".00", "");
            }

            return stringSize + " " + strUnit;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bMove"></param>
        /// <param name="sourcePath"></param>
        /// <param name="destPath"></param>
        /// <param name="lvSourceFiles"></param>
        /// <param name="progessBarControl"></param>
        public void copyFiles(Boolean bMove, Boolean isSelecteds, String sourcePath, String destPath, ListView lvSourceFiles, ProgressBar progressBarControl) 
        {   
            int ind = 0;

            if (!isSelecteds)
            {
                progressBarControl.Maximum = lvSourceFiles.SelectedIndices.Count;
                foreach (ListViewItem itm in lvSourceFiles.SelectedItems)
                {
                    this.copyItemTo(bMove, itm, ind, sourcePath, destPath, progressBarControl);
                }
            }
            else
            {
                progressBarControl.Maximum = lvSourceFiles.Items.Count;
                foreach (ListViewItem itm in lvSourceFiles.Items)
                {
                    this.copyItemTo(bMove, itm, ind, sourcePath, destPath, progressBarControl);
                }
            }
            

            progressBarControl.Value = 0;
            MessageBox.Show("Done");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bMove"></param>
        /// <param name="itm"></param>
        /// <param name="ind"></param>
        /// <param name="sourcePath"></param>
        /// <param name="destPath"></param>
        /// <param name="progressBarControl"></param>
        /// <returns></returns>
        private int copyItemTo(Boolean bMove, ListViewItem itm, int ind, String sourcePath, String destPath, ProgressBar progressBarControl)
        {
            String sToFilePath;
            String sFromFilePath;
            ind++;
            sFromFilePath = sourcePath + "/" + itm.Text;
            sToFilePath = destPath + "/" + itm.Text;

            progressBarControl.Value = ind;
            System.Windows.Forms.Application.DoEvents();

            if (sourcePath != destPath)
            {
                try
                {
                    if (bMove)
                    {
                        File.Move(sFromFilePath, sToFilePath);
                    }
                    else
                    {
                        File.Copy(sFromFilePath, sToFilePath);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    progressBarControl.Value = 0;
                }
            }
            return ind;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lvFiles"></param>
        public void InitListViewFilePanel(ListView lvFiles)
        {
            //init ListView control
            lvFiles.Clear();		//clear control
            //create column header for ListView
            lvFiles.Columns.Add("Name", 150, System.Windows.Forms.HorizontalAlignment.Left);
            lvFiles.Columns.Add("Size", 75, System.Windows.Forms.HorizontalAlignment.Right);
            lvFiles.Columns.Add("Created", 140, System.Windows.Forms.HorizontalAlignment.Left);
            lvFiles.Columns.Add("Modified", 140, System.Windows.Forms.HorizontalAlignment.Left);
            lvFiles.Columns.Add("Full Path", 180, System.Windows.Forms.HorizontalAlignment.Left);

        }

        public void InitListViewPlaylistFilePanel(ListView lvFiles)
        {
            //init ListView control
            lvFiles.Clear();		//clear control
            //create column header for ListView
            lvFiles.Columns.Add("Name", 150, System.Windows.Forms.HorizontalAlignment.Left);
            lvFiles.Columns.Add("Size", 100, System.Windows.Forms.HorizontalAlignment.Right);
            lvFiles.Columns.Add("Full Path", 480, System.Windows.Forms.HorizontalAlignment.Left);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodeCurrent"></param>
        public String PopulateFiles(TreeNode nodeCurrent, ListView lvFiles, String filePattern)
        {
            int lvFileColCount = 5;
            if (lvFiles.Columns.Count > 0)
            {
                lvFileColCount = lvFiles.Columns.Count;
            }
            //Populate listview with files
            string[] lvData = new string[lvFileColCount];
            String returnPath = "";

            //clear list
            InitListViewFilePanel(lvFiles);

            if (nodeCurrent.SelectedImageIndex != 0)
            {
                //check path
                if (Directory.Exists((string)this.getFullPath(nodeCurrent.FullPath)) == false)
                {
                    MessageBox.Show("Directory or path " + nodeCurrent.ToString() + " does not exist.");
                }
                else
                {
                    try
                    {
                        returnPath = this.getFullPath(nodeCurrent.FullPath);
                        ArrayList lstFiles = new ArrayList();
                        String[] fileCriteria = null;
                        if (filePattern != "")
                        {
                            fileCriteria = filePattern.Split(';');
                        }
                        string[] stringFiles = null;
                        if (fileCriteria == null)
                        {
                            stringFiles = Directory.GetFiles(this.getFullPath(nodeCurrent.FullPath));
                            lstFiles = new ArrayList(stringFiles);

                        }
                        else
                        {
                            foreach (string criteria in fileCriteria)
                            {
                                String[] dirFiles = Directory.GetFiles(this.getFullPath(nodeCurrent.FullPath), criteria);
                                lstFiles.AddRange(dirFiles);
                            }
                        }
                        string stringFileName = "";
                        DateTime dtCreateDate, dtModifyDate;
                        Int64 lFileSize = 0;
                        String fullFilePath = "";

                        //loop throught all files
                        foreach (string stringFile in lstFiles)
                        {
                            stringFileName = stringFile;
                            FileInfo objFileSize = new FileInfo(stringFileName);
                            lFileSize = objFileSize.Length;
                            dtCreateDate = objFileSize.CreationTime; //GetCreationTime(stringFileName);
                            dtModifyDate = objFileSize.LastWriteTime; //GetLastWriteTime(stringFileName);
                            fullFilePath = stringFileName;

                            //create listview data
                            lvData[0] = this.GetPathName(stringFileName);
                            lvData[1] = this.formatSize(lFileSize);

                            //check if file is in local current day light saving time
                            if (TimeZone.CurrentTimeZone.IsDaylightSavingTime(dtCreateDate) == false)
                            {
                                //not in day light saving time adjust time
                                lvData[2] = this.formatDate(dtCreateDate.AddHours(1));
                            }
                            else
                            {
                                //is in day light saving time adjust time
                                lvData[2] = this.formatDate(dtCreateDate);
                            }

                            //check if file is in local current day light saving time
                            if (TimeZone.CurrentTimeZone.IsDaylightSavingTime(dtModifyDate) == false)
                            {
                                //not in day light saving time adjust time
                                lvData[3] = this.formatDate(dtModifyDate.AddHours(1));
                            }
                            else
                            {
                                //not in day light saving time adjust time
                                lvData[3] = this.formatDate(dtModifyDate);
                            }

                            //give full file path to last column
                            lvData[4] = fullFilePath;

                            //Create actual list item
                            ListViewItem lvItem = new ListViewItem(lvData, 0);
                            lvFiles.Items.Add(lvItem);

                        }
                    }
                    catch (IOException e)
                    {
                        MessageBox.Show("Error: Drive not ready or directory does not exist." + e.Message);
                    }
                    catch (UnauthorizedAccessException e)
                    {
                        MessageBox.Show("Error: Drive or directory access denided." + e.Message);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Error: " + e);
                    }
                }
            }

            return returnPath;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodeCurrent"></param>
        /// <param name="nodeCurrentCollection"></param>
        public String PopulateDirectory(TreeNode nodeCurrent, TreeNodeCollection nodeCurrentCollection, ListView lvSourceFiles, String filePattern)
        {
            TreeNode nodeDir;
            int imageIndex = 2;		//unselected image index
            int selectIndex = 3;	//selected image index

            String currentSelectedPath = null;
            if (nodeCurrent.SelectedImageIndex != 0)
            {
                //populate treeview with folders
                try
                {
                    //check path
                    if (Directory.Exists(this.getFullPath(nodeCurrent.FullPath)) == false)
                    {
                        MessageBox.Show("Directory or path " + nodeCurrent.ToString() + " does not exist.");
                    }
                    else
                    {
                        //populate files
                        if (lvSourceFiles != null)
                        {
                            currentSelectedPath = this.PopulateFiles(nodeCurrent, lvSourceFiles, filePattern);
                        }


                        string[] stringDirectories = Directory.GetDirectories(this.getFullPath(nodeCurrent.FullPath));
                        string stringFullPath = "";
                        string stringPathName = "";

                        //loop throught all directories
                        foreach (string stringDir in stringDirectories)
                        {
                            stringFullPath = stringDir;
                            stringPathName = this.GetPathName(stringFullPath);

                            //create node for directories
                            nodeDir = new TreeNode(stringPathName.ToString(), imageIndex, selectIndex);
                            nodeCurrentCollection.Add(nodeDir);
                        }
                    }
                }
                catch (IOException e)
                {
                    MessageBox.Show("Error: Drive not ready or directory does not exist." + e.Message);
                }
                catch (UnauthorizedAccessException e)
                {
                    MessageBox.Show("Error: Drive or directory access denided." + e.Message);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error: " + e);
                }
            }

            return currentSelectedPath;
        }

        /// <summary>
        /// This procedure populate the TreeView with the Drive list
        /// </summary>
        /// <param name="tvFolders"></param>
        /// <param name="myCursor"></param>
        public void PopulateDriveList(TreeView tvFolders, Cursor myCursor)
        {
            //OsifyUtilities util = new OsifyUtilities();
            TreeNode nodeTreeNode;
            int imageIndex = 0;
            int selectIndex = 0;

            const int Removable = 2;
            const int LocalDisk = 3;
            const int Network = 4;
            const int CD = 5;
            //const int RAMDrive = 6;

            myCursor = Cursors.WaitCursor;
            //clear TreeView
            tvFolders.Nodes.Clear();
            nodeTreeNode = new TreeNode("My Computer", 0, 0);
            tvFolders.Nodes.Add(nodeTreeNode);

            //set node collection
            TreeNodeCollection nodeCollection = nodeTreeNode.Nodes;

            //Get Drive list
            ManagementObjectCollection queryCollection = this.getDrives();
            foreach (ManagementObject mo in queryCollection)
            {

                switch (int.Parse(mo["DriveType"].ToString()))
                {
                    case Removable:			//removable drives
                        imageIndex = 5;
                        selectIndex = 5;
                        break;
                    case LocalDisk:			//Local drives
                        imageIndex = 6;
                        selectIndex = 6;
                        break;
                    case CD:				//CD rom drives
                        imageIndex = 7;
                        selectIndex = 7;
                        break;
                    case Network:			//Network drives
                        imageIndex = 8;
                        selectIndex = 8;
                        break;
                    default:				//defalut to folder
                        imageIndex = 2;
                        selectIndex = 3;
                        break;
                }
                //create new drive node
                nodeTreeNode = new TreeNode(mo["Name"].ToString() + "\\", imageIndex, selectIndex);

                //add new node
                nodeCollection.Add(nodeTreeNode);

            }


            //Init files ListView
            //InitListView();

            myCursor = Cursors.Default;
        }
        /// <summary>
        /// Properties parsing
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public Dictionary<String, String> GetProperties(String path)
        {
            String fileData = "";
            using (StreamReader sr = new StreamReader(path))
            {
                fileData = sr.ReadToEnd().Replace("\r", "");
                sr.Close();
            }
            
            Dictionary<String, String> Properties = new Dictionary<String, String>();
            String[] kvp;
            String[] records = fileData.Split("\n".ToCharArray());
            foreach (String record in records)
            {
                kvp = record.Split("=".ToCharArray());
                String key = "";
                String value = "";
                if (kvp.Length > 0 && !"".Equals(kvp[0]))
                {
                    key = kvp[0];
                }
                if (kvp.Length > 1 && !"".Equals(kvp[1]))
                {
                    value = kvp[1];
                }

                if (!"".Equals(key))
                {
                    Properties.Add(key, value);
                }                
            }
            return Properties;
        }

        
    }
}
