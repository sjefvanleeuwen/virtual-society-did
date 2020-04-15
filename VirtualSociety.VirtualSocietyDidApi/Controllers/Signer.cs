namespace VirtualSociety.VirtualSocietyDidApi.Controllers
{
    public class Signer
    {
        /// <summary>
        /// Gets or sets the message to sign.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        string Message { get; set; }
        /// <summary>
        /// Gets or sets the key mechanism.
        /// </summary>
        /// <value>
        /// The key mechanism.
        /// </value>
        string KeyMechanism { get; set; }
        /// <summary>
        /// Signers public key.
        /// </summary>
        /// <value>
        /// The public key.
        /// </value>
        byte[] PublicKey { get; set; }
        /// <summary>
        /// Signers private key.
        /// </summary>
        /// <value>
        /// The private key.
        /// </value>
        byte[] PrivateKey { get; set; }
        /// <summary>
        /// Gets or sets the signature.
        /// </summary>
        /// <value>
        /// The signature.
        /// </value>
        byte[] Signature { get; set; }
    }
}
