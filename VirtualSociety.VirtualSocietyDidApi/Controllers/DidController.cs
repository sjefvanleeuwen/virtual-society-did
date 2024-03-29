﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QRCoder;
using Vs.Did.Oqs;

namespace Vs.Did.OpenApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DidController : ControllerBase
    {
        public DidController()
        {
        }

        [HttpPost("verify-signature")]
        public async Task<bool> VerifySignature([FromBody] VerifySignature message)
        {
            using (var verifier = new Sig(message.SigMechanism))
            {
                byte[] messageBytes = new System.Text.UTF8Encoding().GetBytes(message.Message);
                return verifier.verify(messageBytes, message.Signature, message.PublicKey);
            }
        }

        [HttpPost("sign")]
        public async Task<VerifierSignature> Sign([FromBody] SignMessage message)
        {
            using (Sig sign = new Sig(message.SigMechanism))
            {
                byte[] clientMessage = new System.Text.UTF8Encoding().GetBytes(message.Message);
                // Generate the signing key pair
                byte[] public_key;
                byte[] secret_key;
                sign.keypair(out public_key, out secret_key);
                // Sign the message
                byte[] signature;
                sign.sign(out signature, clientMessage, secret_key);
                return new VerifierSignature() { SigMechanism = message.SigMechanism, PublicKey = public_key, Signature = signature };
            }
        }

        [HttpPost("qr-code")]
        public async Task<string> GetQrCode([NakedBody] string payload)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);
            SvgQRCode qrCodePng = new SvgQRCode(qrCodeData);
            return qrCodePng.GetGraphic(new System.Drawing.Size(320, 320));
            /*
            switch (qrType)
            {
                case QrType.Png:
                    PngByteQRCode qrCodePng = new PngByteQRCode(qrCodeData);
                    return qrCodePng.GetGraphic(20);
                case QrType.Svg:
                    SvgQRCode qrCodeSvg = new SvgQRCode(qrCodeData);
                    return qrCodeSvg.GetGraphic(20);
                default:
                    throw new NotImplementedException();
            }
            */
        }

        [HttpPost("encapsulate-shared-secret")]
        public async Task<ServerSharedSecret> EncapsulateSharedSecret([FromBody] PublicKey publicKey)
        {
            // The server generates and encapsulates the shared secret
            byte[] ciphertext;
            byte[] serverSharedSecret;
            using (KEM server = new KEM(publicKey.KeyMechanism))
            {
                byte[] secret_key;
                server.encaps(out ciphertext, out serverSharedSecret, publicKey.Key);
                return new ServerSharedSecret() { Ciphertext = ciphertext, SharedSecret = serverSharedSecret };
            }
        }

        [HttpPost("decapsulate-shared-secret")]
        public async Task<ClientSharedSecret> DecapsulateSharedSecret([FromBody] SecretKey secretKey)
        {
            // The client decapsulates the shared secret
            byte[] clientSharedSecret;
            using (KEM client = new KEM(secretKey.KeyMechanism))
            {
                byte[] secret_key;
                client.decaps(out clientSharedSecret, secretKey.CipherText, secretKey.Key);
                return new ClientSharedSecret() { SharedSecret = clientSharedSecret };
            }
        }

        [HttpGet("key-mechanisms")]
        public async Task<IEnumerable<string>> GetKeyMechanisms()
        {
            return KEM.SupportedMechanisms;
        }

        [HttpGet("sig-mechanisms")]
        public async Task<IEnumerable<string>> GetSigMechanisms()
        {
            return Sig.EnabledMechanisms;
        }

        [HttpGet("sig-info/{id}")]
        public async Task<Sig> SigInfo(string id)
        {
            using (Sig Signer = new Sig(id))
            {
                return Signer;
            }
        }

        [HttpGet("key-info/{id}")]
        public async Task<KEM> KeyInfo(string id)
        {
            using (KEM client = new KEM(id))
            {
                return client;
            }
        }

        [HttpGet("GenerateClientKeyPair/{id}")]
        public async Task<ClientKeyPair> GenerateClientKeyPair(string id)
        {
            using (KEM client = new KEM(id),
                       server = new KEM(id))
            {
                byte[] public_key;
                byte[] secret_key;
                client.keypair(out public_key, out secret_key);
                return new ClientKeyPair(public_key, secret_key);
            }
        }
    }
}
