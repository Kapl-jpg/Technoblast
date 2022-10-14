using Interfaces;
using UnityEngine;
using Zenject;

public class SprayCan : MonoBehaviour, IInteractable
{
    [SerializeField] private int _value;
    
    public bool IsActive => true;

    private IInventory _inventory;
    
    [Inject]
    private void Construct(IInventory inventory)
    {
        _inventory = inventory;
    }
    
    private void Init()
    {
        gameObject.SetActive(true);
    }

    public void Interact()
    {
        _inventory.IncreaseValue(_value);
        gameObject.SetActive(false);
    }
}
