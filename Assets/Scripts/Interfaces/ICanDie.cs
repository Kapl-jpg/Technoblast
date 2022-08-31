using System;

public interface ICanDie
{
    public bool PossibleToDie { get; }
    public event Action OnDeathEvent;
    
    public void Death();
}
