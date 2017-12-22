using System.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;
using VastGIS.Common.Plugins.Interfaces;

namespace VastGIS.Common.UI.Menu.Ribbon
{
    interface IRibbonMenuBase
    {

        IRibbonHeader Header { get; }
        Syncfusion.Windows.Forms.Tools.RibbonControlAdv RibbonControl { get; }

        ToolStripButton AddButton(IMenuItem menuItem);

        ToolStripTabItem AddHeaderTab(string name, string caption);

        ToolStripEx AddToolStripEx(string name, string caption, string headerName);

        ToolStripComboBoxEx AddComboBox(IMenuItem menuItem);

        ToolStripDropDownButton AddDropDownButton(IMenuItem menuItem);

        ToolStripLabel AddLabel(IMenuItem menuItem);
    }
}