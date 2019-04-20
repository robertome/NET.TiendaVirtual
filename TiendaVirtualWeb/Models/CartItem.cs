using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaVirtualWeb.Models
{
    public class CartItem
    {
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int ArticleId { get; set; }
    }
}