using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VastGIS.Common.Plugins.Mvp;

namespace VastGIS.Common.Plugins.Interfaces
{
    public interface IAppView
    {
        bool ShowChildView(Form form, bool modal = true);
        bool ShowChildView(Form form, IWin32Window parent, bool modal = true);
        void Update(bool focusMap = true);
        IWin32Window MainForm { get; }
        void Lock();
        void Unlock();
    }
}
