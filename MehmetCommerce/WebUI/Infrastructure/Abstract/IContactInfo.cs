using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace WebUI.Infrastructure.Abstract
{
    public interface IContactInfo
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Phone { get; set; }
        string Email { get; set; }
        int City { get; set; }
        string PostalCode { get; set; }
        int Country { get; set; }
    }
}
