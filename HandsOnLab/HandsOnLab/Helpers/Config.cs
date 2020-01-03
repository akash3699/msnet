using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
namespace DemoMVC.Helpers
{
    public class Config
    {
        public static string LogFile
        {
            get
            {
                return ConfigurationManager.AppSettings["logFile"].ToString();
            }
        }

        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.AppSettings["Connection"].ToString();
            }
        }
    }
}