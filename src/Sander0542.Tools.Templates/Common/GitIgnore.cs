using System;
using System.Linq;
using System.Net.Http;

namespace Sander0542.Tools.Templates.Common
{
    public static class GitIgnore
    {
        public static string Load(params string[] files)
        {
            using var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://raw.githubusercontent.com/github/gitignore/master/");

            return files.Aggregate(string.Empty, (current, file) => current + httpClient.GetStringAsync(new Uri($"{file}.gitignore")).Result + Environment.NewLine);
        }
    }
}
