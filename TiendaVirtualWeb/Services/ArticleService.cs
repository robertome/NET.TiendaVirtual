using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TiendaVirtualWeb.Data;
using TiendaVirtualWeb.Models;

namespace TiendaVirtualWeb.Services
{
    public class ArticleService
    {
        private TiendaVirtualDbEntities db;

        public ArticleService(TiendaVirtualDbEntities db)
        {
            this.db = db;
        }

        public List<ArticleViewModel> ArticlesViewModelFromArticles(List<Article> articles)
        {
            List<ArticleViewModel> items = new List<ArticleViewModel>();
            foreach (Article article in articles)
            {
                items.Add(ArticleViewModelFromArticle(article));
            }

            return items;
        }

        public ArticleViewModel ArticleViewModelFromArticle(Article article)
        {
            return new ArticleViewModel
            {
                Id = article.Id,
                Name = article.Name,
                Description = article.Description,
                UnitPrice = article.Price,
                PictureUri = UriComposer.ComposeUri(article.PictureFilename)
            };
        }
    }
}