using System;
using System.Collections.Generic;
using System.Extensions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Customization
{
    internal static class Customize
    {
        internal static void SetBufferAppearance(BootstrapTheme theme, BootstrapType type, BootstrapStyle style, bool fillLineBackground)
        {
            lock (Bootstrap.Threads)
            {
                string descTheme = EnumExtension.GetDescription(theme);
                string descType = EnumExtension.GetDescription(type);

                string fgColor = (theme != BootstrapTheme.LigthColor ? descType : $"Dark{descType}");
                string bgColor = (theme != BootstrapTheme.LigthColor ? $"Dark{descType}" : descType);

                if (style == BootstrapStyle.Text)
                {
                    fgColor = (theme != BootstrapTheme.LigthColor ? $"Dark{descType}" : descType);
                }

                Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), fgColor, true);
                Console.BackgroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), (style != BootstrapStyle.Text ? bgColor : "Black"), true);
            }

            FillLineBackground(fillLineBackground);
        }

        static void FillLineBackground(bool fill)
        {
            if (fill)
            {
                lock (Bootstrap.Threads)
                {
                    int cursorLeft = Console.CursorLeft;
                    int cursorTop = Console.CursorTop;
                    int fillWidth = Console.BufferWidth - cursorLeft;

                    StringBuilder background = new StringBuilder();
                    for (int i = 0; i < fillWidth; i++)
                    {
                        background.Append(" ");
                    }

                    Console.Write(background);

                    Console.CursorTop = cursorTop;
                    Console.CursorLeft = cursorLeft;
                }
            }
        }

    }
}
