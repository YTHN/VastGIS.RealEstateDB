using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;
using Syncfusion.Windows.Forms.Tools.Controls.RibbonTabControl.Interfaces;
using Syncfusion.Windows.Forms.Tools.XPMenus;
using VastGIS.Common.Plugins;
using VastGIS.Common.Plugins.Concrete;
using VastGIS.Common.Plugins.Events;
using VastGIS.Common.Plugins.Interfaces;
using VastGIS.Common.UI.Menu.Classic;

namespace VastGIS.Common.UI.Menu.Ribbon
{
    public class RibbonMenu:IRibbonMenu,IRibbonMenuBase
    {
        private Syncfusion.Windows.Forms.Tools.RibbonControlAdv _control;
        private List<ICommand> _commands;

        public RibbonMenu(object menuManager)
        {
            _control =menuManager as RibbonControlAdv;
            _commands=new List<ICommand>();
        }

        public IRibbonHeader Header
        {
            get {return  _control.Header; }
        }

        public RibbonControlAdv RibbonControl
        {
            get { return _control; }
        }

        public ToolStripButton AddButton(ICommand menuCommand)
        {
            ToolStripEx ex = AddToolStripEx(menuCommand.ToolStripExName, menuCommand.ToolStripExName, menuCommand.HeaderName);
           
            ToolStripButton btn = new ToolStripButton(menuCommand.Text, menuCommand.Icon);
            btn.Name = menuCommand.Key;
            ToolStripItem item = btn as ToolStripItem;
            item.Tag =new MenuItemMetadata(menuCommand.PluginIdentity,menuCommand.Key);
            item.Click += Item_Click;
            btn.DisplayStyle= ToolStripItemDisplayStyle.ImageAndText;
            //btn.AutoSize = false;
            btn.ImageScaling= ToolStripItemImageScaling.None;
            btn.TextAlign= ContentAlignment.BottomCenter;
            btn.TextImageRelation= TextImageRelation.ImageAboveText;
            btn.Visible = true;
            ex.Items.Add(btn);
            _commands.Add(menuCommand);
            //ex.Refresh();
            return btn;
        }
        public ToolStripButton AddButton(IMenuItem menuItem)
        {
            ToolStripEx ex = AddToolStripEx(menuItem.ToolStripExName, menuItem.ToolStripExName, menuItem.HeaderName);
            ToolStripButton btn=new ToolStripButton(menuItem.Text,menuItem.Icon.Image);
            btn.Name = menuItem.UniqueKey;
            ToolStripItem item = btn as ToolStripItem;
            item.Tag = new MenuItemMetadata(menuItem.PluginIdentity, menuItem.Key);
            item.Click += Item_Click;
            btn.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            btn.AutoSize = false;
            btn.ImageScaling = ToolStripItemImageScaling.SizeToFit;
            btn.TextAlign = ContentAlignment.TopCenter;
            btn.TextImageRelation = TextImageRelation.ImageAboveText;
            ex.Items.Add(btn);
            return btn;
        }

        public ToolStripDropDownButton AddDropDownButton(IMenuItem menuItem)
        {
            ToolStripEx ex = AddToolStripEx(menuItem.ToolStripExName, menuItem.ToolStripExName, menuItem.HeaderName);
            ToolStripDropDownButton btn = new ToolStripDropDownButton(menuItem.Text, menuItem.Icon.Image);
            btn.Name = menuItem.UniqueKey;
            ToolStripItem item = btn as ToolStripItem;
            item.Tag = menuItem;
            item.Click += Item_Click;
            ex.Items.Add(btn);
            return btn;
        }


        public ToolStripComboBoxEx AddComboBox(IMenuItem menuItem)
        {
            ToolStripEx ex = AddToolStripEx(menuItem.ToolStripExName, menuItem.ToolStripExName, menuItem.HeaderName);
            ToolStripComboBoxEx btn = new ToolStripComboBoxEx();
            btn.Name = menuItem.UniqueKey;
            ToolStripItem item = btn as ToolStripItem;
            item.Tag = menuItem;
            item.Click += Item_Click;
            ex.Items.Add(btn);
            return btn;
        }

        public ToolStripLabel AddLabel(IMenuItem menuItem)
        {
            ToolStripEx ex = AddToolStripEx(menuItem.ToolStripExName, menuItem.ToolStripExName, menuItem.HeaderName);
            ToolStripLabel btn = new ToolStripLabel(menuItem.Text, menuItem.Icon.Image);
            btn.Name = menuItem.UniqueKey;
            ToolStripItem item = btn as ToolStripItem;
            item.Tag = menuItem;
            ex.Items.Add(btn);
            return btn;
        }

        private void Item_Click(object sender, EventArgs e)
        {
            ToolStripItem tool = sender as ToolStripItem;
            MenuItemMetadata item = tool.Tag as MenuItemMetadata;
            if (item == null) return;
            MenuItemEventArgs args = new MenuItemEventArgs(item.Key, false);
            ICommand cmd = _commands.FirstOrDefault(c => c.Key == item.Key);
            if (cmd != null)
            {
                cmd.OnClick();
                //PluginBroadcaster.Instance.FireItemClicked(cmd, args);
            }
        }

      

        private ToolStripTabItem GetHeaderItem(string tabKey)
        {
            ToolStripTabItem item;
            for (int i = 0; i < _control.Header.MainItems.Count; i++)
            {
                if (_control.Header.MainItems[i].Name == tabKey)
                {
                    return _control.Header.MainItems[i] as ToolStripTabItem;
                }
            }
            return null;
        }

        public object MainItems
        {
            get {return _control.Header.MainItems; }
        }

        public object QuickItems
        {
            get { return _control.Header.QuickItems; }
        }

        public ToolStripItem FindToolStripItem(string key, PluginIdentity identity)
        {
            ICommand command = _commands.FirstOrDefault(c => c.Key == key);
            if (command != null && command.PluginIdentity.Guid==identity.Guid)
            {
                ToolStripEx item = GetToolStripEx(command.ToolStripExName,command.HeaderName);
                if (item == null) return null;
                ToolStripItem toolItem = item.Items[key];
                return toolItem;
            }
            return null;
        }

        public ToolStripTabItem AddHeaderTab(string name, string caption)
        {
            ToolStripTabItem item = GetHeaderItem(name);
            if (item != null) return item;
            item=new ToolStripTabItem();
            item.Name = name;
            item.Text = caption;
            item.Panel.Name = name + "_panel";
            item.Panel.ScrollPosition = 0;
            _control.Header.AddMainItem(item);
            return item;
        }

        public ToolStripEx GetToolStripEx(string name,  string headerName)
        {
            ToolStripTabItem item = GetHeaderItem(headerName);
            ToolStripEx stripEx;
            for (int i = 0; i < item.Panel.Controls.Count; i++)
            {
                Control control = item.Panel.Controls[i];
                if (control.Name == name)
                {
                    return control as ToolStripEx;
                }
            }
            return null;
        }

        public ToolStripEx AddToolStripEx(string name, string caption, string headerName)
        {
            ToolStripTabItem item = GetHeaderItem(headerName);
            ToolStripEx stripEx;
            for (int i = 0; i < item.Panel.Controls.Count; i++)
            {
                Control control = item.Panel.Controls[i];
                if (control.Name == name)
                {
                    return control as ToolStripEx ;
                }
            }
            ToolStripEx ex=new ToolStripEx();
            ex.Name = name;
            ex.Text = caption;
            ex.AutoSize = true;
            ex.CanOverflow = true;
            ex.Stretch = true;
            ex.Dock= DockStyle.None;
            ex.LayoutStyle= ToolStripLayoutStyle.HorizontalStackWithOverflow;
            item.Panel.Controls.Add(ex);
            return ex ;
        }
    }
}
