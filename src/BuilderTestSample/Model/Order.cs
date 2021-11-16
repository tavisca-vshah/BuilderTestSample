using Newtonsoft.Json;
using System;

namespace BuilderTestSample.Model
{
    public class Order: ICloneable
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public decimal TotalAmount { get; set; }
        public bool IsExpedited { get; set; }

        public object Clone()
        {
            var serialized = JsonConvert.SerializeObject(this);
            return JsonConvert.DeserializeObject<Order>(serialized);
        }
    }
}
