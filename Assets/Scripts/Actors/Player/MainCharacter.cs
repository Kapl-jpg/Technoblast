using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody))]
public class MainCharacter : MonoBehaviour, ICanDie, ICanBeInvincible
{
    public bool PossibleToDie { get; private set; } = true;

    public event Action OnDeathEvent;

    private AnimationState _animationState;
    private Vector3 _velocity;

    private InputHandler _inputHandler;
    private ILevelEnd _levelEnd;

    [Inject]
    private void Construct(InputHandler inputHandler)
    {
        _inputHandler = inputHandler;
    }

    public void SetLevelEnd(ILevelEnd levelEnd)
    {
        _levelEnd = levelEnd;
        _levelEnd.OnLevelEndEvent += StartWinGameAnimation;
    }

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        _animationState = GetComponent<AnimationState>();
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
        _inputHandler.Death = true;
        _animationState.TriggerDeath();
    }

    public void StartDeathEvents()
    {
        OnDeathEvent?.Invoke();
    }

    private void StartWinGameAnimation()
    {
        _animationState.TriggerWinGame();
    }
}