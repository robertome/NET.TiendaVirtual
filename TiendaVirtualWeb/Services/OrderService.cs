using System;
using System.Collections.Generic;
using System.Data.Entity;
using TiendaVirtualWeb.Data;
using TiendaVirtualWeb.Models;
using TiendaVirtualWeb.Services;

namespace TiendaVirtualWeb.Controllers
{
    internal class OrderService
    {
        private TiendaVirtualDbEntities db;

        public OrderService(TiendaVirtualDbEntities db)
        {
            this.db = db;
        }

        public void CreateOrder(OrderViewModel orderViewModel)
        {
            Order order = new Order
            {
                Date = DateTimeOffset.Now,
                Price = orderViewModel.Total,
                Buyer = orderViewModel.Buyer.ToBuyer(),
                Address = orderViewModel.Address.ToAddress(),
                OrderItems = OrderItemsFromCartItemsViewModel(orderViewModel.Items)
            };

            foreach (OrderItem item in order.OrderItems)
            {
                Article article = item.Article;
                int newStock = article.Stock - item.Quantity;
                article.Stock = newStock > 0 ? newStock : 0;
                db.Entry(article).State = EntityState.Modified;
            }

            db.Orders.Add(order);
            db.SaveChanges();
        }

        private ICollection<OrderItem> OrderItemsFromCartItemsViewModel(List<CartItemViewModel> cartItems)
        {
            List<OrderItem> items = new List<OrderItem>();
            foreach (CartItemViewModel item in cartItems)
            {
                Article article = db.Articles.Find(item.ArticleId);
                items.Add(new OrderItem
                {
                    Article = article,
                    UnitPrice = item.UnitPrice,
                    Quantity = item.Quantity
                });
            }

            return items;
        }
    }
}