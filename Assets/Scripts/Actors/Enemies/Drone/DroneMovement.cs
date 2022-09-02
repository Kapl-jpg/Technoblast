using System.Collections.Generic;
using UnityEngine;
using  DG.Tweening;

public class DroneMovement : MonoBehaviour
{
    [SerializeField] private GameObject points;
    
    [SerializeField] private float secondsMove;

    [SerializeField] private bool loopAgain;

    [SerializeField] private bool stay;

    private List<Vector3> _targetPoints;
    
    private int _numberPoint;

    private void Start()
    {
        if (stay || points.transform.childCount <= 0)
            return;

        GetPoints();
        SetPath();
    }

    private void GetPoints()
    {
        _targetPoints = new List<Vector3>();
        for (var i = 0; i < points.transform.childCount; i++)
        {
            _targetPoints.Add(points.transform.GetChild(i).transform.position);
        }
    }

    private void SetPath()
    {
        transform.position = _targetPoints[0];
        var sequence = DOTween.Sequence();
        for (var i = 1; i < _targetPoints.Count; i++)
        {
            sequence.Append(transform.DOMove(_targetPoints[i], secondsMove));
            if(i==_targetPoints.Count-1 && loopAgain)
                sequence.Append(transform.DOMove( _targetPoints[0], secondsMove));
        }
        sequence.SetLoops(-1, loopAgain ? LoopType.Restart : LoopType.Yoyo);
    }
}
