namespace ShopModel
{
  public class USD : IRate
  {
    private readonly decimal ratio = 0.49M;

    public string GetCurrency()
    {
      return "USD";
    }

    public decimal GetRatio()
    {
      return ratio;
    }
  }
}