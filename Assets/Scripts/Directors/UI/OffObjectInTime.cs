using UnityEngine;

public class OffObjectInTime : MonoBehaviour
{
    public void StartTimer()
    {
    }

    private void OnEnable()
    {
        gameObject.SetActive(false);
    }
}

