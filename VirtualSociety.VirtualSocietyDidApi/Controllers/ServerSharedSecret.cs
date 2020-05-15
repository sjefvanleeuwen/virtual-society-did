namespace Vs.Did.OpenApi.Controllers
{
    public class ServerSharedSecret
    {
        public byte[] Ciphertext { get; set; }
        public byte[] SharedSecret { get; set; }
    }
}