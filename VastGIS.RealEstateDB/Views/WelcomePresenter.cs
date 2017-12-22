using System;
using VastGIS.Common.Plugins.Enums;
using VastGIS.Common.Plugins.Mvp;
using VastGIS.Common.Plugins.Services;
using VastGIS.Common.Shared;
using VastGIS.RealEstateDB.Views.Abstract;


namespace VastGIS.RealEstateDB.Views
{
    public class WelcomePresenter : BasePresenter<IWelcomeView, WelcomeViewModel>
    {
    
        private readonly IProjectService _projectService;

        public WelcomePresenter(IWelcomeView view,  IProjectService projectService) : base(view)
        {
          
            if (projectService == null) throw new ArgumentNullException("projectService");
          
            _projectService = projectService;

            view.GettingStartedClicked += () => PathHelper.OpenUrl("http://www.mapwindow.org/documentation/mapwindow5/getting-started.html");
            view.DocumentsClicked += () => PathHelper.OpenUrl("https://mapwindow5.codeplex.com/documentation");
            view.LogoClicked += () => PathHelper.OpenUrl("http://mapwindow5.codeplex.com");
             
          
            view.OpenProjectClicked += OpenProjectClicked;
        }

        public override bool ViewOkClicked()
        {
            return true;
        }

       

        private void OpenProjectClicked()
        {
            if (View.ProjectId >= Model.RecentProjects.Count)
            {
                MessageService.Current.Info("Invalid project reference.");
                return;
            }
            
            if (View.ProjectId == -1)
            {
                // showing file open dialog:
                if (_projectService.Open())
                {
                    View.Close();
                }

                return;    // it was cancelled, let the user go on working with form
            }

            View.Close();

            // recent project
            string path = Model.RecentProjects[View.ProjectId];
            _projectService.Open(path);
        }
    }
}
