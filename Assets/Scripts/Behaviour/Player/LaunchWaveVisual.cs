using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchWaveVisual : MonoBehaviour
{
    [SerializeField] private ParticleSystem waveParticleSystem;
    [SerializeField] private int waveCount;
    private List<ParticleSystem> _waveParticleSystems;
    private Vector3 _characterPosition;

    private void Start()
    {
        CreateWaves();
    }

    private void CreateWaves()
    {
        _waveParticleSystems = new List<ParticleSystem>();
        for (var i = 0; i < waveCount; i++)
        {
            var instance = Instantiate(waveParticleSystem, Vector3.zero, Quaternion.identity);
            instance.transform.parent = transform;
            instance.gameObject.SetActive(false);
            _waveParticleSystems.Add(instance);
        }
    }

    public void Launch(Vector3 characterRayDirection)
    {
        var wave = GetParticleSystem();
        
        SetWavePosition(wave);
        SetWaveRotation(wave, characterRayDirection);
        ActivateWave(wave);
    }

    private void ActivateWave(ParticleSystem wave)
    {
        wave.gameObject.SetActive(true);
        wave.Play();
    }

    private void SetWavePosition(Component wave)
    {
        wave.gameObject.transform.position = transform.position;
        StartCoroutine(DisableParticleSystem(wave));
    }

    private void SetWaveRotation(Component wave, Vector3 characterRayDirection)
    {
        wave.gameObject.transform.LookAt(transform.position + characterRayDirection);
    }

    private ParticleSystem GetParticleSystem()
    {
        foreach (var wave in _waveParticleSystems)
        {
            if (!wave.gameObject.activeInHierarchy)
                return wave.GetComponent<ParticleSystem>();
        }

        return null;
    }

    private IEnumerator DisableParticleSystem(Component wave)
    {
        yield return new WaitForSeconds(0.5f);
        wave.gameObject.SetActive(false);
    }
}
