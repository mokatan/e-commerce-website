using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;
using WebUI.Infrastructure.Concrete;
using WebUI.Infrastructure.Abstract;

namespace WebUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        //
        // GET: /ShoppingCart/

        public ViewResult Index()
        {
            ShoppingCartX cart = new ShoppingCartX();

            return View(cart.GetItems());
            //shopping cart sayfaya bas
        }

        [HttpPost]
        public RedirectToRouteResult UpdateCart(IEnumerable<CartItemBase> items)
        {
            List<ICartItem> cartItems = new List<ICartItem>();

            foreach (var item in items)
            {
                CartItem cartItem = new CartItem(item.ProductID, item.ItemCount);
                cartItems.Add(cartItem);
            }

            ShoppingCartX shoppingCart = new ShoppingCartX();
            shoppingCart.UpdateCart(cartItems);

            return RedirectToAction("Index");
            
        }

        public RedirectToRouteResult DeleteItem(int productId)
        {
            ShoppingCartX shoppingCart = new ShoppingCartX();
            ECommerceEntities et = new ECommerceEntities();

            shoppingCart.RemoveFromCart(new ProductAdapter(et.Product.Where(x => x.ProductID == productId).FirstOrDefault()));
            return RedirectToAction("Index");

        }
    }
}
