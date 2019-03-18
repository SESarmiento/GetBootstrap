using System;
using System.Collections.Generic;
using System.Customization;
using System.Interfaces;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public class Bootstrap : IBootstrapWriter
    {
        internal static object[] Threads { get; set; } = new object[] { };

        public static BootstrapTheme BootstrapTheme { get; set; } = BootstrapTheme.DarkColor;

        internal static BootstrapType ConsoleWriter(string format, BootstrapType type, BootstrapStyle style, bool fillLineBackground)
        {
            Customize.SetBufferAppearance(BootstrapTheme, type, style, fillLineBackground);

            char[] chars = format.ToCharArray();

            lock (Threads)
            {
                Console.Write(chars);
                Console.ResetColor();
            }
            return type;
        }
        
        public static void Write(string format, BootstrapType type = BootstrapType.Default, BootstrapStyle style = BootstrapStyle.Text, bool fillLineBackground = false)
        {
            ConsoleWriter(format, type, style, fillLineBackground);
        }

        public static void WriteLine(string format = "", BootstrapType type = BootstrapType.Default, BootstrapStyle style = BootstrapStyle.Text, bool fillLineBackground = false)
        {
            ConsoleWriter(format, type, style, fillLineBackground);
            Console.WriteLine();
        }

        public virtual BootstrapType Debug(string format)
        {
            return ConsoleWriter(format, BootstrapType.Default, BootstrapStyle.Text, false);
        }

        public virtual BootstrapType Pass(string format)
        {
            return ConsoleWriter(format, BootstrapType.Success, BootstrapStyle.Text, false);
        }

        public virtual BootstrapType Info(string format)
        {
            return ConsoleWriter(format, BootstrapType.Info, BootstrapStyle.Text, false);
        }

        public virtual BootstrapType Warn(string format)
        {
            return ConsoleWriter(format, BootstrapType.Warning, BootstrapStyle.Text, false);
        }

        public virtual BootstrapType Fatal(string format)
        {
            return ConsoleWriter(format, BootstrapType.Danger, BootstrapStyle.Text, false);
        }

        public virtual BootstrapType Magenta(string format)
        {
            return ConsoleWriter(format, BootstrapType.Magenta, BootstrapStyle.Text, false);
        }

        public virtual BootstrapType Cobalt(string format)
        {
            return ConsoleWriter(format, BootstrapType.Cobalt, BootstrapStyle.Text, false);
        }
    }
}
