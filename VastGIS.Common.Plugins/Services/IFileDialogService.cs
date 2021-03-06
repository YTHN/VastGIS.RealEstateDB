﻿
using VastGIS.Common.Plugins.Enums;

namespace VastGIS.Common.Plugins.Services
{
    public interface IFileDialogService
    {
        bool SaveFile(string filter, ref string filename);
        bool Open(string filter, out string filename, int filterIndex = -1);
        bool OpenFile(DataSourceType layerType, out string filename);
        bool OpenFiles(DataSourceType layerType, out string[] filenames);
        bool ChooseFolder(string initialPath, out string chosenPath);
        string Title { get; set; }
    
    }
}
