// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AppConfig.cs" company="MapWindow OSS Team - www.mapwindow.org">
//   MapWindow OSS Team - 2015
// </copyright>
// <summary>
//   Defines the AppConfig type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Runtime.Serialization;
using System.Windows.Forms;
using VastGIS.Common.Plugins.Enums;
using VastGIS.Common.Shared;


namespace VastGIS.Common.Plugins.Concrete
{
    [DataContract(Name = "Settings")]
    public class AppConfig
    {
        private List<Guid> _applicationPlugins;
       
        private List<int> _favoriteProjections;
        private List<string> _recentProjects;
        private bool _showMenuToolTips;
        private bool _showPluginInToolTip;

        public AppConfig()
        {
            SetDefaults();
        }

        public static AppConfig Instance { get; internal set; }

    

        [DataMember]
        public List<Guid> ApplicationPlugins
        {
            get { return _applicationPlugins ?? (_applicationPlugins = DefaultApplicationPlugins); }
            set { _applicationPlugins = value; }
        }

   
        public List<Guid> DefaultApplicationPlugins
        {
            [SuppressMessage("StyleCop.CSharp.LayoutRules", "SA1500:CurlyBracketsForMultiLineStatementsMustNotShareLine", Justification = "Reviewed. Suppression is OK here.")]
            get
            {
               return new List<Guid> { };
                //return new List<Guid> { new Guid("F05CCFAF-26BB-4656-BBE2-0F5E3C7AD0FB"), // Symbology
                //                        new Guid("D241C820-4B27-4954-8BA1-5A0B1DC25F7B"), // Repository
                //                        new Guid("6AC34207-254E-48DF-A0A1-01C2C9D9B936"), // Identifier
                //                        new Guid("F9C021D3-2BD7-4591-9BFB-235DEC812222"), // Table editor
                //                        new Guid("22729F63-6D97-48DB-9F51-1B46BB8AFEF1"), // Shape editor
                //                        //new Guid("B714AD79-8AFC-41D2-BB96-0C83BA242B7D"), // Debug window
                //                        new Guid("241E5643-8935-4A79-9DD2-745954AD74FA"), // GIS Toolbox
                //                        new Guid("C82AE4FD-4BB2-48EF-A58D-B7E5449B1A27")  // Print lay-out
                //                      };
            }
        }

      
        [DataMember]
        public bool FirstRun { get; set; }

    

        [DataMember]
        public string LastConfigPage { get; set; }

        [DataMember]
        public string LastProjectPath { get; set; }
     

        [DataMember]
        public bool LoadLastProject { get; set; }

   

        [DataMember]
        public bool LocalDocumentation { get; set; }

    
     

        [DataMember]
        public List<string> RecentProjects
        {
            get { return _recentProjects ?? (_recentProjects = new List<string>()); }
            set { _recentProjects = value; }
        }

     

        [DataMember]
        public DateTime UpdaterLastChecked { get; set; }

        [DataMember]
        public bool UpdaterIsDownloading { get; set; }

        [DataMember]
        public bool UpdaterHasNewInstaller { get; set; }

        [DataMember]
        public string UpdaterInstallername { get; set; }

        [DataMember]
        public bool UpdaterCheckNewVersion { get; set; }
        [DataMember]
        public bool ShowMenuToolTips{ get; set; }
        [DataMember]
        public bool ShowPluginInToolTip { get; set; }

        public void AddRecentProject(string path)
        {
            path = path.ToLower();

            if (RecentProjects.Contains(path))
            {
                RecentProjects.Remove(path);
            }

            RecentProjects.Add(path);

            if (RecentProjects.Count > 3)
            {
                RecentProjects.RemoveAt(0);
            }
        }

        public void SetDefaults()
        {
            Logger.Current.Trace("Start AppConfig.SetDefaults()");
      
            FirstRun = true;
        
            LastProjectPath = "";
         
            LoadLastProject = true;
    
            LocalDocumentation = false;
          
            UpdaterCheckNewVersion = true;
            UpdaterHasNewInstaller = false;
            UpdaterIsDownloading = false;
            UpdaterLastChecked = new DateTime(2015, 1, 1);
      
            Logger.Current.Trace("End AppConfig.SetDefaults()");
        }

        [OnDeserializing]
        private void OnDeserializing(StreamingContext context)
        {
            SetDefaults();
        }
    }
}