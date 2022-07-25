using ProductsProject.Data;
using ProductsProject.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProductsProject.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _db;

        public ProductService(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<ProductEntity> getAll()
        {
            var products = _db.Products.ToList();
            return products;
        }

        public ProductEntity get(int Id)
        {
            var product = _db.Products.Find(Id);
            return product;
        }

        public void delete(int Id)
        {
            var product = _db.Products.Find(Id);
            _db.Products.Remove(product);
            _db.SaveChanges();
        }


    }
}
