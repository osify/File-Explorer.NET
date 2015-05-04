using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;

using osi_explorer_searcher.core.util;
using osi_explorer_searcher.core.vo;
using osi_explorer_searcher.core.constant;
using System.IO;
using System.Collections;

namespace osi_explorer_searcher.core.helper
{
    class PlaylistHelper
    {
        OsifyUtilities osifyUtil;
        public String dbPath;
        
        public PlaylistHelper()
        {
            osifyUtil = new OsifyUtilities();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lvContainer"></param>
        /// <param name="myCursor"></param>
        public void loadPlaylist(TreeView tvContainer, Cursor myCursor)
        {
            TreeNode nodeTreeNode;
            
            myCursor = Cursors.WaitCursor;
            //clear TreeView
            tvContainer.Nodes.Clear();
            nodeTreeNode = new TreeNode(OsifyConstants.MAIN_PLAYLIST, 9, 9);
            tvContainer.Nodes.Add(nodeTreeNode);

            //set node collection
            TreeNodeCollection nodeCollection = nodeTreeNode.Nodes;
            //List<CategoryVo> lstCategory = this.getParentPlaylists();
            IDictionary<String, CategoryVo> mapCategories = this.readFilePlaylists();
            //MessageBox.Show(lstCategory.Count.ToString());
            foreach (String key in mapCategories.Keys)
            {
                CategoryVo catVo = mapCategories[key];
                //create new drive node
                nodeTreeNode = new TreeNode(catVo.CategoryName + "\\", catVo.PlaylistType.getImageIndex(), catVo.PlaylistType.getSelectedImageIndex());

                //add new node
                nodeCollection.Add(nodeTreeNode);
            }
            myCursor = Cursors.Default;
        }
        /// <summary>
        /// Load main playlist
        /// </summary>
        /// <param name="tvFolders"></param>
        /// <param name="myCursor"></param>
        /// <param name="mapCategories"></param>
        public void loadPlaylist(TreeView tvFolders, Cursor myCursor, IDictionary<String, CategoryVo> mapCategories)
        {
            //OsifyUtilities util = new OsifyUtilities();
            TreeNode nodeTreeNode;

            myCursor = Cursors.WaitCursor;
            //clear TreeView
            tvFolders.Nodes.Clear();
            nodeTreeNode = new TreeNode(OsifyConstants.MAIN_PLAYLIST, 9, 0);
            tvFolders.Nodes.Add(nodeTreeNode);

            //set node collection
            TreeNodeCollection nodeCollection = nodeTreeNode.Nodes;

            //MessageBox.Show(lstCategory.Count.ToString());
            foreach (String key in mapCategories.Keys)
            {
                CategoryVo catVo = mapCategories[key];
                //create new drive node
                nodeTreeNode = new TreeNode(catVo.CategoryName + "\\", catVo.PlaylistType.getImageIndex(), catVo.PlaylistType.getSelectedImageIndex());

                //add new node
                nodeCollection.Add(nodeTreeNode);
                this.PopulateSubPlaylists(nodeTreeNode, nodeTreeNode.Nodes, null, mapCategories, catVo.CategoryName);
            }


            //Init files ListView
            //InitListView();
            tvFolders.ExpandAll();
            myCursor = Cursors.Default;
        }
        /// <summary>
        /// Populate next playlist categories and file listing when click each node
        /// </summary>
        /// <param name="nodeCurrent"></param>
        /// <param name="nodeCurrentCollection"></param>
        /// <param name="lvSourceFiles"></param>
        /// <param name="mapCategories"></param>
        /// <returns></returns>
        public String PopulateSubPlaylists(TreeNode nodeCurrent, TreeNodeCollection nodeCurrentCollection, ListView lvSourceFiles, IDictionary<String, CategoryVo> mapCategories, String parentPlaylistName)
        {
            TreeNode nodeDir;
            
            String currentSelectedSize = null;
            if (nodeCurrent.SelectedImageIndex != 0)
            {
                //populate treeview with folders
                try
                {
                    List<CategoryVo> lstChildCategories = new List<CategoryVo>();
                    List<FileVo> lstFileVo = new List<FileVo>();
                    String selectedPlaylist = osifyUtil.getFullPath(nodeCurrent.Text, OsifyConstants.MAIN_PLAYLIST);
                    selectedPlaylist = selectedPlaylist.Replace("\\","");
                    //Boolean isParent = false;
                    //check path
                    if (mapCategories.Keys.Contains(selectedPlaylist))
                    {
                        CategoryVo parentCatVo = mapCategories[selectedPlaylist];
                        lstChildCategories = parentCatVo.ListChildCategory;
                        lstFileVo = parentCatVo.ListSavedFiles;
                        //isParent = true;
                    }
                    //loop throught all directories
                    foreach (CategoryVo catVo in lstChildCategories)
                    {
                        nodeDir = new TreeNode(catVo.CategoryName, catVo.PlaylistType.getImageIndex(), catVo.PlaylistType.getSelectedImageIndex());
                        nodeCurrentCollection.Add(nodeDir);
                    }

                    //Check if the selected sub cat
                    if (mapCategories.Keys.Contains(parentPlaylistName))
                    {
                        CategoryVo parentCatVo = mapCategories[parentPlaylistName];
                        foreach (CategoryVo catVo in parentCatVo.ListChildCategory)
                        {
                            if (catVo.CategoryName.Equals(selectedPlaylist))
                            {
                                lstFileVo = catVo.ListSavedFiles;
                            }
                        }
                    }

                    //populate files
                    if (lvSourceFiles != null)
                    {
                        currentSelectedSize = this.PopulatePlaylistFiles(nodeCurrent, lvSourceFiles, lstFileVo);
                        //this.RefreshPlaylistFileView(lvSourceFiles, mapCategories, parentPlaylistName, selectedPlaylist, isParent);
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

            return currentSelectedSize;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodeCurrent"></param>
        /// <param name="lvFiles"></param>
        /// <param name="lstFileVo"></param>
        /// <returns></returns>
        public String PopulatePlaylistFiles(TreeNode nodeCurrent, ListView lvFiles, List<FileVo> lstFileVo)
        {
            int lvFileColCount = 3;
            if (lvFiles.Columns.Count > 0)
            {
                lvFileColCount = lvFiles.Columns.Count;
            }
            //Populate listview with files
            string[] lvData = new string[lvFileColCount];

            Int64 lFullFileSize = 0;

            //clear list
            osifyUtil.InitListViewPlaylistFilePanel(lvFiles);


            if (nodeCurrent.SelectedImageIndex != 0)
            {
                try
                {
                    osifyUtil.getFullPath(nodeCurrent.FullPath, OsifyConstants.MAIN_PLAYLIST);

                    string stringFileName = "";
                    DateTime dtCreateDate, dtModifyDate;
                    Int64 lFileSize = 0;
                    String fullFilePath = "";

                    //loop throught all files
                    foreach (FileVo fileVo in lstFileVo)
                    {
                        stringFileName = fileVo.Path;
                        FileInfo objFileSize = new FileInfo(stringFileName);
                        lFileSize = objFileSize.Length;
                        dtCreateDate = objFileSize.CreationTime; //GetCreationTime(stringFileName);
                        dtModifyDate = objFileSize.LastWriteTime; //GetLastWriteTime(stringFileName);
                        fullFilePath = stringFileName;

                        //create listview data
                        lvData[0] = osifyUtil.GetPathName(stringFileName);
                        lvData[1] = osifyUtil.formatSize(lFileSize);

                        //give full file path to last column
                        lvData[2] = fullFilePath;

                        //Create actual list item
                        ListViewItem lvItem = new ListViewItem(lvData, 0);
                        lvFiles.Items.Add(lvItem);

                        lFullFileSize += lFileSize;
                    }
                }
                catch (IOException e)
                {
                    MessageBox.Show("Error: Playlist not ready or Playlist does not exist." + e.Message);
                }
                catch (UnauthorizedAccessException e)
                {
                    MessageBox.Show("Error: Playlist access denided." + e.Message);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Error: " + e);
                }
            }

            return osifyUtil.formatSize(lFullFileSize, "BYT");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tvContainer"></param>
        /// <param name="myCursor"></param>
        /// <param name="categoryVo"></param>
        public void createPlaylist(TreeView tvContainer, Cursor myCursor, CategoryVo categoryVo, String dbPath)
        {
            myCursor = Cursors.WaitCursor;
            //this.createTreeNode(tvContainer, categoryVo);
            this.dbPath = dbPath;

            String filePath = dbPath
                + OsifyConstants.DB_INIT_PATH_SUB
                + categoryVo.CategoryFileName;

            String fileToWrite = dbPath;
            if (categoryVo.CategoryParent == null || "".Equals(categoryVo.CategoryParent))
            {
                fileToWrite += OsifyConstants.DB_MAIN_FILE;
            }
            else
            {
                fileToWrite = fileToWrite + OsifyConstants.DB_INIT_PATH_SUB + categoryVo.CategoryFileName;
            }
                            
            if (!File.Exists(filePath)
                && (categoryVo.CategoryParent != null && !"".Equals(categoryVo.CategoryParent))) 
            {
                // sub file
                //File.Create(filePath);
            }
            // write main file data
            StreamWriter writer1 = new StreamWriter(fileToWrite, true);
            writer1.WriteLine(CategoryVo.buildCategoryHeading(categoryVo));
            writer1.Close();

            myCursor = Cursors.Default;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IDictionary<String, CategoryVo> readFilePlaylists()
        {
            StreamReader sr = new StreamReader(this.dbPath + OsifyConstants.DB_MAIN_FILE);
            String line = null;
            //List<CategoryVo> lstCategory = new List<CategoryVo>();
            line = sr.ReadLine();
            while (line != null && line != "")
            {
                if (!isCategoryLine(line))
                {
                    continue;
                }
                CategoryVo catVo = splitCsvToCategoryVo(line);
                catVo = this.parseSubFileToList(this.dbPath + OsifyConstants.DB_INIT_PATH_SUB + catVo.CategoryFileName, catVo);
                if (catVo != null 
                    && CategoryVo.mapParentCategory.Keys.Contains(catVo.CategoryName))
                {
                    //lstCategory.Add(catVo);                    
                    CategoryVo.mapParentCategory.Remove(catVo.CategoryName);
                }
                if (catVo != null)
                {
                    CategoryVo.mapParentCategory.Add(catVo.CategoryName, catVo);
                }
                line = sr.ReadLine();
            }
            sr.Close();
            
            return CategoryVo.mapParentCategory;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="parentCatVo"></param>
        private CategoryVo parseSubFileToList(String filename, CategoryVo parentCatVo)
        {
            IDictionary<String, List<IData>> mapList = this.readSubFileToMap(filename);
            if (mapList == null) return parentCatVo;

            List<IData> lstCategoryVo = mapList[OsifyConstants.DB_INIT_CATEGORY];
            List<IData> lstFileVo = mapList[OsifyConstants.DB_INIT_FILE];

            List<CategoryVo> lstChildCategoryVo = new List<CategoryVo>();
            if (lstCategoryVo != null)
            {
                foreach (CategoryVo catVo in lstCategoryVo)
                {
                    if (parentCatVo.CategoryName.Equals(catVo.CategoryParent))
                    {
                        catVo.ListSavedFiles = this.buildFileListWithCategoryVo(lstFileVo, catVo);
                        lstChildCategoryVo.Add(catVo);
                    }
                }
            }
            parentCatVo.ListChildCategory = lstChildCategoryVo;
            parentCatVo.ListSavedFiles = this.buildFileListWithCategoryVo(lstFileVo, parentCatVo);

            return parentCatVo;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lstOriginalFileVo"></param>
        /// <param name="catVo"></param>
        /// <returns></returns>
        private List<FileVo> buildFileListWithCategoryVo(List<IData> lstOriginalFileVo, CategoryVo catVo) 
        {
            List<FileVo> lstFileVo = new List<FileVo>();
            foreach (FileVo fileVo in lstOriginalFileVo)
            {
                if (catVo.CategoryName.Equals(fileVo.CategoryName))
                {
                    lstFileVo.Add(fileVo);
                    //lstOriginalFileVo.Remove(fileVo);
                }
            }
            return lstFileVo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="csvLine"></param>
        /// <returns></returns>
        private CategoryVo splitCsvToCategoryVo(String csvLine)
        {
            Char[] separator = OsifyConstants.DB_SEPARATOR.ToCharArray();
            String[] str = csvLine.Split(separator);
            
            if (str.Length < 5)
            {
                return null; 
            }

            
            CategoryVo catVo = new CategoryVo();
            String heading = str[0];
            if (OsifyConstants.DB_INIT_PARENT.Equals(heading))
            {
                catVo.CategoryParent = null;
            } else {
                // in sub file, heading is the parent category
                if (str.Length > 5 && str[5] != null)
                {
                    catVo.CategoryParent = str[5];
                }
            }
            if (OsifyConstants.DB_INIT_FILE.Equals(str[1])) 
            {
                Console.WriteLine("We expected to read category, not file");
                return null;
            }
            
            if (str[2] != null) {
                catVo.CategoryName = str[2];
            }

            if (str[3] != null)
            {
                PlaylistType plType = PlaylistType.get(str[3]);
                catVo.PlaylistType = plType;
            }
            if (str[4] != null)
            {
                catVo.CategoryFileName = str[4];
            }

            return catVo;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="csvLine"></param>
        /// <returns></returns>
        private FileVo splitCsvToFileVo(String csvLine)
        {
            Char[] separator = OsifyConstants.DB_SEPARATOR.ToCharArray();
            String[] str = csvLine.Split(separator);
            FileVo fileVo = new FileVo();
            if (str.Length < 4)
            {
                return null;
            }

            if (str[0] != null && OsifyConstants.DB_INIT_PARENT.Equals(str[0]))
            {
                fileVo.IsParent = true;
            }
            else
            {
                fileVo.IsParent = false;
            }

            if (str[2] != null) 
            {
                fileVo.CategoryName = str[2];
            }

            if (str[3] != null)
            {
                fileVo.Path = str[3];
            }
            if (str.Length > 3 && str[4] != null)
            {
                fileVo.CategoryParentName = str[4];
            }

            return fileVo;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="csvLine"></param>
        /// <returns></returns>
        private Boolean isCategoryLine(String csvLine)
        {   
            Char[] separator = OsifyConstants.DB_SEPARATOR.ToCharArray();
            String[] str = csvLine.Split(separator);
            if (str.Length > 2 && OsifyConstants.DB_INIT_FILE.Equals(str[1]))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="parentVo"></param>
        private IDictionary<String, List<IData>> readSubFileToMap(String filename)
        {
            List<String> lstFileLines = new List<String>();
            List<IData> lstCategory = new List<IData>();
            List<IData> lstFileVo = new List<IData>();
            if (!File.Exists(filename)) {
                return null;
            }
            StreamReader sr = new StreamReader(filename);
            String line = sr.ReadLine(); 
            while (line != null && line != "")
            {
                if (this.isCategoryLine(line))
                {
                    CategoryVo catVo = splitCsvToCategoryVo(line);
                    if (catVo != null)
                    {
                        lstCategory.Add(catVo);
                    }                    
                }
                else
                {
                    FileVo fileVo = this.splitCsvToFileVo(line);
                    if (fileVo != null)
                    {
                        lstFileVo.Add(fileVo);
                    }
                }
                lstFileLines.Add(line);
                line = sr.ReadLine();
            }
            sr.Close();

            IDictionary<String, List<IData>> mapList = new Dictionary<String, List<IData>>();

            mapList.Add(OsifyConstants.DB_INIT_CATEGORY, lstCategory);
            mapList.Add(OsifyConstants.DB_INIT_FILE, lstFileVo);

            return mapList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tvContainer"></param>
        /// <param name="categoryVo"></param>
        public void createTreeNode(TreeView tvContainer, CategoryVo categoryVo)
        {
            TreeNode tvNodeMain = tvContainer.Nodes[0];
            if (categoryVo.CategoryParent != null && categoryVo.CategoryParent != "")
            {
                tvNodeMain = tvNodeMain.Nodes[categoryVo.ParentIndex];
            }
            
             
            TreeNodeCollection nodeCollection = tvNodeMain.Nodes;
            
            TreeNode nodeTreeNode = new TreeNode(categoryVo.CategoryName + "\\", categoryVo.PlaylistType.getImageIndex(), categoryVo.PlaylistType.getSelectedImageIndex());
            nodeCollection.Add(nodeTreeNode);
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="tvContainer"></param>
        ///// <param name="cboParent"></param>
        //public void listParentNode(TreeView tvContainer, ComboBox cboParent, int selectedNode)
        //{
        //    TreeNode tvNodeMain = tvContainer.Nodes[0];
        //    TreeNodeCollection nodeCollection = tvNodeMain.Nodes;
        //    cboParent.Items.Clear();
        //    foreach (TreeNode tvNode in nodeCollection)
        //    {
        //        cboParent.Items.Add(tvNode.Text);
        //    }
        //    if (selectedNode != -1)
        //    {
        //        cboParent.SelectedIndex = selectedNode;
        //    }
        //}
        /// <summary>
        /// Load to combo all parent list
        /// </summary>
        /// <param name="cboParent"></param>
        public void listParentPlaylist(ComboBox cboParent)
        {
            cboParent.Items.Clear();
            IDictionary<String, CategoryVo> mapCategories = this.readFilePlaylists();
            //MessageBox.Show(lstCategory.Count.ToString());
            foreach (String key in mapCategories.Keys)
            {
                CategoryVo catVo = mapCategories[key];            
                cboParent.Items.Add(catVo.CategoryName);
            }
        }

        public void initializePlaylistTypeCombo(ComboBox cbPlType)
        {
            PlaylistType.buildCombo(cbPlType);
            cbPlType.SelectedIndex = 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileVo"></param>
        /// <param name="filenameToWrite"></param>
        public void buildFileVoAndAdd(FileVo fileVo, String filenameToWrite)
        {
            bool canContinue = true;
            if (File.Exists(filenameToWrite))
            {
                StreamReader sr = new StreamReader(filenameToWrite);
                String line = sr.ReadLine();
                while (line != null && !"".Equals(line))
                {
                    if (fileVo.toString().Equals(line))
                    {
                        canContinue = false;
                        break;
                    }
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            
            if (!canContinue)
            {
                return;
            }
            StreamWriter sw = new StreamWriter(filenameToWrite, true);
            sw.WriteLine(fileVo.toString());
            sw.Close();
        }

#region  File Utilities
        /// <summary>
        /// Write files to clipboard (from http://blogs.wdevs.com/idecember/archive/2005/10/27/10979.aspx)
        /// </summary>
        /// <param name="cut">True if cut, false if copy</param>
        public void CopyToClipboard(bool cut, ListView listView1)
        {
            string[] files = GetSelection(listView1);
            if (files != null)
            {
                IDataObject data = new DataObject(DataFormats.FileDrop, files);
                MemoryStream memo = new MemoryStream(4);
                byte[] bytes = new byte[] { (byte)(cut ? 2 : 5), 0, 0, 0 };
                memo.Write(bytes, 0, bytes.Length);
                data.SetData("Preferred DropEffect", memo);
                Clipboard.SetDataObject(data);
            }
        }

        public string[] GetSelection(ListView listView1)
        {
            if (listView1.SelectedItems.Count == 0)
                return null;

            string[] files = new string[listView1.SelectedItems.Count];
            int i = 0;
            foreach (ListViewItem item in listView1.SelectedItems)
            {
                if (item.SubItems.Count > 2)
                {
                    files[i++] = item.SubItems[2].Text;
                }
                else
                {
                    files[i++] = item.Text;
                }
                
            }
            return files;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="lvFiles"></param>
        /// <param name="lstFileVo"></param>
        public String RefreshPlaylistFileView(ListView lvFiles, IDictionary<String, CategoryVo> mapCategories, String mainPlaylist, String selectedPlaylist, Boolean isParent)
        {
            List<FileVo> lstFileVo = new List<FileVo>();
            //Check if the selected sub cat
            if (mapCategories.Keys.Contains(mainPlaylist))
            {
                CategoryVo parentCatVo = mapCategories[mainPlaylist];
                lstFileVo = parentCatVo.ListSavedFiles;
                if (!isParent)
                {
                    foreach (CategoryVo catVo in parentCatVo.ListChildCategory)
                    {
                        if (catVo.CategoryName.Equals(selectedPlaylist))
                        {
                            lstFileVo = catVo.ListSavedFiles;
                        }
                    }
                }                
            }

            int lvFileColCount = 3;
            if (lvFiles.Columns.Count > 0)
            {
                lvFileColCount = lvFiles.Columns.Count;
            }
            //Populate listview with files
            string[] lvData = new string[lvFileColCount];

            //clear list
            osifyUtil.InitListViewPlaylistFilePanel(lvFiles);

            string stringFileName = "";
            DateTime dtCreateDate, dtModifyDate;
            Int64 lFileSize = 0;
            Int64 lFullFileSize = 0;
            String fullFilePath = "";

            //loop throught all files
            foreach (FileVo fileVo in lstFileVo)
            {
                stringFileName = fileVo.Path;
                if (!File.Exists(stringFileName))
                {
                    continue;
                }

                FileInfo objFileSize = new FileInfo(stringFileName);
                lFileSize = objFileSize.Length;
                dtCreateDate = objFileSize.CreationTime; //GetCreationTime(stringFileName);
                dtModifyDate = objFileSize.LastWriteTime; //GetLastWriteTime(stringFileName);
                fullFilePath = stringFileName;

                //create listview data
                lvData[0] = osifyUtil.GetPathName(stringFileName);
                lvData[1] = osifyUtil.formatSize(lFileSize);

                //give full file path to last column
                lvData[2] = fullFilePath;

                //Create actual list item
                ListViewItem lvItem = new ListViewItem(lvData, 0);
                lvFiles.Items.Add(lvItem);

                lFullFileSize += lFileSize;
            }

            return osifyUtil.formatSize(lFullFileSize, OsifyConstants.BYT);
        }
#endregion
    }
}
