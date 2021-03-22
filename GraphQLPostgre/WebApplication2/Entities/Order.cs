using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebApplication2.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public string Currency { get; set; }
        public DateTime TS { get; set; }
        public int CustomerId { get; set; }
        [JsonIgnore]
        public Customer Customer { get; set; }
    }
}
