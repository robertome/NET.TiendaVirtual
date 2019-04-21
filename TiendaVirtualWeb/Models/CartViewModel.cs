using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TiendaVirtualWeb.Data;

namespace TiendaVirtualWeb.Models
{
    public class CartViewModel
    {
        private readonly Cart cart;
        public List<CartItemViewModel> Items { get; set; } = new List<CartItemViewModel>();
        [DataType(DataType.Currency)]
        [Display(Name = "Total Price")]
        public decimal Total { get { return cart.Total(); } }
        public bool Empty { get { return Items.Count == 0; } }

        public CartViewModel(Cart cart, List<CartItemViewModel> items)
        {
            this.cart = cart;
            Items = items;
        }

    }
}