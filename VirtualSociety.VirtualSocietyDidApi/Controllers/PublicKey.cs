using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VirtualSociety.VirtualSocietyDidApi.Controllers
{
    public class PublicKey
    {
        public string KeyMechanism { get; set; }
        public byte[] Key { get; set; }
    }
}
