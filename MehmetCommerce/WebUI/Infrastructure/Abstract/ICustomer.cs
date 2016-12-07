using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using WebUi = WebUI.Infrastructure.Concrete;
using WebUI.Infrastructure.Concrete;

namespace WebUI.Infrastructure.Abstract
{
    public interface ICustomer : IContactInfo
    {
        int CustomerID { get; set; }
        string Address { get; set; }
        WebUi.ShoppingCartX ShoppingCart { get; set; }
        bool IsAccountSuspended { get; set; }

        //Customer CreateCustomer(); neden hata verdi?
        //bool UpdateCustomer(); neden hata verdi?
        //void SuspendMembership(bool status); neden hata verdi?
    }
}
