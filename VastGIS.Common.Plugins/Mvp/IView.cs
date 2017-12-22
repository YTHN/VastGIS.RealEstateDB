using System;
using System.Collections.Generic;
using System.Windows.Forms;
using VastGIS.Common.Plugins.Interfaces;

namespace VastGIS.Common.Plugins.Mvp
{
    public interface IView : IViewInternal
    {
        ButtonBase OkButton { get; }

        void StartWait();

        void StopWait();

        Form AsForm { get; }
    }

    public interface IView<TModel> : IView, IViewInternal<TModel>
    {
        /// <summary>
        /// Called before view is shown. Allows to initialize UI from this.Model property.
        /// </summary>
        void Initialize();
    }
}
