using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VastGIS.Common.Shared;
using Syncfusion.GridHelperClasses;
using Syncfusion.Windows.Forms.Grid;

namespace VastGIS.Common.UI.Controls
{
    public class LinkLabelCellRendererEx: LinkLabelCellRenderer
    {
        public LinkLabelCellRendererEx(GridControlBase grid, GridCellModelBase cellModel) : base(grid, cellModel)
        {
        }

        protected override void LaunchBrowser(GridStyleInfo style)
        {
            string url = style.Tag as string;

            PathHelper.OpenUrl(url);
        }
    }
}
