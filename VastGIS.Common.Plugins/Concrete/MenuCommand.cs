using System;
using System.Drawing;
using System.Windows.Forms;
using VastGIS.Common.Plugins.Interfaces;

namespace VastGIS.Common.Plugins.Concrete
{

    /// <summary>
    /// Helps to avoid passing the same data twice for the same menu item added 
    /// to the main menu and toolbar.
    /// </summary>
    public class MenuCommand : ICommand
    {
        private readonly string _key;
        private readonly string _text;
        private readonly Bitmap _icon;
        private readonly string _description;
        private readonly string _headerName;
        private readonly string _toolStripExName;
        private string _message;
        private string _tooltip;
        private bool _isEnabled;
        private bool _isChecked;

        public MenuCommand(string text, string key, Bitmap icon) 
            : this(text, key, icon, string.Empty, null, Keys.None)
        {
        }

        public MenuCommand(string text, string key, Bitmap icon,string header,string group)
            : this(text, key, icon, string.Empty, header,group,null, Keys.None)
        {
        }

        public MenuCommand(string text, string key, Bitmap icon, string description, PluginIdentity identity = null, 
                Keys shortcutKeys = Keys.None)
        {
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException("key");

            if (string.IsNullOrWhiteSpace(text))
            {
                text = string.Empty;
            }

            _key = key;
            _text = text;
            _icon = icon;
            _description = description;
            _headerName = "";
            _toolStripExName = "";
            PluginIdentity = identity;
            ShortcutKeys = shortcutKeys;
        }

        public MenuCommand(string text, string key, Bitmap icon, string description,string headerName,string toolStripExName, PluginIdentity identity = null,
                           Keys shortcutKeys = Keys.None)
        {
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException("key");

            if (string.IsNullOrWhiteSpace(text))
            {
                text = string.Empty;
            }

            _key = key;
            _text = text;
            _icon = icon;
            _description = description;
            _headerName = headerName;
            _toolStripExName = toolStripExName;
            PluginIdentity = identity;
            ShortcutKeys = shortcutKeys;
        }


        public string Description
        {
            get { return _description; }
        }

        public string Key
        {
            get { return _key; }
        }

        public string HeaderName
        {
            get { return _headerName; }
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

        public void OnClick()
        {
           
        }

        public void OnCreate(object hook)
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

        public Bitmap Icon
        {
            get { return _icon; }
        }

        public string Text
        {
            get { return _text; }
        }

        public Keys ShortcutKeys { get; set; }

        public PluginIdentity PluginIdentity { get; set; }
    }
}
