using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class TurretShoot : MonoBehaviour
{
    [Header("Turret parameters")]
    [SerializeField] private float timeToAttack;
    [SerializeField] private float speedBullet;
    [SerializeField] private float rangeAttack;
    [SerializeField] private Transform startPoint;

    private List<GameObject> _poolBullets;

    [Header("Bullets")]
    [SerializeField] private GameObject prefabBullet;
    [SerializeField] private uint countBullets;
    [SerializeField] private Vector3 startSize;
    [SerializeField] private Vector3 finalSize;
    [SerializeField] private float magnificationTime;
    
    [SerializeField] private bool draw;
    private float _currentTime;
    private float _distance;

    private TurretLookAt _turretLookAt;
    private CharacterMovement _characterMovement;

    #region Создание пула объектов
    
    private void CreatePool()
    {
        _poolBullets = new List<GameObject>();
        
        var turretBullets = new GameObject("TurretBullets");
        
        var turretData = GetComponent<Platform>().ObjectData;
        prefabBullet.GetComponent<BulletColor>().InitColor(turretData.ObjectMaterial);
        prefabBullet.GetComponent<BulletColor>().SetJumpableOnjectData(turretData);

        for (var i = 0; i < countBullets; i++)
        {
            
            var instance = Instantiate(prefabBullet, Vector3.zero, Quaternion.identity);
            instance.transform.parent = turretBullets.transform;
            SetFields(instance);
            _poolBullets.Add(instance);
            instance.SetActive(false);
        }
    }

    private void SetFields(GameObject bullet)
    {
        bullet.GetComponent<Bullet>().Speed = speedBullet;
        bullet.GetComponent<Bullet>().StartSize = startSize;
        bullet.GetComponent<Bullet>().FinalSize = finalSize;
        bullet.GetComponent<Bullet>().MagnificationTime = magnificationTime;
    }
    #endregion

    [Inject]
    private void Construct(CharacterMovement characterMovement)
    {
        _characterMovement = characterMovement;
    }

    private void Start()
    {
        _turretLookAt = GetComponent<TurretLookAt>();
        CreatePool();
    }

    private void Update()
    {
        _distance = Vector3.Distance(transform.position, _characterMovement.transform.position);
        if (_distance <= rangeAttack)
        {
            _turretLookAt.LookAtCharacter(_characterMovement.gameObject);
            TimeTicking();
        }
        else
        {
            _currentTime = 0;
        }
    }

    private void TimeTicking()
    {
        _currentTime += Time.deltaTime;
        if (!(_currentTime >= timeToAttack)) return;
        
        GetBullet();
        _currentTime = 0;
    }

    private void GetBullet()
    {
        foreach (var bullet in _poolBullets.Where(bullet => !bullet.activeInHierarchy))
        {
            bullet.SetActive(true);
            bullet.transform.position = startPoint.position;
            bullet.GetComponent<Bullet>().Direction = _characterMovement.transform.position - transform.position;
            return;
        }
    }

    private void OnDrawGizmos()
    {
        if (!draw) return;
        
        Gizmos.color = _distance <= rangeAttack ? Color.blue : Color.red;
        
        if(_characterMovement!=null)
            Gizmos.DrawLine(transform.position, _characterMovement.transform.position);
    }
}
