namespace ShopModel
{
  public class NoDiscount : IDiscount
  {
    public int GetDiscount()
    {
      return 0;
    }
  }
}