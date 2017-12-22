using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VastGIS.Common.Plugins.Events;

namespace VastGIS.Common.Plugins.Interfaces
{
    public interface IComboBoxMenuItem: IMenuItem
    {
        StringCollection DataSource { get; }
        int Width { get; set; }
        event EventHandler<StringValueChangedEventArgs> ValueChanged;
        void Focus();
    }
}
