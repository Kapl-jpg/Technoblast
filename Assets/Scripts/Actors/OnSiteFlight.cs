using System;
using UnityEngine;

public class OnSiteFlight : MonoBehaviour
{
    [SerializeField] private float speedFlight;
    [SerializeField] private float amplitude;
    [Range(-1, 1)] [SerializeField] private float offset;
    [SerializeField] private GameObject body;
    private Vector3 _parentPosition;

    private void Start()
    {
        _parentPosition = transform.position;
    }

    private void Update()
    {
        body.transform.position = _parentPosition + new Vector3(0,
            Mathf.Lerp(-amplitude, amplitude, Mathf.Sin(offset + Time.time * speedFlight) / 2 + 0.5f));
    }
}
