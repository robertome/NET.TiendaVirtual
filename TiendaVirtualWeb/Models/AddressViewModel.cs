using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TiendaVirtualWeb.Data;

namespace TiendaVirtualWeb.Models
{
    public class AddressViewModel
    {
        [Required]
        [MaxLength(250)]
        public string Street { get; set; }

        [Required]
        [MaxLength(50)]
        public string ZipCode { get; set; }

        [Required]
        [MaxLength(100)]
        public string City { get; set; }

        [Required]
        [MaxLength(50)]
        public string State { get; set; }

        [Required]
        [MaxLength(50)]
        public string Country { get; set; }

        public Address ToAddress()
        {
            return new Address
            {
                Street = Street,
                City = City,
                Country = Country,
                ZipCode = ZipCode,
                State = State,
            };
        }
    }
}