using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VastGIS.Common.Plugins.Events;

namespace VastGIS.Common.Services.Serialization
{
    public interface IProjectLoaderBase
    {
        event System.EventHandler<ProgressEventArgs> ProgressChanged;
    }

    public interface IProjectLoader : IProjectLoaderBase
    {
        bool Restore(XmlProject project);
    }
}
