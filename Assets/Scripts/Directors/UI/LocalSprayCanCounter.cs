using UnityEngine;
using Zenject;

namespace Directors.UI
{
    public class LocalSprayCanCounter : MonoBehaviour
    {
        [SerializeField] private GameObject[] _viewsToTurnOn;

        [Inject]
        private void Construct(IInventory inventory)
        {
            inventory.OnItemAddedEvent += UpdateUI;
        }

        private void UpdateUI()
        {
            foreach (var view in _viewsToTurnOn)
            {
                if (!view.activeSelf)
                {
                    view.SetActive(true);
                    return;
                }
            }
        }
    }
}