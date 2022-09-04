using System;

public interface IInventory
{
  public event Action OnItemAddedEvent;
  
  public int CurrentValue { get; }
  
  public void IncreaseValue(int value);
}