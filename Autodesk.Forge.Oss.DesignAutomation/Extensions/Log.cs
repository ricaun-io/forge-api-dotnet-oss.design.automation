using System;
using System.Runtime.CompilerServices;

namespace Autodesk.Forge.Oss.DesignAutomation.Extensions
{
    internal static class Log
    {
        [MethodImplAttribute(MethodImplOptions.NoInlining)]
        public static void WriteLine(object value)
        {
            Console.WriteLine($"[{GetUtcNow}] {value}");
        }

        public static string GetUtcNow => DateTime.UtcNow.ToString("MM/dd/yyyy HH:mm:ss");
    }
}
