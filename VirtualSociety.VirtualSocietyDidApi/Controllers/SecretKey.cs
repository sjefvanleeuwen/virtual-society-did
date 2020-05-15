namespace Vs.Did.OpenApi.Controllers
{
    public class SecretKey
    {
        public string KeyMechanism { get; set; }
        public byte[] CipherText { get; set; }
        public byte[] Key { get; set; }
    }
}
