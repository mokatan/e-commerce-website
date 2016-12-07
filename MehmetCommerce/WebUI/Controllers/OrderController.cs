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
    public class OrderController : Controller
    {
        //
        // GET: /Order/

        public ActionResult Index()
        {
            return View();
        }

       
        public ActionResult BuyItems()
        {
            ShoppingCartX cart = new ShoppingCartX();
            List<ICartItem> myList = cart.GetItems();
            if (SessionUser.UserLoggedIn())
            {
                
                foreach (var item in myList)
                {
                    ECommerceEntities entities = new ECommerceEntities();
                    Product product = entities.Product.Where(x => x.ProductID == item.Product.ProductID).FirstOrDefault();
                    product.StockCount -= item.ItemCount;
                    Orders order = new Orders();
                    order.CustomerID = SessionUser.Current.CustomerID;
                    order.DateOrdered = DateTime.Now;
                    order.PaymentAmount = cart.TotalAmount;
                    order.PaymentDate = DateTime.Now;
                    //entities.SaveChanges();
                    OrderDetail detail = new OrderDetail();
                    //OrderDetail detail = entities.OrderDetail.Where(x => x.OrderID == order.OrderID).FirstOrDefault();
                    detail.OrderID = order.OrderID;
                    detail.OrderTime = DateTime.Now;
                    detail.ProductID = item.Product.ProductID;
                    detail.ProductPrice = item.Product.Price;
                    
                    entities.SaveChanges();
                }        
            }

            
            return View(myList);

        }
        

    }
}
