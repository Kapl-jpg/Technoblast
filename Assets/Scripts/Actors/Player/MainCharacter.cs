using System;
using System.Collections;
using Interfaces;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody))]
public class MainCharacter : MonoBehaviour, ICanDie, ICanBeInvincible
{
    [SerializeField] private AnimationsEvents _animationsEvents;
    
    public bool PossibleToDie { get; private set; } = true;
    
    public event Action OnDeathEvent;

    private AnimationState _animationState;
    private Rigidbody _characterRigidbody;
    private Vector3 _velocity;

    private ILevelEnd _levelEnd;
    private CharacterMovement _characterMovement;

    [Inject]
    private void Construct(ILevelEnd levelEnd,CharacterMovement characterMovement)
    {
        _characterMovement = characterMovement;
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
        _characterRigidbody = GetComponent<Rigidbody>();
    }

    private void OnDestroy()
    {
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
        _characterMovement.Death = true;
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

