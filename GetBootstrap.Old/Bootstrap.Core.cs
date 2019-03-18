using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Extensions;
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
        private static Logger _logger;
        internal static object[] _threads = new object[] { };

        private static void Writer(string format, BootstrapType type = BootstrapType.Default, BootsrapStyle style = BootsrapStyle.Text, bool fill = false, bool beep = false)
        {
            PerformBeep(beep);

            SetConsoleAppearance(Theme, type, style);

            FillLine(fill);

            char[] chars = format.ToCharArray();

            lock(_threads)
            {
                WriteLog(type, format);

                for (int i = 0; i < chars.Length; i++)
                {
                    Console.Write(chars[i]);
                }
            }

            Console.ResetColor();
        }

        private static void WriteLog(BootstrapType type, string format)
        {
            if (_logger == null)
            {
                return;
            }

            switch (type)
            {
                case BootstrapType.Success:
                    _logger.Pass(format);
                    break;
                case BootstrapType.Info:
                    _logger.Info(format);
                    break;
                case BootstrapType.Warning:
                    _logger.Warn(format);
                    break;
                case BootstrapType.Danger:
                    _logger.Fatal(format);
                    break;
                case BootstrapType.Magenta:
                    _logger.Magenta(format);
                    break;
                case BootstrapType.Cobalt:
                    _logger.Cobalt(format);
                    break;
                case BootstrapType.Default:
                default:
                    _logger.Debug(format);
                    break;
            }
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
