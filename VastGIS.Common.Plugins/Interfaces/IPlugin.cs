using System;
using VastGIS.Common.Plugins.Mvp;

namespace VastGIS.Common.Plugins.Interfaces
{
    public interface IPlugin
    {
        string Description { get; }

        void Initialize(IAppContext context);

        void Terminate();
    }
}
