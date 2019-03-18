using System;
using System.Collections.Generic;
using System.Customization;
using System.Diagnostics;
using System.Extensions;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System
{
    class Program
    {
        private static Random _random;
        private static int _rank = 1;

        static void Main()
        {
            Version buildver = Assembly.GetEntryAssembly().GetName().Version;
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string releasever = fvi.FileVersion;

            Console.Title = $"GetBootstrap";
            Bootstrap.Write("DEVELOPER:", BootstrapType.Info, BootstrapStyle.Alert);
            Bootstrap.Write(" Leonel Sarmiento - ");
            Bootstrap.WriteLine("leonel.sarmiento@outlook.com", BootstrapType.Success);
            Bootstrap.Write("BOOTSTRAP:", BootstrapType.Magenta, BootstrapStyle.Alert);
            Bootstrap.WriteLine($" Build {buildver}");
            Bootstrap.Write("BOOTSTRAP:", BootstrapType.Magenta, BootstrapStyle.Alert);
            Bootstrap.WriteLine($" Release {releasever}");
            Console.ReadKey();

            Bootstrap.WriteLine("The Cyber Horse Race ~ 2018 ~ ");
            _random = new Random();
            float km = 1;
            foreach (var color in Enum.GetNames(typeof(ConsoleColor)).Where(c => c != "Gray").OrderByDescending(c => c))
            {
                ProgressBarTest(new ProgressBar() { MaxValue = (int)(3600 * km), ProgressColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), color) });
            }
            Console.Read();
        }

        private static void ProgressBarTest(ProgressBar pb)
        {
            pb.DisplayPercentage = true;
            pb.DisplaySeparator = true;
            pb.Width = 100;
            pb.DrawProgressBar();
            int sanity = 100;
            int tired = 1000;
            new Thread(() => {
                do
                {
                    // whip hit
                    int hit = _random.Next(0, 10);
                    // horse mps
                    pb.Value += _random.Next(11, 21) + (hit * 7);
                    // second
                    Thread.Sleep(tired - sanity);


                    if (sanity <= 0)
                    {
                        if (tired <= 1000)
                        {
                            new Bootstrap().Fatal($"Horse Exhausted:{Enum.GetName(typeof(ConsoleColor), pb.ProgressColor)}\n");
                        }
                        tired += (hit + 1) * 2;
                    }
                    else
                    {
                        sanity -= _random.Next(0, hit);
                        sanity += _random.Next(0, 2);
                    }

                    if (pb.Value >= pb.MaxValue)
                    {
                        pb.Value = pb.MaxValue;
                    }
                } while (pb.Value < pb.MaxValue);

                lock (Bootstrap.Threads)
                {
                    Console.WriteLine($"RANK {_rank}:{Enum.GetName(typeof(ConsoleColor), pb.ProgressColor)}");
                }
                _rank++;
            }).Start();
        }
    }
}
