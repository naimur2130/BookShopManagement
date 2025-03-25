using BookShop.DataAccess.Context;
using BookShop.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDBContext _db;
        public ICategoryRepository CategoryRepository { get; private set; }
        public UnitOfWork(AppDBContext db)
        {
            _db = db;
            CategoryRepository = new CategoryRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
