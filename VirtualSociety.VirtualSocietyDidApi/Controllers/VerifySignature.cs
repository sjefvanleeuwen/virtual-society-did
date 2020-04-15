namespace VirtualSociety.VirtualSocietyDidApi.Controllers
{
    public class VerifySignature
    {
        /// <summary>
        /// Gets or sets the signing mechanism.
        /// </summary>
        /// <value>
        /// The sig mechanism.
        /// </value>
        public string SigMechanism { get; set; }
        /// <summary>
        /// Gets or sets the message to be verified.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message { get; set; }
        /// <summary>
        /// Gets or sets the signature used in verification.
        /// </summary>
        /// <value>
        /// The signature.
        /// </value>
        public byte[] Signature { get; set; }
        /// <summary>
        /// Gets or sets the public key used in verification.
        /// </summary>
        /// <value>
        /// The public key.
        /// </value>
        public byte[] PublicKey { get; set; }

    }
}
