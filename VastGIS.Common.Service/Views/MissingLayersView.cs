using System.Collections.Generic;
using System.Windows.Forms;
using VastGIS.Common.Plugins.Mvp;
using VastGIS.Common.Services.Controls;
using VastGIS.Common.Services.Views.Abstract;
using VastGIS.Common.UI.Forms;

namespace VastGIS.Common.Services.Views
{
    public partial class MissingLayersView : MissingLayersViewBase, IMissingLayersView
    {
        public MissingLayersView()
        {
            InitializeComponent();
        }

        public override ViewStyle Style
        {
            get
            {
                return new ViewStyle()
                {
                    Modal = true,
                    Sizable = true
                };
            }   
        }

        public void Initialize()
        {
            missingLayersGrid1.DataSource = Model;
        }

        public ButtonBase OkButton
        {
            get { return btnOk; }
        }
    }

    public class MissingLayersViewBase: MapWindowView<List<MissingLayer>> { }
}
