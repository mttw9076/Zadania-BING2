using Xunit;
using CalculatorApp;

namespace CalculatorTests
{
    public class CalculatorTests
    {
        private readonly Calculator _calc = new();

        [Fact]
        public void Add_ReturnsCorrectSum()
        {
            var result = _calc.Add(2, 3);
            Assert.Equal(5, result);
        }

        [Fact]
        public void Subtract_ReturnsCorrectDifference()
        {
            var result = _calc.Subtract(10, 4);
            Assert.Equal(6, result);
        }

        [Fact]
        public void Multiply_ReturnsCorrectProduct()
        {
            var result = _calc.Multiply(3, 4);
            Assert.Equal(12, result);
        }

        [Fact]
        public void Divide_ReturnsCorrectQuotient()
        {
            var result = _calc.Divide(10, 2);
            Assert.Equal(5, result);
        }

        [Fact]
        public void Divide_ByZero_ThrowsException()
        {
            Assert.Throws<DivideByZeroException>(() => _calc.Divide(10, 0));
        }
    }
}
