// -------------------------------------------------------------------------------------------
// <copyright file="ConfigService.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2016
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.IO;
using System.Linq;
using System.Text;
using VastGIS.Common.Plugins.Concrete;
using VastGIS.Common.Plugins.Helpers;
using VastGIS.Common.Plugins.Interfaces;
using VastGIS.Common.Plugins.Services;
using VastGIS.Common.Services.Serialization;
using VastGIS.Common.Shared;

namespace VastGIS.Common.Services.Concrete
{
    internal class ConfigService : IConfigService
    {
        private readonly IPluginManager _manager;
    

        public ConfigService(IPluginManager manager)
        {
            Logger.Current.Trace("In ConfigService");
            if (manager == null) throw new ArgumentNullException("manager");
          

            _manager = manager;
          

            AppConfig.Instance = new AppConfig();
        }

        public AppConfig Config
        {
            get { return AppConfig.Instance; }
        }

        public string ConfigPath
        {
            get { return ConfigPathHelper.GetConfigPath(); }
        }

        public void SaveAll()
        {
            SaveConfig();
         
        }

        public void LoadAll()
        {
            LoadConfig();
        }

        public bool SaveConfig()
        {
            try
            {
                using (var stream = new StreamWriter(ConfigPathHelper.GetConfigFilePath(), false))
                {
                    string state = GetXmlConfig().Serialize(false);
                    stream.Write(state);
                    stream.Flush();
                    stream.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                const string msg = "Failed to save app config.";
                Logger.Current.Error(msg, ex);
                MessageService.Current.Info(msg);
            }
            return false;
        }

        public bool LoadConfig()
        {
            var path = ConfigPathHelper.GetConfigFilePath();
            Logger.Current.Trace("Start LoadConfig. Config file: " + path);
            if (!File.Exists(path))
            {
                Logger.Current.Debug("Config file {0} does not exist", path);
                return false;
            }

            try
            {
                XmlConfig xmlConfig;
                using (var stream = new StreamReader(path, Encoding.UTF8))
                {
                    string state = stream.ReadToEnd();
                    xmlConfig = state.Deserialize<XmlConfig>();
                    stream.Close();
                }

                ApplyXmlConfig(xmlConfig);
                Logger.Current.Trace("End LoadConfig");
                return true;
            }
            catch (Exception ex)
            {
                MessageService.Current.Info("Failed to load app settings: " + ex.Message);
            }
            return false;
        }

       

        private void ApplyXmlConfig(XmlConfig xmlConfig)
        {
            AppConfig.Instance = xmlConfig.Settings;
            AppConfig.Instance.ApplicationPlugins = xmlConfig.ApplicationPlugins.Select(p => p.Guid).ToList();
        }

        private XmlConfig GetXmlConfig()
        {
            var xmlConfig = new XmlConfig { Settings = AppConfig.Instance };

            var plugins =
                _manager.ApplicationPlugins.Select(p => new XmlPlugin { Guid = p.Identity.Guid, Name = p.Identity.Name });

            xmlConfig.ApplicationPlugins = plugins.ToList();

            return xmlConfig;
        }

        

       
    }
}