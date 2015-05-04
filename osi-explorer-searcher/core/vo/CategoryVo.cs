using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using osi_explorer_searcher.core.constant;
using System.Collections;

namespace osi_explorer_searcher.core.vo
{
    /// <summary>
    /// @author Pongsametrey.SOK
    /// </summary>
    class CategoryVo : IData
    {
        public static IDictionary<String, CategoryVo> mapParentCategory = new Dictionary<String, CategoryVo>();
        private long _categoryId;
        private String _categoryName;
        private String _categoryParent;
        private int _parentIndex;
        private PlaylistType _playlistType;
        private List<CategoryVo> _listChildCategory;
        private List<FileVo> _listSavedFiles;
        private String _categoryFileName;

        public CategoryVo()
        {
            this._listChildCategory = new List<CategoryVo>();
            this._listSavedFiles = new List<FileVo>();
        }

        public long CategoryId
        {
            get { return this._categoryId; }
            set { this._categoryId = value; }
        }

        public String CategoryName
        {
            get { return this._categoryName; }
            set { this._categoryName = value; }
        }

        public String CategoryParent
        {
            get { return this._categoryParent; }
            set { this._categoryParent = value; }
        }

        public int ParentIndex
        {
            get { return this._parentIndex; }
            set { this._parentIndex = value; }
        }

        public String CategoryFileName
        {
            get { return this._categoryFileName; }
            set { this._categoryFileName = value; }
        }

        public PlaylistType PlaylistType
        {
            get { return this._playlistType; }
            set { this._playlistType = value; }
        }

        public List<CategoryVo> ListChildCategory
        {
            get { return this._listChildCategory; }
            set { this._listChildCategory = value; }
        }

        public List<FileVo> ListSavedFiles
        {
            get { return this._listSavedFiles; }
            set { this._listSavedFiles = value; }
        }
        /// <summary>
        /// Manage child category list
        /// </summary>
        /// <param name="categoryVo"></param>
        public void SetChildCategory(CategoryVo categoryVo)
        {
            if (!this._listChildCategory.Contains(categoryVo))
            {
                this._listChildCategory.Add(categoryVo);
            }            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="parentVo"></param>
        public static void AddParent(String name, CategoryVo parentVo)
        {
            if (parentVo.CategoryParent == null && parentVo.CategoryParent == "")
            {
                CategoryVo.mapParentCategory.Add(name, parentVo);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileVo"></param>
        public void SetSavedFile(FileVo fileVo)
        {
            if (!this._listSavedFiles.Contains(fileVo))
            {
                this._listSavedFiles.Add(fileVo);
            }
        }

        /// <summary>
        /// MAIN (or SUB);CATEGORY;Category Name;Playlist type Code;CategoryFileName
        /// </summary>
        /// <param name="catVo"></param>
        /// <returns></returns>
        public static String buildCategoryHeading(CategoryVo catVo)
        {
            StringBuilder strBuild = new StringBuilder();
            String codeFirst = "";
            String subPlaylistParent = "";

            if (catVo.CategoryParent == null
                || catVo.CategoryParent == "")
            {
                codeFirst = OsifyConstants.DB_INIT_PARENT;    
            }
            else
            {
                codeFirst = OsifyConstants.DB_INIT_CHILD;
                subPlaylistParent = OsifyConstants.DB_SEPARATOR + catVo.CategoryParent;
            }

            strBuild.Append(catVo.CategoryId).Append(OsifyConstants.DB_SEPARATOR)
                    .Append(codeFirst).Append(OsifyConstants.DB_SEPARATOR)
                    .Append(OsifyConstants.DB_INIT_CATEGORY).Append(OsifyConstants.DB_SEPARATOR)
                    .Append(catVo.CategoryName).Append(OsifyConstants.DB_SEPARATOR)
                    .Append(catVo.PlaylistType.getCode()).Append(OsifyConstants.DB_SEPARATOR)
                    .Append(catVo.CategoryFileName).Append(subPlaylistParent);

            return strBuild.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static String parentToCsv()
        {
            StringBuilder strBuilder = new StringBuilder();
            foreach (String myCode in CategoryVo.mapParentCategory.Keys)
            {
                CategoryVo catVo = (CategoryVo)CategoryVo.mapParentCategory[myCode];
                strBuilder.Append(CategoryVo.buildCategoryHeading(catVo)).Append("\r\n");
            }

            return strBuilder.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static String parentBuildSubCategory(CategoryVo catVo)
        {
            if (catVo.CategoryParent == null || catVo.CategoryParent == "")
            {
                return null;
            }
            StringBuilder strBuilder = new StringBuilder();

            foreach (CategoryVo catTmpVo in catVo.ListChildCategory)
            {
                strBuilder.Append(CategoryVo.buildCategoryHeading(catTmpVo)).Append("\r\n");
                strBuilder.Append(CategoryVo.prepareFileLines(catTmpVo));
            }
            return strBuilder.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="catVo"></param>
        /// <returns></returns>
        public static String prepareFileLines(CategoryVo catVo)
        {
            if (catVo.ListSavedFiles == null || catVo.ListSavedFiles.Count <= 0)
            {
                return null;
            }
            String strHeading = OsifyConstants.DB_INIT_PARENT;
            if (catVo.CategoryParent != null && catVo.CategoryParent != "")
            {
                strHeading = OsifyConstants.DB_INIT_CHILD;
            }

            StringBuilder strBuilder = new StringBuilder();
            foreach (FileVo fileVo in catVo.ListSavedFiles)
            {
                strBuilder.Append(strHeading).Append(OsifyConstants.DB_SEPARATOR)
                    .Append(fileVo.ToString()).Append("\r\n");
            }

            return strBuilder.ToString();
        }

    }
}
