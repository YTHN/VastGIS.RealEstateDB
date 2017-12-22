using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VastGIS.Common.Plugins.Concrete;
using VastGIS.Common.Plugins.Interfaces;
using VastGIS.Common.Plugins.Services;

namespace VastGIS.Common.Plugins.Mvp
{
    public abstract class CommandDispatcher<TView, TCommand>: CommandDispatcher<TCommand>
        where TCommand : struct, IConvertible
    {
        public TView View { get; private set; }

        protected CommandDispatcher(TView view)
        {
            View = view;
            WireUpMenus(view as Control);
        }
    }
}
