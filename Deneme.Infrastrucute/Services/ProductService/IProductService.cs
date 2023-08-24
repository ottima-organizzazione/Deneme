using Deneme.Application.Dtos;
using Deneme.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneme.Infrastrucute.Services.ProductService
{
    public interface IProductService
    {
        Task<List<Product>> GetProductList();
        Task<Product> GetProductById(int id);
        Task<Product> InsertProduct(ProductRequest product);
        Task<Product> UpdateProduct(UpdateRequest product);
        Task<bool> DeleteProduct(int id);
    }
}
