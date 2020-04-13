using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace VirtualSociety.VirtualSocietyOqs.Tests
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
