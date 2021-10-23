using Sander0542.Tools.Templates.Common.Files.Common;

namespace Sander0542.Tools.Templates.Common.Files.DotNet
{
    public class SrcProps : FileBase
    {
        private readonly string _description;
        private readonly string _framework;

        public SrcProps(string description, string framework)
        {
            _description = description;
            _framework = framework;
        }

        public override string[] Lines => new[]
        {
            "<Project>",
            "    <Import Project=\"../root.props\"/>",
            "    ",
            "    <PropertyGroup>",
            $"        <Description>{_description}</Description>",
            $"        <TargetFramework>{_framework}</TargetFramework>",
            "        <LangVersion>8.0</LangVersion>",
            "    </PropertyGroup>",
            "",
            "    <PropertyGroup>",
            "        <GeneratePackageOnBuild>true</GeneratePackageOnBuild>",
            "        <IsPackable>true</IsPackable>",
            "    </PropertyGroup>",
            "",
            "    <PropertyGroup Condition=\"'$(Configuration)|$(Platform)'=='Debug|AnyCPU'\">",
            "        <DefineConstants>DEBUG;TRACE</DefineConstants>",
            "    </PropertyGroup>",
            "",
            "    <ItemGroup>",
            "        <PackageReference Update=\"GitVersion.MsBuild\" Version=\"5.6.11\">",
            "            <PrivateAssets>all</PrivateAssets>",
            "            <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>",
            "        </PackageReference>",
            "    </ItemGroup>",
            "",
            "    <PropertyGroup Condition=\" '$(GitVersion_SemVer)' != ''\">",
            "        <GetVersion>false</GetVersion>",
            "        <WriteVersionInfoToBuildLog>false</WriteVersionInfoToBuildLog>",
            "        <UpdateAssemblyInfo>false</UpdateAssemblyInfo>",
            "        <GenerateGitVersionInformation>false</GenerateGitVersionInformation>",
            "",
            "        <Version>$(GitVersion_FullSemVer)</Version>",
            "        <VersionPrefix>$(GitVersion_MajorMinorPatch)</VersionPrefix>",
            "        <VersionSuffix Condition=\" '$(UseFullSemVerForNuGet)' == 'false' \">$(GitVersion_NuGetPreReleaseTag)</VersionSuffix>",
            "        <VersionSuffix Condition=\" '$(UseFullSemVerForNuGet)' == 'true' \">$(GitVersion_PreReleaseTag)</VersionSuffix>",
            "        <PackageVersion Condition=\" '$(UseFullSemVerForNuGet)' == 'false' \">$(GitVersion_NuGetVersion)</PackageVersion>",
            "        <PackageVersion Condition=\" '$(UseFullSemVerForNuGet)' == 'true' \">$(GitVersion_FullSemVer)</PackageVersion>",
            "        <InformationalVersion Condition=\" '$(InformationalVersion)' == '' \">$(GitVersion_InformationalVersion)</InformationalVersion>",
            "        <AssemblyVersion Condition=\" '$(AssemblyVersion)' == '' \">$(GitVersion_AssemblySemVer)</AssemblyVersion>",
            "        <FileVersion Condition=\" '$(FileVersion)' == '' \">$(GitVersion_AssemblySemFileVer)</FileVersion>",
            "        <RepositoryBranch Condition=\" '$(RepositoryBranch)' == '' \">$(GitVersion_BranchName)</RepositoryBranch>",
            "        <RepositoryCommit Condition=\" '$(RepositoryCommit)' == '' \">$(GitVersion_Sha)</RepositoryCommit>",
            "    </PropertyGroup>",
            "</Project>"
        };
    }
}
