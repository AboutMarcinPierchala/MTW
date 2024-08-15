using MTW.CoreBusiness;
using MTW.UseCases.Products;
using MTW.UseCases.Products.Interfaces;
using MTW.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTW.UseCases.Products
{
    public class EditProductUseCase : IEditProductUseCase
    {
        private readonly IProductRepository _productRepository;

        public EditProductUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task ExecuteAsync(int id, Product product)
        {
            await _productRepository.EditProductAsync(id, product);
        }
    }
}
