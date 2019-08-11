using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace ShopModel
{
  public class ShoppingCart
  {
    private ValueCalculator valueCalc;

    public IEnumerable<Product> Products { get; set; }

    public ShoppingCart()
    {
      Products = new List<Product>();
      valueCalc = new ValueCalculator(IoCContainer.Provider.GetService<IRate>(), IoCContainer.Provider.GetService<IDiscount>());
    }

    public decimal CalculateProductTotal()
    {
      return valueCalc.ValueProducts(Products);
    }
  }
}