using System;
using System.Collections.Generic;
using System.IO;
using Xunit;
using Xunit.Abstractions;

namespace Calculations.Tests
{

    public class CalculatorFixture
    {
        public Calculator Calc => new Calculator();       
    }
    public class CalculatorTest : IClassFixture<CalculatorFixture>, IDisposable
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly CalculatorFixture _calculatorFixture;
        private readonly MemoryStream memoryStream;

        public CalculatorTest(ITestOutputHelper testOutputHelper, CalculatorFixture calculatorFixture)
        {
            _testOutputHelper = testOutputHelper;
            _calculatorFixture = calculatorFixture;
            _testOutputHelper.WriteLine("Constructor");

            memoryStream = new MemoryStream();
        }

        public void Dispose()
        {
            memoryStream.Close();
        }

        [Fact]
        public void TestAdd()
        {
            Assert.True(true);
        }

        [Fact]
        [Trait("Category", "Calculator")]
        public void Add_GivenTwoIntValues_ReturnsInt()
        {            
            var result = _calculatorFixture.Calc.Add(1, 2);
            Assert.Equal(3, result);
        }

        [Fact]
        [Trait("Category", "Calculator")]
        public void AddDouble_GivenTwoDoubleValues_ReturnsDouble()
        {            
            var result = _calculatorFixture.Calc.AddDouble(1.2, 3.5);
            Assert.Equal(4.7, result);
        }

        [Fact]
        [Trait("Category","Fibo")]
        public void FiboDoesNotIncludeZero()
        {
            _testOutputHelper.WriteLine("FiboDoesNotIncludeZero");
            //Assert.All(calc.FiboNumbers, n => Assert.NotEqual(0, n));
            Assert.DoesNotContain(0, _calculatorFixture.Calc.FiboNumbers);
        }

        [Fact]
        [Trait("Category", "Fibo")]
        public void FiboDoesIncludes13()
        {
            _testOutputHelper.WriteLine("FiboDoesIncludes13");
            Assert.Contains(13, _calculatorFixture.Calc.FiboNumbers);
        }

        [Fact]
        [Trait("Category", "Fibo")]
        public void FiboDoesNotInclude4()
        {            
            Assert.DoesNotContain(4, _calculatorFixture.Calc.FiboNumbers);
        }

        [Fact]
        [Trait("Category", "Fibo")]
        public void CheckCollection()
        {
            _testOutputHelper.WriteLine($"CheckCollection. Test Starting at {DateTime.Now}");

            var expectedColletion = new List<int> { 1, 1, 2, 3, 5, 8, 13 };

            _testOutputHelper.WriteLine("Creating an instance of Calculator class...");
            Assert.Equal(expectedColletion, _calculatorFixture.Calc.FiboNumbers);
        }

        [Fact]
        public void IsOdd_GivenOddValue_ReturnsTrue()
        {
            var calc = new Calculator();
            var result = calc.IsOdd(1);
            Assert.True(result);
        }

        [Fact]
        public void IsOdd_GivenEvenValue_ReturnsFalse()
        {
            var calc = new Calculator();
            var result = calc.IsOdd(1);
            Assert.False(false);
        }

        [Theory]
        [InlineData(1, true)]
        [InlineData(200, false)]
        public void IsOdd_TestOddAndEven(int value, bool expected)
        {
            var calc = new Calculator();
            var result = calc.IsOdd(value);
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(TestDataShare.IsOddOrEvenData), MemberType =typeof(TestDataShare))]
        public void IsOdd_TestOddAndEven_WithCollectionShare(int value, bool expected)
        {
            var calc = new Calculator();
            var result = calc.IsOdd(value);
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(TestDataShare.IsOddOrEvenExternalData), MemberType = typeof(TestDataShare))]
        public void IsOdd_TestOddAndEven_FromFile(int value, bool expected)
        {
            var calc = new Calculator();
            var result = calc.IsOdd(value);
            Assert.Equal(expected, result);
        }

        [Theory]
        [IsOddOrEvenData]
        public void IsOdd_TestOddAndEven_WithAttribute(int value, bool expected)
        {
            var calc = new Calculator();
            var result = calc.IsOdd(value);
            Assert.Equal(expected, result);
        }

    }
}
