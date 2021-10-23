using System;
using Sander0542.Tools.Templates.Common.Files.Common;

namespace Sander0542.Tools.Templates.Common.Files.DotNet
{
    public class CustomFile : FileBase
    {
        private readonly string _content;

        public CustomFile(string content)
        {
            _content = content;
        }

        public override string[] Lines => _content.Split(Environment.NewLine);
    }
}
