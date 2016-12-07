using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace WebUI.Infrastructure.Abstract
{
    public interface ISessionUser
    {
        int CustomerID { get; }
        string FirstName { get; }
        string LastName { get; }

    }
}
