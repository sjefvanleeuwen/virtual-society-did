namespace Vs.Did.Abstractions
{
    public class MethodNamespace : IMethodNamespace
    {
        public string Namespace { get; }

        public MethodNamespace(string @namespace)
        {
            if (string.IsNullOrEmpty(@namespace))
            {
                throw new System.ArgumentException("a namespace for vsoc methods should be provided", nameof(@namespace));
            }

            Namespace = @namespace;
        }
    }
}