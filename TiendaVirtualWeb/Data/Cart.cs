using System;
using System.Collections.Generic;
using System.Linq;

namespace TiendaVirtualWeb.Data
{
    public class Cart
    {
        private List<CartItem> items = new List<CartItem>();
        public IReadOnlyCollection<CartItem> Items => items.AsReadOnly();
        public int ItemsCount { get; set; }
        public decimal Total
        {
            get { return Math.Round(Items.Sum(i => i.UnitPrice * i.Quantity), 2); }
        }

        public void AddItem(int articleId, decimal unitPrice, int quantity = 1)
        {
            CartItem existingItem = items.FirstOrDefault(i => i.ArticleId == articleId);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
                if (existingItem.Quantity < 1)
                {
                    items.Remove(existingItem);
                }
            }
            else if (quantity > 0)
            {
                items.Add(new CartItem()
                {
                    ArticleId = articleId,
                    Quantity = quantity,
                    UnitPrice = unitPrice
                });
            }

            ItemsCount = Items.Sum(i => i.Quantity);
        }

        public void Clear()
        {
            ItemsCount = 0;
            items.Clear();
        }
    }
}