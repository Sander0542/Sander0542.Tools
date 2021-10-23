using Sander0542.Tools.Templates.Common.Files.Common;

namespace Sander0542.Tools.Templates.Common.Files.DotNet
{
    public class DotnetTools : FileBase
    {
        public override string[] Lines => new[]
        {
            "{",
            "  \"isRoot\": true,",
            "  \"tools\": {",
            "    \"gitversion.tool\": {",
            "      \"version\": \"5.7.0\",",
            "      \"commands\": [",
            "        \"dotnet-gitversion\"",
            "      ]",
            "    }",
            "  }",
            "}",
        };
    }
}
