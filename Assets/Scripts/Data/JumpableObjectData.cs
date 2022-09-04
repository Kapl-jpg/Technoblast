using UnityEngine;

public class JumpableObjectData 
{
    public ForceColor ForceColor { get; private set; }
    public int ObjectForce { get; private set; }
    public Material ObjectMaterial { get; private set; }
    public AudioClip ObjectHitAudio { get; private set; }

    public JumpableObjectData(ForceColor forceColor ,int objectForce, Material objectMaterial, AudioClip objectHitSound)
    {
        this.ForceColor = forceColor;
        ObjectForce = objectForce;
        ObjectMaterial = objectMaterial;
        ObjectHitAudio = objectHitSound;
    }
}
