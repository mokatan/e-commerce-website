using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;
using WebUI.Infrastructure.Concrete;

namespace WebUI.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(string email, string password)
        {
            ECommerceEntities entities = new ECommerceEntities();
            Customer customer = entities.Customer.Where(x => x.Email == email).FirstOrDefault();
            if (customer != null)
            {
                if (password == customer.Password)
                {
                    SessionUser.SetSessionUser(new CustomerAdapter(customer), SessionUser.Current.CartItems);

                    ShoppingCartX cart = new ShoppingCartX();
                    cart.MoveSessionCartToDb();
                }
                else
                {
                    throw new Exception("Yanlış şifre!");
                }
            }
            else
            {
                throw new Exception("Böyle bir kullanıcı bulunmamaktadır!");
            }
            return RedirectToAction("Index","Home");
        }

    }
}
