using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return KEM.SupportedMechanisms;
        }

        [HttpGet("client-info/{id}")]
        public KEM ClientInfo(string id)
        {
            using (KEM client = new KEM(id))
            {
                return client;
            }
        }

        [HttpGet("GenerateClientKeyPair/{id}")]
        public ClientKeyPair GenerateClientKeyPair(string id)
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
