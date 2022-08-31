namespace Interfaces
{
    public interface IInteractable
    {
        public bool IsActive { get; }
        public void Interact();
    }
}