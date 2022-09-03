using Interfaces;
using UnityEngine;

namespace Player.Interactables
{
    public abstract class OpenableActor: MonoBehaviour,IOpenable
    {
        public abstract void Open();

        public abstract void OpenOnTime(float time);
    }
}