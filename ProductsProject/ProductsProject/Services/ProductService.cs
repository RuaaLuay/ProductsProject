using ProductsProject.Data;
using ProductsProject.DTOs;
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

        public int create(CreateProductDto dto)
        {
            var product = new ProductEntity();
            product.Name = dto.Name;
            product.price = dto.Price;  
            _db.Products.Add(product);
            _db.SaveChanges();
            return product.ID;
        }

        public int update(UpdateProductDto dto)
        {
            var product = _db.Products.Find(dto.Id); ;
            product.Name = dto.Name;
            product.price = dto.Price;
            _db.Products.Update(product);
            _db.SaveChanges();
            return product.ID;
        }





    }
}
