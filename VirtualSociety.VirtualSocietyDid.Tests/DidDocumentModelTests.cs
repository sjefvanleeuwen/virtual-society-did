using Newtonsoft.Json;
using System.Collections.Generic;
using Xunit;

namespace VirtualSociety.VirtualSocietyDid.Tests
{
    public class DidDocumentModelTests
    {
        [Fact]
        public void ShouldCreateMinimalSelfManagedDidDocument()
        {
            var doc = new DidDocument
            {
                Id = "did:example:123456789abcdefghi",
                PublicKey = new List<PublicKey>()
                {
                    new PublicKey()
                    {
                        Id = "did:example:123456789abcdefghi#keys-1",
                        Type = "RsaVerificationKey2018",
                        Owner = "did:example:123456789abcdefghi",
                        PublicKeyPem = "-----BEGIN PUBLIC KEY...END PUBLIC KEY-----\r\n"
                    }
                },
                Authentication = new List<Authentication>()
                {
                    new Authentication()
                    {
                        Type = "RsaSignatureAuthentication2018",
                        PublicKey = "did:example:123456789abcdefghi#keys-1"
                    }
                },
                Service = new List<Service>()
                {
                    new Service()
                    {
                        Type="ExampleService",
                        ServiceEndpoint = "https://example.com/endpoint/8377464"
                    }
                }
            };

            var result = JsonConvert.SerializeObject(doc);
            Assert.True(result == "{\"@context\":\"https://w3id.org/did/v1\",\"id\":\"did:example:123456789abcdefghi\",\"publicKey\":[{\"id\":\"did:example:123456789abcdefghi#keys-1\",\"type\":\"RsaVerificationKey2018\",\"owner\":\"did:example:123456789abcdefghi\",\"publicKeyPem\":\"-----BEGIN PUBLIC KEY...END PUBLIC KEY-----\\r\\n\"}],\"service\":[{\"type\":\"ExampleService\",\"serviceEndpoint\":\"https://example.com/endpoint/8377464\"}],\"authentication\":[{\"type\":\"RsaSignatureAuthentication2018\",\"publicKey\":\"did:example:123456789abcdefghi#keys-1\"}]}");
        }
    }
}
