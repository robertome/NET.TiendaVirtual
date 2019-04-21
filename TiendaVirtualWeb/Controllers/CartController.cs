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

        public CartController()
        {
            this.db = new TiendaVirtualDbEntities();
            this.cartService = new CartService(db);
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
