using Xunit;

namespace Calculations.Tests
{
    [Collection("Customer")]
    public class CustomerDetailsTest
    {
        private readonly CustomerFixture _customerFixture;

        public CustomerDetailsTest(CustomerFixture customerFixture)
        {
            _customerFixture = customerFixture;
        }

        [Fact]
        public void GetFullName_GivenFirstAndLastName_ReturnsFullName()
        {
            Assert.Equal("Aref Karimi", _customerFixture.Cust.GetFullName("Aref", "Karimi"));
        }
    }
}
