using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace WebUI.Infrastructure.Abstract
{
    public interface IImage
    {
        string ImageUrl { get; set; }
        Guid? ImageId { get; set; }
        int ItemType { get; set; }
       
    }
}
