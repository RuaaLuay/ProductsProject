using ProductsProject.DTOs;
using ProductsProject.Models;
using System.Collections.Generic;

namespace ProductsProject.Services
{
    public interface IProductService
    {
        ProductEntity get(int Id);
        List<ProductEntity> getAll();
        void delete(int Id);
        int create(CreateProductDto dto);
        int update(UpdateProductDto dto);
    }
}