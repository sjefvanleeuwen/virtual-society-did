using Xunit;

namespace Vs.Did.Oqs.Tests
{
    public class OqsTests
    {
        [Fact]
        public void CanDiscoverAllKeyEncapsulationMechanisms()
        {
            Assert.True(KEM.SupportedMechanisms.Count == 61);
        }
    }
}
