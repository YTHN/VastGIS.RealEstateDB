using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VastGIS.Common.Api;
using VastGIS.Common.Api.Enums;
using VastGIS.Common.Api.Helpers;
using VastGIS.Common.Plugins.Interfaces;
using VastGIS.Common.Plugins.Mvp;
using VastGIS.Common.Services.Views.Abstract;
using VastGIS.Common.UI;
using VastGIS.Common.UI.Forms;
using VastGIS.Common.UI.Helpers;
using Syncfusion.Windows.Forms;

namespace VastGIS.Common.Services.Views
{
    public partial class CreateLayerView : CreateLayerViewBase, ICreateLayerView
    {
        private static GeometryType _lastGeometryType = GeometryType.Point;
        private static ZValueType _lastZValue = ZValueType.None;
        private static bool _lastMemoryLayer = false;

        public CreateLayerView()
        {
            InitializeComponent();

            InitControls();

            FormClosing += OnFormClosing;
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            _lastGeometryType = GeometryType;
            _lastZValue = ZValueType;
            _lastMemoryLayer = chkMemoryLayer.Checked;
        }

        private void InitControls()
        {
            var list = new[] { GeometryType.Point, GeometryType.Polyline, GeometryType.Polygon, GeometryType.MultiPoint, };

            _layerTypeComboBox.AddItemsFromEnum(list);
        }

        /// <summary>
        /// Called before view is shown. Allows to initialize UI from this.Model property.
        /// </summary>
        public void Initialize()
        {
            _layerTypeComboBox.SetValue(_lastGeometryType);

            chkMemoryLayer.Checked = _lastMemoryLayer;

            switch (_lastZValue)
            {
                case ZValueType.None:
                    opt2D.Checked = true;
                    break;
                case ZValueType.M:
                    optM.Checked = true;
                    break;
                case ZValueType.Z:
                    optZ.Checked = true;
                    break;
            }
        }

        public ButtonBase OkButton
        {
            get { return _okButton; }
        }

        public bool MemoryLayer
        {
            get { return chkMemoryLayer.Checked; }
        }

        public string LayerName
        {
            get { return _layerNameTextbox.Text; }
            set { _layerNameTextbox.Text = value; }
        }

        public GeometryType GeometryType
        {
            get { return _layerTypeComboBox.GetValue<GeometryType>(); }
            set { _layerTypeComboBox.SetValue(value); }
        }

        public ZValueType ZValueType
        {
            get
            {
                if (optM.Checked)
                {
                    return ZValueType.M;
                }
                if (optZ.Checked)
                {
                    return ZValueType.Z;
                }
                return ZValueType.None;
            }
            set
            {
                switch (value)
                {
                    case ZValueType.M:
                        optM.Checked = true;
                        break;
                    case ZValueType.Z:
                        optZ.Checked = true;
                        break;
                    case ZValueType.None:
                        opt2D.Checked = true;
                        break;
                }
            }
        }
    }

    public class CreateLayerViewBase : MapWindowView<CreateLayerModel> { }
}
