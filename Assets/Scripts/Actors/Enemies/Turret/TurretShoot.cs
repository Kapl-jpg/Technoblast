using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class TurretShoot : MonoBehaviour
{
    [SerializeField] private float timeToAttack;
    [SerializeField] private float speedBullet;
    [SerializeField] private float rangeAttack;
    [SerializeField] private Transform startPoint;

    private List<GameObject> _poolBullets;

    [Header("Bullets")]
    [SerializeField] private GameObject prefabBullet;
    [SerializeField] private uint countBullets;

    private float _currentTime;

    private TurretLookAt _turretLookAt;
    private CharacterMovement _characterMovement;

    private void CreatePool()
    {
        _poolBullets = new List<GameObject>();
        
        var turretBullets = new GameObject("TurretBullets");
        
        var bulletColor = GetComponent<Platform>().GetData().ObjectMaterial;
        prefabBullet.GetComponent<BulletColor>().InitColor(bulletColor);

        for (var i = 0; i < countBullets; i++)
        {
            var instance = Instantiate(prefabBullet, Vector3.zero, Quaternion.identity);
            instance.transform.parent = turretBullets.transform;
            instance.AddComponent<KillComponent>();
            _poolBullets.Add(instance);
            instance.SetActive(false);
        }
    }

    [Inject]
    private void Construct(CharacterMovement characterMovement)
    {
        _characterMovement = characterMovement;
    }

    private void Start()
    {
        _turretLookAt = GetComponent<TurretLookAt>();

        var platform = GetComponent<Platform>().GetData();
        
        CreatePool();
    }

    private void Update()
    {
        var distance = Vector3.Distance(transform.position, _characterMovement.transform.position);
        if (distance <= rangeAttack)
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

    private GameObject GetBullet()
    {
        foreach (var bullet in _poolBullets.Where(bullet => !bullet.activeInHierarchy))
        {
            bullet.SetActive(true);
            bullet.transform.position = startPoint.position;
            bullet.GetComponent<Bullet>().Direction = _characterMovement.transform.position - transform.position;
            bullet.GetComponent<Bullet>().Speed = speedBullet;
            return bullet;
        }

        return null;
    }
}
