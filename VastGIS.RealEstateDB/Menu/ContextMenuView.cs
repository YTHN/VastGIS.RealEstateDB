using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using VastGIS.Common.Api.Enums;
using VastGIS.Common.Plugins.Interfaces;
using VastGIS.Common.Plugins.Mvp;


namespace VastGIS.RealEstateDB.Menu
{
    public partial class ContextMenuView : UserControl, IMenuProvider
    {
        private readonly IAppContext _context;

        public ContextMenuView(IAppContext context)
        {
            if (context == null) throw new ArgumentNullException("context");

            _context = context;

            InitializeComponent();

         
        }

   
        public IEnumerable<ToolStripItemCollection> ToolStrips
        {
            get
            {
                yield return contextMeasuring.Items;
                yield return contextZooming.Items;
            }
        }

        public IEnumerable<Control> Buttons
        {
            get { yield break; }
        }

      

       

    

     
    }
}
