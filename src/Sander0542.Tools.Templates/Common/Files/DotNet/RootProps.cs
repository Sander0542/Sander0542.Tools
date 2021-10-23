using Sander0542.Tools.Templates.Common.Files.Common;

namespace Sander0542.Tools.Templates.Common.Files.DotNet
{
    public class RootProps : FileBase
    {
        private readonly string _author;
        private readonly string _description;
        private readonly string _gitHubUsername;
        private readonly string _solutionName;

        public RootProps(string author, string description, string gitHubUsername, string solutionName)
        {
            _author = author;
            _description = description;
            _gitHubUsername = gitHubUsername;
            _solutionName = solutionName;

        }

        public override string[] Lines => new[]
        {
            "<Project>",
            "    <PropertyGroup>",
            $"        <Authors>{_author}</Authors>",
            $"        <Description>{_description}</Description>",
            "        <GenerateAssemblyInfo>True</GenerateAssemblyInfo>",
            "        <GenerateDocumentationFile>True</GenerateDocumentationFile>",
            "        <LangVersion>8.0</LangVersion>",
            "        <NeutralLanguage>en-US</NeutralLanguage>",
            "        <NoWarn>$(NoWarn);CS1591;NU5105;NU5125</NoWarn>",
            "        <Nullable>annotations</Nullable>",
            "        <PackageLicenseFile>LICENSE.txt</PackageLicenseFile>",
            $"        <PackageProjectUrl>https://github.com/{_gitHubUsername}/{_solutionName}</PackageProjectUrl>",
            "        <PackageRequireLicenseAcceptance>true</PackageRequireLicenseAcceptance>",
            "        <RepositoryType>git</RepositoryType>",
            $"        <RepositoryUrl>https://github.com/{_gitHubUsername}/{_solutionName}</RepositoryUrl>",
            "        <IsPackable>false</IsPackable>",
            "    </PropertyGroup>",
            "",
            "    <ItemGroup>",
            "        <Content Include=\"$(MSBuildThisFileDirectory)/LICENSE.txt\">",
            "            <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>",
            "            <Pack>true</Pack>",
            "            <PackagePath>LICENSE.txt</PackagePath>",
            "            <Visible>false</Visible>",
            "        </Content>",
            "        <Content Include=\"$(MSBuildThisFileDirectory)/README.md\">",
            "            <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>",
            "            <Pack>true</Pack>",
            "            <PackagePath>README.md</PackagePath>",
            "            <Visible>false</Visible>",
            "        </Content>",
            "    </ItemGroup>",
            "</Project>"
        };
    }
}
