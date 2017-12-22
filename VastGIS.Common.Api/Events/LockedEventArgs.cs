using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VastGIS.Common.Api.Events
{
    public class LockedEventArgs: EventArgs
    {
        public LockedEventArgs(bool locked)
        {
            Locked = locked;
        }

        public bool Locked { get; set; }
    }

    public class SingleTargetEventArgs : EventArgs
    {
        public bool Handled { get; set; }
    }
}
