using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VastGIS.Common.Plugins.Interfaces
{
    public interface IToolbarCollection: IToolbarCollectionBase
    {
        IToolbar MapToolbar { get; }

        IToolbar FileToolbar { get; }
    }
}
