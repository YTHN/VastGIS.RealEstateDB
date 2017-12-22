using System;
using System.Collections.Generic;
using VastGIS.Common.Plugins.Mvp;

using VastGIS.RealEstateDB.Controls;
using VastGIS.RealEstateDB.Enums;

namespace VastGIS.RealEstateDB.Views.Abstract
{
    public interface IAboutView: IView
    {
     
        List<AssemblyInfo> Assemblies { set; }
        AssemblyFilter AssemblyFilter { get; set; }
        event Action AssemblyFilterChanged;
    }
}
