using Syncfusion.GridHelperClasses;
using Syncfusion.Windows.Forms.Grid.Grouping;
using VastGIS.Common.Plugins.Interfaces;
using VastGIS.Common.Plugins.Mvp;
using VastGIS.Common.UI.Forms;
using VastGIS.Common.UI.Helpers;
using VastGIS.RealEstateDB.Menu;
using VastGIS.RealEstateDB.Views;
using VastGIS.RealEstateDB.Views.Abstract;

namespace VastGIS.RealEstateDB
{
    internal static class CompositionRoot
    {
        public static void Compose(IApplicationContainer container)
        {
            container.RegisterSingleton<IMainView, NewMainView>()
                .RegisterSingleton<IAppContext, AppContext>()
                .RegisterView<IAboutView, AboutView>()
                .RegisterView<IWelcomeView, WelcomeView>()
                .RegisterView<IConfigView, ConfigView>()
                .RegisterSingleton<IAppView, AppView>()
                .RegisterInstance<IApplicationContainer>(container)
             
                .RegisterService<ContextMenuView>()
                .RegisterService<ContextMenuPresenter>();
            
            Common.Services.CompositionRoot.Compose(container);
            Common.Plugins.CompositionRoot.Compose(container);
            Common.UI.CompositionRoot.Compose(container);
        


            CommandBarHelper.InitMenuColors();

            GridEngineFactory.Factory = new AllowResizingIndividualRows();
        }
    }
}
