using System;
using System.Collections;
using Interfaces;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody))]
public class MainCharacter : PausableActor, ICanDie, ICanBeInvincible
{
    public bool PossibleToDie { get; private set; } = true;
    
    public event Action OnDeathEvent;

    private AnimationState _animationState;
    private Rigidbody _characterRigidbody;
    private Vector3 _velocity;

    private ILevelEnd _levelEnd;

    [Inject]
    private void Construct(ILevelEnd levelEnd)
    {
        _levelEnd = levelEnd;
        _levelEnd.OnLevelEndEvent += StartWinGameAnimation;
    }

    protected override void Init()
    {
        _animationState = GetComponent<AnimationState>();
        _characterRigidbody = GetComponent<Rigidbody>();
        OnPauseEvent += SetGravityOff;
        OnUnpauseEvent += SetGravityOn;
    }

    private void OnDestroy()
    {
        OnPauseEvent -= SetGravityOff;
        OnUnpauseEvent -= SetGravityOn;
        _levelEnd.OnLevelEndEvent -= StartWinGameAnimation;
    }

    private void SetGravityOff()
    {
        _characterRigidbody.useGravity = false;
        _velocity = _characterRigidbody.velocity;
        _characterRigidbody.velocity = Vector3.zero;
    }

    private void SetGravityOn()
    {
        _characterRigidbody.useGravity = true;
        _characterRigidbody.velocity = _velocity;
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
        Pause();
        _animationState.TriggerDeath();
        _characterRigidbody.useGravity = false;
    }

    public void StartDeathEvents()
    {
        OnDeathEvent?.Invoke();
    }
    
    private void StartWinGameAnimation()
    {
        Pause();
        _characterRigidbody.useGravity = false;
        _animationState.TriggerWinGame();
    }
}

