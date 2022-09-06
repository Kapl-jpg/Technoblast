using UnityEngine;

namespace Zenject
{
    public class InventoryCompoentInstaller : MonoInstaller
    {
        [SerializeField] private InventoryComponent _inventoryComponent;
        
        public override void InstallBindings()
        {
            Container.Bind<IInventory>().FromInstance(_inventoryComponent.gameObject.GetComponent<IInventory>())
                .AsSingle()
                .NonLazy();
        }
    }
}