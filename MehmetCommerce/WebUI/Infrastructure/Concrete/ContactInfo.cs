using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebUI.Infrastructure.Abstract;
using Domain;

namespace WebUI.Infrastructure.Concrete
{
    public class ContactInfo : IContactInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int City { get; set; }
        public string PostalCode { get; set; }
        public int Country { get; set; }

        public ContactInfo(CustomerX customerEntity)
        {
            this.FirstName = customerEntity.FirstName;
            this.LastName = customerEntity.LastName;
            this.Phone = customerEntity.Phone;
            this.Email = customerEntity.Email;
            this.City = customerEntity.City;
            this.PostalCode = customerEntity.PostalCode;
            this.Country = customerEntity.Country;
        }


        //public int City
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

        //public int Country
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