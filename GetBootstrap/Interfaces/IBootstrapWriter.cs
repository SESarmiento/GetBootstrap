using System;
using System.Collections.Generic;
using System.Customization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Interfaces
{
    public interface IBootstrapWriter
    {
        BootstrapType Debug(string format);
        BootstrapType Pass(string format);
        BootstrapType Info(string format);
        BootstrapType Warn(string format);
        BootstrapType Fatal(string format);
        BootstrapType Magenta(string format);
        BootstrapType Cobalt(string format);
    }
}
