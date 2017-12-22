using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VastGIS.Common.Api.Concrete;

using VastGIS.Common.Plugins.Events;
using VastGIS.Common.Plugins.Interfaces;
using VastGIS.Common.Plugins.Services;
using VastGIS.Common.Services.Serialization;
using VastGIS.Common.Services.Serialization.Legacy;
using VastGIS.Common.Shared;

namespace VastGIS.Common.Services.Concrete
{
    public class ProjectLoaderLegacy: ProjectLoaderBase
    {
        private readonly ImageSerializationService _imageSerializationService;
      
        private readonly ISecureContext _context;

        public ProjectLoaderLegacy(IAppContext context, ImageSerializationService imageSerializationService)
        {
            if (imageSerializationService == null) throw new ArgumentNullException("imageSerializationService");
         
            _imageSerializationService = imageSerializationService;
        

            _context = context as ISecureContext;
            if (_context == null)
            {
                throw new InvalidCastException("Application context must support ISerializable_context interface.");
            }
        }

        /// <summary>
        /// Restores the state of application by populating application _context after project file was deserialized.
        /// </summary>
        public bool Restore(MapWin4Project project, string filename)
        {
            if (project == null)
            {
                return false;
            }

       

            string path = Path.GetDirectoryName(filename);

            try
            {
             

                return true;
            }
            finally
            {
            
            }
        }

     
    }
}
