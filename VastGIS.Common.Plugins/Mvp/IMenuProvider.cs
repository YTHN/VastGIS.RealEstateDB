using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VastGIS.Common.Plugins.Interfaces;

namespace VastGIS.Common.Plugins.Mvp
{
    public interface IMenuProvider
    {
        IEnumerable<ToolStripItemCollection> ToolStrips { get; }
        IEnumerable<Control> Buttons { get; }
    }
}
