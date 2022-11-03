using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float radiusMultiplier = 1.5f;
    [SerializeField] private GameObject light;
    public float Radius { get; set; }
    public float Speed { get; set; }
    public float MagnificationTime { get; set; }
    public float Angle { get; set; }
    
    public Vector3 StartPosition { get; set; }
    public Vector3 StartSize { get; set; }
    public Vector3 FinalSize { get; set; }
    public Vector3 Direction { get; set; }

    public bool Appearance { get; set; } = true;

    private float _timeAppearance;
    private float _lifeTime;
    
    private void Update()
    {
        ReSize();
        Rotate();
        ChangePosition();
        GeneralTime();
        CalculateDistance();
    }

    private void Rotate()
    {
        transform.rotation = Quaternion.Euler(_lifeTime * Angle, _lifeTime * Angle, _lifeTime * Angle);
    }

    private void ReSize()
    {
        transform.localScale = Vector3.Lerp(StartSize, FinalSize, MagnificationTime * _timeAppearance);
    }

    private void ChangePosition()
    {
        transform.position += Direction * Speed * Time.deltaTime;
    }

    private void CalculateDistance()
    {
        var distance = Vector3.Distance(transform.position, StartPosition);
        if (distance >= Radius * radiusMultiplier)
        {
            Appearance = false;
        }
    }

    private void GeneralTime()
    {
        _lifeTime += Time.deltaTime;
        TimerTick();
    }

    private void TimerTick()
    {
        if (Appearance)
        {
            if (_timeAppearance < 1)
                _timeAppearance += Time.deltaTime;
            else
                _timeAppearance = 1;
        }
        else
        {
            if (_timeAppearance > 0)
                _timeAppearance -= Time.deltaTime;
            else
                _timeAppearance = 0;
            
            if (_timeAppearance <= 0.1f)
            {
                light.SetActive(true);
            }

            if (_timeAppearance <= 0)
            {
                DisableCurrentObject();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        DisableCurrentObject();
    }

    private void DisableCurrentObject()
    {
        _timeAppearance = 0;
        transform.localScale = StartSize;
        light.SetActive(false);
        gameObject.SetActive(false);
    }
}
