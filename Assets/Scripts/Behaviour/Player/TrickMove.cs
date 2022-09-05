using System;
using System.Collections;
using Interfaces;
using ModestTree.Util;
using UnityEngine;
using Zenject;

public class TrickMove : BaseBehaviour
{
    [Header("Trick Settings")] 
    [SerializeField] private float _cooldownTime;
    [SerializeField] private float _invincibilityTime;
    [SerializeField] private float _radiusOfInteraction;

    [Header("Interactive Objects Layer")]
    [SerializeField] private LayerMask _layerOfInteraction;

    private bool _isOnCooldown;
    private RaycastHit[] _raycastHits = new RaycastHit[1];

    private InputHandler _playersInput;
    private ICanBeInvincible _invincibility;

    public event Action OnTrickPressedEvent;

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
            Debug.LogError("There is no ICanBeInvincible interface on Actor " + gameObject.name);
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
        OnTrickPressedEvent?.Invoke();
        StartCoroutine(StartCooldown());
        MakeInvinsialbe();
        TryInteractWithObjects();
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

    private bool TryInteractWithObjects()
    {
        var result = Physics.SphereCastNonAlloc(transform.position, _radiusOfInteraction, Vector3.forward,
            _raycastHits, _radiusOfInteraction, _layerOfInteraction);
        if (result > 0)
        {
            if(_raycastHits[0].collider.TryGetComponent<IInteractable>(out var interactable) && interactable.IsActive)
            {
                interactable.Interact();
                return true;
            }
        }

        return false;
    }
}