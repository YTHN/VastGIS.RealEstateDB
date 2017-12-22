﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VastGIS.Common.UI.Controls;

namespace VastGIS.RealEstateDB.Controls
{
    public class AssembliesGrid: StronglyTypedGrid<AssemblyInfo>
    {
        public AssembliesGrid()
        {
            Adapter.ReadOnly = true;
            Adapter.HotTracking = true;
            WrapWithPanel = false;
        }

        protected override void UpdateColumns()
        {
            // do nothing
        }
    }
}
