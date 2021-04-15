using Xunit;
using System;
using TestService;

namespace TestService.Tests
{
    public class TestService_IsPrimeShould
    {
        public class PrimeService_IsPrimeShould
        {
            [Fact]
            public void IsPrime_InputIs1_ReturnFalse()
            {
                var primeService = new TestService.PrimeService();
                bool result = primeService.IsPrime(1);

                Assert.False(result, "1 should not be prime");
            }
        }
    }
}
