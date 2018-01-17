using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Extensions;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GetBootstrap
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;

            Console.Title = $"GetBootstrap v{version}";
            Bootstrap.Logger = Logger.GetLogger("GetBootstrap");
            Bootstrap.Write("DEVELOPER:", BootstrapType.Info, BootsrapStyle.Alert);
            Bootstrap.Write( " Leonel Sarmiento - ");
            Bootstrap.WriteLine("Leonel.Sarmiento@outlook.com", BootstrapType.Success);
            Bootstrap.Write("BOOTSTRAP:", BootstrapType.Magenta, BootsrapStyle.Alert);
            Bootstrap.WriteLine($" Build {Assembly.GetEntryAssembly().GetName().Version}");
            Bootstrap.Write("BOOTSTRAP:", BootstrapType.Magenta, BootsrapStyle.Alert);
            Bootstrap.WriteLine($" Release {version}");
            Console.ReadKey();
            
            Bootstrap.WriteLine("Customize Progress Bar", type: BootstrapType.Info);

            ProgressBar pb = new ProgressBar(Enum.GetNames(typeof(BootstrapType)).Length * 3);
            pb.Width = 50;
            pb.WriteLine();
            
            ProgressBar pb1 = new ProgressBar(Enum.GetNames(typeof(BootstrapType)).Length * 2);
            pb1.ProgressColor = ConsoleColor.DarkBlue;
            pb1.Width = 75;
            pb1.WriteLine();

            ProgressBar pb2 = new ProgressBar(Enum.GetNames(typeof(BootstrapType)).Length * 1);
            pb2.ProgressColor = ConsoleColor.DarkMagenta;
            pb2.Width = 100;
            pb2.WriteLine();

            Bootstrap.WriteLine("Adjustable Typewriter Speed", type: BootstrapType.Info);

            foreach (var name in Enum.GetNames(typeof(BootstrapType)))
            {
                pb.Increment();
                pb1.Increment();
                pb2.Increment();
                Typewriter.WriteLine($"{name}", style: BootsrapStyle.Alert, type: (BootstrapType)Enum.Parse(typeof(BootstrapType), name), fill: true);
            }

            Bootstrap.WriteLine("Light and Dark Themes", type: BootstrapType.Info);

            foreach (var name in Enum.GetNames(typeof(BootstrapType)))
            {
                pb.Increment();
                pb1.Increment();
                Typewriter.Write($"{name}", style: BootsrapStyle.Alert, type: (BootstrapType)Enum.Parse(typeof(BootstrapType), name), fill: true);
            }

            Console.WriteLine();

            foreach (var name in Enum.GetNames(typeof(BootstrapType)))
            {
                pb.Increment();
                Bootstrap.Write($"{name}", type: (BootstrapType)Enum.Parse(typeof(BootstrapType), name));
            }
            Console.ReadLine();
        }
    }
}
