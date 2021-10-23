using Sander0542.Tools.Templates.Common.Files.Common;

namespace Sander0542.Tools.Templates.Common.Files.DotNet
{
    public class SrcProject : FileBase
    {
        public override string[] Lines => new[]
        {
            "<Project Sdk=\"Microsoft.NET.Sdk\">",
            "",
            "    <Import Project=\"../src.props\" />",
            "",
            "</Project>"
        };
    }
}
