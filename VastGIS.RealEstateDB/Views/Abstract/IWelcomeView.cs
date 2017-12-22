using System;
using VastGIS.Common.Plugins.Mvp;


namespace VastGIS.RealEstateDB.Views.Abstract
{
    public interface IWelcomeView: IView<WelcomeViewModel>
    {
        event Action GettingStartedClicked;
        event Action DocumentsClicked;
     
        event Action OpenProjectClicked;
        event Action LogoClicked;

        int ProjectId { get; }
    }
}
