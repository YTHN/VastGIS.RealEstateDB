using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VastGIS.Common.Plugins.Concrete;
using VastGIS.Common.Plugins.Interfaces;
using VastGIS.RealEstateDB.Commands.File;


namespace VastGIS.RealEstateDB.Menu
{
    /// <summary>
    /// Holds list of commands for the core app. 
    /// </summary>
    internal class MenuCommands : CommandProviderBase
    {
        private List<ICommand> _commands;
       
        private PluginIdentity _identity;
        public MenuCommands(IAppContext context,PluginIdentity identity)
            : base(context,identity)
        {
            _context = context;
            _identity = identity;
        }

        protected override void AssignShortcutKeys()
        {
            Commands[MenuKeys.FindLocation].ShortcutKeys = Keys.Control | Keys.F;

            Commands[MenuKeys.NewMap].ShortcutKeys = Keys.Control | Keys.N;

            Commands[MenuKeys.SaveProject].ShortcutKeys = Keys.Control | Keys.S;

            Commands[MenuKeys.OpenProject].ShortcutKeys = Keys.Control | Keys.O;

            Commands[MenuKeys.AddLayer].ShortcutKeys = Keys.Control | Keys.L;

            Commands[MenuKeys.Settings].ShortcutKeys = Keys.Shift | Keys.Alt | Keys.S;

            Commands[MenuKeys.SetScale].ShortcutKeys = Keys.Control | Keys.Shift | Keys.S;

            Commands[MenuKeys.ShowRepository].ShortcutKeys = Keys.Control | Keys.R;

            Commands[MenuKeys.ShowToolbox].ShortcutKeys = Keys.Control | Keys.T;
        }

        public override IEnumerable<ICommand> GetCommands()
        {
            if (_commands == null)
            {
                _commands=new List<ICommand>();
                ICommand command=new CmdCreateNewMap(_context);
                command.PluginIdentity = _identity;
                _commands.Add(command);

           
           

                command = new CmdOpenProject(_context);
                command.PluginIdentity = _identity;
                _commands.Add(command);

                command = new CmdSaveProject(_context);
                command.PluginIdentity = _identity;
                _commands.Add(command);

                command = new CmdSaveProjectAs(_context);
                command.PluginIdentity = _identity;
                _commands.Add(command);

                command = new CmdQuit(_context);
                command.PluginIdentity = _identity;
                _commands.Add(command);

             
                command = new CmdSettings(_context);
                command.PluginIdentity = _identity;
                _commands.Add(command);

       

            }
            return _commands;
        }
    }
}
