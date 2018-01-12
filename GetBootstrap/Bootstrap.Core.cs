using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static partial class Bootstrap
    {
        private static BootstrapTheme _theme;
        private static int _frequency = 800;
        private static int _duration = 100;
        internal static object[] _threads = new object[] { };

        static void Writer(string format, BootstrapType type = BootstrapType.Default, BootsrapStyle style = BootsrapStyle.Text, bool fill = false, bool beep = false)
        {
            PerformBeep(beep);

            SetConsoleAppearance(Theme, type, style);

            FillLine(fill);

            char[] chars = format.ToCharArray();

            lock(_threads)
            {
                for (int i = 0; i < chars.Length; i++)
                {
                    Console.Write(chars[i]);
                }
            }

            Console.ResetColor();
        }

        internal static void PerformBeep(bool beep)
        {
            if (beep)
            {
                lock (_threads)
                {
                    Console.Beep(_frequency, _duration);
                }
            }
        }

        internal static void FillLine(bool fill)
        {
            if (fill)
            {
                lock (_threads)
                {
                    int cursorLeft = Console.CursorLeft;
                    int cursorTop = Console.CursorTop;
                    int fillWidth = Console.BufferWidth - cursorLeft;

                    for (int i = 0; i < fillWidth; i++)
                    {
                        Console.Write(" ");
                    }

                    Console.CursorTop = cursorTop;
                    Console.CursorLeft = cursorLeft;
                }
            }
        }
    }
}
