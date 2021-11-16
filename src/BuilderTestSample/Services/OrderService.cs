using Ardalis.GuardClauses;
using BuilderTestSample.Exceptions;
using BuilderTestSample.Model;

namespace BuilderTestSample.Services
{
    public class OrderService
    {
        public void PlaceOrder(Order order)
        {
            ValidateOrder(order);

            ExpediteOrder(order);

            AddOrderToCustomerHistory(order);
        }

        private void ValidateOrder(Order order)
        {
            // throw InvalidOrderException unless otherwise noted.

            Guard.Against.Null(order, nameof(Order), "order must be not null.");
            Guard.Against.AgainstExpression( (id) => id == 0, order.Id, "Order ID must be 0.");
            Guard.Against.NegativeOrZero(order.TotalAmount, nameof(Order.TotalAmount), "order amount must be greater than zero");
            Guard.Against.Null(order.Customer, nameof(Order.Customer), "order must have a customer (customer is not null)");

            ValidateCustomer(order.Customer);
        }

        private void ValidateCustomer(Customer customer)
        {
            // throw InvalidCustomerException unless otherwise noted
            // create a CustomerBuilder to implement the tests for these scenarios

            Guard.Against.NegativeOrZero(customer.Id, nameof(Order.Customer), "customer must have an ID > 0");

            // TODO: customer must have an ID > 0
            // TODO: customer must have an address (it is not null)
            // TODO: customer must have a first and last name
            // TODO: customer must have credit rating > 200 (otherwise throw InsufficientCreditException)
            // TODO: customer must have total purchases >= 0

            ValidateAddress(customer.HomeAddress);
        }

        private void ValidateAddress(Address homeAddress)
        {
            // throw InvalidAddressException unless otherwise noted
            // create an AddressBuilder to implement the tests for these scenarios

            // TODO: street1 is required (not null or empty)
            // TODO: city is required (not null or empty)
            // TODO: state is required (not null or empty)
            // TODO: postalcode is required (not null or empty)
            // TODO: country is required (not null or empty)
        }

        private void ExpediteOrder(Order order)
        {
            // TODO: if customer's total purchases > 5000 and credit rating > 500 set IsExpedited to true
        }

        private void AddOrderToCustomerHistory(Order order)
        {
            // TODO: add the order to the customer

            // TODO: update the customer's total purchases property
        }
    }
}
