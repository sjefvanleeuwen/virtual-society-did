namespace VirtualSociety.VirtualSocietyDidApi.Controllers
{
    public class ServerSharedSecret
    {
        public byte[] Ciphertext { get; set; }
        public byte[] SharedSecret { get; set; }
    }
}