using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TiendaVirtualWeb.Data;

namespace TiendaVirtualWeb.Models
{
    public class OrderViewModel
    {
        private DateTimeOffset date = DateTimeOffset.Now;

        [DataType(DataType.DateTime)]
        public DateTimeOffset Date => date;

        public CartViewModel CartViewModel { get; set; }

        public AddressViewModel Address { get; set; }

        public BuyerViewModel Buyer { get; set; }

        public List<CartItemViewModel> Items { get { return CartViewModel.Items; } }

        [DataType(DataType.Currency)]
        public decimal Total { get { return CartViewModel == null ? 0 : CartViewModel.Total; } }
    }
}