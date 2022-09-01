using UnityEngine;
using DG.Tweening;

public class OnSiteFlight : MonoBehaviour
{
    [SerializeField] private float secondsFlight;
    [SerializeField] private float amplitude;
    
    private Vector3 _startPosition;

    private void Start()
    {
        _startPosition = transform.position;
        transform.position = EndPosition(Vector3.down);
        
        var sequence = DOTween.Sequence();
        sequence.Append(transform.DOMove(EndPosition(Vector3.up), secondsFlight));
        sequence.Append(transform.DOMove(EndPosition(Vector3.down), secondsFlight));
        sequence.SetLoops(-1, LoopType.Restart);
    }

    private Vector3 EndPosition(Vector3 direction)
    {
        return new Vector3(0,_startPosition.y + amplitude * direction.y,0);
    }
}
