﻿using VastGIS.RealEastate.Api.Enums;
using VastGIS.RealEastate.Api.Interface;

namespace VastGIS.RealEastate.Api.Concrete
{
    public class FeatureClass : IFeatureClass
    {
        private string _name;
        private string _caption;
        private string _idFieldName;
        private REClassType _classType;
        private string _parentName;
        private string _databaseName;
        private string _geometryFieldName;
        private REGeometryType _geometryType;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Caption
        {
            get { return _caption; }
            set { _caption = value; }
        }

        public string IDFieldName
        {
            get { return _idFieldName; }
            set { _idFieldName = value; }
        }

        public REClassType ClassType
        {
            get { return _classType; }
            set { _classType = value; }
        }

        public string ParentName
        {
            get { return _parentName; }
            set { _parentName = value; }
        }

        public string DatabaseName
        {
            get { return _databaseName; }
            set { _databaseName = value; }
        }

        public string GeometryFieldName
        {
            get { return _geometryFieldName; }
            set { _geometryFieldName = value; }
        }

        public REGeometryType GeometryType
        {
            get { return _geometryType; }
            set { _geometryType = value; }
        }
    }
}