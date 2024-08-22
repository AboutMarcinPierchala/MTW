using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTW.CoreBusiness.Validation
{
    public class Product_IsPriceGreaherThanInventoriesCost : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var product = validationContext.ObjectInstance as Product;
            if (product != null)
            {
                if (!ValidatePricing(product)){
                    return new ValidationResult($"!!!The prduct's price is less than total inventories cost: {InventoriesCostSumator(product)}PLN!!!",
                        new List<string>() { validationContext.MemberName});
                }
            }
            return ValidationResult.Success;
        }

        private double InventoriesCostSumator(Product product)
        {
            if (product is null || product.ProductInventories is null) return 0;
            return product.ProductInventories.Sum(i => i.Inventory?.Price * i.InventoryQuantity ?? 0);
        }

        private bool ValidatePricing(Product product)
        {
            if(product.ProductInventories == null || product.ProductInventories.Count <= 0) return true;

            if(InventoriesCostSumator(product) >= product.Price) return false;

            return true;
        }
    }
}
