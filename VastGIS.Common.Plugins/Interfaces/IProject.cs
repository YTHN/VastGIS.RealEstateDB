using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VastGIS.Common.Plugins.Interfaces
{
    public interface IProject
    {
        void SetModified();
        bool Modified { get; }
        string Filename { get; }
        bool IsEmpty { get; }
    }
}
