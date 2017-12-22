using System;
using System.Windows.Forms;
using VastGIS.Common.Api.Enums;
using VastGIS.Common.Plugins.Interfaces;
using VastGIS.Common.Plugins.Mvp;
using VastGIS.Common.Plugins.Services;
using VastGIS.RealEstateDB.Views;


namespace VastGIS.RealEstateDB.Menu
{
    public class ContextMenuPresenter : CommandDispatcher<ContextMenuView, ContextMenuCommand>
    {
        private readonly IAppContext _context;
        private readonly IConfigService _configService;

        public ContextMenuPresenter(IAppContext context, ContextMenuView view, IConfigService configService)
            :base(view)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (configService == null) throw new ArgumentNullException("configService");

            _context = context;
            _configService = configService;
        }

      

        public override void RunCommand(ContextMenuCommand command)
        {
           

        }

        private bool HandleZoomingCommand(ContextMenuCommand command)
        {
            switch (command)
            {
               
            }

            return false;
        }

      
    }
}
