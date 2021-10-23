using System.IO;

namespace Sander0542.Tools.Templates.Common.Files.Common
{
    public abstract class FileBase
    {
        public abstract string[] Lines { get; }

        public void Write(string location)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(location));
            File.WriteAllLines(location, Lines);
        }
    }
}
