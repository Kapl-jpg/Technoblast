using System;
using ScriptableObjects.Sounds_SO;
using UnityEngine;

namespace Directors
{
    public class AudioController : MonoBehaviour
    {
        [SerializeField] private Profiles _profiles;

        public Profiles Profile
        {
            get => _profiles;
        }

        private void Awake()
        {
            if(_profiles != null)
                Profile = _profiles;
        }
    }
}