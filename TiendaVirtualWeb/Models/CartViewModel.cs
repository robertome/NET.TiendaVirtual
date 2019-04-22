using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TiendaVirtualWeb.Data;

namespace TiendaVirtualWeb.Models
{
    public class CartViewModel
    {        
        public List<CartItemViewModel> Items { get; set; } = new List<CartItemViewModel>();

        [DataType(DataType.Currency)]
        [Display(Name = "Total Price")]
        public decimal Total { get; set; }

        public bool Empty { get { return Items.Count == 0; } }

        public CartViewModel(Cart cart, List<CartItemViewModel> items)
        {
            Total = cart.Total;
            Items = items;
        }

    }
}