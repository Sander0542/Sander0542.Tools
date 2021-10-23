using Sander0542.Tools.Templates.Common.Files.Common;

namespace Sander0542.Tools.Templates.Common.Files.DotNet
{
    public class TestsProps : FileBase
    {
        private readonly string _framework;

        public TestsProps(string framework)
        {
            _framework = framework;
        }

        public override string[] Lines => new[]
        {
            "<Project>",
            "",
            "    <Import Project=\"../root.props\" />",
            "",
            "    <PropertyGroup>",
            $"        <TargetFramework>{_framework}</TargetFramework>",
            "        <IsPackable>false</IsPackable>",
            "        <IsTestProject>true</IsTestProject>",
            "        <NoWarn>$(NoWarn);NU1701;IDE1006</NoWarn>",
            "    </PropertyGroup>",
            "",
            "    <ItemGroup>",
            "        <PackageReference Include=\"Microsoft.NET.Test.Sdk\" Version=\"16.5.0\" />",
            "        <PackageReference Include=\"xunit\" Version=\"2.4.1\" />",
            "        <PackageReference Include=\"xunit.runner.visualstudio\" Version=\"2.4.1\" />",
            "        <PackageReference Include=\"coverlet.collector\" Version=\"1.2.1\">",
            "            <PrivateAssets>all</PrivateAssets>",
            "            <IncludeAssets>runtime;build;native;contentfiles;analyzers;buildtransitive</IncludeAssets>",
            "        </PackageReference>",
            "        <PackageReference Include=\"FluentAssertions\" Version=\"5.10.3\" />",
            "        <PackageReference Include=\"Moq\" Version=\"4.16.1\" />",
            "    </ItemGroup>",
            "",
            "</Project>"
        };
    }
}
