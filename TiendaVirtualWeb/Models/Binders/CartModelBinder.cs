using System.Web;
using System.Web.Mvc;
using TiendaVirtualWeb.Data;

namespace TiendaVirtualWeb.Models.Binders
{
    public class CartModelBinder : IModelBinder
    {
        private const string CART = "CART";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            HttpSessionStateBase session = controllerContext.HttpContext.Session;
            Cart cart = (Cart)session[CART];
            if (cart == null)
            {
                cart = new Cart();
                session[CART] = cart;
            }

            return cart;
        }
    }
}