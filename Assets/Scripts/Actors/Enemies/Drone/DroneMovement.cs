using System;
using System.Collections.Generic;
using UnityEngine;
using  DG.Tweening;
using Interfaces;
using Zenject;

public class DroneMovement : MonoBehaviour
{
    [SerializeField] private GameObject points;
    
    [SerializeField] private float secondsMove;

    [SerializeField] private bool loopAgain;

    [SerializeField] private bool stay;

    private List<Vector3> _targetPoints;

    private Sequence _runningSequence;

    private int _numberPoint;

    private void Start()
    {
        if (stay || points.transform.childCount <= 0)
            return;

        GetPoints();
        SetPath();
    }

    private void OnDestroy()
    {
        _runningSequence.Kill();
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
        _runningSequence = DOTween.Sequence();
        
        for (var i = 1; i < _targetPoints.Count; i++)
        {
            _runningSequence.Append(transform.DOMove(_targetPoints[i], secondsMove));
            if(i==_targetPoints.Count-1 && loopAgain)
                _runningSequence.Append(transform.DOMove( _targetPoints[0], secondsMove));
        }
        
        _runningSequence.SetLoops(-1, loopAgain ? LoopType.Restart : LoopType.Yoyo);
    }
}
