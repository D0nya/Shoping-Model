using System.Collections.Generic;

namespace ShopModel
{
  public class ValueCalculator
  {
    IRate rate;
    IDiscount discount;
    public ValueCalculator(IRate rate, IDiscount discount)
    {
      this.rate = rate;
      this.discount = discount;
    }

    public decimal ValueProducts(IEnumerable<Product> products)
    {
      decimal sumOfProduct = 0;
      foreach (var product in products)
      {
        sumOfProduct += product.Price;
      }

      sumOfProduct *= rate.GetRatio();
      sumOfProduct -= sumOfProduct * (discount.GetDiscount()/100M);
      return sumOfProduct;
    }
  }
}