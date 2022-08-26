using System;

public class MainCharacter : PausableActor, ICanDie
{
    public event Action OnDeathEvent;
    
    public void Death()
    {
        OnDeathEvent?.Invoke();
    }

    protected override void Init()
    {
    }

    protected override void OnUpdate()
    {
    }
}
