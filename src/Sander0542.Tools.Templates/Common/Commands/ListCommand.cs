using System;
using McMaster.Extensions.CommandLineUtils;
using Sander0542.Tools.Common;
using Sander0542.Tools.Templates.Common.Utils;

namespace Sander0542.Tools.Templates.Common.Commands
{
    [Command(Description = "Show a list of all templates")]
    public class ListCommand : CommandBase
    {
        protected override int OnExecute(CommandLineApplication app)
        {
            if (app.Parent == null) throw new NotImplementedException("Template list not implemented");

            var templates = TemplateUtil.All(app.Parent.Name);

            Console.WriteLine($"Templates: ({templates.Count})");
            foreach (var template in templates)
            {
                Console.WriteLine(template.Name);
            }

            return 1;
        }
    }
}
