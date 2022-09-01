using UnityEngine;

public class InventoryComponent : MonoBehaviour, IInventory
{
    public int CurrentValue { get; private set; }

    public void IncreaseValue(int value)
    {
        CurrentValue += value;
    }
}
