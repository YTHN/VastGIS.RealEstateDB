using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VastGIS.Common.Plugins.Interfaces;
using VastGIS.Common.Plugins.Mvp;
using Syncfusion.Windows.Forms;

namespace VastGIS.Common.UI.Forms
{
    public class MapWindowView<TModel> : VGWindowView, IViewInternal<TModel>
    {
        protected TModel _model;

        public void InitInternal(TModel model)
        {
            _model = model;
        }

        public TModel Model
        {
            get { return _model; }
        }
    }
}
