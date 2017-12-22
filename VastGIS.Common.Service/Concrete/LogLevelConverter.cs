using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VastGIS.Common.Shared;

namespace VastGIS.Common.Services.Concrete
{
    public class LogLevelConverter : IEnumConverter<LogLevel>
    {
        public string GetString(LogLevel value)
        {
            switch (value)
            {
                case LogLevel.Info:
                    return "Info";
                case LogLevel.Debug:
                    return "Debug";
                case LogLevel.Warn:
                    return "Warn";
                case LogLevel.Error:
                    return "Error";
                case LogLevel.Fatal:
                    return "Fatal";
                case LogLevel.All:
                    return "All";
            }

            throw new IndexOutOfRangeException("Invalid enum value");
        }
    }
}
