using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static partial class Bootstrap
    {
        public static BootstrapTheme Theme { get => _theme; set => _theme = value; }

        public static int BeepDuration
        {
            get => _duration;
            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("Beep duration must not be less than to 1.");
                }
                else
                {
                    _duration = value;
                }
            }
        }

        public static int BeepFrequency
        {
            get => _frequency;
            set
            {
                if (value < 37 || value > 32767)
                {
                    throw new ArgumentOutOfRangeException("Beep frequency must not less than to 73 nor greater than to 32767.");
                }
                else
                {
                    _frequency = value;
                }
            }
        }

        public static void Write(string format, BootstrapType type = BootstrapType.Default, BootsrapStyle style = BootsrapStyle.Text, bool fill = false, bool beep = true)
        {
            Writer(format, type, style, fill, beep);
        }

        public static void WriteLine(string format, BootstrapType type = BootstrapType.Default, BootsrapStyle style = BootsrapStyle.Text, bool fill = false, bool beep = true)
        {
            Writer(format, type, style, fill, beep);
            Console.WriteLine();
        }
    }
}
