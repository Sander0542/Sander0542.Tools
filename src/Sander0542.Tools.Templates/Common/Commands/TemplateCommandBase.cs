using McMaster.Extensions.CommandLineUtils;
using Sander0542.Tools.Common;

namespace Sander0542.Tools.Templates.Common.Commands
{
    [Subcommand(
        typeof(CreateCommand),
        typeof(ListCommand)
    )]
    public abstract class TemplateCommandBase : CommandBase
    {
        
    }
}
