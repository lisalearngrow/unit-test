using Xunit;
using System;
using TestService;

namespace TestService.Tests
{
    public class TestService_IsPrimeShould
    {
        public class SwapService_IsSwappedRight {

            private SwapsService _swapsService;

            public SwapService_IsSwappedRight() {
                this._swapsService = new SwapsService();
            }

            /// <summary>
            /// 5,5,5,5,5 should result in 0,5,5
            /// </summary>
            [Fact]
            public void AreSwapResultsCorrect()
            {

                int[] a = new int[] { 5, 5, 5, 5, 5 };
                var result = _swapsService.countTheSwaps(a);
                var expectedResult = new SwapInfo(0,5,5);

                Assert.True(expectedResult.Equals(result));

            }

        }

        //public class PrimeService_IsPrimeShould
        //{
        //    private SwapsService _primeService;

        //    public PrimeService_IsPrimeShould()
        //    {
        //        this._primeService = new SwapsService();
        //    }

        //    [Fact]
        //    public void IsPrime_InputIs1_ReturnFalse()
        //    {
        //        var primeService = new SwapsService();
        //        bool result = primeService.IsPrime(1);

        //        Assert.False(result, "1 should not be prime");
        //    }

        //    [Theory]
        //    [InlineData(-1)]
        //    [InlineData(0)]
        //    [InlineData(1)]
        //    public void IsPrime_ValuesLessThan2_ReturnFalse(int value)
        //    {
        //        var result = _primeService.IsPrime(value);

        //        Assert.False(result, $"{value} should not be prime");
        //    }
        //}
    }
}