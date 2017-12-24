using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using VastGIS.Common.Api.Concrete;
using VastGIS.Common.Api.Helpers;

using VastGIS.Common.Plugins.Interfaces;
using VastGIS.Common.Services.Concrete;

namespace VastGIS.Common.Services.Serialization
{
    /// <summary>
    /// Represents a data contract for MapWindow project file. 
    /// Before serialization the instance is populated from ISerializedContext.
    /// After deserialization RestoreState method should be called.
    /// </summary>
    [DataContract(Name="VastGIS")]
    public class XmlProject
    {
        public XmlProject(ISecureContext context, string filename)
        {
            //ProjectName = context.VastProject.ProjectName;
            //Database = context.VastProject.Database;
            //AttachmentPath = context.VastProject.AttachmentPath;
            Plugins = context.PluginManager.ActivePlugins.Select(p => new XmlPlugin()
            {
                Name = p.Identity.Name,
                Guid = p.Identity.Guid
            }).ToList();
            Settings = new XmlProjectSettings {SavedAsFilename = filename};
        }
     
        [DataMember(Name="ProjectName",Order=0)]
        public string ProjectName { get; set; }

        [DataMember(Name = "Database", Order = 1)]
        public string Database { get; set; }

        [DataMember(Name = "AttachmentPath", Order = 2)]
        public string AttachmentPath { get; set; }
       
     
        [DataMember(Name = "Plugins", Order = 3)]
        public List<XmlPlugin> Plugins { get; set; }

        [DataMember(Name = "Settings", Order = 4)]
        public XmlProjectSettings Settings { get; set; }

    }
}
