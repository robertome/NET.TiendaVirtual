using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TiendaVirtualWeb.Data;
using TiendaVirtualWeb.Models;
using TiendaVirtualWeb.Services;

namespace TiendaVirtualWeb.Controllers
{
    public class CartController : Controller
    {
        private TiendaVirtualDbEntities db;
        private CartService cartService;
        private OrderService orderService;

        public CartController()
        {
            this.db = new TiendaVirtualDbEntities();
            this.cartService = new CartService(db);
            this.orderService = new OrderService(db);
        }

        // GET: Cart
        public ActionResult Index(Cart cart)
        {
            return View(cartService.CartViewModelFromCart(cart));
        }
                            
        // POST: Cart/RemoveFromCart
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveFromCart(Cart cart, int id)
        {
            if (ModelState.IsValid)
            {
                cartService.RemoveItemFromCart(cart, id);
            }

            return RedirectToAction("Index");
        }

        // GET: Cart/OrderInfo
        public ActionResult OrderInfo()
        {
            return View();
        }

        // POST: Orders/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult OrderInfo(Cart cart, [Bind(Include = "Buyer,Address")] OrderViewModel orderViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(orderViewModel);
            }

            orderViewModel.CartViewModel = cartService.CartViewModelFromCart(cart);
            orderService.CreateOrder(orderViewModel);            
            cart.Clear();

            return View(viewName:"OrderSummary", model: orderViewModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
