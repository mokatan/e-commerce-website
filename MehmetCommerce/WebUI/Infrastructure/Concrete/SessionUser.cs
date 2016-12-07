using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebUI.Infrastructure.Abstract;
using Domain;

namespace WebUI.Infrastructure.Concrete
{
    public class SessionUser : ISessionUser
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<ICartItem> CartItems;

        public SessionUser(ICustomer customerEntity)
        {
            this.CustomerID = customerEntity.CustomerID;
            this.FirstName = customerEntity.FirstName;
            this.LastName = customerEntity.LastName;
        }

        public static bool UserLoggedIn()
        {
            current = current;

            return ((SessionUser)HttpContext.Current.Session["SessionUser"]).CustomerID != 0;
        }

        public static void LogOut()
        {
            HttpContext.Current.Session.Remove("SessionUser");
        }

        private SessionUser(List<ICartItem> cartItems = null)
        {
            if (cartItems != null)
                this.CartItems = cartItems;

            if (this.CartItems == null)
                this.CartItems = new List<ICartItem>();
        }

        private static SessionUser current
        {
            get
            {
                if (HttpContext.Current.Session["SessionUser"] == null)
                    HttpContext.Current.Session["SessionUser"] = new SessionUser();

                return (SessionUser)HttpContext.Current.Session["SessionUser"];
            }
            set
            {
                HttpContext.Current.Session["SessionUser"] = value;
            }
        }

        public static SessionUser Current
        {
            get
            {
                return current;
            }
        }

        public static void SetSessionUser(ICustomer customer, List<ICartItem> cartItems = null)
        {
            SessionUser sessionUser = new SessionUser();
            sessionUser.CustomerID = customer.CustomerID;
            sessionUser.FirstName = customer.FirstName;
            sessionUser.LastName = customer.LastName;

            if (cartItems != null)
                sessionUser.CartItems = cartItems;

            current = sessionUser;


            
        }
    }
}