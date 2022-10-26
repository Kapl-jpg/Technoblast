using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class LaunchWaveVisual : MonoBehaviour
{
    [SerializeField] private GameObject wavePrefab;
    [SerializeField] private GameObject waveParent;
    [SerializeField] private float waveSpeed;
    [SerializeField] private int wavesCount;
    [SerializeField] private int waveLaunchCount;
    [SerializeField] private float delay;
    [SerializeField] private float disableTime;


    private List<GameObject> _poolWave;
    private static readonly int Color = Shader.PropertyToID("_WaveColor");
    private static readonly int FirstWidth = Shader.PropertyToID("_firstWidth");
    private static readonly int SecondWidth = Shader.PropertyToID("_secondWidth");
    private static readonly int ThirdWidth = Shader.PropertyToID("_thirdWidth");
    private static readonly int FourthWidth = Shader.PropertyToID("_fourthWidth");

    private void Start()
    {
        SpawnWaves();
    }

    private void SpawnWaves()
    {
        _poolWave = new List<GameObject>();

        for (int i = 0; i < wavesCount; i++)
        {
            var instance = Instantiate(wavePrefab, Vector3.zero, Quaternion.identity);
            _poolWave.Add(instance);
            instance.transform.parent = waveParent.transform;
            instance.SetActive(false);
        }
    }

    private GameObject GetDisabledWave()
    {
        foreach (var item in _poolWave)
        {
            if (!item.activeInHierarchy)
            {
                return item;
            }
        }
        return null;
    }

    public void Launch(Vector3 direction, Color color)
    {
        StartCoroutine(TimerLaunch(direction, color));
    }

    private void SetColor(GameObject wave, Color color)
    {
        SetShader(wave,Color,color);
        SetLight(wave,color);
    }

    private void SetLight(GameObject wave,Color color)
    {
        var childLight = wave.GetComponentInChildren<Light>();
        childLight.color = color;
    }

    private void ActivateWave(GameObject wave)
    {
        wave.gameObject.SetActive(true);
    }

    private void SetWavePosition(GameObject wave)
    {
        wave.transform.position = transform.position;
    }

    private void SetWaveRotation(GameObject wave, Vector3 direction)
    {
        var intoPlane = Vector3.forward;
        wave.transform.rotation = Quaternion.LookRotation(intoPlane, -direction);
    }

    private void SetWaveSize(GameObject wave)
    {
        SetShader(wave,FirstWidth,Random.Range(0f,1f));
        SetShader(wave,SecondWidth,Random.Range(0f,1f));
        SetShader(wave,ThirdWidth,Random.Range(0f,1f));
        SetShader(wave,FourthWidth,Random.Range(0f,1f));
    }

    private void SetFlightWaveParameters(GameObject wave,Vector3 direction, float speed)
    {
        var flightWave = wave.GetComponent<FlightWave>();
        flightWave.Direction = direction;
        flightWave.Speed = speed;
    }

    private void ResetWaveTimer(GameObject wave)
    {
        var disableWave = wave.GetComponent<DisableWave>();
        disableWave.ResetTime();
        disableWave.DisableTime = disableTime;
    }

    #region SetShaders
    
    private void SetShader(GameObject wave,int index,float value)
    {
        wave.GetComponent<Renderer>().material.SetFloat(index,value);
    }
    
    private void SetShader(GameObject wave,int index,Color color)
    {
        wave.GetComponent<Renderer>().material.SetColor(index,color);
    }
    
    #endregion

    private IEnumerator TimerLaunch(Vector3 direction,Color color)
    {
        for (var i = 0; i < waveLaunchCount; i++)
        {
            var wave = GetDisabledWave();
            ActivateWave(wave);
            ResetWaveTimer(wave);
            SetWavePosition(wave);
            SetWaveRotation(wave, direction);
            SetColor(wave, color);
            SetWaveSize(wave);
            SetFlightWaveParameters(wave,direction,waveSpeed);
            yield return new WaitForSeconds(delay);
        }
        yield return null;
    }
}
