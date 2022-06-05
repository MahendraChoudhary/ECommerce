using System.ComponentModel.DataAnnotations;

namespace ECommerce.Api.Customers.Models
{
    public class Address
    {
        public int Id { get; internal set; }

        public string HouseNumber { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        [Required()]
        public int ZipCode { get; set; }

        public string LandMark { get; set; }
    }
}