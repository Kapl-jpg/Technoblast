using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    [SerializeField] private Transform characterTransform;
    [SerializeField] private Transform[] layers;
    [SerializeField] private float[] ratio;
    [SerializeField] private Vector3 offset;
    
    void Update()
    {
        for (int i = 0; i < layers.Length; i++)
        {
            layers[i].position = new Vector3(characterTransform.position.x * ratio[i] + offset.x,offset.y,offset.z);
        }
    }
}
