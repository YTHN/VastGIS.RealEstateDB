using VastGIS.RealEastate.Api.Enums;
using VastGIS.RealEastate.Api.Interface;

namespace VastGIS.RealEastate.Api.Concrete
{
    public class ObjectClass : IObjectClass
    {
        private string _name;
        private string _caption;
        private string _idFieldName;
        private REClassType _classType;
        private string _parentName;
        private string _databaseName;

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
    }
}