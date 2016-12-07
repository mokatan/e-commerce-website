using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebUI.Infrastructure.Abstract;
using Domain;

namespace WebUI.Infrastructure.Concrete
{
    public class CustomerX : ICustomer
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int City { get; set; }
        public string PostalCode { get; set; }
        public int Country { get; set; }
        public ShoppingCartX ShoppingCart { get; set; }
        public bool IsAccountSuspended { get; set; }
        public DateTime DateEntered { get; set; }
        public string Password { get; set; }

        //exception log
        //orders

        public Customer CreateCustomer()
        {
            ECommerceEntities et = new ECommerceEntities();
            Customer CustomerToCreate = new Customer()
            {
                CustomerID = this.CustomerID,
                FirstName = this.FirstName,
                LastName = this.LastName,
                Address = this.Address,
                City = this.City,
                PostalCode = this.PostalCode,
                Country = this.Country,
                Phone = this.Phone,
                Email = this.Email,
                Password = this.Password,
                ShoppingCartID = this.ShoppingCart.ShoppingCartId,
                IsAcountSuspended = this.IsAccountSuspended,
                DateEntered = DateTime.Now
                //shoppingcart
                //exceptionlog
                //orders

            };
            et.Customer.Add(CustomerToCreate);
            et.SaveChanges();
            return null;
        }

        public bool UpdateCustomer()
        {
            ECommerceEntities entities = new ECommerceEntities();
            Customer customer = entities.Customer.Where(x => x.CustomerID == this.CustomerID).FirstOrDefault();

            customer.FirstName = this.FirstName;
            customer.LastName = this.LastName;
            customer.Address = this.Address;
            customer.City = this.City;
            customer.PostalCode = this.PostalCode;
            customer.Country = this.Country;
            customer.Email = this.Email;
            //customer.Password = this.Password;

            entities.SaveChanges();
            return true;
        }

        public void SuspendMembership(bool status)
        {
            ECommerceEntities entities = new ECommerceEntities();
            Customer customer = entities.Customer.Where(x => x.CustomerID == this.CustomerID).FirstOrDefault();

            customer.IsAcountSuspended = status;
            entities.SaveChanges();
        }
    }
}