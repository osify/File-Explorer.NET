using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace osi_explorer_searcher.core.constant
{
    public class OsifyConstants
    {
        // main label
        public static String MAIN_PLAYLIST = "Collection";
        public static String APP_CONFIG_FILE = Application.StartupPath + "/application-config.properties";
        public static String APP_RELEASE_FILE = Application.StartupPath + "/RELEASE";

        public static String GLOBAL_DB_AT_STARTUP = "global.db_at_startup";
        public static String GLOBAL_DB_PATH = "global.db_path";

        // path
        public static String DB_INIT_PATH = "/db/";
        public static String DB_INIT_PATH_SUB = "sub/";
        public static String DB_DEFAULT_PATH = Application.StartupPath + DB_INIT_PATH;

        public static String DB_ASSIGN_PATH = Application.StartupPath;

        // db files
        public static String DB_MAIN_FILE = "categories.csv";
        public static String DB_DEFAULT_MAIN_FILE = DB_DEFAULT_PATH + DB_MAIN_FILE;
        public static String DB_SEPARATOR = ";";

        // notice on db content
        public static String DB_INIT_PARENT = "MAIN";
        public static String DB_INIT_CHILD = "SUB";
        public static String DB_INIT_CATEGORY = "CATEGORY";
        public static String DB_INIT_FILE = "FILE";

        // size unit
        public const String KB = "KB";
        public const String BYT = "BYT";
        public const String MB = "MB";
        public const String GB = "GB";
        public const String TB = "TB";
    }
}
