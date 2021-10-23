using Sander0542.Tools.Templates.Common.Files.Common;

namespace Sander0542.Tools.Templates.Common.Files.DotNet
{
    public class TestsProject : FileBase
    {
        public override string[] Lines => new[]
        {
            "<Project Sdk=\"Microsoft.NET.Sdk\">",
            "",
            "    <Import Project=\"../tests.props\" />",
            "",
            "</Project>"
        };
    }
}
