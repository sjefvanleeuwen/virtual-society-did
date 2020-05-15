namespace Vs.Did.Abstractions.Interfaces
{
    public interface IDid
    {
        string Method { get; set; }
        string MethodIdentifier { get; set; }
        string MethodNameSpace { get; set; }
        string Scheme { get; }

        string ToString();
    }
}