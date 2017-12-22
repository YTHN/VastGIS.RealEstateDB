using System.Windows.Forms;

namespace VastGIS.Common.UI.Style
{
    public interface IStyleService
    {
        void ApplyStyle(Form form);
        void ApplyStyle(Control control);
    }
}
