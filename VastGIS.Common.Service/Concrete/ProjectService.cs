using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using VastGIS.Common.Plugins;
using VastGIS.Common.Plugins.Concrete;
using VastGIS.Common.Plugins.Enums;
using VastGIS.Common.Plugins.Helpers;
using VastGIS.Common.Plugins.Interfaces;
using VastGIS.Common.Plugins.Services;
using VastGIS.Common.Services.Helpers;
using VastGIS.Common.Services.Serialization;
using VastGIS.Common.Services.Serialization.Legacy;
using VastGIS.Common.Services.Views;
using VastGIS.Common.Shared;

namespace VastGIS.Common.Services.Concrete
{
    public class ProjectService: IProjectService, IProject
    {
        private const string ProjectFilter = "VastGIS项目文件 (*.vgproj)|*.vgproj";
        private const int ProjectFilterIndex = 0;

        private ProjectLoadingView _loadingForm;
        private readonly IAppContext _context;
        private readonly IFileDialogService _fileService;
        private readonly IBroadcasterService _broadcaster;
        private readonly IProjectLoader _projectLoader;
        private readonly ProjectLoaderLegacy _projectLoaderLegacy;
        private string _filename = string.Empty;
        private bool _modified;

        public ProjectService(IAppContext context, IFileDialogService fileService, 
         IBroadcasterService broadcaster, IProjectLoader projectLoader, ProjectLoaderLegacy projectLoaderLegacy)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (fileService == null) throw new ArgumentNullException("fileService");
            if (broadcaster == null) throw new ArgumentNullException("broadcaster");
            if (projectLoader == null) throw new ArgumentNullException("projectLoader");
            if (projectLoaderLegacy == null) throw new ArgumentNullException("projectLoaderLegacy");

            _context = context;
            _fileService = fileService;
            _broadcaster = broadcaster;
            _projectLoader = projectLoader;
            _projectLoaderLegacy = projectLoaderLegacy;
        }

        public bool IsEmpty
        {
            get { return _filename.Length == 0; }
        }

        public string Filename
        {
            get { return _filename; }
        }

        public ProjectState GetState()
        {
            return State;       // don't expose as property or it will cause serialization of state on examining it during debugging
        }

        private ProjectState State
        {
            get
            {
               

                if (string.IsNullOrWhiteSpace(_filename))
                {
                    return ProjectState.NotSaved;
                }

                try
                {
                    using (var r = new StreamReader(_filename))
                    {
                        var oldState = r.ReadToEnd();
                        var state = SerializeMapState(_filename);
                        return state.EqualsIgnoreCase(oldState) && !_modified ? ProjectState.NoChanges : ProjectState.HasChanges;
                    }
                }
                catch
                {
                    return ProjectState.NotSaved;
                }
            }
        }

        public bool TryClose()
        {
            //var args = new CancelEventArgs();

            //if (!(_context is ISecureContext))
            //{
            //    throw new ApplicationException("Invalid application context");
            //}

            //_broadcaster.BroadcastEvent(p => p.ProjectClosing_, this, args);
            //if (args.Cancel)
            //{
            //    return false;
            //}

            //if (TryCloseCore())
            //{
            //    Clear();

            //    _broadcaster.BroadcastEvent(p => p.ProjectClosed_, this, args);
            //    return true;
            //}
            //return false;
            return true;
        }

        private void Clear()
        {
           
        }

        private bool TryCloseCore()
        {
            var state = State;
            switch (state)
            {
                case ProjectState.NotSaved:
                case ProjectState.HasChanges:
                {
                    string prompt = "Save the project?";

                    if (!string.IsNullOrWhiteSpace(_filename))
                    {
                        prompt = string.Format("Save the project: {0}?", Path.GetFileName(_filename));
                    }

                    var result = MessageService.Current.AskWithCancel(prompt);
                    if (result == DialogResult.Cancel)
                    {
                        return false;
                    }

                    if (result == DialogResult.Yes)
                    {
                        Save();
                    }
                    break;
                }
                case ProjectState.NoChanges:
                case ProjectState.Empty:
                    break;
            }

            SetEmptyProject();
            return true;
        }

        public bool Save()
        {
            string filename = _filename;
            var state = State; 
            
            bool newProject = state == ProjectState.NotSaved || state == ProjectState.Empty;
            if (newProject)
            {
                if (!_fileService.SaveFile(ProjectFilter, ref filename))
                {
                    return false;
                }
            }

            SaveProject(filename);

            if (newProject)
            {
                // OnProjectChanged();
            }

            return true;
        }

        public bool SaveAs()
        {
            string filename = _filename;
            if (!_fileService.SaveFile(ProjectFilter, ref filename))
            {
                return false;
            }

            return SaveProject(filename);
        }

        private bool SaveProject(string filename)
        {
            var state = SerializeMapState(filename);

            try
            {
                using (var writer = new StreamWriter(filename))
                {
                    writer.Write(state);
                    writer.Flush();
                    _filename = filename;
                    _modified = false;

                    AppConfig.Instance.AddRecentProject(filename);

                    // PM:
                    // MessageService.Current.Info("Project was saved: " + filename);
                    Logger.Current.Info("项目保存为: " + filename);
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageService.Current.Warn("Failed to save project: " + ex.Message);
            }

            return false;
        }

        public bool Open()
        {
            string filename;
            if (_fileService.Open(ProjectFilter, out filename, ProjectFilterIndex))
            {
                Open(filename);
            }

            return false;
        }

        private ProjectLoaderBase GetCurrentLoader(bool legacy = false)
        {
            return  (ProjectLoaderBase)_projectLoader;
        }

        public bool Open(string filename, bool silent = true)
        {
            if (!CheckProjectFilename(filename, silent))
            {
                return false;
            }

            if (!TryClose())
            {
                return false;
            }

            ShowLoadingForm(filename);

            bool legacy = !filename.ToLower().EndsWith(".vgproj");
            var loader = GetCurrentLoader(legacy);
            loader.ProgressChanged += OnLoadingProgressChanged;

            bool result;

            _context.View.Lock();
            result = OpenCore(filename, silent);
           

            // let's redraw map before hiding the progress
            _loadingForm.ShowProgress(100, "加载数据...");
          
            _context.View.Unlock();

            Application.DoEvents();

            loader.ProgressChanged -= OnLoadingProgressChanged;

            HideLoadingForm();
            

            return result;
        }

        private void OnLoadingProgressChanged(object sender, Plugins.Events.ProgressEventArgs e)
        {
            _loadingForm.ShowProgress(e.Percent, e.Message);
        }

        private void HideLoadingForm()
        {
            _loadingForm.Close();
            _loadingForm.Dispose();
            _loadingForm = null;
        }

        private void ShowLoadingForm(string filename)
        {
            _loadingForm = new ProjectLoadingView(filename);

            _context.View.ShowChildView(_loadingForm, false);
            Application.DoEvents();
        }

        private bool CheckProjectFilename(string filename, bool silent)
        {
            if (string.IsNullOrWhiteSpace(filename))
            {
                return false;
            }

            if (!File.Exists(filename))
            {
                if (!silent)
                {
                    MessageService.Current.Info("Project file wasn't found: " + filename);
                }
                
                return false;
            }

            return true;
        }

     

        private bool OpenCore(string filename, bool silent = true)
        {
            using (var reader = new StreamReader(filename))
            {
                string state = reader.ReadToEnd();
                var project = state.Deserialize<XmlProject>();

                if (project.Settings == null)
                {
                    // in case of a bit older project version, where no such settings existed
                    project.Settings = new XmlProjectSettings();
                }

                project.Settings.LoadAsFilename = filename;
                _filename = filename;
                if (!_projectLoader.Restore(project,_loadingForm))
                {
                    _filename = "";
                    Clear();
                    SetEmptyProject();
                    return false;
                }

                AppConfig.Instance.AddRecentProject(filename);

                _filename = filename;

                if (!silent)
                {
                    MessageService.Current.Info("打开项目: " + filename);
                }

                Logger.Current.Info("Project was loaded: " + filename);

                return true;
            }

            //OnProjectChanged();
        }

        public void SetModified()
        {
            _modified = true;
        }

        public bool Modified
        {
            get
            {
                var state = State;
                return (state == ProjectState.NotSaved || state == ProjectState.HasChanges);
            }
        }

        private string SerializeMapState(string filename)
        {
            var project = new XmlProject(_context as ISecureContext, filename);
            return project.Serialize(false);
        }

        private void SetEmptyProject()
        {
            _filename = "";
            //OnProjectChanged();
        }
    }
}
