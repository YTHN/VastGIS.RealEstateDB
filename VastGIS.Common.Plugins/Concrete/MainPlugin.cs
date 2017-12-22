using VastGIS.Common.Plugins.Interfaces;
using VastGIS.Common.Plugins.Mvp;

namespace VastGIS.Common.Plugins.Concrete
{
    /// <summary>
    /// A consumer of plugin events for the main application. Isn't added to the list of plugins.
    /// </summary>
    public class MainPlugin: BasePlugin
    {
        public MainPlugin()
        {
            Identity = PluginIdentity.Default;
        }

        public override void Initialize(IAppContext context)
        {
            
        }

        public override void Terminate()
        {
            
        }

        protected override void RegisterServices(IApplicationContainer container)
        {

        }
    }
}
