using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ViewAPI
{
    public static class Configs
    {
        public static string GetConfig(string key)
        {
            return System.Configuration.ConfigurationManager.AppSettings[key];
        }
        public static string ApiPassword
        {
            get
            {
                return GetConfig("ApiPassword");
            }
        }
        public static string DBConnection
        {
            get
            {
                return GetConfig("DBConnection");
            }
        }
        public static string DBADAccount
        {
            get { return GetConfig("DBADAccount"); }
        }
        public static string DBADPasswrod
        {
            get { return GetConfig("DBADPasswrod"); }
        }

        public static string DBIP { get { return GetConfig("DBIP"); } }
    }
}