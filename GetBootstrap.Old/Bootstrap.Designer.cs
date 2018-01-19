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
        internal static void SetConsoleAppearance(BootstrapTheme theme = BootstrapTheme.LigthColor, BootstrapType type = BootstrapType.Default, BootsrapStyle style = BootsrapStyle.Text)
        {
            string descTheme = GetDescription(theme);
            string descType = GetDescription(type);

            string fgColor = (theme != BootstrapTheme.LigthColor ? descType : $"Dark{descType}");
            string bgColor = (theme != BootstrapTheme.LigthColor ? $"Dark{descType}" : descType);

            if (style == BootsrapStyle.Text)
            {
                fgColor = (theme != BootstrapTheme.LigthColor ? $"Dark{descType}" : descType);
            }

            Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), fgColor, true);
            Console.BackgroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), (style != BootsrapStyle.Text ? bgColor : "Black"), true);
        }
        
        internal static string GetDescription<T>(this T enumerationValue)
          where T : struct
        {
            var type = enumerationValue.GetType();
            if (!type.IsEnum)
            {
                throw new ArgumentException($"{nameof(enumerationValue)} must be of Enum type", nameof(enumerationValue));
            }
            var memberInfo = type.GetMember(enumerationValue.ToString());
            if (memberInfo.Length > 0)
            {
                var attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }
            return enumerationValue.ToString();
        }
    }

    public enum BootsrapStyle
    {
        Text,
        Alert
    }

    public enum BootstrapType
    {
        [Description("Gray")]
        Default,
        [Description("Green")]
        Success,
        [Description("Cyan")]
        Info,
        [Description("Yellow")]
        Warning,
        [Description("Red")]
        Danger,
        [Description("Magenta")]
        Magenta,
        [Description("Blue")]
        Cobalt
    }

    public enum BootstrapTheme
    {
        [Description("Dark")]
        DarkColor,
        LigthColor
    }
}
