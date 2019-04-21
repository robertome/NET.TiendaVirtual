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
    public class ShopController : Controller
    {
        private TiendaVirtualDbEntities db;
        private CartService cartService;
        private ArticleService articleService;

        public ShopController()
        {
            this.db = new TiendaVirtualDbEntities();
            this.cartService = new CartService(db);
            this.articleService = new ArticleService(db);
        }

        // GET: Article
        public ActionResult Index()
        {
            var articles = db.Articles.ToList();
            var articlesViewModel = articleService.ArticlesViewModelFromArticles(articles);
            return View(articlesViewModel);
        }

        // GET: Article/AddToCart/5
        public ActionResult AddToCart(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Articles.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(articleService.ArticleViewModelFromArticle(article));
        }

        // POST: Article/AddToCart
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddToCart(Cart cart, int id)
        {
            if (ModelState.IsValid)
            {
                cartService.AddItemToCart(cart, id);
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
