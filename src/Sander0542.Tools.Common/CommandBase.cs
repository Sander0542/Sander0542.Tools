using McMaster.Extensions.CommandLineUtils;

namespace Sander0542.Tools.Common
{
    [HelpOption("--help")]
    public abstract class CommandBase
    {
        protected virtual int OnExecute(CommandLineApplication app)
        {
            app.ShowHelp();
            return 1;
        }
    }
}
