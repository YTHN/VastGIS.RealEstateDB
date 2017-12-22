using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VastGIS.Common.Plugins.Events
{
    public class StringValueChangedEventArgs: EventArgs
    {
        public StringValueChangedEventArgs(string newValue)
        {
            NewValue = newValue;
        }

        public string NewValue { get; private set; }
    }
}
