using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace osi_explorer_searcher.core.vo
{
    class PlaylistType
    {
        /// <summary>
        /// 
        /// </summary>
        private static IDictionary _instances = new Dictionary<String, PlaylistType>();

        public static PlaylistType AUDIO = new PlaylistType("AUDIOS", "Audios", "Audio files", 14, 14, "*.mp3;*.wma");
        public static PlaylistType VIDEO = new PlaylistType("VIDEOS", "Videos", "Video files", 10, 11, "*.wmv;*.avi;*.mpg;*.mp4");
        public static PlaylistType IMAGES = new PlaylistType("IMAGES", "Images", "Software", 12, 13, "*");
        public static PlaylistType SOFTWARE = new PlaylistType("SOFTWARE", "Software", "Software", 15, 16, "*");
        public static PlaylistType E_BOOK = new PlaylistType("E-BOOKS", "E-Books", "E-Book documents", 19, 20, "*");
        public static PlaylistType RPORT = new PlaylistType("REPORTS", "Reports", "Report documents", 21, 22, "*");
        public static PlaylistType SPECIAL = new PlaylistType("SPECIAL", "Special", "Special files", 17, 18, "*");
        public static PlaylistType ANY = new PlaylistType("ANY", "Any", "Any files", 23, 23, "*");

        private String _code;
        private String _label;
        private String _description;
        private int _imageIndex = 23;
        private int _selectedImageIndex = 23;
        private String _filter;

        private PlaylistType(String code, String label, String description, int imageIndex, int selectedImageIndex, String filter)
        {
            this._code = code;
            this._label = label;
            this._description = description;
            this._imageIndex = imageIndex;
            this._selectedImageIndex = selectedImageIndex;
            this._filter = filter;

            PlaylistType._instances.Add(this._code, this);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static PlaylistType get(String code)
        {
            return (PlaylistType)PlaylistType._instances[code];
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cbPlaylist"></param>
        public static void buildCombo(ComboBox cbPlaylist) 
        {
            foreach (String myCode in PlaylistType._instances.Keys) {
                //PlaylistType plType = PlaylistType.get(myCode);
                cbPlaylist.Items.Add(myCode);
            }
        }
        
        /// <summary>
        /// Get code
        /// </summary>
        /// <returns></returns>
        public String getCode()
        {
            return this._code;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public String getLabel()
        {
            return this._label;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public String getDescription()
        {
            return this._description;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public String toString()
        {
            return this.getLabel();
        }
        public int getImageIndex()
        {
            return this._imageIndex;
        }
        public int getSelectedImageIndex()
        {
            return this._selectedImageIndex;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public String getFilter()
        {
            return this._filter;
        }

    }
}
