
public interface ICanBePaused
{
    public bool IsPaused { get; }
    public void Pause();
    public void Unpause();
}
