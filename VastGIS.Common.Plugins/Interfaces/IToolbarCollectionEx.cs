﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VastGIS.Common.Plugins.Events;

namespace VastGIS.Common.Plugins.Interfaces
{
    public interface IToolbarCollectionEx: IToolbarCollectionBase
    {
        event EventHandler<MenuItemEventArgs> ItemClicked;
    }
}
