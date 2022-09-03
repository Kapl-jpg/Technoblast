using UnityEngine;

public class JumpableObjectData 
{
    public int ObjectForce { get; private set; }
    public Material ObjectMaterial { get; private set; }
    public AudioClip ObjectHitAudio { get; private set; }


    public JumpableObjectData(int objectForce, Material objectMaterial, AudioClip objectHitSound)
    {
        ObjectForce = objectForce;
        ObjectMaterial = objectMaterial;
        ObjectHitAudio = objectHitSound;
    }
}
