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

namespace TiendaVirtualWeb.Controllers
{
    public class ShopController : Controller
    {
        private TiendaVirtualDbEntities db = new TiendaVirtualDbEntities();

        // GET: Article
        public ActionResult Index()
        {
            return View(db.Articles.ToList());
        }

        // GET: Article/Details/5
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
            return View(article);
        }

        // POST: Article/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddToCart(Cart cart, int id)
        {
            if (ModelState.IsValid)
            {
                Article article = db.Articles.Find(id);
                cart.AddItem(id, article.Price);
            }

            return RedirectToAction("Index");
        }








        // POST: Article/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Article article = db.Articles.Find(id);
            db.Articles.Remove(article);
            db.SaveChanges();
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
