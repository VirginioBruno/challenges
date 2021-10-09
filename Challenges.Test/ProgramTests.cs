using Xunit;

namespace Challenges.Test
{
    public class ProgramTests
    {
        [Fact]
        
        public void ShouldCheckIfAllNumbersIsPrime()
        {
            var array = new[] { 2, 3, 5, 7, 11, 13, 67, 89, 107, 113, 71};

            foreach (var item in array)
            {
                var isPrime = Program.PrimeNumber(item);
                Assert.True(isPrime);
            }
        }

        [Fact]

        public void ShouldCheckIfNoneNumbersIsPrime()
        {
            var array = new[] { 4, 6, 8, 9, 32, 42, 58, 62, 114, 95, 102 };

            foreach (var item in array)
            {
                var isPrime = Program.PrimeNumber(item);
                Assert.False(isPrime);
            }
        }

        [Fact]

        public void ShouldReturnFalseWhenTheNumberIsNegativeOrZero()
        {
            var array = new[] { -1, -6, 0 };

            foreach (var item in array)
            {
                var isPrime = Program.PrimeNumber(item);
                Assert.False(isPrime);
            }
        }
    }
}
