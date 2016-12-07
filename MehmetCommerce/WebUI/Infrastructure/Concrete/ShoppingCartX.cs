using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebUI.Infrastructure.Abstract;
using WebUI.Infrastructure.Concrete;
using Domain;

namespace WebUI.Infrastructure.Concrete
{
    public class ShoppingCartX
    {
        private List<ICartItem> Items { get; set; }
        public int ShoppingCartId { get; set; }
        public decimal TotalAmount
        {
            get
            {
                return ReCalculateTotalAmount();
            }
            set { }
        }

        public List<ICartItem> GetItems()
        {
            List<ICartItem> myList = new List<ICartItem>();
            List<ICartItem> cartItems = new List<ICartItem>();

            if (!SessionUser.UserLoggedIn())
                cartItems = SessionUser.Current.CartItems;
            else
            {
                ECommerceEntities et = new ECommerceEntities();
                Customer customer = et.Customer.Where(x=>x.CustomerID == SessionUser.Current.CustomerID).FirstOrDefault();

                if (customer != null)
                {
                    List<ShoppingCartDetail> details = et.ShoppingCartDetail.Where(x => x.ShoppingCartId == customer.ShoppingCartID).ToList();
                    Items = new List<ICartItem>();

                    foreach (ShoppingCartDetail detail in details)
                    {
                        Product product = et.Product.Where(x => x.ProductID == detail.ProductId).FirstOrDefault();

                        if (product != null)
                        {
                            CartItem cartItem = new CartItem(new ProductAdapter(product), detail.ItemCount);
                            Items.Add(cartItem);
                        }
                    }

                    cartItems = Items;
                }
            }

            foreach (var itemproduct in cartItems)
            {
                myList.Add(itemproduct);
            }
            return myList;
        }

        private decimal ReCalculateTotalAmount()
        {
            decimal sum = 0;

            if (!SessionUser.UserLoggedIn())
                return SessionUser.Current.CartItems.Select(x => x.ItemCount * x.Product.Price).Sum();
            else
            {
                //return Items.Select(x => x.ItemCount * x.Product.Price).Sum();
                ECommerceEntities entities = new ECommerceEntities();
                Customer customer = entities.Customer.Where(x => x.CustomerID == SessionUser.Current.CustomerID).FirstOrDefault();

                if (customer != null)
                {
                    ShoppingCart cart = entities.ShoppingCart.Where(x => x.ShoppingCartID == customer.ShoppingCartID).FirstOrDefault();

                    if (cart != null)
                    {
                        List<ShoppingCartDetail> detail = entities.ShoppingCartDetail.Where(x => x.ShoppingCart.ShoppingCartID == cart.ShoppingCartID).ToList();

                        if (detail != null)
                        {
                            foreach (var item in detail)
                            {
                                sum = item.Product.Price * item.ItemCount;
                            }
                        }
                        else
                        {
                            
                        }                       
                    }                  
                }

                return sum;     
            }
        }

        public void UpdateCart(List<ICartItem> items)
        {
            if (!SessionUser.UserLoggedIn())
                SessionUser.Current.CartItems = items.Where(x => x.ItemCount > 0).ToList();
            else
            {
                //Items = items.Where(x => x.ItemCount > 0).ToList();
                ECommerceEntities entities = new ECommerceEntities();
                Customer customer = entities.Customer.Where(x => x.CustomerID == SessionUser.Current.CustomerID).FirstOrDefault();

                if (customer != null)
                {
                    ShoppingCart cart = entities.ShoppingCart.Where(x => x.ShoppingCartID == customer.ShoppingCartID).FirstOrDefault();

                    if (cart != null)
                    {
                        cart = entities.ShoppingCart.Where(x => x.ShoppingCartID == customer.ShoppingCartID).FirstOrDefault();
                    }
                }
                entities.SaveChanges();
            }
        }

        public bool AddToCart(IProduct product, int numberOfItems)
        {
            try
            {
                var t = new CartItem(product, numberOfItems);

                if (!SessionUser.UserLoggedIn() && SessionUser.Current.CartItems.Where(x => x.Product.ProductID == product.ProductID).Any() == false)
                {
                    SessionUser.Current.CartItems.Add(t);
                }
                else if (GetItems().Where(x => x.Product.ProductID == product.ProductID).Any() == false)
                {
                    ECommerceEntities entities = new ECommerceEntities();
                    Customer customer = entities.Customer.Where(x => x.CustomerID == SessionUser.Current.CustomerID).FirstOrDefault();

                    if (customer != null)
                    {
                        ShoppingCart cart = entities.ShoppingCart.Where(x => x.ShoppingCartID == customer.ShoppingCartID).FirstOrDefault();

                        if (cart != null)
                        {
                            ShoppingCartDetail detail = entities.ShoppingCartDetail.Where(x => x.ShoppingCart.ShoppingCartID == cart.ShoppingCartID && x.ProductId == product.ProductID).FirstOrDefault();
                            
                            if (detail != null)
                            {
                                //Product prod = entities.Product.Where(x => x.ProductID == product.ProductID).FirstOrDefault();
                                detail.ItemCount += numberOfItems;
                            }
                            else
                            {
                                ShoppingCartDetail newItem = new ShoppingCartDetail();
                                newItem.CreationTime = DateTime.Now;
                                newItem.ItemCount = numberOfItems;
                                newItem.ProductId = product.ProductID;
                                newItem.ShoppingCartId = cart.ShoppingCartID;
                                entities.ShoppingCartDetail.Add(newItem);
                            }
                        }
                    }    
                    
                    entities.SaveChanges();                 
                }
                return true;
            }

            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public void RemoveFromCart(IProduct product)
        {
            if (!SessionUser.UserLoggedIn())
                SessionUser.Current.CartItems.Remove(
                    SessionUser.Current.CartItems.Where(x => x.Product.ProductID == product.ProductID).FirstOrDefault()
                    );
            else
            {
                //Items.Remove(SessionUser.Current.CartItems.Where(x => x.Product.ProductID == product.ProductID).FirstOrDefault());
                ECommerceEntities entities = new ECommerceEntities();
                Customer customer = entities.Customer.Where(x => x.CustomerID == SessionUser.Current.CustomerID).FirstOrDefault();
                if (customer != null)
                {
                    ShoppingCart cart = entities.ShoppingCart.Where(x => x.ShoppingCartID == customer.ShoppingCartID).FirstOrDefault();
                    if (cart != null)
                    {
                        ShoppingCartDetail detail = entities.ShoppingCartDetail.Where(x => x.ShoppingCart.ShoppingCartID == cart.ShoppingCartID && x.ProductId == product.ProductID).FirstOrDefault();
                        if (detail != null)
                        {
                            entities.ShoppingCartDetail.Remove(detail);
                        }
                    }
                }
                entities.SaveChanges();
            }               
        }

        public void MoveSessionCartToDb()
        {
            if (SessionUser.UserLoggedIn())
            {
                ECommerceEntities et = new ECommerceEntities();
                Customer customer = et.Customer.Where(x => x.CustomerID == SessionUser.Current.CustomerID).FirstOrDefault();

                if (customer != null)
                {
                    List<ShoppingCartDetail> details = et.ShoppingCartDetail.Where(x => x.ShoppingCartId == customer.ShoppingCartID).ToList();
                    List<ShoppingCartDetail> newItems = new List<ShoppingCartDetail>();

                    foreach (ShoppingCartDetail detail in details)
                    {
                        ICartItem cartItem = SessionUser.Current.CartItems.Where(x => x.Product.ProductID == detail.ProductId).FirstOrDefault();

                        if (cartItem != null)
                            detail.ItemCount += cartItem.ItemCount;
                    }

                    foreach (ICartItem item in SessionUser.Current.CartItems)
                    {
                        ShoppingCartDetail itemDetail = new ShoppingCartDetail();
                        itemDetail.CreationTime = DateTime.Now;
                        itemDetail.ItemCount = item.ItemCount;
                        itemDetail.ProductId = item.Product.ProductID;
                        itemDetail.ShoppingCartId = customer.ShoppingCartID;

                        newItems.Add(itemDetail);
                    }

                    foreach (ShoppingCartDetail detail in newItems)
                    {
                        et.ShoppingCartDetail.Add(detail);
                    }

                    et.SaveChanges();

                    SessionUser.Current.CartItems.Clear();
                }
            }
        }

        public void EmptyCart()
        {
            Items = new List<ICartItem>();
        }
    }
}