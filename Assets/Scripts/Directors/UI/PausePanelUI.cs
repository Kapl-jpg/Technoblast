using Interfaces;
using UnityEngine;
using Zenject;

namespace Directors.UI
{
    public class PausePanelUI : MonoBehaviour, ICanBePaused
    {
        [SerializeField] private GameObject _pausePanel;
        
        public bool IsPaused { get; }

        [Inject]
        private void Construct(IPauseDirector pauseDirector)
        {
            pauseDirector.RegisterICanBePausedActor(this);
        }
        
        public void Pause()
        {
            _pausePanel.SetActive(true);
        }

        public void Unpause()
        {
            _pausePanel.SetActive(false);
        }
    }
}