using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;

namespace WebUI.Controllers
{
    public class MembershipController : Controller
    {
        //
        // GET: /Membership/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddMembership(string email, string password, string firstName, string lastName, string address, string city, string postalCode, string country, string phone)
        {
            try
            {
                ECommerceEntities entities = new ECommerceEntities();
                Customer customer = new Customer();
                ShoppingCart cart = new ShoppingCart();
                entities.ShoppingCart.Add(cart);
                entities.SaveChanges();
                customer.Email = email;
                customer.Password = password;
                customer.LastName = lastName;
                customer.FirstName = firstName;
                customer.Address = address;
                customer.City = int.Parse(city);
                customer.PostalCode = postalCode;
                customer.Country = int.Parse(country);
                customer.Phone = phone;
                customer.DateEntered = DateTime.Now;
                customer.ShoppingCartID = cart.ShoppingCartID;
                entities.Customer.Add(customer);
                entities.SaveChanges();
                ViewBag.Result = "Başarılı";
            }
            catch(Exception)
            {
                ViewBag.Result = "Olmadı";
            }
            return View();
        }

    }
}
