﻿using System.Windows.Forms;

namespace VastGIS.Common.Plugins.Services
{
    public interface IMessageService
    {
        void Warn(string message);
        void Info(string message);
        bool Ask(string message);
        DialogResult AskWithCancel(string message);
    }
}
