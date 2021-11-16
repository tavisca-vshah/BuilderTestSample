using BuilderTestSample.Model;

namespace BuilderTestSample.Tests.TestBuilders
{
    /// <summary>
    /// Reference: https://ardalis.com/improve-tests-with-the-builder-pattern-for-test-data
    /// </summary>
    public class OrderBuilder
    {
        private Order _order = new ();

        public OrderBuilder WithId(int id)
        {
            _order.Id = id;
            return this;
        }

        public OrderBuilder WithCustomer(Customer customer)
        {
            _order.Customer = customer != null ? (Customer)customer.Clone() : null;
            return this;
        }
        public OrderBuilder WithTotalAmount(decimal totalAmount)
        {
            _order.TotalAmount = totalAmount;
            return this;
        }
        public OrderBuilder WithEnabledExpediteture()
        {
            _order.IsExpedited = true;
            return this;
        }
        public OrderBuilder WithDisabledExpediteture()
        {
            _order.IsExpedited = false;
            return this;
        }
        public OrderBuilder WithTestValues()
        {
            _order = new OrderBuilder()
                .WithId(111)
                .WithTotalAmount(1000m)
                .WithCustomer(new CustomerBuilder().WithTestValues())
                .WithEnabledExpediteture();
            return this;
        }

        public static implicit operator Order(OrderBuilder instance)
        {
            return instance.Build();
        }
        public Order Build()
        {
            return (Order)_order.Clone();
        }
    }
}
