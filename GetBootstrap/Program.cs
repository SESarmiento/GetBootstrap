using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Extensions;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    class Program
    {
        static void Main()
        {
            Version buildver = Assembly.GetEntryAssembly().GetName().Version;
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string releasever = fvi.FileVersion;

            Console.Title = "GetBootstrap";

            Bootstrap bootstrap = new Bootstrap();
            bootstrap.Warn("Hello, World");
            Bootstrap.Write("Hello, World");
            Typewriter.Write("Test");
            Console.Read();
        }
    }
}
