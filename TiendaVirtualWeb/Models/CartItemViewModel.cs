using System;
using System.ComponentModel.DataAnnotations;

namespace TiendaVirtualWeb.Models
{
    public class CartItemViewModel
    {
        public int ArticleId { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Currency)]
        [Display(Name = "Price")]
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string PictureUri { get; set; }
        [DataType(DataType.Currency)]
        [Display(Name = "Total Price")]
        public decimal TotalPrice
        {
            get
            {
                return Math.Round(UnitPrice * Quantity, 2);
            }
        }
    }
}