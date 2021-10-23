using System;
using System.Collections.Generic;
using System.Linq;
using Sander0542.Tools.Common.Extensions;

namespace Sander0542.Tools.Templates.Common.Utils
{
    public static class TemplateUtil
    {
        public static IList<TemplateBuilder> All(string group)
        {
            var assembly = typeof(TemplateUtil).Assembly;
            var buildersNamespace = $"{assembly.GetName().Name}.{group}.Builders";
            var types = assembly.GetTypesInNamespace(buildersNamespace);
            return types.Select(type => (TemplateBuilder)Activator.CreateInstance(type)).ToList();
        }

        public static TemplateBuilder Get(string group, string name)
        {
            var assembly = typeof(TemplateUtil).Assembly;
            var buildersNamespace = $"{assembly.GetName().Name}.{group}.Builders";
            var type = Type.GetType($"{buildersNamespace}.{name}");

            return (TemplateBuilder)Activator.CreateInstance(type);
        }
    }
}
