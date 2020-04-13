namespace VirtualSociety.VirtualSocietyDidApi.Controllers
{
    public class ClientKeyPair
    {
        public ClientKeyPair(byte[] publicKey, byte[] privateKey)
        {
            PublicKey = publicKey;
            PrivateKey = privateKey;
        }

        public byte[] PublicKey { get; }
        public byte[] PrivateKey { get; }
    }
}