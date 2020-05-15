namespace Vs.Did.OpenApi.Controllers
{
    public class VerifierSignature
    {
        public string SigMechanism { get; set; }
        public byte[] PublicKey { get; set; }
        public byte[] Signature { get; set; }
    }
}
