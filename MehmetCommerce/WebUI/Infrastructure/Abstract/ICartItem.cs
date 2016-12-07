using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace WebUI.Infrastructure.Abstract
{
    public interface ICartItem
    {
        IProduct Product { get; set; }
        int ItemCount { get; set; }
    }
}
