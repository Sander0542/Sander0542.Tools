using Sander0542.Tools.Templates.Common.Files.Common;

namespace Sander0542.Tools.Templates.Common.Files.DotNet
{
    public class GitVersion : FileBase
    {
        public override string[] Lines => new[]
        {
            "mode: ContinuousDeployment",
            "branches:",
            "  main:",
            "    tag: alpha"
        };
    }
}
