using Interfaces;
using UnityEngine;
using Zenject;

namespace Directors.UI
{
    public class PausePanelUI : MonoBehaviour
    {
        [SerializeField] private GameObject _pausePanel;
        [SerializeField] private GameObject _settingsPanel;
    }
}