using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VastGIS.Common.Plugins.Mvp
{
    public abstract class SubViewBase<TModel> : UserControl
    {
        public TModel Model { get; private set; }

        public void Initialize(TModel model)
        {
            if (model == null) throw new ArgumentNullException("model");
            Model = model;

            var subView = this as ISubView;
            if (subView != null)
            {
                subView.Initialize();
            }
        }
    }
}
