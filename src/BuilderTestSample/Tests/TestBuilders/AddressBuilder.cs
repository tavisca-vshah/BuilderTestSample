using BuilderTestSample.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderTestSample.Tests.TestBuilders
{
    public class AddressBuilder
    {
        private Address _instance = new();
        public AddressBuilder WithStreet1(string street1)
        {
            _instance.Street1 = street1;
            return this;
        }
        public AddressBuilder WithStreet2(string street2)
        {
            _instance.Street2 = street2;
            return this;
        }
        public AddressBuilder WithStreet3(string street3)
        {
            _instance.Street3 = street3;
            return this;
        }
        public AddressBuilder WithCity(string city)
        {
            _instance.City = city;
            return this;
        }
        public AddressBuilder WithState(string state)
        {
            _instance.State = state;
            return this;
        }
        public AddressBuilder WithPostalCode(string postalCode)
        {
            _instance.PostalCode = postalCode;
            return this;
        }
        public AddressBuilder WithCountry(string country)
        {
            _instance.Country = country;
            return this;
        }
        public AddressBuilder WithTestValues()
        {
            _instance = new AddressBuilder()
                .WithStreet1("1972")
                .WithStreet2("Meadow")
                .WithStreet3("View Drive")
                .WithCity("MACHIAS")
                .WithPostalCode("14101")
                .WithState("New York")
                .WithCountry("USA");

            return this;
        }
        public static implicit operator Address(AddressBuilder instance)
        {
            return instance.Build();
        }
        public Address Build()
        {
            return (Address)_instance.Clone();
        }

    }
}
