public interface IInventory
{
  public int CurrentValue { get; }
  
  public void IncreaseValue(int value);
}