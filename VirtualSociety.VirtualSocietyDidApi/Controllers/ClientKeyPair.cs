namespace Vs.Did.OpenApi.Controllers
{
    public class ClientKeyPair
    {
        public ClientKeyPair(byte[] publicKey, byte[] privateKey)
        {
            PublicKey = publicKey;
            PrivateKey = privateKey;
        }

        public ClientKeyPair() { }

        public byte[] PublicKey { get; set; }
        public byte[] PrivateKey { get; set; }
    }
}