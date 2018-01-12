using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.Extensions
{
    public static partial class Typewriter
    {
        private static Random _random = new Random();
        private static int _maxDelay = 150;
        private static int _minDelay = 0;
        
        static void Writer(string format, BootstrapType type = BootstrapType.Default, BootsrapStyle style = BootsrapStyle.Text, bool fill = false, bool beep = false)
        {
            Bootstrap.PerformBeep(beep);

            Bootstrap.SetConsoleAppearance(Bootstrap.Theme, type, style);

            Bootstrap.FillLine(fill);

            char[] chars = format.ToCharArray();

            lock(Bootstrap._threads)
            {
                for (int i = 0; i < chars.Length; i++)
                {
                    Thread.Sleep(_random.Next(_minDelay, _maxDelay));
                    Console.Write(chars[i]);
                }
            }

            Console.ResetColor();
        }
    }
}
