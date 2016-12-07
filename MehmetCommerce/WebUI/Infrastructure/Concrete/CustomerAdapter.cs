using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain;
using WebUI.Infrastructure.Abstract;

namespace WebUI.Infrastructure.Concrete
{
    public class CustomerAdapter : CustomerX, ISessionUser, ICustomer
    {
        //public int CustomerID { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public string Phone { get; set; }
        //public string Email { get; set; }
        //public string Address { get; set; }
        //public int City { get; set; }
        //public string PostalCode { get; set; }
        //public int Country { get; set; }
        //public ShoppingCart ShoppingCart { get; set; }
        //public bool IsAccountSuspended { get; set; }

        public CustomerAdapter(Customer customerEntity) 
        {
            this.CustomerID = customerEntity.CustomerID;
            this.FirstName = customerEntity.FirstName;
            this.LastName = customerEntity.LastName;
            this.Phone = customerEntity.Phone;
            this.Email = customerEntity.Email;
            this.Address = customerEntity.Address;
            this.City = customerEntity.City;
            this.PostalCode = customerEntity.PostalCode;
            this.Country = customerEntity.Country;
            this.Password = customerEntity.Password;
            this.IsAccountSuspended = customerEntity.IsAcountSuspended;
            this.DateEntered = customerEntity.DateEntered;

            this.ShoppingCart = new ShoppingCartX();
            this.ShoppingCart.ShoppingCartId = customerEntity.ShoppingCartID;


            //shopping cart
            //exception log
            //orders
        }


        //Domain.ShoppingCart ICustomer.ShoppingCart
        //{
        //    get
        //    {
        //        throw new NotImplementedException();
        //    }
        //    set
        //    {
        //        throw new NotImplementedException();
        //    }
        //}
    }
}