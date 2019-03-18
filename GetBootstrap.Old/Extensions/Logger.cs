using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Extensions
{
    public partial class Logger
    {
        public Logger()
        {
            SetLoggerInfo("GetBootstrap");
        }

        public Logger(string name, string dir, string fileName)
        {
            SetLoggerInfo(name, dir, fileName);
        }

        public void Debug(string format)
        {
            WriteLog(DateTime.Now, "DEBUG", format);
        }

        public void Pass(string format)
        {
            WriteLog(DateTime.Now, "PASS", format);
        }

        public void Info(string format)
        {
            WriteLog(DateTime.Now, "INFO", format);
        }

        public void Warn(string format)
        {
            WriteLog(DateTime.Now, "WARN", format);
        }

        public void Fatal(string format)
        {
            WriteLog(DateTime.Now, "FATAL", format);
        }

        public void Magenta(string format)
        {
            WriteLog(DateTime.Now, "MAGENTA", format);
        }

        public void Cobalt(string format)
        {
            WriteLog(DateTime.Now, "COBALT", format);
        }

        public void Write(string level, string format)
        {
            WriteLog(DateTime.Now, level, format);
        }

        public static Logger GetLogger(string name, string dir = "logs", string fileName = "log.xml")
        {
            return new Logger(name, dir, fileName);
        }
    }
}
