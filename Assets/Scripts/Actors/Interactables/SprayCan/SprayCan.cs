using Interfaces;
using UnityEngine;
using Zenject;

public class SprayCan : PausableActor, IInteractable
{
    [SerializeField] private int _value;
    
    public bool IsActive => true;

    private IInventory _inventory;
    
    [Inject]
    private void Construct(IInventory inventory)
    {
        _inventory = inventory;
    }
    
    protected override void Init()
    {
        gameObject.SetActive(true);
    }

    public void Interact()
    {
        _inventory.IncreaseValue(_value);
        gameObject.SetActive(false);
    }
}
