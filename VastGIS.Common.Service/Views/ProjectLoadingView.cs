using System.IO;
using System.Windows.Forms;
using VastGIS.Common.UI.Forms;

namespace VastGIS.Common.Services.Views
{
    public partial class ProjectLoadingView : VGWindowView
    {
        public ProjectLoadingView()
        {
            InitializeComponent();
        }

        public ProjectLoadingView(string projectName)
        {
            InitializeComponent();

            Text = "Loading project: " + Path.GetFileNameWithoutExtension(projectName);
        }

        public override Plugins.Mvp.ViewStyle Style
        {
            get { return new Plugins.Mvp.ViewStyle() { Modal = false, Sizable = false }; }
        }

        public void ShowProgress(int percent, string message)
        {
            if (percent < 0) percent = 0;
            if (percent > 100) percent = 100;

            progressBarAdv1.Value = percent;
            progressBarAdv1.Refresh();

            lblMessage.Text = message;
            lblMessage.Refresh();

            Application.DoEvents();
        }
    }
}
