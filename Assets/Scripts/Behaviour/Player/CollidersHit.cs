using UnityEngine;

public class CollidersHit : MonoBehaviour
{
    [SerializeField] private SoundWave soundWave;

    [SerializeField] private Vector3 directionForce;
    public bool getPlatform { get; set; }

    private Collider _collider;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent<IJumpableObject>(out var objectData)) return;
        TranslateData(other, true);
        getPlatform = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.TryGetComponent<IJumpableObject>(out var objectData)) return;
        TranslateData(other,true);
        getPlatform = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.TryGetComponent<IJumpableObject>(out var objectData)) return;
        TranslateData(other, false);
        getPlatform = false;
    }

    private void TranslateData(Collider collider,bool stayOnPlatform)
    {
        soundWave.stayOnPlatform = stayOnPlatform;
        _collider = collider;
    }

    public Collider GetCollider()
    {
        return _collider;
    }
}

