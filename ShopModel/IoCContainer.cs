using Microsoft.Extensions.DependencyInjection;
using System;

namespace ShopModel
{
  public static class IoCContainer
  {
    private static ServiceCollection services = new ServiceCollection();
    public static IServiceProvider Provider { get; private set; }

    public static void AddService<TKey, TConcrete>() where TConcrete : TKey
    {
      services.AddTransient(typeof(TKey), typeof(TConcrete));
      Provider = services.BuildServiceProvider();
    }
  }
}
