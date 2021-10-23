using System;
using System.Linq;
using System.Reflection;

namespace Sander0542.Tools.Common.Extensions
{
    public static class AssemblyExtensions
    {
        public static Type[] GetTypesInNamespace(this Assembly assembly, string nameSpace)
        {
            return assembly.GetTypes().Where(type => string.Equals(type.Namespace, nameSpace, StringComparison.OrdinalIgnoreCase)).ToArray();
        }
    }
}
