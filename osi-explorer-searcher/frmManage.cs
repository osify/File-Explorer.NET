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
using osi_explorer_searcher.core.helper;
using osi_explorer_searcher.core.vo;
using osi_explorer_searcher.core.constant;
using System.IO;
using System.Collections;

namespace osi_explorer_searcher
{
    public partial class frmManage : Form
    {
        OsifyUtilities osifyUtil;
        PlaylistHelper playlistHelper;
        //TreeNode m_OldSelectNode;
        String filePath;
        String subFilePath;
        IDictionary<String, CategoryVo> mapCategories;

        const int ALT = 32;
        const int CTRL = 8;
        const int SHIFT = 4;

        public frmManage()
        {
            InitializeComponent();
            osifyUtil = new OsifyUtilities();
            playlistHelper = new PlaylistHelper();
        }

        private void frmManage_Load(object sender, EventArgs e)
        {
            
            this.checkDbPath();
            playlistHelper.dbPath = filePath;
            this.processWhenUpdate();
            playlistHelper.initializePlaylistTypeCombo(this.cboPlType);
            this.statusSelected.Text = "Please select a list to start";
        }

        private void checkDbPath()
        {
            String appPropertiesFile = OsifyConstants.APP_CONFIG_FILE;
            Dictionary<String, String> properties = osifyUtil.GetProperties(appPropertiesFile);
            Boolean loadDbFromStartUp = true;
            if (properties.Keys.Contains(OsifyConstants.GLOBAL_DB_AT_STARTUP))
            {
                loadDbFromStartUp = (properties[OsifyConstants.GLOBAL_DB_AT_STARTUP] == "1" ? true : false);
            }
            filePath = Application.StartupPath;
            if (!loadDbFromStartUp) 
            {
                if (properties.Keys.Contains(OsifyConstants.GLOBAL_DB_PATH) && properties[OsifyConstants.GLOBAL_DB_PATH] != null)
                {
                    filePath = properties[OsifyConstants.GLOBAL_DB_PATH].Trim();
                }
            }
            filePath += OsifyConstants.DB_INIT_PATH;
            subFilePath = filePath + OsifyConstants.DB_INIT_PATH_SUB;
            OsifyConstants.DB_ASSIGN_PATH = filePath;

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            if (!Directory.Exists(subFilePath))
            {
                Directory.CreateDirectory(subFilePath);
            }

            if (!File.Exists(this.filePath + OsifyConstants.DB_MAIN_FILE))
            {
                StreamWriter sw = new StreamWriter(this.filePath + OsifyConstants.DB_MAIN_FILE,true);
                sw.Close();
            }
        }

        private Boolean mandatoryProcessError()
        {
            if (!File.Exists(OsifyConstants.APP_RELEASE_FILE))
            {
                MessageBox.Show("You need to attach RELEASE file at application startup path.");
                return true;
            }

            return false;
        }

        // FileSystemWatcher calls on another thread
        private delegate void ChangeHandler(object sender, FileSystemEventArgs e);

        private void tvPlaylist_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //Populate folders and files when a folder is selected
            this.Cursor = Cursors.WaitCursor;

            //get current selected drive or folder
            TreeNode nodeCurrent = e.Node;

            //clear all sub-folders
            nodeCurrent.Nodes.Clear();

            if (nodeCurrent.SelectedImageIndex == 0)
            {
                playlistHelper.loadPlaylist(this.tvPlaylist, this.Cursor, this.mapCategories);
                
            } else {
                this.txtSelectedPlaylist.Text = nodeCurrent.FullPath;
                this.findMainPlaylist();                
                this.txtPlaylistSize.Text = playlistHelper.PopulateSubPlaylists(nodeCurrent, nodeCurrent.Nodes, this.lvPlaylistFiles, this.mapCategories, this.txtMainPlaylist.Text);
            }
            this.Cursor = Cursors.Default;
        }


        private void btnNewPlaylist_Click(object sender, EventArgs e)
        {   
            
        }
        /// <summary>
        /// When create new playlist
        /// </summary>
        private void callPlaylistPanel()
        {
            int locationX = this.Location.X + (this.Width / 2 - this.panelPlaylist.Width);
            int locationY = this.Location.Y + (this.Height / 2 - this.panelPlaylist.Height);
            this.panelPlaylist.Visible = true;
            this.panelPlaylist.Location = new Point(locationX, locationY);
        }

        private void btnPlaylistCancel_Click(object sender, EventArgs e)
        {
            this.panelPlaylist.Visible = false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPlaylistSave_Click(object sender, EventArgs e)
        {
            CategoryVo categoryVo = this.buildCategoryVoFromForm();
            if (categoryVo == null) return;

            if ((categoryVo.CategoryParent == null 
                || "".Equals(categoryVo.CategoryParent))
                && mapCategories.Keys.Contains(categoryVo.CategoryName))
            {
                MessageBox.Show("Main list: " + categoryVo.CategoryName + " already exists, please choose another name");
                return;
            }

            // if sub cat
            if (categoryVo.CategoryParent != null 
                    && !"".Equals(categoryVo.CategoryParent)) {
                CategoryVo parentCatVo = mapCategories[categoryVo.CategoryParent];
                categoryVo.CategoryFileName = parentCatVo.CategoryFileName;
            }

            playlistHelper.createPlaylist(this.tvPlaylist, this.Cursor, categoryVo, filePath);
            MessageBox.Show("List [" + categoryVo.CategoryName + "] created.");
            // re-init
            this.processWhenUpdate();
            this.panelPlaylist.Visible = false;
        }
        /// <summary>
        /// 
        /// </summary>
        private void clearPlaylistPanel()
        {
            this.txtPlaylistName.Text = "";
            this.cboPlaylistParent.Text = "";
            this.cboPlType.Text = "";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private CategoryVo buildCategoryVoFromForm()
        {
            if (this.txtPlaylistName.Text.Trim() == "")
            {
                MessageBox.Show("List Name is required.");
                return null;
            }
            if (this.cboPlType.Text.Trim() == "") 
            {
                MessageBox.Show("Content type of list is required.");
                return null;
            }

            CategoryVo categoryVo = new CategoryVo();
            categoryVo.CategoryName = this.txtPlaylistName.Text;
            categoryVo.CategoryParent = this.cboPlaylistParent.Text;
            categoryVo.CategoryFileName = osifyUtil.generateFileName(categoryVo.CategoryName, filePath) + ".csv";
            PlaylistType playlistType = PlaylistType.get(this.cboPlType.Text);
            if (playlistType == null)
            {
                MessageBox.Show("Issue seem impact when you select list type, now use default instead.");
                playlistType = PlaylistType.ANY;
            }
            categoryVo.PlaylistType = playlistType;
            categoryVo.ParentIndex = this.cboPlaylistParent.SelectedIndex;

            CategoryVo.AddParent(categoryVo.CategoryName, categoryVo);
            return categoryVo;
        }
        /// <summary>
        /// Everytime db change
        /// </summary>
        private void processWhenUpdate()
        {   
            mapCategories = playlistHelper.readFilePlaylists();
            playlistHelper.loadPlaylist(this.tvPlaylist, this.Cursor, mapCategories);
            playlistHelper.listParentPlaylist(this.cboPlaylistParent);            
        }


#region Drag and drop
        /// <summary>
        /// Called when we start dragging an item out of our listview
        /// </summary>
        private void lvPlaylistFiles_ItemDrag(object sender, System.Windows.Forms.ItemDragEventArgs e)
        {
            String[] files = playlistHelper.GetSelection(lvPlaylistFiles);
            DoDragDrop(new DataObject(DataFormats.FileDrop, files), DragDropEffects.Copy /* | DragDropEffects.Move | DragDropEffects.Link */);
            this.RefrestPlaylistFileView();
        }

        /// <summary>
        /// Called when someone drags something over our listview
        /// </summary>
        private void lvPlaylistFiles_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
        {
            // Determine whether file data exists in the drop data. If not, then
            // the drop effect reflects that the drop cannot occur.
            if (!e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.None;
                return;
            }

            // Set the effect based upon the KeyState.
            // Can't get links to work - Use of Ole1 services requiring DDE windows is disabled
            //			if ((e.KeyState & (CTRL | ALT)) == (CTRL | ALT) &&
            //				(e.AllowedEffect & DragDropEffects.Link) == DragDropEffects.Link) 
            //			{
            //				e.Effect = DragDropEffects.Link;
            //			}
            //			
            //			else if ((e.KeyState & ALT) == ALT && 
            //				(e.AllowedEffect & DragDropEffects.Link) == DragDropEffects.Link) 
            //			{
            //				e.Effect = DragDropEffects.Link;
            //
            //			} 
            //			else
            if ((e.KeyState & SHIFT) == SHIFT &&
                (e.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move)
            {
                e.Effect = DragDropEffects.Move;

            }
            else if ((e.KeyState & CTRL) == CTRL &&
                (e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
            {
                e.Effect = DragDropEffects.Copy;
            }
            else if ((e.AllowedEffect & DragDropEffects.Move) == DragDropEffects.Move)
            {
                // By default, the drop action should be move, if allowed.
                e.Effect = DragDropEffects.Move;

                // Implement the rather strange behaviour of explorer that if the disk
                // is different, then default to a COPY operation
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.Length > 0 && /*!files[0].ToUpper().StartsWith(homeDisk) &&*/			// Probably better ways to do this
                (e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
                    e.Effect = DragDropEffects.Copy;
            }
            else
                e.Effect = DragDropEffects.None;

            // This is an example of how to get the item under the mouse
            Point pt = lvPlaylistFiles.PointToClient(new Point(e.X, e.Y));
            ListViewItem itemUnder = lvPlaylistFiles.GetItemAt(pt.X, pt.Y);
        }

        /// <summary>
        /// Somebody dropped something on our listview - perform the action
        /// </summary>
        private void lvPlaylistFiles_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            // Can only drop files, so check
            if (!e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                return;
            }

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (string file in files)
            {
                //string dest = homeFolder + "\\" + Path.GetFileName(file);
                bool isFolder = Directory.Exists(file);
                bool isFile = File.Exists(file);
                if (!isFolder && !isFile)				// Ignore if it doesn't exist
                    continue;

                try
                {
                    switch (e.Effect)
                    {
                        case DragDropEffects.Copy:
                            if (isFile) // TODO: Need to handle folders
                            {
                                //File.Copy(file, dest, false);
                                this.processCopy(file);
                            }
                            else
                            {
                                MessageBox.Show("Inputing folder: " + file);
                            }
                            break;
                        case DragDropEffects.Move:
                            if (isFile)
                            {
                                //File.Move(file, dest);
                                this.processCopy(file);
                            }
                            else
                            {
                                MessageBox.Show("Inputing folder: " + file);
                            }
                             
                            break;
                        case DragDropEffects.Link:		// TODO: Need to handle links
                            break;
                    }
                }
                catch (IOException ex)
                {
                    MessageBox.Show(this, "Failed to perform the specified operation:\n\n" + ex.Message, "File operation failed", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }

            this.RefrestPlaylistFileView();
            
        }

        private void processCopy(String strFile)
        {
            FileVo fileVo = this.buildFileVo(strFile);
            String fileToWrite = this.subFilePath + this.txtMainPlaylistFile.Text;
            playlistHelper.buildFileVoAndAdd(fileVo, fileToWrite);
        }
        /// <summary>
        ///  
        /// </summary>
        /// <returns></returns>
        private FileVo buildFileVo(String strFile)
        {
            FileVo fileVo = new FileVo();
            fileVo.Path = strFile;
            fileVo.CategoryName = this.txtSelectedSubPlaylist.Text;
            fileVo.IsParent = false;
            fileVo.CategoryParentName = this.txtMainPlaylist.Text;
            if (this.txtIsParent.Text == "1")
            {
                fileVo.IsParent = true;
            }
            return fileVo;
        }
        /// <summary>
        /// 
        /// </summary>
        private void RefrestPlaylistFileView()
        {
            mapCategories = playlistHelper.readFilePlaylists();
            Boolean isParent = true;
            if (this.txtIsParent.Text == "0")
            {
                isParent = false;
            }
            this.txtPlaylistSize.Text = playlistHelper.RefreshPlaylistFileView(this.lvPlaylistFiles, mapCategories, this.txtMainPlaylist.Text, this.txtSelectedSubPlaylist.Text, isParent);
        }
#endregion

        private void lvPlaylistFiles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void menuNewPlaylist_Click(object sender, EventArgs e)
        {
            if (!checkIsCanEdit())
            {
                return;
            }
            callPlaylistPanel();
            clearPlaylistPanel();

            this.cboPlaylistParent.Text = this.findMainPlaylist();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private String findMainPlaylist()
        {
            String mainPlaylist = "";
            if (this.txtSelectedPlaylist.Text != "")
            {
                String tmpStr = this.txtSelectedPlaylist.Text;
                String[] strPlaylist = tmpStr.Split('\\');
                
                if (strPlaylist.Length >= 2 && !"".Equals(strPlaylist[1]))
                {
                    mainPlaylist = strPlaylist[1];
                }
                tmpStr = mainPlaylist;
                this.txtIsParent.Text = "1";
                if (!"".Equals(strPlaylist[strPlaylist.Length - 1])) 
                {
                    tmpStr = strPlaylist[strPlaylist.Length - 1];
                    this.txtIsParent.Text = "0";
                }
                this.txtSelectedSubPlaylist.Text = tmpStr;
            }

            if (!"".Equals(mainPlaylist) && mapCategories.Keys.Contains(mainPlaylist))
            {
                CategoryVo catVo = mapCategories[mainPlaylist];
                this.txtMainPlaylistFile.Text = catVo.CategoryFileName;
                this.txtMainPlaylist.Text = catVo.CategoryName;
            }
            return mainPlaylist;
        }

        private Boolean checkIsCanEdit()
        {
            if (this.chkEditable.Checked != true)
            {
                MessageBox.Show("You need to enable editable flag - You can not directly modify all these data.");
                return false;
            }
            return true;
        }

        private void menuEditPlaylist_Click(object sender, EventArgs e)
        {
            if (!checkIsCanEdit())
            {
                return;
            }
        }

        private void menuDelPlaylist_Click(object sender, EventArgs e)
        {
            if (!checkIsCanEdit())
            {
                return;
            }
        }

        private void pasteMenuItem_Click(object sender, EventArgs e)
        {
            if (!checkIsCanEdit())
            {
                return;
            }

            IDataObject data = Clipboard.GetDataObject();
            if (!data.GetDataPresent(DataFormats.FileDrop))
                return;

            string[] files = (string[])data.GetData(DataFormats.FileDrop);
            MemoryStream stream = (MemoryStream)data.GetData("Preferred DropEffect", true);
            int flag = stream.ReadByte();
            if (flag != 2 && flag != 5)
                return;
            bool cut = (flag == 2);
            foreach (string file in files)
            {
                try
                {
                    if (cut)
                        this.processCopy(file);
                    else
                        this.processCopy(file);
                }
                catch (IOException ex)
                {
                    MessageBox.Show(this, "Failed to perform the specified operation:\n\n" + ex.Message, "File operation failed", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }

            this.RefrestPlaylistFileView();
        }

        private void refreshMenuItem_Click(object sender, EventArgs e)
        {
            this.RefrestPlaylistFileView();
        }

        private void copyMenuItem_Click(object sender, EventArgs e)
        {
            playlistHelper.CopyToClipboard(false, this.lvPlaylistFiles);
        }

        private void txtSelectedSubPlaylist_TextChanged(object sender, EventArgs e)
        {
            this.statusSelected.Text = "Selected [" + this.txtSelectedSubPlaylist.Text + "]";
        }

        private void txtPlaylistSize_TextChanged(object sender, EventArgs e)
        {
            this.statusListSize.Text = "Size [" + this.txtPlaylistSize.Text + "]";
            this.statusNumFiles.Text = "Total item(s) [" + this.lvPlaylistFiles.Items.Count + "]";
        }

        private void cutMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
