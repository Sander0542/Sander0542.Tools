namespace Sander0542.Tools.Templates.Common
{
    public abstract class TemplateBuilder
    {
        public abstract string Name { get; }

        public abstract bool Build();
    }
}
