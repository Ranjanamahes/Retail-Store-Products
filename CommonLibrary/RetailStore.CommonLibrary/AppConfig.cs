using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace RetailStore.CommonLibrary
{
    public class AppConfig
    {
        public static string ErrorLogPath
        {
            get
            {
                return ConfigurationManager.AppSettings["ErrorLogPath"];
            }
        }

        public static string ErrorLogFile
        {
            get
            {
                return ConfigurationManager.AppSettings["LogFileName"];
            }
        }
        public static string RetailStoreWebAPI
        {
            get
            {
                return ConfigurationManager.AppSettings["RetailStoreWebAPIHostAddress"];
            }
        }
    }
}
