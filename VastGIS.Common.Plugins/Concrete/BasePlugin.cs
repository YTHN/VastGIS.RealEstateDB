// -------------------------------------------------------------------------------------------
// <copyright file="BasePlugin.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2016
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using VastGIS.Common.Plugins.Events;
using VastGIS.Common.Plugins.Interfaces;
using VastGIS.Common.Plugins.Mvp;
using VastGIS.Common.Shared.Log;

namespace VastGIS.Common.Plugins.Concrete
{
    public abstract class BasePlugin : IPlugin
    {
        private FileVersionInfo _fileVersionInfo;
        private PluginIdentity _identity;
        private bool _registered;

        public virtual IEnumerable<IConfigPage> ConfigPages
        {
            get { yield break; }
        }

        public virtual List<ICommand> Commands { get;set; }

        public PluginIdentity Identity
        {
            get
            {
                if (_identity == null)
                {
                    throw new ApplicationException("Can't access plugin identity before it was initialized");
                }
                return _identity;
            }
            internal set
            {
                if (_identity != null)
                {
                    throw new ApplicationException("Plugin identity may be set only once.");
                }
                _identity = value;
            }
        }

        public bool IsApplicationPlugin { get; private set; }

        private Assembly ReferenceAssembly
        {
            get { return GetType().Assembly; }
        }

        private FileVersionInfo ReferenceFile
        {
            get
            {
                return _fileVersionInfo ??
                       (_fileVersionInfo = FileVersionInfo.GetVersionInfo(ReferenceAssembly.Location));
            }
        }

        public virtual string Description
        {
            get { return ReferenceFile.Comments; }
        }

        public abstract void Initialize(IAppContext context);

        public virtual void Terminate()
        {
            // do nothing
        }

        protected abstract void RegisterServices(IApplicationContainer container);

        internal void DoRegisterServices(IApplicationContainer container)
        {
            if (!_registered)
            {
                RegisterServices(container);
                _registered = true;
            }
        }

        internal void SetApplicationPlugin(bool value)
        {
            IsApplicationPlugin = value;
        }

#pragma warning disable 67

        #region Plugin events

        // backing fields
        internal EventHandler<LogEventArgs> LogEntryAdded_;
        internal EventHandler<MenuItemEventArgs> ItemClicked_;
        internal EventHandler<CancelEventArgs> ProjectClosing_;
        internal EventHandler<EventArgs> ProjectClosed_;
        internal EventHandler<EventArgs> ViewUpdating_;
        internal EventHandler<PluginMessageEventArgs> MessageBroadcasted_;

     

        public event EventHandler<LogEventArgs> LogEntryAdded
        {
            add { LogEntryAdded_ += value; }
            remove { LogEntryAdded_ -= value; }
        }

     
        public event EventHandler<EventArgs> ViewUpdating
        {
            add { ViewUpdating_ += value; }
            remove { ViewUpdating_ -= value; }
        }

        public event EventHandler<PluginMessageEventArgs> MessageBroadcasted
        {
            add { MessageBroadcasted_ += value; }
            remove { MessageBroadcasted_ -= value; }
        }

        public event EventHandler<MenuItemEventArgs> ItemClicked
        {
            add { ItemClicked_ += value; }
            remove { ItemClicked_ -= value; }
        }

        public event EventHandler<CancelEventArgs> ProjectClosing
        {
            add { ProjectClosing_ += value; }
            remove { ProjectClosing_ -= value; }
        }

        public event EventHandler<EventArgs> ProjectClosed
        {
            add { ProjectClosed_ += value; }
            remove { ProjectClosed_ -= value; }
        }

        #endregion

   

        #region DockPanel events

        internal EventHandler<DockPanelCancelEventArgs> DockPanelOpening_;
        internal EventHandler<DockPanelCancelEventArgs> DockPanelClosing_;
        internal EventHandler<DockPanelEventArgs> DockPanelOpened_;
        internal EventHandler<DockPanelEventArgs> DockPanelClosed_;

        public BasePlugin()
        {
            IsApplicationPlugin = false;
        }

        public event EventHandler<DockPanelCancelEventArgs> DockPanelOpening
        {
            add { DockPanelOpening_ += value; }
            remove { DockPanelOpening_ -= value; }
        }

        public event EventHandler<DockPanelCancelEventArgs> DockPanelClosing
        {
            add { DockPanelClosing_ += value; }
            remove { DockPanelClosing_ -= value; }
        }

        public event EventHandler<DockPanelEventArgs> DockPanelClosed
        {
            add { DockPanelClosed_ += value; }
            remove { DockPanelClosed_ -= value; }
        }

        public event EventHandler<DockPanelEventArgs> DockPanelOpened
        {
            add { DockPanelOpened_ += value; }
            remove { DockPanelOpened_ -= value; }
        }

        #endregion

#pragma warning restore 67
    }
}