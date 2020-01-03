using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace DemoMVC.Helpers
{
    public class Logger
    {
        private static Logger _logger = new Logger();
        FileStream fs = null;
        StreamWriter writer = null;
        private Logger(){}
        public static Logger CurrentLogger
        {
            get { return _logger; }
        }

        public void Log(string msg)
        {
            if (File.Exists(Config.LogFile))
            {
                fs = new FileStream(Config.LogFile, FileMode.Append, FileAccess.Write);
            }
            else
            {
                fs = new FileStream(Config.LogFile, FileMode.Create, FileAccess.Write);
            }
            writer = new StreamWriter(fs);

            writer.WriteLine(string.Format("Logged at {0} : {1}", DateTime.Now.ToString(), msg));
            writer.Close();
            fs.Close();
            writer = null;
            fs = null;
        }
    }
}