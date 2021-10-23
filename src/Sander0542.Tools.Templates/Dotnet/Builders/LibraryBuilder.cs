using System;
using System.IO;
using System.Text.RegularExpressions;
using McMaster.Extensions.CommandLineUtils;
using Sander0542.Tools.Common;
using Sander0542.Tools.Templates.Common;
using Sander0542.Tools.Templates.Common.Files.DotNet;

namespace Sander0542.Tools.Templates.Dotnet.Builders
{
    public class LibraryBuilder : TemplateBuilder
    {
        private const string SolutionNamePattern = @"^[a-zA-Z][a-zA-Z0-9.]*[a-zA-Z0-9]$";
        private const string ProjectNamePattern = @"^[a-zA-Z][a-zA-Z0-9.]*[a-zA-Z0-9]$";

        public override string Name => "Library";

        public override bool Build()
        {
#if DEBUG
            var solutionName = "Sander0542.Dev";
            var projectName = "Sander0542.Dev.Lib";
            var projectDescription = "Simple library created with Sander0542 Tools";
            var srcFramework = "netstandard2.1";
            var testsFramework = "net5.0";
            var gitHubActions = true;
            var gitHubUsername = "Sander0542";
#else
            var solutionName = AskSolutionName();
            var projectName = AskProjectName(solutionName);
            var projectDescription = AskProjectDescription();
            var Srcframework = AskFramework("netstandard2.1");
            var Testsframework = AskFramework("net5.0");
            var gitHubActions = AskGitHubActions();
            var gitHubUsername = AskGitHubUsername();
#endif
            var testsProjectName = $"{projectName}.Tests";

            var solutionDir = Path.Combine(Directory.GetCurrentDirectory(), solutionName);
            var srcDir = Path.Combine(solutionDir, "src");
            var testsDir = Path.Combine(solutionDir, "tests");

            var srcProjectDir = $"src/{projectName}";
            var testsProjectsDir = $"tests/{testsProjectName}";

            try
            {
                if (Directory.Exists(solutionDir))
                {
#if DEBUG
                    Directory.Delete(solutionDir, true);
#else
                    Output.WriteLine("Directory already exists");
                    return false;
#endif
                }
                Directory.CreateDirectory(solutionDir);

                // Create Solution
                Terminal.Run("dotnet", "new sln", solutionDir);
                new GitVersion().Write(Path.Combine(solutionDir, "GitVersion.yml"));
                new DotnetTools().Write(Path.Combine(solutionDir, "dotnet-tools.json"));
                new RootProps(gitHubUsername, "", gitHubUsername, solutionName).Write(Path.Combine(solutionDir, "root.props"));
                new CustomFile(GitIgnore.Load("VisualStudio", "Global/JetBrains")).Write(Path.Combine(solutionDir, ".gitignore"));

                // Create src
                new SrcProps(projectDescription, srcFramework).Write(Path.Combine(srcDir, "src.props"));
                new SrcProject().Write(Path.Combine(solutionDir, srcProjectDir, $"{projectName}.csproj"));
                Terminal.Run("dotnet", $"sln add -s src \"{srcProjectDir}\"", solutionDir);

                // Create tests
                new TestsProps(testsFramework).Write(Path.Combine(testsDir, "tests.props"));
                new TestsProject().Write(Path.Combine(solutionDir, testsProjectsDir, $"{testsProjectName}.csproj"));
                Terminal.Run("dotnet", $"sln add -s tests \"{testsProjectsDir}\"", solutionDir);

                return true;
            }
            catch (Exception)
            {
                Directory.Delete(solutionDir, true);
                throw;
            }
        }

        private static string AskSolutionName()
        {
            while (true)
            {
                var name = Prompt.GetString("Solution Name:", promptColor: ConsoleColor.Green);

                if (Regex.Match(name ?? "", SolutionNamePattern).Success) return name;

                Output.WriteLine("Invalid Solution Name, please enter a valid name.");
            }
        }

        private static string AskProjectName(string solutionName)
        {
            while (true)
            {
                var name = Prompt.GetString("Project Name:", solutionName, ConsoleColor.Green);

                if (Regex.Match(name ?? "", ProjectNamePattern).Success) return name;

                Output.WriteLine("Invalid Project Name, please enter a valid name.");
            }
        }

        private static string AskProjectDescription()
        {
            while (true)
            {
                var framework = Prompt.GetString("Project Description:", promptColor: ConsoleColor.Green);

                if (!string.IsNullOrWhiteSpace(framework)) return framework;

                Output.WriteLine("Invalid description, please enter a valid description.");
            }
        }

        private static string AskFramework(string defaultFramework)
        {
            while (true)
            {
                var framework = Prompt.GetString("Framework:", defaultFramework, ConsoleColor.Green);

                if (!string.IsNullOrWhiteSpace(framework)) return framework;

                Output.WriteLine("Invalid Project Name, please enter a valid name.");
            }
        }

        private static bool AskGitHubActions()
        {
            return Prompt.GetYesNo("GitHub Actions:", true, ConsoleColor.Green);
        }

        private static string AskGitHubUsername()
        {
            while (true)
            {
                var framework = Prompt.GetString("GitHub Username:", promptColor: ConsoleColor.Green);

                if (!string.IsNullOrWhiteSpace(framework)) return framework;

                Output.WriteLine("Invalid username, please enter a valid username.");
            }
        }
    }
}
