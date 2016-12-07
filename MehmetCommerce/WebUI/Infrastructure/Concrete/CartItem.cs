using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebUI.Infrastructure.Abstract;
using Domain;

namespace WebUI.Infrastructure.Concrete
{
    public class CartItem : ICartItem
    {
        public IProduct Product
        {
            get;
            set;
        }

        public int ItemCount
        {
            get;
            set;
        }

        public CartItem(IProduct product, int itemCount)
        {
            this.Product = product;
            this.ItemCount = itemCount;
        }

        public CartItem(int productId, int itemCount)
        {
            ECommerceEntities entities = new ECommerceEntities();
            Product product = entities.Product.Where(x => x.ProductID == productId).FirstOrDefault();
            if (product == null)
            {
                throw new Exception("bu urun bulunmamaktadır");   
            }
            this.Product = new ProductAdapter(product);
            this.ItemCount = itemCount;
        }

    }
}