using System;
using System.Collections.Generic;
using System.Customization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.Extensions
{
    public class Typewriter : Bootstrap
    {
        private static Random _random = new Random();
        private static int _minDelay = 50;
        private static int _maxDelay = 150;

        public Typewriter(int minDelay, int maxDelay)
        {
            _random.Next(minDelay, maxDelay);
            _minDelay = minDelay;
            _maxDelay = maxDelay;
        }

        internal new static BootstrapType ConsoleWriter(string format, BootstrapType type, BootstrapStyle style, bool fillLineBackground)
        {
            Customize.SetBufferAppearance(BootstrapTheme, type, style, fillLineBackground);

            char[] chars = format.ToCharArray();

            lock (Threads)
            {
                for (int i = 0; i < chars.Length; i++)
                {
                    Console.Write(chars[i]);
                    Thread.Sleep(_random.Next(_minDelay, _maxDelay));
                }
                Console.ResetColor();
            }
            return type;
        }

        public new static void Write(string format, BootstrapType type = BootstrapType.Default, BootstrapStyle style = BootstrapStyle.Text, bool fillLineBackground = false)
        {
            ConsoleWriter(format, type, style, fillLineBackground);
        }

        public new static void WriteLine(string format = "", BootstrapType type = BootstrapType.Default, BootstrapStyle style = BootstrapStyle.Text, bool fillLineBackground = false)
        {
            ConsoleWriter(format, type, style, fillLineBackground);
            Console.WriteLine();
        }

        public override BootstrapType Debug(string format)
        {
            return ConsoleWriter(format, BootstrapType.Default, BootstrapStyle.Text, false);
        }

        public override BootstrapType Pass(string format)
        {
            return ConsoleWriter(format, BootstrapType.Success, BootstrapStyle.Text, false);
        }

        public override BootstrapType Info(string format)
        {
            return ConsoleWriter(format, BootstrapType.Info, BootstrapStyle.Text, false);
        }

        public override BootstrapType Warn(string format)
        {
            return ConsoleWriter(format, BootstrapType.Warning, BootstrapStyle.Text, false);
        }

        public override BootstrapType Fatal(string format)
        {
            return ConsoleWriter(format, BootstrapType.Danger, BootstrapStyle.Text, false);
        }

        public override BootstrapType Magenta(string format)
        {
            return ConsoleWriter(format, BootstrapType.Magenta, BootstrapStyle.Text, false);
        }

        public override BootstrapType Cobalt(string format)
        {
            return ConsoleWriter(format, BootstrapType.Cobalt, BootstrapStyle.Text, false);
        }
    }
}
