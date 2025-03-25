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
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {

        private AppDBContext _db;
        public CategoryRepository(AppDBContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Category category)
        {
            _db.Category.Update(category);
        }
    }
}
