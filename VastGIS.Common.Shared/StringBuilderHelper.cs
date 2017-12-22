using System.Text;

namespace VastGIS.Common.Shared
{
    public static class StringBuilderHelper
    {
        public static void RemoveFromEnd(this StringBuilder sb, string token)
        {
            int length = token.Length;
            sb.Remove(sb.Length - length, length);
        }
    }
}
