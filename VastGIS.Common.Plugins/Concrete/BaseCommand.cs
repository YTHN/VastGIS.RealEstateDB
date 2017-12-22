using System;
using System.Drawing;
using System.Windows.Forms;
using VastGIS.Common.Plugins.Interfaces;

namespace VastGIS.Common.Plugins.Concrete
{
    public abstract class BaseCommand : ICommand
    {
        protected string _description;
        protected string _headerName;
        protected Bitmap _icon;
        protected string _key;
        protected PluginIdentity _pluginIdentity;
        protected Keys _shortcutKeys;
        protected string _text;
        protected string _toolStripExName;
        protected string _message;
        protected string _tooltip;
        protected bool _isEnabled;
        protected bool _isChecked;

        protected BaseCommand()
        {
            _isEnabled = true;
            _isChecked = false;
        }
        public string Description
        {
            get { return _description; }
        }

        public string HeaderName
        {
            get { return _headerName; }
        }

        public Bitmap Icon
        {
            get { return _icon; }
        }

        public string Key
        {
            get { return _key; }
        }

        public PluginIdentity PluginIdentity
        {
            get { return _pluginIdentity; }
            set { _pluginIdentity = value; }
        }

        public Keys ShortcutKeys
        {
            get { return _shortcutKeys; }
            set { _shortcutKeys = value; }
        }

        public string Text
        {
            get { return _text; }
        }

        public string ToolStripExName
        {
            get { return _toolStripExName; }
        }

        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }

        public string Tooltip
        {
            get { return _tooltip; }
            set { _tooltip = value; }
        }

        public virtual void OnClick()
        {
            
        }

        public virtual void OnCreate(object hook)
        {
           
        }

        public bool IsEnabled
        {
            get { return _isEnabled; }
        }

        public bool IsChecked
        {
            get { return _isChecked; }
            set { _isChecked = value; }
        }
    }


   
}