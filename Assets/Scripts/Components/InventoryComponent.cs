using System;
using UnityEngine;

public class InventoryComponent : MonoBehaviour, IInventory
{
    public event Action OnItemAddedEvent;
    public int CurrentValue { get; private set; }

    public void IncreaseValue(int value)
    {
        CurrentValue += value;
        OnItemAddedEvent?.Invoke();
    }
}
