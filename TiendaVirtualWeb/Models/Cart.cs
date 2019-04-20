using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TiendaVirtualWeb.Models
{
    public class Cart
    {
        private List<CartItem> items = new List<CartItem>();        

        public void AddItem(int articleId, decimal unitPrice, int quantity = 1)
        {
            CartItem existingItem = items.FirstOrDefault(i => i.ArticleId == articleId);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                items.Add(new CartItem()
                {
                    ArticleId = articleId,
                    Quantity = quantity,
                    UnitPrice = unitPrice
                });
            }                        
        }
    }
}