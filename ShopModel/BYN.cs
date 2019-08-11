namespace ShopModel
{
  public class BYN : IRate
  {
    private readonly decimal ratio = 1M;

    public string GetCurrency()
    {
      return "BYN";
    }

    public decimal GetRatio()
    {
      return ratio;
    }
  }
}