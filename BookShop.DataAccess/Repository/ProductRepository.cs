using BookShop.DataAccess.Context;
using BookShop.DataAccess.Repository.IRepository;
using BookShop.Models;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {

        private AppDBContext _db;
        public ProductRepository(AppDBContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Product product)
        {
            //_db.Product.Update(product);

            var obj = _db.Product.FirstOrDefault(u=>u.ProductId==product.ProductId);

            if (obj != null)
            {
                obj.ProductName = product.ProductName;
                obj.ProductDescription = product.ProductDescription;
                obj.ProductISBN = product.ProductISBN;
                obj.ProductAuthor = product.ProductAuthor;
                obj.Price = product.Price;
                obj.ListofPrice = product.ListofPrice;
                obj.ListofPrice50 = product.ListofPrice50;
                obj.ListofPrice100 = product.ListofPrice100;
                obj.CategoryId = product.CategoryId;
                if(product.ProductImage!=null)
                {
                    obj.ProductImage = product.ProductImage;
                }
            }
        }
    }
}
