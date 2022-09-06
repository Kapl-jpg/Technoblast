using UnityEngine;

namespace Directors
{
    public abstract class SingleInstanceObject : MonoBehaviour
    {
        protected SingleInstanceObject _instance;
        
        private void Start()
        {
            Config();
        }

        private void Config()
        {
            if (_instance == null)
            {
                _instance = this;
                DontDestroyOnLoad(this);
                Init();
            }
            else
            {
                Destroy(gameObject);
            }
        }

        protected abstract void Init();
    }
}