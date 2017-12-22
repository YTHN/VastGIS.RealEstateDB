using System;

namespace VastGIS.Common.Shared
{
    public interface IEnumConverter<T> where T : IConvertible
    {
        string GetString(T value);
    }
}
