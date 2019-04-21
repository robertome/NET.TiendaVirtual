using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TiendaVirtualWeb.Data;
using TiendaVirtualWeb.Models;

namespace TiendaVirtualWeb.Services
{
    public class CartService
    {
        private TiendaVirtualDbEntities db;

        public CartService(TiendaVirtualDbEntities db)
        {
            this.db = db;
        }

        public void AddItemToCart(Cart cart, int id)
        {
            Article article = db.Articles.Find(id);
            cart.AddItem(id, article.Price);
        }

        public void RemoveItemFromCart(Cart cart, int id)
        {
            cart.AddItem(id, 0, -1);
        }

        public CartViewModel CartViewModelFromCart(Cart cart)
        {
            return new CartViewModel(cart, CartItemsViewModelFromCartItems(cart.Items));
        }

        private List<CartItemViewModel> CartItemsViewModelFromCartItems(IReadOnlyCollection<CartItem> cartItems)
        {
            List<CartItemViewModel> items = new List<CartItemViewModel>();
            foreach (CartItem item in cartItems)
            {
                Article article = db.Articles.Find(item.ArticleId);
                items.Add(new CartItemViewModel
                {
                    ArticleId = article.Id,
                    Name = article.Name,
                    UnitPrice = item.UnitPrice,
                    Quantity = item.Quantity,
                    PictureUri = UriComposer.ComposeUri(article.PictureFilename)
                });
            }

            return items;
        }
    }
    
}