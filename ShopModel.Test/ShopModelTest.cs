using System;
using Xunit;
using ShopModel;
using System.Linq;

namespace ShopModel.Test
{
  public class ShopModelTest
  {
    [Fact]
    public void BYNNoDiscount_CalculateProductTotal_Return100()
    {
      IoCContainer.AddService<IRate, BYN>();
      IoCContainer.AddService<IDiscount, NoDiscount>();
      ShoppingCart cart = new ShoppingCart();
      cart.Products = cart.Products.Concat(new Product[] { new Product { Price = 100 } });

      var res = cart.CalculateProductTotal();

      Assert.Equal(100, res);
    }

    [Fact]
    public void BYNDiscount10_CalculateProductTotal_Return90()
    {
      IoCContainer.AddService<IRate, BYN>();
      IoCContainer.AddService<IDiscount, Discount10>();
      ShoppingCart cart = new ShoppingCart();
      cart.Products = cart.Products.Concat(new Product[] { new Product { Price = 100 } });

      var res = cart.CalculateProductTotal();

      Assert.Equal(90, res);
    }

    [Fact]
    public void USDNoDiscount_CalculateProductTotal_Return49_9()
    {
      IoCContainer.AddService<IRate, USD>();
      IoCContainer.AddService<IDiscount, NoDiscount>();
      ShoppingCart cart = new ShoppingCart();
      cart.Products = cart.Products.Concat(new Product[] { new Product { Price = 100 } });

      var res = cart.CalculateProductTotal();

      Assert.Equal(49M, res);
    }

    [Fact]
    public void USD10Discount_CalculateProductTotal_Return441_17()
    {
      IoCContainer.AddService<IRate, USD>();
      IoCContainer.AddService<IDiscount, Discount10>();
      ShoppingCart cart = new ShoppingCart();
      cart.Products = cart.Products.Concat(new Product[] { new Product { Price = 600 }, new Product { Price = 400 } });

      var res = cart.CalculateProductTotal();

      Assert.Equal(441M, res);
    }
  }
}
