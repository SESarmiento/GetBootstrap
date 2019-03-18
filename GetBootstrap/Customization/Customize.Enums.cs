using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Customization
{
    public enum BootstrapStyle
    {
        Text,
        Alert
    }

    public enum BootstrapTheme
    {
        [Description("Dark")]
        DarkColor,
        LigthColor
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
}
