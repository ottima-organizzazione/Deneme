using Deneme.Application.Dtos;
using Deneme.Application.Interfaces.Repositories;
using Deneme.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deneme.Infrastrucute.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<Product>> GetProductList()
        {
            List<Product> products = await _productRepository.GetAll(p => p.IsActive == true);

            return products;
        }

        public Task<Product> GetProductById(int id)
        {
            var entity = _productRepository.GetById(id);

            return entity;
        }

        public Task<Product> InsertProduct(ProductRequest product)
        {
            var entity = new Product()
            {
                Sku = product.Sku,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                StockCount = product.StockCount,
            };

            var data = _productRepository.Create(entity);
            return data;
        }

        public async Task<Product> UpdateProduct(UpdateRequest product)
        {
            Product entity = await _productRepository.GetById(product.Id);

            entity.Price = product.Price;
            entity.StockCount = product.StockCount;

            var data = await _productRepository.Update(entity);

            return data;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            Product entity = await _productRepository.GetById(id);
            if (entity == null)
            {
                return false;
            }

            entity.IsActive = false;

            await _productRepository.Update(entity);

            return true;
        }
    }
}
