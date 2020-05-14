using System;
using System.Linq;
using Xunit;

namespace VirtualSociety.VirtualSocietyDid.Tests
{
    public class DidTests
    {
        [Fact]
        public async void CanExtractDidUriMethodElements()
        {
            var url = new Uri("did:vsoc:gen:actor:21tDAKCERh95uGgKbJNHYp");
            var did = url.Did();
            Assert.Equal(did.Scheme, "did");
            Assert.Equal(did.Method, "vsoc");
            Assert.Equal(did.MethodNameSpace, "gen:actor");
            Assert.Equal(did.MethodIdentifier, "21tDAKCERh95uGgKbJNHYp");
        }

        [Fact]
        public async void CanCreateUniqueIdentifier()
        {
            // multiple passes, make sure no invalid character result from guid => base64 conversion.
            for (int i = 0; i < 100; i++)
            {
                var result = Did.GenerateMethodIdentifier();
                Assert.True(result.All(c => char.IsLetterOrDigit(c)));
            }
        }

        [Fact]
        public async void CanCreateDidWithNameSpace()
        {
            var did = new Did("gen:actor");
            Assert.Equal($"did:vsoc:gen:actor:{did.MethodIdentifier}", did.ToString());
        }

        [Fact]
        public async void CanCreateDidWithoutNameSpace()
        {
            var did = new Did();
            Assert.Equal($"did:vsoc:{did.MethodIdentifier}", did.ToString());
        }

        [Fact]
        public async void ShouldbeAllLowerCaseExceptMethodIdentifier()
        {
            var did = new Did("gEn:acTor","ExAMPle");
            Assert.Equal($"did:example:gen:actor:{did.MethodIdentifier}", did.ToString());
        }
    }
}
