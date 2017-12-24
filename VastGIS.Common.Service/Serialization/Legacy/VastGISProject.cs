using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using VastGIS.Common.Shared;

namespace VastGIS.Common.Services.Serialization.Legacy
{
   [XmlRoot("VastGIS")]
   public class VastGISProject
    {
        [XmlAttribute(AttributeName = "Name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "Database")]
        public string Database { get; set; }

        [XmlAttribute(AttributeName = "Attachment")]
        public string Attachment { get; set; }



        public class ApplicationPlugins
        {
            [XmlAttribute(AttributeName = "PluginDir")]
            public string PluginDir { get; set; }

            [XmlElement(ElementName = "Plugin")]
            public List<Plugin> Plugins { get; set; }
        }

        public class Plugin
        {
            [XmlAttribute(AttributeName = "SettingsString")]
            public string SettingsString { get; set; }

            [XmlAttribute(AttributeName = "Key")]
            public string Key { get; set; }

        }
     
        
    }
}
