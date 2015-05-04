using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using osi_explorer_searcher.core.constant;

namespace osi_explorer_searcher.core.vo
{
    class FileVo : IData
    {
        private String _categoryName;
        private Boolean _isParent;
        private String _categoryParentName;
        private String _path;
        private Boolean _isFolder;

        public Boolean IsParent
        {
            get { return this._isParent; }
            set { this._isParent = value; }
        }

        public Boolean IsFolder
        {
            get { return this._isFolder; }
            set { this._isFolder = value; }
        }
        public String CategoryParentName
        {
            get { return this._categoryParentName; }
            set { this._categoryParentName = value; }
        }

        public String CategoryName
        {
            get { return this._categoryName; }
            set { this._categoryName = value; }
        }

        public String Path
        {
            get { return this._path; }
            set { this._path = value; }
        }
        /// <summary>
        /// SUB(or MAIN);FILE;CategoryName;path
        /// </summary>
        /// <returns></returns>
        public String toString()
        {
            StringBuilder strBuilder = new StringBuilder();
            if (this._isParent)
            {
                strBuilder.Append(OsifyConstants.DB_INIT_PARENT).Append(OsifyConstants.DB_SEPARATOR);
            }
            else
            {
                strBuilder.Append(OsifyConstants.DB_INIT_CHILD).Append(OsifyConstants.DB_SEPARATOR);
            }
            strBuilder.Append(OsifyConstants.DB_INIT_FILE).Append(OsifyConstants.DB_SEPARATOR)                
                .Append(this._categoryName).Append(OsifyConstants.DB_SEPARATOR)
                .Append(this._path).Append(OsifyConstants.DB_SEPARATOR)
                .Append(this._categoryParentName).Append(OsifyConstants.DB_SEPARATOR);
            if (this._isFolder)
            {
                strBuilder.Append(1);
            }
            else
            {
                strBuilder.Append(0);
            }
            return strBuilder.ToString();
        }
    }
}
