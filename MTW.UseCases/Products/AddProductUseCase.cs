using MTW.CoreBusiness;
using MTW.UseCases.Products.Interfaces;
using MTW.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTW.UseCases.Products
{
    public class AddProductUseCase : IAddProductUseCase
    {
        private readonly IProductRepository _productRepository;

        public AddProductUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task ExecuteAsync(Product product)
        {
            await _productRepository.AddProductAsync(product);
        }
    }
}
