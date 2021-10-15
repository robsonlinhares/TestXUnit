using System;
using Xunit;

namespace Calculations.Tests
{
    [Collection("Customer")]
    public class CustomerTest
    {
        private readonly CustomerFixture _customerFixture;

        public CustomerTest(CustomerFixture customerFixture)
        {
            _customerFixture = customerFixture;
        }

        [Fact]
        [Trait("Category", "Customer")]
        public void CheckNameNotEmpty()
        {            
            Assert.NotNull(_customerFixture.Cust.Name);
            Assert.False(string.IsNullOrEmpty(_customerFixture.Cust.Name));
        }

        [Fact]
        [Trait("Category", "Customer")]
        public void CheckLegitimateForDiscount()
        {            
            Assert.InRange(_customerFixture.Cust.Age, 25, 40);
        }

        [Fact]
        [Trait("Category", "Customer")]
        public void GetOrdersByNameNotNull()
        {            
            // Assert.Throws<ArgumentException>(() => customer.GetOrdersByName(null));
            var exceptionDetails = Assert.Throws<ArgumentException>(() => _customerFixture.Cust.GetOrdersByName(""));
            Assert.Equal("Hello", exceptionDetails.Message);
        }

        [Fact]
        [Trait("Category", "Fibo")]
        public void LoyalCustomerForOrdersG100()
        {
            var customer = CustomerFactory.CreateCustomerInstance(102);
            //var loyalCustomer = Assert.IsType<LoyalCustomer>(customer);
            //Assert.Equal(10, loyalCustomer.Discount);
            Assert.IsType<LoyalCustomer>(customer);
          
        }
    }
}
