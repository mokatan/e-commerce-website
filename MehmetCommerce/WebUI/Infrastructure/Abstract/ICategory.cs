using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain;

namespace WebUI.Infrastructure.Abstract
{
    public interface ICategory
    {
        ICategory ParentCategory { get; set; }
        int CategoryID { get; set; }
        string CategoryName { get; set; }
        string Description { get; set; }
        IImage Image { get; set; }

        List<IProduct> GetCategoryProducts(int categoryId);
        List<ICategory> GetCategories();
        void CreateCategory();
        void DeleteCategory();
    }
}