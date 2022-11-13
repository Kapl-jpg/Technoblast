using System.Collections;
using UnityEngine;

public class AddImpulse : MonoBehaviour
{
    [SerializeField] private Rigidbody[] rigidbodies;
    [SerializeField] private float force;
    [SerializeField] private float delay;
    
    private void Start()
    {
        StartCoroutine(AddForce());
    }

    private IEnumerator AddForce()
    {
        while (true)
        {
            rigidbodies[Random.Range(0, rigidbodies.Length)].AddForce(Vector3.forward * force);
            yield return new WaitForSeconds(delay);
        }
    }
}
