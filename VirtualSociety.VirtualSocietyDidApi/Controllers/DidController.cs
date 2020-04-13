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
    }
}
