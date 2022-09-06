using System;
using System.Collections;
using Interfaces;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MainCharacter : PausableActor, ICanDie, ICanBeInvincible
{
    public bool PossibleToDie { get; private set; } = true;
    
    public event Action OnDeathEvent;

    private Rigidbody _characterRigidbody;
    private Vector3 _velocity;
    
    protected override void Init()
    {
        _characterRigidbody = GetComponent<Rigidbody>();
        OnPauseEvent += SetGravityOff;
        OnUnpauseEvent += SetGravityOn;
    }

    private void OnDestroy()
    {
        OnPauseEvent -= SetGravityOff;
        OnUnpauseEvent -= SetGravityOn;
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
        OnDeathEvent?.Invoke();
    }
}

