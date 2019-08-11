namespace ShopModel
{
  public interface IRate
  {
    string GetCurrency();
    decimal GetRatio();
  }
}