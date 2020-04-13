using Newtonsoft.Json;
using System.Collections.Generic;

namespace VirtualSociety.VirtualSocietyDid
{
    public class DidDocument
    {
        [JsonProperty("@context")]
        public string Context => "https://w3id.org/did/v1";

        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("publicKey")]
        public IEnumerable<PublicKey> PublicKey { get; set; }
        [JsonProperty("service")]
        public IEnumerable<Service> Service { get; set; }
        [JsonProperty("authentication")]
        public IEnumerable<Authentication> Authentication { get; set; }

    }

    public class PublicKey
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("owner")]
        public string Owner { get; set; }
        [JsonProperty("publicKeyPem")]
        public string PublicKeyPem { get; set; }
    }

    public class Authentication
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("publicKey")]
        public string PublicKey { get; set; }
    }

    public class Service
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("serviceEndpoint")]
        public string ServiceEndpoint { get; set; }
    }
}