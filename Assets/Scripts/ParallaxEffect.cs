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
            var position = characterTransform.position;
            layers[i].position = new Vector3(position.x * ratio[i] + offset.x,position.y * ratio[i] + offset.y,offset.z);
        }
    }
}
