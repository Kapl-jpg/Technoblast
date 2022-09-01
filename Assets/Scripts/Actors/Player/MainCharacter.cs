using System;
using System.Collections;
using Interfaces;
using UnityEngine;

public class MainCharacter : PausableActor, ICanDie, ICanBeInvincible
{
    public bool PossibleToDie { get; private set; } = true;
    
    public event Action OnDeathEvent;

    protected override void Init()
    {
    }

    public void MakeInvincibleForSeconds(float invincibilityTime)
    {
        StartCoroutine(Invincibility(invincibilityTime));
    }

    private IEnumerator Invincibility(float seconds)
    {
        PossibleToDie = false;
        yield return new WaitForSecondsRealtime(seconds);
        PossibleToDie = true;
    }

    public void Death()
    {
        OnDeathEvent?.Invoke();
    }
}
