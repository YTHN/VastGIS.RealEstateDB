using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using VastGIS.Common.Api.Concrete;
using VastGIS.Common.Api.Helpers;
using VastGIS.Common.Plugins.Events;
using VastGIS.Common.Plugins.Helpers;
using VastGIS.Common.Plugins.Interfaces;
using VastGIS.Common.Plugins.Services;
using VastGIS.Common.Services.Controls;
using VastGIS.Common.Services.Serialization;
using VastGIS.Common.Services.Serialization.Legacy;
using VastGIS.Common.Services.Views;
using VastGIS.Common.Shared;

namespace VastGIS.Common.Services.Concrete
{
    public class ProjectLoader : ProjectLoaderBase, IProjectLoader
    {
        private readonly ImageSerializationService _imageSerializationService;
     
        private readonly IBroadcasterService _broadcaster;
        private readonly ISecureContext _context;

        public ProjectLoader(IAppContext context, ImageSerializationService imageSerializationService, 
            IBroadcasterService broadcaster)
        {
            if (imageSerializationService == null) throw new ArgumentNullException("imageSerializationService");
          
            _imageSerializationService = imageSerializationService;
         
            _broadcaster = broadcaster;

            _context = context as ISecureContext;
            if (_context == null)
            {
                throw new InvalidCastException("Application context must support ISerializable_context interface.");
            }
        }

        /// <summary>
        /// Restores the state of application by populating application _context after project file was deserialized.
        /// </summary>
        public bool Restore(XmlProject project)
        {
          

           

            try
            {
              

                RestorePlugins(project);

             
            

                return true;
            }
            finally
            {
              
            }
        }

       

      

        private void RestorePlugins(XmlProject project)
        {
            foreach (var p in project.Plugins)
            {
                _context.PluginManager.LoadPlugin(p.Guid, _context);
            }
        }

     

     

      
       

       

     
    }
}
