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
           

            Plugins = context.PluginManager.ActivePlugins.Select(p => new XmlPlugin()
            {
                Name = p.Identity.Name,
                Guid = p.Identity.Guid
            }).ToList();

          

            Settings = new XmlProjectSettings {SavedAsFilename = filename};

           
        }
     
        [DataMember] public XmlProjectSettings Settings { get; set; }
     
        [DataMember] public List<XmlPlugin> Plugins { get; set; }
        
    }
}
