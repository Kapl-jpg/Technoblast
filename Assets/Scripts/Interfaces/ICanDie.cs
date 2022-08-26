using System;

public interface ICanDie
{
    public event Action OnDeathEvent;
    
    public void Death();
}
