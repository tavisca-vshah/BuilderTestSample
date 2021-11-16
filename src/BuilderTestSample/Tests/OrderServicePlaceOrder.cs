using BuilderTestSample.Exceptions;
using BuilderTestSample.Model;
using BuilderTestSample.Services;
using BuilderTestSample.Tests.TestBuilders;
using FluentAssertions;
using System;
using Xunit;

namespace BuilderTestSample.Tests
{
    public class OrderServicePlaceOrder
    {
        private readonly OrderService _orderService = new ();

        [Fact]
        public void ThrowsExceptionGivenOrderWithValueAsNull()
        {
            Action placeOrder = () => _orderService.PlaceOrder(null);
            placeOrder.Should().Throw<ArgumentException>().WithMessage("order must be not null.");
        }
        [Fact]
        public void ThrowsExceptionGivenOrderWithExistingId()
        {
            Order order = new OrderBuilder().WithTestValues().WithId(123);

            Action placeOrder = () => _orderService.PlaceOrder(order);
            placeOrder.Should().Throw<ArgumentException>().WithMessage("Order ID must be 0.");
        }
        [InlineData(-10)]
        [InlineData(0)]
        [Theory]
        public void ThrowsExceptionGivenOrderWithNonPositiveTotalAmount(int totalPurchases)
        {
            Order order = new OrderBuilder().WithTestValues().WithId(0).WithTotalAmount(totalPurchases);

            Action placeOrder = () => _orderService.PlaceOrder(order);
            placeOrder.Should().Throw<ArgumentException>().WithMessage("order amount must be greater than zero (Parameter 'TotalAmount')");
        }
        [Fact]
        public void ThrowsExceptionGivenOrderWithCustomerAsNull()
        {
            Order order = new OrderBuilder().WithTestValues().WithId(0).WithCustomer(null);

            Action placeOrder = () => _orderService.PlaceOrder(order);
            placeOrder.Should().Throw<ArgumentException>().WithMessage("order must have a customer (customer is not null)");
        }

        [InlineData(-10)]
        [InlineData(0)]
        [Theory]
        public void ThrowsExceptionGivenOrderWithCustomerIdAsNegative(int customerId)
        {
            Order order = new OrderBuilder()
                .WithTestValues()
                .WithId(0)
                .WithCustomer(new CustomerBuilder().WithTestValues().WithId(customerId));

            Action placeOrder = () => _orderService.PlaceOrder(order);
            placeOrder.Should().Throw<ArgumentException>().WithMessage("customer must have an ID > 0 (Parameter 'Customer')");
        }
    }
}
