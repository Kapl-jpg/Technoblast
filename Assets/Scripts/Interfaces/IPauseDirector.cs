namespace Interfaces
{
    public interface IPauseDirector
    {
        public void RegisterICanBePausedActor(ICanBePaused actor);
    }
}