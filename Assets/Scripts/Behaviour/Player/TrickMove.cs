using System.Collections;
using Interfaces;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

public class TrickMove : BaseBehaviour
{
    [FormerlySerializedAs("_cooldown")]
    [Header("Trick Settings")]
    [SerializeField] private float _cooldownTime;

    [SerializeField] private float _invincibilityTime;
    
    private bool _isOnCooldown;
    
    private InputHandler _playersInput;
    private ICanBeInvincible _invincibility;
    
    [Inject]
    private void Construct(InputHandler inputHandler)
    {
        _playersInput = inputHandler;
        if (TryGetComponent<ICanBeInvincible>(out var canBeInvincible))
        {
            _invincibility = canBeInvincible;
        }
        else
        {
            Debug.LogError("There is no ICanBeInvincible interface on Actor " +gameObject.name);
        }
    }

    protected override void OnUpdate()
    {
        if (_playersInput.Trick && !_isOnCooldown)
        {
            DoTrickMove();
        }
    }

    private void DoTrickMove()
    {
        StartCoroutine(StartCooldown());
        MakeInvinsialbe();
    }

    private IEnumerator StartCooldown()
    {
        _isOnCooldown = true;
        yield return new WaitForSecondsRealtime(_cooldownTime);
        _isOnCooldown = false;
    }

    private void MakeInvinsialbe()
    {
        _invincibility.MakeInvincibleForSeconds(_invincibilityTime);
    }
}
