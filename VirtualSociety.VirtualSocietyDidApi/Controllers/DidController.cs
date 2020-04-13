using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VirtualSociety.VirtualSocietyOqs;

namespace VirtualSociety.VirtualSocietyDidApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DidController : ControllerBase
    {
        private readonly ILogger<DidController> _logger;

        public DidController(ILogger<DidController> logger)
        {
            _logger = logger;
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
