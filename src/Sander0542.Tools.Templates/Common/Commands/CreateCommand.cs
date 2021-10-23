using System;
using McMaster.Extensions.CommandLineUtils;
using Sander0542.Tools.Common;
using Sander0542.Tools.Templates.Common.Utils;

namespace Sander0542.Tools.Templates.Common.Commands
{
    [Command(Description = "Create a project based on a template")]
    public class CreateCommand : CommandBase
    {
        [Argument(0)]
        public string Template { get; }

        protected override int OnExecute(CommandLineApplication app)
        {
            if (string.IsNullOrWhiteSpace(Template))
            {
                app.ShowHint();
                return 1;
            }

            var templates = TemplateUtil.All(app.Parent.Name);

            foreach (var template in templates)
            {
                if (string.Equals(Template, template.Name, StringComparison.OrdinalIgnoreCase))
                {
                    return template.Build() ? 0 : 1;
                }
            }

            throw new Exception("Template not found");
        }
    }
}
