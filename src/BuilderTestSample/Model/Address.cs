using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderTestSample.Model
{
    public class Address: ICloneable
    {
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string Street3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }

        public object Clone()
        {
            var serialized = JsonConvert.SerializeObject(this);
            return JsonConvert.DeserializeObject<Address>(serialized);
        }
    }
}
