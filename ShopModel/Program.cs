using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace ShopModel
{
  static class Program
  {
    static List<Product> products = new List<Product>()
      {
        new Product(){ProductID = 0, Name = "Product0", Category = "Cat0", Description="Desription", Price = 100},
        new Product(){ProductID = 1, Name = "Product1", Category = "Cat0", Description="Desription", Price = 200},
        new Product(){ProductID = 2, Name = "Product2", Category = "Cat0", Description="Desription", Price = 40},
        new Product(){ProductID = 3, Name = "Product3", Category = "Cat1", Description="Desription", Price = 250},
        new Product(){ProductID = 4, Name = "Product4", Category = "Cat1", Description="Desription", Price = 130},
        new Product(){ProductID = 5, Name = "Product5", Category = "Cat1", Description="Desription", Price = 420},
        new Product(){ProductID = 6, Name = "Product6", Category = "Cat2", Description="Desription", Price = 31},
        new Product(){ProductID = 7, Name = "Product7", Category = "Cat2", Description="Desription", Price = 15}
      };

    public static void Main()
    {
      char k;
      Entrance();
      ShoppingCart cart = new ShoppingCart();
      Console.WriteLine();
      GetProducts();

      while(true)
      {
        Console.WriteLine("1. Show Prdoucts\n2. Add Product to cart\n3. Show total price\n0. exit\n");
        k = (char)Console.Read();
        FlushKeyboard();
        switch(k)
        {
          case '1':
            GetProducts();
            break;
          case '2':
            AddProduct(cart);
            break;
          case '3':
            Console.WriteLine("{0:f} {1}", cart.CalculateProductTotal(), IoCContainer.Provider.GetService<IRate>().GetCurrency());
            break;
          case '0':
            return;
          default:
            Console.WriteLine("Wrong case.");
            break;
        }
      }
    }
    private static void Entrance()
    {
      char k;
      Console.WriteLine("Hello!\nSelect your country:\n");
      Console.WriteLine("1. Belarus");
      Console.WriteLine("else Other");
      k = (char)Console.Read();
      FlushKeyboard();
      if (k == '1')
        IoCContainer.AddService<IRate, BYN>();
      else
        IoCContainer.AddService<IRate, USD>();


      Console.WriteLine("\nDo you have any discount?\n");
      Console.WriteLine("1. 5%");
      Console.WriteLine("2. 10%");
      Console.WriteLine("else NO");
      k = (char)Console.Read();
      FlushKeyboard();
      if (k == '1')
        IoCContainer.AddService<IDiscount, Discount5>();
      else if (k == '2')
        IoCContainer.AddService<IDiscount, Discount10>();
      else
        IoCContainer.AddService<IDiscount, NoDiscount>();
    }
    private static void FlushKeyboard()
    {
      while (Console.In.Peek() != -1)
        Console.In.Read();
    }
    private static void GetProducts()
    {
      foreach (var item in products)
      {
        Console.WriteLine(item.ProductID + "\t|" + item.Name + "\t|" + item.Description + "\t|" + item.Category + "\t|" + item.Price + " BYN \t|");
      }
    }
    private static void AddProduct(ShoppingCart cart)
    {
      int id;
      Console.WriteLine("Product ID: ");
      id = int.Parse(Console.ReadLine());
      FlushKeyboard();
      Product product = null;
      try
      {
        product = products[id];
      }
      catch (ArgumentOutOfRangeException e)
      {
        Console.WriteLine(e.Message);
      }
      if(product != null)
        cart.Products = cart.Products.Concat(new Product[] { product });
    }
  }
}