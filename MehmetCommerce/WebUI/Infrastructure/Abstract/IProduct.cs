using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using WebUI.Infrastructure.Concrete;


namespace WebUI.Infrastructure.Abstract
{
    public interface IProduct
    {
        ICategory ProductCategory { get; set; }
        int ProductID { get; set; }
        Guid UniqueId { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        double Rating { get; set; }
        decimal Price { get; set; }
        IImage Image { get; set; }

        int GetStockCount();
        bool CreateProduct();
        bool UpdateProduct();
        void AddToStock(int itemCount);

    }
}
