using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TiendaVirtualWeb.Data;

namespace TiendaVirtualWeb.Models
{
    public class BuyerViewModel
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(250)]
        public string Surname { get; set; }

        [Required]
        [MaxLength(250)]
        public string Email { get; set; }

        public Buyer ToBuyer()
        {
            return new Buyer
            {
                Name = Name,
                Surname = Surname,
                Email = Email
            };
        }
    }
}