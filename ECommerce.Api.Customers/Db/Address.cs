using System;

namespace ECommerce.Api.Customers.Db
{
    public class Address
    {
        public int Id { get; set; }

        public string HouseNumber { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public int ZipCode { get; set; }

        public string LandMark { get; set; }

        public Guid CustomerId { get; set; }
    }
}
