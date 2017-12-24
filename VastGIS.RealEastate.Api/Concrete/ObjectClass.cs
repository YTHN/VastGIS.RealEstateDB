using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using VastGIS.Common.Services.Concrete;
using VastGIS.Common.Services.Serialization.Legacy;
using VastGIS.RealEstate.Api.Enums;
using VastGIS.RealEstate.Api.Interface;

namespace VastGIS.RealEstate.Api.Concrete
{
    public class ObjectClass : IObjectClass
    {
        private string _name;
        private string _caption;
        private string _idFieldName;
        private REClassType _classType;
        private string _parentName;
        private string _databaseName;
        private string _geometryFieldName;
        private REGeometryType _geometryType;
        private List<IObjectClass> _subClasses;

        public ObjectClass()
        {
            _classType = REClassType.Dataset;
        }

        public ObjectClass(SQLiteDataReader reader)
        {
            _name = reader.GetString(0);
            _caption = reader.IsDBNull(1)?_name:reader.GetString(1);
            _idFieldName = reader.GetString(3);
            _classType = (REClassType) reader.GetInt32(2);
            _geometryFieldName = reader.GetString(4);
            _geometryType = reader.IsDBNull(5) ? REGeometryType.None : (REGeometryType) reader.GetInt32(5);
            _parentName = reader.IsDBNull(6) ? "" : reader.GetString(6);
        }

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

        public string DatabaseName
        {
            get { return _databaseName; }
            set { _databaseName = value; }
        }

        public List<IObjectClass> SubClasses
        {
            get { return _subClasses; }
            set { _subClasses = value; }
        }
    }

    public class CodeDomain : ICodeDomain
    {
        private string _name;
        private List<ICodeDomainValue> _values;
        private ICodeDomainValue _defaultValue;

        public CodeDomain()
        {
            _values=new List<ICodeDomainValue>();
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public List<ICodeDomainValue> Values
        {
            get { return _values; }
            set { _values = value; }
        }

        public ICodeDomainValue DefaultValue
        {
            get
            {
                if(_defaultValue!= null)return _defaultValue;
                if (_values.Count > 0) return _values[0];
                return null;
            }
            set { _defaultValue = value; }
        }
    }

    public class CodeDomainValue : ICodeDomainValue
    {
        private string _description;
        private string _code;
        private bool _isDefault;

        public CodeDomainValue(string code, string description, bool isDefault)
        {
            _code = code;
            _description = description;
            _isDefault = isDefault;
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string Code
        {
            get { return _code; }
            set { _code = value; }
        }

        public bool IsDefault
        {
            get { return _isDefault; }
            set { _isDefault = value; }
        }
    }
}