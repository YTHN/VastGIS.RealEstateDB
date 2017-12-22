using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VastGIS.Common.Plugins.Interfaces;

namespace VastGIS.Common.Plugins.Concrete
{
    /// <summary>
    /// Stores a list of menu commands, that can be added both to toolbars and main menu.
    /// </summary>
    public abstract class CommandProviderBase
    {
        protected readonly Dictionary<string, ICommand> Commands = new Dictionary<string, ICommand>();
        protected IAppContext _context;

        protected CommandProviderBase(PluginIdentity identity)
        {
            if (identity == null) throw new ArgumentNullException("identity");

            var list = GetCommands();

            foreach (var cmd in list)
            {
                cmd.PluginIdentity = identity;
                Commands.Add(cmd.Key, cmd);
            }

            AssignShortcutKeys();
        }

        protected CommandProviderBase(IAppContext context,PluginIdentity identity)
        {
            if (identity == null) throw new ArgumentNullException("identity");
            _context = context;
            var list = GetCommands();

            foreach (var cmd in list)
            {
                cmd.PluginIdentity = identity;
                Commands.Add(cmd.Key, cmd);
            }

           
        }

        protected virtual void AssignShortcutKeys()
        {
            // override in derived class
        }

        /// <summary>
        /// Defines the list of menu commands, populate a List with commands that your plugin is using.
        /// </summary>
        public abstract IEnumerable<ICommand> GetCommands();

        /// <summary>
        /// Gets the <see cref="MenuCommand"/> with the specified key.
        /// </summary>
        public ICommand this[string key]
        {
            get
            {
                return Commands[key] ;  // don't catch it, if there is a mistake we want to know at once
            }
        }
    }
}
