using BuilderTestSample.Model;
using System.Collections.Generic;

namespace BuilderTestSample.Tests.TestBuilders
{
    public class CustomerBuilder
    {
        private int _id;
        private int _creditRating;
        private decimal _totalPurchases;
        private string _firstName;
        private string _lastName;
        private Address _homeAddress;
        private readonly List<Order> _orderHistory = new();
        public CustomerBuilder WithId(int id)
        {
            _id = id;
            return this;
        }
        public CustomerBuilder WithCreditRating(int creditRating)
        {
            _creditRating = creditRating;
            return this;
        }
        public CustomerBuilder WithFirstName(string firstName)
        {
            _firstName = firstName;
            return this;
        }
        public CustomerBuilder WithLastName(string lastName)
        {
            _lastName = lastName;
            return this;
        }
        public CustomerBuilder WithHomeAddress(Address homeAddress)
        {
            _homeAddress = homeAddress;
            return this;
        }
        public CustomerBuilder WithTotalPurchases(decimal totalPurchases)
        {
            _totalPurchases = totalPurchases;
            return this;
        }
        public CustomerBuilder WithOrder(Order order)
        {
            var newOrder = (Order)order.Clone();
            _orderHistory.Add(newOrder);
            return this;
        }
        public CustomerBuilder WithOrderHistory(List<Order> orderHistory)
        {
            var newOrderHistory = new List<Order>(orderHistory);
            _orderHistory.AddRange(newOrderHistory);
            return this;
        }
        public CustomerBuilder WithTestValues()
        {
            _id = 12345;
            _firstName = "Allie";
            _lastName = "Grater";
            _creditRating = 9;
            _totalPurchases = 1000m;
            _homeAddress = new AddressBuilder().WithTestValues();
            return this;
        }
        public static implicit operator Customer(CustomerBuilder instance)
        {
            return instance.Build();
        }
        public Customer Build()
        {
            return new Customer(_id)
            {
                FirstName = _firstName,
                LastName = _lastName,
                CreditRating = _creditRating,
                HomeAddress = _homeAddress,
                TotalPurchases = _totalPurchases
            };
        }

    }
}
