using System;
using System.Collections.Generic;
using System.Customization;
using System.Interfaces;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace System.Extensions
{
    public class Logger : Bootstrap
    {
        private LoggerXmlFile _loggerXmlFile;

        public Logger(string name, string path, string filename)
        {
            _loggerXmlFile = new LoggerXmlFile(name, path, filename);
        }

        public static Logger GetLogger(string name, string path = "logs", string filename = "log.xml")
        {
            return new Logger(name, path, filename);
        }
        
        public void Log(string format)
        {
            _loggerXmlFile.XmlWrite(DateTime.Now, "LOGGER", format);
        }

        public BootstrapType Log(string format, BootstrapType type)
        {
            _loggerXmlFile.XmlWrite(DateTime.Now, EnumExtension.GetDescription(type), format);
            return type;
        }

        public override BootstrapType Debug(string format)
        {
            return Log(format, base.Debug(format));
        }

        public override BootstrapType Pass(string format)
        {
            return Log(format, base.Pass(format));
        }

        public override BootstrapType Info(string format)
        {
            return Log(format, base.Info(format));
        }

        public override BootstrapType Warn(string format)
        {
            return Log(format, base.Warn(format));
        }

        public override BootstrapType Fatal(string format)
        {
            return Log(format, base.Fatal(format));
        }

        public override BootstrapType Magenta(string format)
        {
            return Log(format, base.Magenta(format));
        }

        public override BootstrapType Cobalt(string format)
        {
            return Log(format, base.Cobalt(format));
        }
    }
}
