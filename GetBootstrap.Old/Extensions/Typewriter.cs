﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Extensions
{
    public static partial class Typewriter
    {
        public static void SetDelay(int max, int min = 0)
        {
            if (min > max)
            {
                throw new ArgumentOutOfRangeException("'min' should not be greater than 'max' value.");
            }

            if (min < 0)
            {
                throw new ArgumentOutOfRangeException("'min' should not be less than to 0.");
            }

            _maxDelay = max;
            _minDelay = min;
        }
        
        public static void Write(string format, BootstrapType type = BootstrapType.Default, BootsrapStyle style = BootsrapStyle.Text, bool fill = false, bool beep = false)
        {
            Writer(format, type, style, fill, beep);
        }

        public static void WriteLine(string format, BootstrapType type = BootstrapType.Default, BootsrapStyle style = BootsrapStyle.Text, bool fill = false, bool beep = false)
        {
            Writer(format, type, style, fill, beep);
            Console.WriteLine();
        }
    }
}
